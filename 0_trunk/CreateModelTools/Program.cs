using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace CreateModelTools
{
    static class Program
    {
        public class Test
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
        public static void Main(string[] args)
        {
            string[] tableNames = new string[]
            {
                "t_sys_function",
                "t_sys_role_permision",
                "t_sys_user_permision",
                "t_base_dictronary",
                "t_base_dictronary_type",
                "t_base_empolyee",
                "t_base_farmer",
                "t_base_leaf_level",
                "t_base_parameter",
                "t_pur_leaf",
                "t_sys_permision",
                "t_sys_role",
            };
            string connectionString = "server=localhost;port=3306;Database=lps;Uid=lps;Pwd=admin;allow zero datetime=true";
            {
                MySQLModelCreater helper = new MySQLModelCreater();
                helper.ConnectionString = connectionString;
                helper.Output = "Model";
                helper.Namespace = "LPS.Model";
                helper.Using = @"using System;
using System.Data;";
                helper.Suffix = "";
                helper.Inherit = "EntityObject";

                helper.TableNames = tableNames;

                helper.Finish();
            }

            {
                MySQLDALBaseCreater helper = new MySQLDALBaseCreater();
                helper.Output = "DAL";
                helper.ConnectionString = connectionString;
                helper.Namespace = "LPS.DAL";
                helper.Using = @"using LPS.Model.[Function];

using System;
using System.Collections.ObjectModel;
using System.Data;";
                helper.Suffix = "DALBase";
                helper.Inherit = "DALBase";
                helper.ClassType = "abstract";

                helper.TableNames = tableNames;

                helper.Finish();
            }

            {
                MySQLDALCreater helper = new MySQLDALCreater();
                helper.Output = "DAL";
                helper.ConnectionString = connectionString;
                helper.Namespace = "LPS.DAL";
                helper.Using = @"";
                helper.Suffix = "DAL";
                helper.Inherit = "[ModelName]DALBase";
                helper.ClassType = "";

                helper.TableNames = tableNames;

                helper.Finish();
            }

            Console.WriteLine();
            Console.WriteLine("按输入任意键退出");
            Console.ReadKey();
        }
    }
}
