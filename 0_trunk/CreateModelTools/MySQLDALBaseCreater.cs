using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CreateModelTools
{
    public class MySQLDALBaseCreater : MySQLModelCreater
    {
        protected override void CreateFile(string tableName, string tableComments, DataTable dt, StringBuilder sb, string className, string modelName)
        {
            string variableModelName = TransferToCShapeVariableName(modelName);
            string key, column, type, privateName, variableName, publicName, columnComment, csType;
            bool isNullable;
            List<string> lstInsertFeild = new List<string>();
            List<string> lstInsertVariable = new List<string>();
            List<string> lstUpdateFeild = new List<string>();
            List<string> lstUpdateWhere = new List<string>();

            List<string> listParameter = new List<string>();
            List<string> listKey = new List<string>();
            List<string> listKeyParameter = new List<string>();
            List<string> listKeyVariable = new List<string>();
            List<string> listKeySummrary = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                column = row["COLUMN_NAME"].ToString();
                columnComment = row["COLUMN_COMMENT"].ToString();
                type = row["COLUMN_TYPE"].ToString();
                key = row["COLUMN_KEY"].ToString();
                isNullable = row["IS_NULLABLE"].ToString() == "YES" || row["IS_NULLABLE"].ToString() == "Y";
                csType = GetCShapeType(type, isNullable);
                privateName = TransferToCShapePrivateName(column, modelName);
                publicName = TransferToCShapeFieldName(column, modelName);
                variableName = TransferToCShapeVariableName(column, modelName);

                lstInsertFeild.Add(column);
                lstInsertVariable.Add("@" + column);
                
                if (string.IsNullOrEmpty(key))
                {
                    lstUpdateFeild.Add(column + " = @" + column);
                }
                else
                {
                    lstUpdateWhere.Add(column + " = @" + column);
                    listKey.Add(publicName);
                    listKeyVariable.Add(string.Format("{0} {1}", csType, variableName));
                    listKeySummrary.Add(string.Format("/// <param name=\"{0}\">{1}</param>", variableName, columnComment));
                    listKeyParameter.Add(string.Format("db.GetDataParameter(\"@{0}\", {1})", column, variableName));
                }
                listParameter.Add(string.Format("db.GetDataParameter(\"@{0}\", {1}.{2})", column, variableModelName, publicName));
            }

            if (lstUpdateWhere.Count == 0 && dt.Rows.Count > 0)
            {

                column = dt.Rows[0]["COLUMN_NAME"].ToString();
                columnComment = dt.Rows[0]["COLUMN_COMMENT"].ToString();
                type = dt.Rows[0]["COLUMN_TYPE"].ToString();
                key = dt.Rows[0]["COLUMN_KEY"].ToString();
                isNullable = dt.Rows[0]["IS_NULLABLE"].ToString() == "YES" || dt.Rows[0]["IS_NULLABLE"].ToString() == "Y";
                csType = GetCShapeType(type, isNullable);
                privateName = TransferToCShapePrivateName(column, modelName);
                publicName = TransferToCShapeFieldName(column, modelName);
                variableName = TransferToCShapeVariableName(column, modelName);

                lstUpdateWhere.Add(column + " = @" + column);
                listKey.Add(publicName);
                listKeyVariable.Add(string.Format("{0} {1}", csType, variableName));
                listKeySummrary.Add(string.Format("/// <param name=\"{0}\">{1}</param>", variableName, columnComment));
                listKeyParameter.Add(string.Format("db.GetDataParameter(\"@{0}\", {1})", column, variableName));
            }

            string insertFeilds = string.Join(", ", lstInsertFeild);
            string insertVariables = string.Join(", ", lstInsertVariable);
            string updateFeilds = string.Join(", ", lstUpdateFeild);
            string updateWheres = string.Join(" AND ", lstUpdateWhere);

            string parameters = string.Join(",\n\t\t\t\t", listParameter);
            string keys = string.Join(", ", listKey);
            string keyVariables = string.Join(", ", listKeyVariable);
            string keyParameters = string.Join(",\n\t\t\t\t", listKeyParameter);
            string keySummary = string.Join("\n\t\t", listKeySummrary);

            sb.AppendLine("\t\t/// <summary>");
            sb.Append("\t\t/// 根据 ");
            sb.Append(keys);
            sb.Append(" 获取");
            sb.Append(tableComments.TrimEnd('表'));
            sb.AppendLine("对象");
            sb.AppendLine("\t\t/// </summary>");
            sb.Append("\t\t");
            sb.AppendLine(keySummary);
            sb.Append("\t\t/// <returns>返回");
            sb.Append(tableComments.TrimEnd('表'));
            sb.AppendLine("对象</returns>");
            sb.Append("\t\tpublic virtual ");
            sb.Append(modelName);
            sb.Append(" Get(");
            sb.Append(keyVariables);
            sb.AppendLine(")");
            sb.AppendLine("\t\t{");
            sb.Append("\t\t\treturn db.ExecuteGet<");
            sb.Append(modelName);
            sb.Append(">(\"SELECT ");
            sb.Append(insertFeilds);
            sb.Append("FROM ");
            sb.Append(tableName);
            sb.Append(" WHERE ");
            sb.Append(updateWheres);
            sb.AppendLine("\",");
            sb.Append("\t\t\t\t(dr) => { return new ");
            sb.Append(modelName);
            sb.AppendLine("(dr); },");
            sb.Append("\t\t\t\t");
            sb.Append(keyParameters);
            sb.AppendLine(");");
            sb.AppendLine("\t\t}");

            sb.AppendLine();

            sb.AppendLine("\t\t/// <summary>");
            sb.Append("\t\t/// 查询");
            sb.Append(tableComments);
            sb.AppendLine("的所有对象列表");
            sb.AppendLine("\t\t/// </summary>");
            sb.Append("\t\t/// <returns>返回");
            sb.Append(tableComments.TrimEnd('表'));
            sb.AppendLine("对象列表</returns>");
            sb.Append("\t\tpublic virtual ObservableCollection<");
            sb.Append(modelName);
            sb.Append("> Query(");
            sb.AppendLine(")");
            sb.AppendLine("\t\t{");
            sb.Append("\t\t\treturn db.ExecuteQuery<");
            sb.Append(modelName);
            sb.Append(">(\"SELECT ");
            sb.Append(insertFeilds);
            sb.Append(" FROM ");
            sb.Append(tableName);
            sb.AppendLine(" \",");
            sb.Append("\t\t\t\t(dr) => { return new ");
            sb.Append(modelName);
            sb.AppendLine("(dr); });");
            sb.AppendLine("\t\t}");

            sb.AppendLine();

            sb.AppendLine("\t\t/// <summary>");
            sb.Append("\t\t/// 新增一条");
            sb.Append(tableComments.TrimEnd('表'));
            sb.AppendLine("记录");
            sb.AppendLine("\t\t/// </summary>");
            sb.Append("\t\t/// <param name=\"");
            sb.Append(variableModelName);
            sb.Append("\">");
            sb.Append(TableNames);
            sb.AppendLine("<param>");
            sb.Append("\t\t/// <returns>返回");
            sb.Append(tableComments.TrimEnd('表'));
            sb.AppendLine("受影响的行数</returns>");
            sb.Append("\t\tpublic virtual int Add(");
            sb.Append(modelName);
            sb.Append(" ");
            sb.Append(variableModelName);
            sb.AppendLine(")");
            sb.AppendLine("\t\t{");
            sb.Append("\t\t\treturn db.ExecuteNoQuery(\"INSERT INTO ");
            sb.Append(tableName);
            sb.Append(" (");
            sb.Append(insertFeilds);
            sb.Append(") VALUES (");
            sb.Append(insertVariables);
            sb.AppendLine(")\", ");
            sb.Append("\t\t\t\t");
            sb.Append(parameters);
            sb.AppendLine(");");
            sb.AppendLine("\t\t}");

            sb.AppendLine("\t\t/// <summary>");
            sb.Append("\t\t/// 根据 ");
            sb.Append(keys);
            sb.Append(" 更新");
            sb.Append(tableComments);
            sb.AppendLine("记录");
            sb.AppendLine("\t\t/// </summary>");
            sb.Append("\t\t/// <returns>返回");
            sb.Append(tableComments.TrimEnd('表'));
            sb.AppendLine("受影响的行数</returns>");
            sb.Append("\t\tpublic virtual int Update(");
            sb.Append(modelName);
            sb.Append(" ");
            sb.Append(variableModelName);
            sb.AppendLine(")");
            sb.AppendLine("\t\t{");
            sb.Append("\t\t\treturn db.ExecuteNoQuery(\"UPDATE ");
            sb.Append(tableName);
            sb.Append(" SET ");
            sb.Append(updateFeilds);
            sb.Append(" WHERE ");
            sb.Append(updateWheres);
            sb.AppendLine("\", ");
            sb.Append("\t\t\t\t");
            sb.Append(parameters);
            sb.AppendLine(");");
            sb.AppendLine("\t\t}");

            sb.AppendLine();

            sb.AppendLine("\t\t/// <summary>");
            sb.Append("\t\t/// 根据 ");
            sb.Append(keys);
            sb.Append(" 删除");
            sb.Append(tableComments);
            sb.AppendLine("记录");
            sb.AppendLine("\t\t/// </summary>");
            sb.Append("\t\t");
            sb.AppendLine(keySummary);
            sb.Append("\t\t/// <returns>返回");
            sb.Append(tableComments.TrimEnd('表'));
            sb.AppendLine("受影响的行数</returns>");
            sb.Append("\t\tpublic virtual int Delete(");
            sb.Append(keyVariables);
            sb.AppendLine(")");
            sb.AppendLine("\t\t{");
            sb.Append("\t\t\treturn db.ExecuteNoQuery(\"DELETE FROM ");
            sb.Append(tableName);
            sb.Append(" WHERE ");
            sb.Append(updateWheres);
            sb.AppendLine("\", ");
            sb.Append("\t\t\t\t");
            sb.Append(keyParameters);
            sb.AppendLine(");");
            sb.AppendLine("\t\t}");
        }
    }
}
