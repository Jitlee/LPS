using LPS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LPS.DAL
{
    public abstract class DALBase
    {
        protected readonly DbHelper db;
        public DALBase()
        {
            db = new MySQLDbHepler(System.Configuration.ConfigurationManager.ConnectionStrings["lps"].ConnectionString);
        }
    }
}
