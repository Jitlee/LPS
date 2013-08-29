using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace CreateModelTools
{
    public class MySQLModelCreater : MySQLBaseCreater
    {
        protected override void CreateFile(string tableName, string tableComments, DataTable dt, StringBuilder sb, string className, string modelName)
        {
            string column, type, privateName, publicName, columnComment, csType;
            bool isNullable;
            foreach (DataRow row in dt.Rows)
            {
                column = row["COLUMN_NAME"].ToString();
                columnComment = row["COLUMN_COMMENT"].ToString();
                type = row["COLUMN_TYPE"].ToString();
                isNullable = row["IS_NULLABLE"].ToString() == "YES" || row["IS_NULLABLE"].ToString() == "Y";
                csType = GetCShapeType(type, isNullable);
                privateName = TransferToCShapePrivateName(column, className);
                publicName = TransferToCShapeFieldName(column, className);
                

                sb.AppendLine();
                sb.Append("\t\t// 保存");
                sb.AppendLine(columnComment);
                sb.Append("\t\tprivate ");

                sb.Append(csType);
                sb.Append(" ");

                sb.Append(privateName);
                sb.AppendLine(";");

                sb.AppendLine();
                sb.AppendLine("\t\t/// <summary>");
                sb.Append("\t\t/// 获取或设置");
                sb.AppendLine(columnComment);
                sb.AppendLine("\t\t/// </summary>");
                sb.Append("\t\tpublic ");

                sb.Append(csType);
                sb.Append(" ");

                sb.AppendLine(publicName);
                sb.AppendLine("\t\t{");
                sb.AppendLine("\t\t\tget");
                sb.AppendLine("\t\t\t{");
                sb.Append("\n\t\t\t\treturn ");
                sb.Append(privateName);
                sb.AppendLine(";");
                sb.AppendLine("\t\t\t}");
                sb.AppendLine("\t\t\tset");
                sb.AppendLine("\t\t\t{");
                sb.Append("\t\t\t\t");
                sb.Append(privateName);
                sb.AppendLine(" = value;");
                sb.Append("\t\t\t\tRaisePropertyChanged(\"");
                sb.Append(publicName);
                sb.AppendLine("\");");
                sb.AppendLine("\t\t\t}");
                sb.AppendLine("\t\t}");
            }


            sb.AppendLine();

            sb.AppendLine("\t\t#region 构造函数");


            sb.AppendLine();

            sb.AppendLine("\t\t/// <summary>");
            sb.Append("\t\t/// ");
            sb.Append(tableComments);
            sb.AppendLine("构造函数");
            sb.AppendLine("\t\t/// </summary>");
            sb.Append("\t\tpublic ");

            sb.Append(className);

            sb.AppendLine("()");

            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t}");
            sb.AppendLine();

            sb.AppendLine("\t\t/// <summary>");
            sb.Append("\t\t/// ");
            sb.Append(tableComments);
            sb.AppendLine("构造函数");
            sb.AppendLine("\t\t/// </summary>");
            sb.AppendLine("\t\t/// <param name=\"dr\">数据行</param>");
            sb.Append("\t\tpublic ");

            sb.Append(className);

            sb.AppendLine("(IDataReader dr)");

            sb.AppendLine("\t\t{");
            
            string drString;
            foreach (DataRow dr in dt.Rows)
            {
                column = dr["COLUMN_NAME"].ToString();
                columnComment = dr["COLUMN_COMMENT"].ToString();
                type = dr["COLUMN_TYPE"].ToString();
                isNullable = dr["IS_NULLABLE"].ToString() == "YES" || dr["IS_NULLABLE"].ToString() == "Y";
                csType = GetCShapeType(type, isNullable);
                privateName = TransferToCShapePrivateName(column, className);
                drString = string.Concat("dr[\"", column, "\"]");

                sb.Append("\t\t\tif (DBNull.Value != ");
                sb.Append(drString);
                sb.AppendLine(")");
                sb.AppendLine("\t\t\t{");
                sb.Append("\t\t\t\t");
                sb.Append(privateName);
                sb.Append(" = ");
                switch (csType)
                {
                    case "string":
                        sb.Append(drString);
                        sb.Append(".ToString()");
                        break;
                    case "int":
                    case "int?":
                        sb.Append("Convert.ToInt32(");
                        sb.Append(drString);
                        sb.Append(")");
                        break;
                    case "double":
                    case "double?":
                        sb.Append("Convert.ToDouble(");
                        sb.Append(drString);
                        sb.Append(")");
                        break;
                    case "DateTime":
                    case "DateTime?":
                        sb.Append("Convert.ToDateTime(");
                        sb.Append(drString);
                        sb.Append(")");
                        break;
                }
                sb.AppendLine(";");
                sb.AppendLine("\t\t\t}");
            }

            sb.AppendLine("\t\t}");

            sb.AppendLine();

            sb.AppendLine("\t\t#endregion 构造函数");

            sb.AppendLine();
        }
    }
}
