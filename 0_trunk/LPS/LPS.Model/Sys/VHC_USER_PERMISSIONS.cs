using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LPS.Model.Sys
{
    

    public partial class VHC_USER_PERMISSIONS: FunctionOR
    {

        private string _USER_GUID;
        public string PERMISSION_CODE { get; set; }



        public VHC_USER_PERMISSIONS()
        {

        }
        
        //private char _isFunction;

        public VHC_USER_PERMISSIONS(IDataReader dr)
        {
            USER_GUID = dr["USER_ID"].ToString();
            PERMISSION_CODE = dr["PERM_CODE"].ToString();
            MOD_URL = dr["MOD_URL"].ToString();
            MOD_NAME = dr["MOD_NAME"].ToString();
            PARENT_URL = dr["PARENT_URL"].ToString();
            SORT = int.Parse(dr["SORT"].ToString());
            MOD_LEVEL = int.Parse(dr["MOD_LEVEL"].ToString());
            MOD_DESC = dr["MOD_DESC"].ToString();
            ENABLED = dr["ENABLED"].ToString();
            IMAGE_PATH = dr["IMAGE_PATH"].ToString();
        }

       
        public string USER_GUID
        {
            get
            {
                return this._USER_GUID;
            }
            set
            {
                if ((this._USER_GUID != value))
                {
                    this._USER_GUID = value;
                }
            }
        }

       

        //public char isFunction
        //{
        //    get
        //    {
        //        return this._isFunction;
        //    }
        //    set
        //    {
        //        if ((this._isFunction != value))
        //        {
        //            this._isFunction = value;
        //        }
        //    }
        //}
    }
}
