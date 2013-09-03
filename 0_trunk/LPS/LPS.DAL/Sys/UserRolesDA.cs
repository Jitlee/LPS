using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LPS.Model.Sys;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Sys
{
    public class UserRolesDA : DALBase
    {
        /// <summary>
        /// 查询用户角色
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <returns></returns>
        public ObservableCollection<UserRolesOR> GetUserRoseBuyUserID(string UserGuid)
        {
			string sql = string.Format(@"SELECT T_SYS_USER_ROLE.*,T_SYS_ROLE.ROLE_NAME from T_SYS_USER_ROLE
LEFT JOIN T_SYS_ROLE ON T_SYS_ROLE.ROLE_ID=T_SYS_USER_ROLE.ROLE_ID WHERE USER_ID='{0}'", UserGuid);

            return db.ExecuteQuery<UserRolesOR>(sql, (dr) => { return new UserRolesOR(dr); });
        }

        public bool AddUserRoles(List<UserRolesOR> listRolse)
        {
            if (listRolse.Count == 0) return false;
            string sql = string.Format("delete T_SYS_USER_ROLE where USER_ID='{0}'", listRolse[0].UserGuid);
            List<string> listCommand = new List<string>();
            listCommand.Add(sql);
            foreach (UserRolesOR ur in listRolse)
            {
                sql = string.Format("insert into T_SYS_USER_ROLE(USER_ID, ROLE_ID) values ('{0}', '{1}')", ur.UserGuid, ur.RoleGuid);
                listCommand.Add(sql);
            }
            db.ExecuteNoQuery(listCommand);
            return true;

        }
		public ObservableCollection<EmpolyeeOR> GetUserRosetList(int pageCrrent, int pageSize, out int pageCount, string where)
		{
			string sql = "select * from t_base_empolyee";
			if (!string.IsNullOrEmpty(where))
			{
				sql = string.Format(" {0} where {1}", sql, where);
			}

			ObservableCollection<EmpolyeeOR> EmpolyeeList = db.ExecuteQuery<EmpolyeeOR>(sql, (dr) => { return new EmpolyeeOR(dr); });
			foreach (EmpolyeeOR emp in EmpolyeeList)
			{
				emp.RoseNameList = GetUserRoseNames(emp.EmpolyeeId);
			}
			pageCount = 0;
			return EmpolyeeList;
		}

		protected string GetUserRoseNames(string UserID)
		{
			ObservableCollection<UserRolesOR> Roles = GetUserRoseBuyUserID(UserID);
			string RoleNames = string.Empty;
			if (Roles != null && Roles.Count >= 0)
			{
				foreach (UserRolesOR obj in Roles)
				{
					if (!string.IsNullOrEmpty(RoleNames))
					{
						RoleNames += "#";
					}
					RoleNames += obj.RoleName;
				}
				return RoleNames;
			}
			return string.Empty;
		}
    }
}
