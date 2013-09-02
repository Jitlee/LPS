using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LPS.Model.Sys;
using System.Collections.ObjectModel;

namespace LPS.DAL.Sys
{
    public class RolesDA : DALBase
    {

        #region 查询
        public ObservableCollection<RolesOR> selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from T_SYS_ROLE";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            sql += " order by ROLE_NAME desc";
            pageCount = 0;
            return db.ExecuteQuery<RolesOR>(sql, (dr) => { return new RolesOR(dr); });
        }

        public RolesOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from T_SYS_ROLE where ROLE_ID='{0}'", m_id);
            return db.ExecuteGet<RolesOR>(sql, (dr) => { return new RolesOR(dr); });
        }

        public ObservableCollection<RolesOR> SelectAllRoles()
        {
            string sql = string.Format("select * from T_SYS_ROLE");
            return db.ExecuteQuery<RolesOR>(sql, (dr) => { return new RolesOR(dr); });
        }

        public ObservableCollection<RolesOR> SelectRolesWithoutSelf(string rolename)
        {
            string sql = string.Format("select * from T_SYS_ROLES where role_name != '" + rolename + "'");
            return db.ExecuteQuery<RolesOR>(sql, (dr) => { return new RolesOR(dr); });
        }
        #endregion

        #region 插入
        /// <summary>
        /// 插入T_SYS_ROLES
        /// </summary>
        public virtual bool Insert(RolesOR roles)
        {
            string sql = "insert into T_SYS_ROLE (ROLE_ID, ROLE_NAME, ROLE_DESC) values (@ROLE_ID, @ROLE_NAME, @ROLE_DESC)";

            return db.ExecuteNoQuery(sql,
                db.GetDataParameter("@ROLE_ID", Guid.NewGuid().ToString()),
                db.GetDataParameter("@ROLE_NAME", roles.RoleName),
                db.GetDataParameter("@ROLE_DESC", roles.RoleDesc))>0;
        }


        #endregion

        #region 修改
        /// <summary>
        /// 更新T_SYS_ROLES
        /// </summary>
        public virtual bool Update(RolesOR roles)
        {
            string sql = "update T_SYS_ROLE set  ROLE_NAME = @ROLE_NAME,  ROLE_DESC = @ROLE_DESC where ROLE_ID= @ROLE_ID";
            return db.ExecuteNoQuery(sql,
                db.GetDataParameter("@ROLE_ID", Guid.NewGuid().ToString()),
                db.GetDataParameter("@ROLE_NAME", roles.RoleName),
                db.GetDataParameter("@ROLE_DESC", roles.RoleDesc)) > 0;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除T_SYS_ROLES
        /// </summary>
        public virtual bool Delete(string strGuid)
        {
            string sql = string.Format("delete from T_SYS_ROLES where  ROLE_ID = '{0}'", strGuid);
            return db.ExecuteNoQuery(sql) > -1;
        }
        #endregion
    }
}
