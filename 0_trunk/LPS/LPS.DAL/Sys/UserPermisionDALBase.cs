using LPS.Model.Sys;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Sys
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_sys_user_permision)实体类
	/// </summary>
	public abstract class UserPermisionDALBase : DALBase
	{
		/// <summary>
		/// 根据 UserId, PermCode 获取对象
		/// </summary>
		/// <param name="userId">用户ID</param>
		/// <param name="permCode">权限编码</param>
		/// <returns>返回对象</returns>
		public virtual UserPermision Get(string userId, string permCode)
		{
			return db.ExecuteGet<UserPermision>("SELECT USER_ID, PERM_CODEFROM T_SYS_USER_PERMISION WHERE USER_ID = @USER_ID AND PERM_CODE = @PERM_CODE",
				(dr) => { return new UserPermision(dr); },
				db.GetDataParameter("@USER_ID", userId),
				db.GetDataParameter("@PERM_CODE", permCode));
		}

		/// <summary>
		/// 查询的所有对象列表
		/// </summary>
		/// <returns>返回对象列表</returns>
		public virtual ObservableCollection<UserPermision> Query()
		{
			return db.ExecuteQuery<UserPermision>("SELECT USER_ID, PERM_CODE FROM T_SYS_USER_PERMISION ",
				(dr) => { return new UserPermision(dr); });
		}

		/// <summary>
		/// 新增一条记录
		/// </summary>
		/// <param name="userpermision">System.String[]<param>
		/// <returns>返回受影响的行数</returns>
		public virtual int Add(UserPermision userpermision)
		{
			return db.ExecuteNoQuery("INSERT INTO T_SYS_USER_PERMISION (USER_ID, PERM_CODE) VALUES (@USER_ID, @PERM_CODE)", 
				db.GetDataParameter("@USER_ID", userpermision.UserId),
				db.GetDataParameter("@PERM_CODE", userpermision.PermCode));
		}
		/// <summary>
		/// 根据 UserId, PermCode 更新记录
		/// </summary>
		/// <returns>返回受影响的行数</returns>
		public virtual int Update(UserPermision userpermision)
		{
			return db.ExecuteNoQuery("UPDATE T_SYS_USER_PERMISION SET  WHERE USER_ID = @USER_ID AND PERM_CODE = @PERM_CODE", 
				db.GetDataParameter("@USER_ID", userpermision.UserId),
				db.GetDataParameter("@PERM_CODE", userpermision.PermCode));
		}

		/// <summary>
		/// 根据 UserId, PermCode 删除记录
		/// </summary>
		/// <param name="userId">用户ID</param>
		/// <param name="permCode">权限编码</param>
		/// <returns>返回受影响的行数</returns>
		public virtual int Delete(string userId, string permCode)
		{
			return db.ExecuteNoQuery("DELETE FROM T_SYS_USER_PERMISION WHERE USER_ID = @USER_ID AND PERM_CODE = @PERM_CODE", 
				db.GetDataParameter("@USER_ID", userId),
				db.GetDataParameter("@PERM_CODE", permCode));
		}
	}
}
