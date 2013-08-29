using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace CreateModelTools
{
    public abstract class MySQLBaseCreater : Creater
    {
        protected override string TableInfoSQL { get; set; }
        protected override string TableCommentSQL { get; set; }

        public MySQLBaseCreater()
        {
            TableInfoSQL = "SELECT COLUMN_NAME, COLUMN_COMMENT,DATA_TYPE COLUMN_TYPE, COLUMN_KEY, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='{0}' AND TABLE_NAME='{1}'";
            TableCommentSQL = "SELECT TABLE_COMMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='{0}' AND TABLE_NAME='{1}'";
        }

        public override void Finish()
        {
            Output = Output ?? "Output";
            if (!Directory.Exists(Output))
            {
                Directory.CreateDirectory(Output);
            }

            Console.Write("输出路径：");
            Console.WriteLine(Output);
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        cmd.Connection = conn;
                        foreach (string tableName in TableNames)
                        {
                            CreateFile(conn.Database, tableName, cmd, da);
                        }

                        Console.WriteLine("操作成功，成功生成{0}个文件", TableNames.Length);
                    }
                }
            }
        }
    }
}
