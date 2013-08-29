using LPS.Model.Sys;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Sys
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_sys_role)实体类
	/// 用户角色表
	/// </summary>
	public abstract class RoleDALBase : DALBase
	{
		/// <summary>
		/// 根据 RoleId 获取用户角色对象
		/// </summary>
		/// <param name="roleId">角色ID</param>
		/// <returns>返回用户角色对象</returns>
		public virtual Role Get(string roleId)
		{
			return db.ExecuteGet<Role>("SELECT ROLE_ID, ROLE_NAME, ROLE_DESCFROM T_SYS_ROLE WHERE ROLE_ID = @ROLE_ID",
				(dr) => { return new Role(dr); },
				db.GetDataParameter("@ROLE_ID", roleId));
		}

		/// <summary>
		/// 查询用户角色表的所有对象列表
		/// </summary>
		/// <returns>返回用户角色对象列表</returns>
		public virtual ObservableCollection<Role> Query()
		{
			return db.ExecuteQuery<Role>("SELECT ROLE_ID, ROLE_NAME, ROLE_DESC FROM T_SYS_ROLE ",
				(dr) => { return new Role(dr); });
		}

		/// <summary>
		/// 新增一条用户角色记录
		/// </summary>
		/// <param name="role">System.String[]<param>
		/// <returns>返回用户角色受影响的行数</returns>
		public virtual int Add(Role role)
		{
			return db.ExecuteNoQuery("INSERT INTO T_SYS_ROLE (ROLE_ID, ROLE_NAME, ROLE_DESC) VALUES (@ROLE_ID, @ROLE_NAME, @ROLE_DESC)", 
				db.GetDataParameter("@ROLE_ID", role.RoleId),
				db.GetDataParameter("@ROLE_NAME", role.RoleName),
				db.GetDataParameter("@ROLE_DESC", role.RoleDesc));
		}
		/// <summary>
		/// 根据 RoleId 更新用户角色表记录
		/// </summary>
		/// <returns>返回用户角色受影响的行数</returns>
		public virtual int Update(Role role)
		{
			return db.ExecuteNoQuery("UPDATE T_SYS_ROLE SET ROLE_NAME = @ROLE_NAME, ROLE_DESC = @ROLE_DESC WHERE ROLE_ID = @ROLE_ID", 
				db.GetDataParameter("@ROLE_ID", role.RoleId),
				db.GetDataParameter("@ROLE_NAME", role.RoleName),
				db.GetDataParameter("@ROLE_DESC", role.RoleDesc));
		}

		/// <summary>
		/// 根据 RoleId 删除用户角色表记录
		/// </summary>
		/// <param name="roleId">角色ID</param>
		/// <returns>返回用户角色受影响的行数</returns>
		public virtual int Delete(string roleId)
		{
			return db.ExecuteNoQuery("DELETE FROM T_SYS_ROLE WHERE ROLE_ID = @ROLE_ID", 
				db.GetDataParameter("@ROLE_ID", roleId));
		}
	}
}
