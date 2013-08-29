using LPS.Model.Sys;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Sys
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_sys_function)实体类
	/// 系统功能表
	/// </summary>
	public abstract class FunctionDALBase : DALBase
	{
		/// <summary>
		/// 根据 FuncCode 获取系统功能对象
		/// </summary>
		/// <param name="funcCode">模块URL</param>
		/// <returns>返回系统功能对象</returns>
		public virtual Function Get(string funcCode)
		{
			return db.ExecuteGet<Function>("SELECT FUNC_CODE, FUNC_NAME, FUNC_PARENT_CODE, FUNC_SORT, FUNC_LEVEL, FUNC_DESC, FUNC_IS_ENABLEDFROM T_SYS_FUNCTION WHERE FUNC_CODE = @FUNC_CODE",
				(dr) => { return new Function(dr); },
				db.GetDataParameter("@FUNC_CODE", funcCode));
		}

		/// <summary>
		/// 查询系统功能表的所有对象列表
		/// </summary>
		/// <returns>返回系统功能对象列表</returns>
		public virtual ObservableCollection<Function> Query()
		{
			return db.ExecuteQuery<Function>("SELECT FUNC_CODE, FUNC_NAME, FUNC_PARENT_CODE, FUNC_SORT, FUNC_LEVEL, FUNC_DESC, FUNC_IS_ENABLED FROM T_SYS_FUNCTION ",
				(dr) => { return new Function(dr); });
		}

		/// <summary>
		/// 新增一条系统功能记录
		/// </summary>
		/// <param name="function">System.String[]<param>
		/// <returns>返回系统功能受影响的行数</returns>
		public virtual int Add(Function function)
		{
			return db.ExecuteNoQuery("INSERT INTO T_SYS_FUNCTION (FUNC_CODE, FUNC_NAME, FUNC_PARENT_CODE, FUNC_SORT, FUNC_LEVEL, FUNC_DESC, FUNC_IS_ENABLED) VALUES (@FUNC_CODE, @FUNC_NAME, @FUNC_PARENT_CODE, @FUNC_SORT, @FUNC_LEVEL, @FUNC_DESC, @FUNC_IS_ENABLED)", 
				db.GetDataParameter("@FUNC_CODE", function.FuncCode),
				db.GetDataParameter("@FUNC_NAME", function.FuncName),
				db.GetDataParameter("@FUNC_PARENT_CODE", function.FuncParentCode),
				db.GetDataParameter("@FUNC_SORT", function.FuncSort),
				db.GetDataParameter("@FUNC_LEVEL", function.FuncLevel),
				db.GetDataParameter("@FUNC_DESC", function.FuncDesc),
				db.GetDataParameter("@FUNC_IS_ENABLED", function.FuncIsEnabled));
		}
		/// <summary>
		/// 根据 FuncCode 更新系统功能表记录
		/// </summary>
		/// <returns>返回系统功能受影响的行数</returns>
		public virtual int Update(Function function)
		{
			return db.ExecuteNoQuery("UPDATE T_SYS_FUNCTION SET FUNC_NAME = @FUNC_NAME, FUNC_PARENT_CODE = @FUNC_PARENT_CODE, FUNC_SORT = @FUNC_SORT, FUNC_LEVEL = @FUNC_LEVEL, FUNC_DESC = @FUNC_DESC, FUNC_IS_ENABLED = @FUNC_IS_ENABLED WHERE FUNC_CODE = @FUNC_CODE", 
				db.GetDataParameter("@FUNC_CODE", function.FuncCode),
				db.GetDataParameter("@FUNC_NAME", function.FuncName),
				db.GetDataParameter("@FUNC_PARENT_CODE", function.FuncParentCode),
				db.GetDataParameter("@FUNC_SORT", function.FuncSort),
				db.GetDataParameter("@FUNC_LEVEL", function.FuncLevel),
				db.GetDataParameter("@FUNC_DESC", function.FuncDesc),
				db.GetDataParameter("@FUNC_IS_ENABLED", function.FuncIsEnabled));
		}

		/// <summary>
		/// 根据 FuncCode 删除系统功能表记录
		/// </summary>
		/// <param name="funcCode">模块URL</param>
		/// <returns>返回系统功能受影响的行数</returns>
		public virtual int Delete(string funcCode)
		{
			return db.ExecuteNoQuery("DELETE FROM T_SYS_FUNCTION WHERE FUNC_CODE = @FUNC_CODE", 
				db.GetDataParameter("@FUNC_CODE", funcCode));
		}
	}
}
