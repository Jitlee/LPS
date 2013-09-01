using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LPS.Model.Sys;
using System.Collections.ObjectModel;

namespace LPS.DAL.Sys
{
    public class UserPermissionsDA : DALBase
    {
        public ObservableCollection<VHC_USER_PERMISSIONS> GetListByUserID(string userLoginID)
        {
            string sql = string.Format("select * from V_USER_PERMISSIONS where USER_ID='{0}' order by Sort", userLoginID);

            return db.ExecuteQuery<VHC_USER_PERMISSIONS>(sql,(dr) => { return new VHC_USER_PERMISSIONS(dr); });
        }

        public bool InsertRolePermission(List<RolePermissionsOR> list)
        {
            if (list.Count == 0) return false;
            string sql = string.Format("delete from T_SYS_ROLE_PERMISSION where  ROLE_ID='{0}'", list[0].RoleGuid);
            List<string> listCommand = new List<string>();
            listCommand.Add(sql);
            foreach (RolePermissionsOR ur in list)
            {
                sql = string.Format("insert into T_SYS_ROLE_PERMISSION (ROLE_GUID, PERMISSION_CODE) values ('{0}', '{1}')", ur.RoleGuid, ur.PermissionCode);
                listCommand.Add(sql);
            }
            db.ExecuteNoQuery(listCommand);
            return true;
        }

        public ObservableCollection<VHC_USER_PERMISSIONS> GetPermByRoleID(string ROLE_ID)
        {
            string sql = string.Format("select * from V_USER_PERMISSIONS where ROLE_ID='{0}' order by Sort", ROLE_ID);
            return db.ExecuteQuery<VHC_USER_PERMISSIONS>(sql,(dr) => { return new VHC_USER_PERMISSIONS(dr); });
        }

        /// <summary>
        /// 查询所有角色，并检测给定角色，是否选中
        /// </summary>
        public ObservableCollection<FunctionOR> SelectFunctionCheckPermInRose(string ROLE_ID)
        {
            string strSQL = "select * from t_sys_function";
            ObservableCollection<FunctionOR> FunctionList = db.ExecuteQuery<FunctionOR>(strSQL, (dr) => { return new FunctionOR(dr); });
            ObservableCollection<VHC_USER_PERMISSIONS> RolePermList = GetPermByRoleID(ROLE_ID);

            foreach (FunctionOR FPer in FunctionList)
            {
                foreach (VHC_USER_PERMISSIONS RPer in RolePermList)
                {
                    if (FPer.MOD_URL == RPer.MOD_URL)
                    {
                        FPer.IsChecked = true;
                        break;
                    }
                }
            }
            return FunctionList;
        }


    }
}
