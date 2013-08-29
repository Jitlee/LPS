using LPS.Model.Sys;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Sys
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_sys_permision)实体类
	/// 权限表
	/// </summary>
	public abstract class PermisionDALBase : DALBase
	{
		/// <summary>
		/// 根据 PermCode 获取权限对象
		/// </summary>
		/// <param name="permCode">权限编码</param>
		/// <returns>返回权限对象</returns>
		public virtual Permision Get(string permCode)
		{
			return db.ExecuteGet<Permision>("SELECT PERM_CODE, FUNC_CODE, PERM_NAME, PERM_DESC, PERM_SORT, PERM_IS_ENABLED, PERM_IS_DEFAULTFROM T_SYS_PERMISION WHERE PERM_CODE = @PERM_CODE",
				(dr) => { return new Permision(dr); },
				db.GetDataParameter("@PERM_CODE", permCode));
		}

		/// <summary>
		/// 查询权限表的所有对象列表
		/// </summary>
		/// <returns>返回权限对象列表</returns>
		public virtual ObservableCollection<Permision> Query()
		{
			return db.ExecuteQuery<Permision>("SELECT PERM_CODE, FUNC_CODE, PERM_NAME, PERM_DESC, PERM_SORT, PERM_IS_ENABLED, PERM_IS_DEFAULT FROM T_SYS_PERMISION ",
				(dr) => { return new Permision(dr); });
		}

		/// <summary>
		/// 新增一条权限记录
		/// </summary>
		/// <param name="permision">System.String[]<param>
		/// <returns>返回权限受影响的行数</returns>
		public virtual int Add(Permision permision)
		{
			return db.ExecuteNoQuery("INSERT INTO T_SYS_PERMISION (PERM_CODE, FUNC_CODE, PERM_NAME, PERM_DESC, PERM_SORT, PERM_IS_ENABLED, PERM_IS_DEFAULT) VALUES (@PERM_CODE, @FUNC_CODE, @PERM_NAME, @PERM_DESC, @PERM_SORT, @PERM_IS_ENABLED, @PERM_IS_DEFAULT)", 
				db.GetDataParameter("@PERM_CODE", permision.PermCode),
				db.GetDataParameter("@FUNC_CODE", permision.FuncCode),
				db.GetDataParameter("@PERM_NAME", permision.PermName),
				db.GetDataParameter("@PERM_DESC", permision.PermDesc),
				db.GetDataParameter("@PERM_SORT", permision.PermSort),
				db.GetDataParameter("@PERM_IS_ENABLED", permision.PermIsEnabled),
				db.GetDataParameter("@PERM_IS_DEFAULT", permision.PermIsDefault));
		}
		/// <summary>
		/// 根据 PermCode 更新权限表记录
		/// </summary>
		/// <returns>返回权限受影响的行数</returns>
		public virtual int Update(Permision permision)
		{
			return db.ExecuteNoQuery("UPDATE T_SYS_PERMISION SET FUNC_CODE = @FUNC_CODE, PERM_NAME = @PERM_NAME, PERM_DESC = @PERM_DESC, PERM_SORT = @PERM_SORT, PERM_IS_ENABLED = @PERM_IS_ENABLED, PERM_IS_DEFAULT = @PERM_IS_DEFAULT WHERE PERM_CODE = @PERM_CODE", 
				db.GetDataParameter("@PERM_CODE", permision.PermCode),
				db.GetDataParameter("@FUNC_CODE", permision.FuncCode),
				db.GetDataParameter("@PERM_NAME", permision.PermName),
				db.GetDataParameter("@PERM_DESC", permision.PermDesc),
				db.GetDataParameter("@PERM_SORT", permision.PermSort),
				db.GetDataParameter("@PERM_IS_ENABLED", permision.PermIsEnabled),
				db.GetDataParameter("@PERM_IS_DEFAULT", permision.PermIsDefault));
		}

		/// <summary>
		/// 根据 PermCode 删除权限表记录
		/// </summary>
		/// <param name="permCode">权限编码</param>
		/// <returns>返回权限受影响的行数</returns>
		public virtual int Delete(string permCode)
		{
			return db.ExecuteNoQuery("DELETE FROM T_SYS_PERMISION WHERE PERM_CODE = @PERM_CODE", 
				db.GetDataParameter("@PERM_CODE", permCode));
		}
	}
}
