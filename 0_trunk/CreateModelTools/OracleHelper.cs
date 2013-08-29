using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace CreateModelTools
{
    class OracleHelper
    {
        private string _output;

        public string ConnectionString { get; set; }

        public string Namespace { get; set; }

        public string Using { get; set; }

        public string Suffix { get; set; }

        public string[] TableNames { get; set; }

        public string Output { get; set; }

        public OracleHelper()
        {
        }

        public void Finish()
        {
            _output = Output ?? "Output";
            if (!Directory.Exists(_output))
            {
                Directory.CreateDirectory(_output);
            }

            Console.Write("输出路径：");
            Console.WriteLine(_output);
            using (OracleConnection conn = new OracleConnection(ConnectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        cmd.Connection = conn;
                        foreach (string tableName in TableNames)
                        {
                            CreateFile(tableName, cmd, da);
                            Console.WriteLine("成功创建文件:{0}.cs", tableName);
                        }

                        Console.WriteLine("操作成功，成功生成{0}个文件", TableNames.Length);
                    }
                }
            }
        }

        private void CreateFile(string tableName, IDbCommand cmd, DbDataAdapter da)
        {
            cmd.CommandText = string.Format("SELECT A.COLUMN_NAME,B.COMMENTS COLUMN_COMMENT, A.DATA_TYPE COLUMN_TYPE, A.NULLABLE IS_NULLABLE FROM USER_TAB_COLUMNS A INNER JOIN USER_COL_COMMENTS B ON A.TABLE_NAME = B.TABLE_NAME AND A.COLUMN_NAME = B.COLUMN_NAME WHERE A.TABLE_NAME = '{0}'", tableName.ToUpper());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.CommandText = string.Format("SELECT COMMENTS FROM USER_TAB_COMMENTS WHERE TABLE_NAME ='{0}'", tableName.ToUpper());
            string tableComments = (cmd.ExecuteScalar() ?? string.Empty).ToString();

            CreateModelFile(tableName, tableComments, dt);
        }

        private void CreateModelFile(string tableName, string tableComments, DataTable dt)
        {
            var className = string.Concat(TransferToCShapeName(tableName), Suffix);
            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("using System;");
            //sb.AppendLine("using System.Collections.Generic;");
            //sb.AppendLine("using System.Linq;");
            //sb.AppendLine("using System.Text;");
            sb.AppendLine(Using);

            sb.AppendLine();

            sb.Append("namespace ");
            sb.AppendLine(Namespace);
            sb.AppendLine("{");

            sb.Append("\t// 添加 ");
            sb.Append(Environment.UserName);
            sb.Append(" ");
            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd"));
            sb.AppendLine("\t/// <summary>");
            sb.Append("\t/// (");
            sb.Append(tableName.ToLower());
            sb.AppendLine(")实体类");
            if (!string.IsNullOrEmpty(tableComments))
            {
                sb.Append("\t/// ");
                sb.AppendLine(tableComments);
            }
            sb.AppendLine("\t/// </summary>");
            sb.Append("\tpublic class ");
            sb.AppendLine(className);
            sb.AppendLine("\t{");

            string type, privateName, publicName, columnComment, csType;
            bool isNullable;
            foreach (DataRow row in dt.Rows)
            {
                columnComment = row["COLUMN_COMMENT"].ToString();
                type = row["COLUMN_TYPE"].ToString();
                isNullable = row["IS_NULLABLE"].ToString() == "YES" || row["IS_NULLABLE"].ToString() == "Y";
                csType = GetCShapeType(type, isNullable);

                //type = row["COLUMN_TYPE"].ToString();
                //isNullable = row["IS_NULLABLE"].ToString() == "YES" || row["IS_NULLABLE"].ToString() == "Y";
                privateName = TransferToCShapePrivateName(row["COLUMN_NAME"].ToString());
                publicName = TransferToCShapeFieldName(row["COLUMN_NAME"].ToString());

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

            sb.AppendLine("\t\t#endregion 构造函数");

            sb.AppendLine();

            sb.AppendLine("\t}");
            sb.AppendLine("}");

            File.WriteAllText(Path.Combine(_output, className + ".cs"), sb.ToString(), Encoding.UTF8);

            sb.Clear();
        }

        private string GetCShapeType(string type, bool isNullable)
        {
            string result = "string";
            type = type.ToLower();
            if (type == "datetime" || type == "date")
            {
                result = isNullable ? "DateTime?" : "DateTime";
            }
            else if (type == "int" || type == "integer" || type == "bit" || type == "tinyint"
                || type == "smallint" || type == "mediumint" || type == "bigint" || type == "number"
                || Regex.IsMatch(type, "decimal") || Regex.IsMatch(type, "int"))
            {

                result = isNullable ? "int?" : "int";
            }
            else if (type == "float" || type == "double")
            {

                result = isNullable ? "double?" : "double";
            }
            return result;
        }

        private string TransferToCShapeFieldName(string name)
        {
            var strs = name.ToLower().Split('_');
            var result = string.Empty;
            foreach (string str in strs)
            {
                result += str[0].ToString().ToUpper() + str.Remove(0, 1);
            }
            result = result[0].ToString().ToUpper() + result.Remove(0, 1);
            result = Regex.Replace(result, "Id$", "ID");
            return result;
        }

        private string TransferToCShapeName(string name)
        {
            var strs = name.ToLower().Split('_');
            var result = string.Empty;
            foreach (string str in strs)
            {
                result += str[0].ToString().ToUpper() + str.Remove(0, 1);
            }
            return result;
        }

        private string TransferToCShapePrivateName(string name)
        {
            var strs = name.ToLower().Split('_');
            var result = string.Empty;
            foreach (string str in strs)
            {
                result += str[0].ToString().ToUpper() + str.Remove(0, 1);
            }
            result = ("_" + result[0].ToString().ToLower() + result.Remove(0, 1));
            result = Regex.Replace(result, "Id$", "ID");
            return result;
        }
    }
}
