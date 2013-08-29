using LPS.Model.Sys;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Sys
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_sys_role_permision)实体类
	/// 角色权限表
	/// </summary>
	public abstract class RolePermisionDALBase : DALBase
	{
		/// <summary>
		/// 根据 RoleId, PermCode 获取角色权限对象
		/// </summary>
		/// <param name="roleId">角色ID</param>
		/// <param name="permCode">权限编码</param>
		/// <returns>返回角色权限对象</returns>
		public virtual RolePermision Get(string roleId, string permCode)
		{
			return db.ExecuteGet<RolePermision>("SELECT ROLE_ID, PERM_CODEFROM T_SYS_ROLE_PERMISION WHERE ROLE_ID = @ROLE_ID AND PERM_CODE = @PERM_CODE",
				(dr) => { return new RolePermision(dr); },
				db.GetDataParameter("@ROLE_ID", roleId),
				db.GetDataParameter("@PERM_CODE", permCode));
		}

		/// <summary>
		/// 查询角色权限表的所有对象列表
		/// </summary>
		/// <returns>返回角色权限对象列表</returns>
		public virtual ObservableCollection<RolePermision> Query()
		{
			return db.ExecuteQuery<RolePermision>("SELECT ROLE_ID, PERM_CODE FROM T_SYS_ROLE_PERMISION ",
				(dr) => { return new RolePermision(dr); });
		}

		/// <summary>
		/// 新增一条角色权限记录
		/// </summary>
		/// <param name="rolepermision">System.String[]<param>
		/// <returns>返回角色权限受影响的行数</returns>
		public virtual int Add(RolePermision rolepermision)
		{
			return db.ExecuteNoQuery("INSERT INTO T_SYS_ROLE_PERMISION (ROLE_ID, PERM_CODE) VALUES (@ROLE_ID, @PERM_CODE)", 
				db.GetDataParameter("@ROLE_ID", rolepermision.RoleId),
				db.GetDataParameter("@PERM_CODE", rolepermision.PermCode));
		}
		/// <summary>
		/// 根据 RoleId, PermCode 更新角色权限表记录
		/// </summary>
		/// <returns>返回角色权限受影响的行数</returns>
		public virtual int Update(RolePermision rolepermision)
		{
			return db.ExecuteNoQuery("UPDATE T_SYS_ROLE_PERMISION SET  WHERE ROLE_ID = @ROLE_ID AND PERM_CODE = @PERM_CODE", 
				db.GetDataParameter("@ROLE_ID", rolepermision.RoleId),
				db.GetDataParameter("@PERM_CODE", rolepermision.PermCode));
		}

		/// <summary>
		/// 根据 RoleId, PermCode 删除角色权限表记录
		/// </summary>
		/// <param name="roleId">角色ID</param>
		/// <param name="permCode">权限编码</param>
		/// <returns>返回角色权限受影响的行数</returns>
		public virtual int Delete(string roleId, string permCode)
		{
			return db.ExecuteNoQuery("DELETE FROM T_SYS_ROLE_PERMISION WHERE ROLE_ID = @ROLE_ID AND PERM_CODE = @PERM_CODE", 
				db.GetDataParameter("@ROLE_ID", roleId),
				db.GetDataParameter("@PERM_CODE", permCode));
		}
	}
}
