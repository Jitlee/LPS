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
    public abstract class Creater
    {
        private string _output;

        public string ConnectionString { get; set; }

        public string Namespace { get; set; }

        public string Using { get; set; }

        public string Suffix { get; set; }

        public string Inherit { get; set; }

        public string ClassType { get; set; }

        public string[] TableNames { get; set; }

        public string Output { get; set; }

        public abstract void Finish();

        protected abstract string TableInfoSQL { get; set; }
        protected abstract string TableCommentSQL { get; set; }

        protected void CreateFile(string database, string tableName, IDbCommand cmd, DbDataAdapter da)
        {
            cmd.CommandText = string.Format(TableInfoSQL, database.ToLower(), tableName.ToLower());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.CommandText = string.Format(TableCommentSQL, database.ToLower(), tableName.ToLower());
            string tableComments = (cmd.ExecuteScalar() ?? string.Empty).ToString();

            CreateFile(tableName.ToUpper(), tableComments, dt);
        }

        private void CreateFile(string tableName, string tableComments, DataTable dt)
        {
            Output = Output ?? "Output";
            string func;
            var modelName = GetClassName(tableName, out func);
            var className = string.Concat(modelName, Suffix);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Using.Replace("[Function]", func));

            sb.AppendLine();

            sb.Append("namespace ");
            sb.Append(Namespace);
            if (!string.IsNullOrEmpty(func))
            {
                sb.Append(".");
                sb.Append(func);
            }
            sb.AppendLine();
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
            sb.Append("\tpublic");
            if (!string.IsNullOrEmpty(ClassType))
            {
                sb.Append(" ");
                sb.Append(ClassType);
            }
            sb.Append(" class ");
            sb.Append(className);
            if (!string.IsNullOrEmpty(Inherit))
            {
                sb.Append(" : ");
                sb.Append(Inherit.Replace("[ModelName]", modelName));
            }
            sb.AppendLine();
            sb.AppendLine("\t{");

            CreateFile(tableName, tableComments, dt, sb, className, modelName);

            sb.AppendLine("\t}");

            sb.AppendLine("}");

            if (!Directory.Exists(Path.Combine(Output, func)))
            {
                Directory.CreateDirectory(Path.Combine(Output, func));
            }
            File.WriteAllText(Path.Combine(Output, func, className + ".cs"), sb.ToString(), Encoding.UTF8);

            Console.WriteLine("成功创建文件:{0}.cs", className);
            sb.Clear();
        }

        protected abstract void CreateFile(string tableName, string tableComments, DataTable dt, StringBuilder sb, string className, string modelName);

        protected string GetCShapeType(string type, bool isNullable)
        {
            string result = "string";
            type = type.ToLower();
            if (type == "datetime" || type == "date")
            {
                result = isNullable ? "DateTime?" : "DateTime";
            }
            else if (type == "int" || type == "integer" || type == "bit" || type == "tinyint"
                || type == "smallint" || type == "mediumint" || type == "bigint" || type == "number"
                || type == "int")
            {

                result = isNullable ? "int?" : "int";
            }
            else if (type == "float" || type == "double" || type == "decimal")
            {

                result = isNullable ? "double?" : "double";
            }
            return result;
        }

        protected string TransferToCShapeFieldName(string name, string className = "")
        {
            var strs = name.ToLower().Split('_');
            var result = string.Empty;
            foreach (string str in strs)
            {
                result += str[0].ToString().ToUpper() + str.Remove(0, 1);
            }
            result = result[0].ToString().ToUpper() + result.Remove(0, 1);

            if (result == className)
            {
                var match = Regex.Match(name, "(?i)(?<=[A-Za-z]+_).*");
                if (match.Success)
                {
                    result = TransferToCShapeFieldName(match.Value);
                }
            }
            return result;
        }

        protected string GetClassName(string tableName, out string model)
        {
            string className = tableName;
            model = string.Empty;
            var match = Regex.Match(tableName, "(?i)(?<=t_)[A-Za-z]+(?=_)");
            if (match.Success)
            {
                model = TransferToCShapeName(match.Value);
                className = tableName.Substring(match.Index + match.Length + 1);
            }
            return TransferToCShapeName(className);
        }

        protected string TransferToCShapeName(string name)
        {
            var strs = name.ToLower().Split('_');
            var result = string.Empty;
            foreach (string str in strs)
            {
                result += str[0].ToString().ToUpper() + str.Remove(0, 1);
            }
            return result;
        }

        protected string TransferToCShapePrivateName(string name, string className = "")
        {
            var strs = name.ToLower().Split('_');
            var result = string.Empty;
            foreach (string str in strs)
            {
                result += str[0].ToString().ToUpper() + str.Remove(0, 1);
            }
            result = ("_" + result[0].ToString().ToLower() + result.Remove(0, 1));

            if (name == className)
            {
                var match = Regex.Match(name, "(?i)(?<=[A-Za-z]+_).*");
                if (match.Success)
                {
                    result = TransferToCShapePrivateName(match.Value);
                }
            }
            return result;
        }

        protected string TransferToCShapeVariableName(string name, string className = "")
        {
            var strs = name.ToLower().Split('_');
            var result = string.Empty;
            foreach (string str in strs)
            {
                result += str[0].ToString().ToUpper() + str.Remove(0, 1);
            }
            result = (result[0].ToString().ToLower() + result.Remove(0, 1));

            if (name == className)
            {
                var match = Regex.Match(name, "(?i)(?<=[A-Za-z]+_).*");
                if (match.Success)
                {
                    result = TransferToCShapePrivateName(match.Value);
                }
            }
            return result;
        }
    }
}
