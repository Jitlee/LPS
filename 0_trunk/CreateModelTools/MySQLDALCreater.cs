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
    public class MySQLDALCreater : MySQLModelCreater
    {
        protected override void CreateFile(string tableName, string tableComments, DataTable dt, StringBuilder sb, string className, string modelName)
        {
        }
    }
}
