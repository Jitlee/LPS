using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LPS.Model.Sys
{
    public class FunctionOR
    {
        
        public string MOD_URL { get; set; }
        public string MOD_NAME { get; set; }
        public string PARENT_URL { get; set; }
        public int SORT { get; set; }
        public int MOD_LEVEL { get; set; }
        public string MOD_DESC { get; set; }
        public string ENABLED { get; set; }
        public string IMAGE_PATH { get; set; }
        public bool IsChecked { get; set; }

        public FunctionOR()
        {

        }
        public FunctionOR(IDataReader dr)
        {
            //
            MOD_URL = dr["MOD_URL"].ToString();
            MOD_NAME = dr["MOD_NAME"].ToString();
            PARENT_URL = dr["PARENT_URL"].ToString();
            SORT = int.Parse(dr["SORT"].ToString());
            MOD_LEVEL = int.Parse(dr["MOD_LEVEL"].ToString());
            MOD_DESC = dr["MOD_DESC"].ToString();
            ENABLED = dr["ENABLED"].ToString();
            IMAGE_PATH = dr["IMAGE_PATH"].ToString();
        }
    }
}
