using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LPS.Model.Sys
{
    public class RolesOR
    {

        private string _Guid;
        /// <summary>
        /// 主键
        /// </summary>
        public string Guid
        {
            get { return _Guid; }
            set { _Guid = value; }
        }

        private string _RoleName;
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        private string _RoleDesc;
        /// <summary>
        /// 角色说明
        /// </summary>
        public string RoleDesc
        {
            get { return _RoleDesc; }
            set { _RoleDesc = value; }
        }

        /// <summary>
        /// Roles构造函数

        /// </summary>
        public RolesOR()
        {

        }

        /// <summary>
        /// Roles构造函数

        /// </summary>
        public RolesOR(IDataReader row)
        {
            // 主键
            _Guid = row["ROLE_ID"].ToString().Trim();
            // 角色名称
            _RoleName = row["ROLE_NAME"].ToString().Trim();
            // 角色说明
            _RoleDesc = row["ROLE_DESC"].ToString().Trim();
        }
    }
}
