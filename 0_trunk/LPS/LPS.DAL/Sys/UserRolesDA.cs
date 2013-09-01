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
            string sql = string.Format("select * from T_SYS_USER_ROLE where USER_ID='{0}'", UserGuid);

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
        public DataTable GetUserRosetList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from V_UserRoseInfo";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;
            int returnC = 0; try
            {
                //dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }



        //public UserRolesOR selectARowDate(string m_id)
        //{
        //    string sql = string.Format("select * from T_SYS_USER_ROLE where string strUserGuid='{0}'", m_id);
        //    DataTable dt = null;
        //    try
        //    {
        //        dt = db.ExecuteQueryDataSet(sql).Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    if (dt == null)
        //        return null;
        //    if (dt.Rows.Count == 0)
        //        return null;
        //    DataRow dr = dt.Rows[0];
        //    UserRolesOR m_User = new UserRolesOR(dr);
        //    return m_User;
        //}

    }
}
