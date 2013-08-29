using LPS.Model.Base;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_parameter)实体类
	/// 系统参数表
	/// </summary>
	public abstract class ParameterDALBase : DALBase
	{
		/// <summary>
		/// 根据 ParamCode 获取系统参数对象
		/// </summary>
		/// <param name="paramCode">参数编码</param>
		/// <returns>返回系统参数对象</returns>
		public virtual Parameter Get(string paramCode)
		{
			return db.ExecuteGet<Parameter>("SELECT PARAM_CODE, PARAM_NAME, PARAM_VALUE, PARAM_DESCFROM T_BASE_PARAMETER WHERE PARAM_CODE = @PARAM_CODE",
				(dr) => { return new Parameter(dr); },
				db.GetDataParameter("@PARAM_CODE", paramCode));
		}

		/// <summary>
		/// 查询系统参数表的所有对象列表
		/// </summary>
		/// <returns>返回系统参数对象列表</returns>
		public virtual ObservableCollection<Parameter> Query()
		{
			return db.ExecuteQuery<Parameter>("SELECT PARAM_CODE, PARAM_NAME, PARAM_VALUE, PARAM_DESC FROM T_BASE_PARAMETER ",
				(dr) => { return new Parameter(dr); });
		}

		/// <summary>
		/// 新增一条系统参数记录
		/// </summary>
		/// <param name="parameter">System.String[]<param>
		/// <returns>返回系统参数受影响的行数</returns>
		public virtual int Add(Parameter parameter)
		{
			return db.ExecuteNoQuery("INSERT INTO T_BASE_PARAMETER (PARAM_CODE, PARAM_NAME, PARAM_VALUE, PARAM_DESC) VALUES (@PARAM_CODE, @PARAM_NAME, @PARAM_VALUE, @PARAM_DESC)", 
				db.GetDataParameter("@PARAM_CODE", parameter.ParamCode),
				db.GetDataParameter("@PARAM_NAME", parameter.ParamName),
				db.GetDataParameter("@PARAM_VALUE", parameter.ParamValue),
				db.GetDataParameter("@PARAM_DESC", parameter.ParamDesc));
		}
		/// <summary>
		/// 根据 ParamCode 更新系统参数表记录
		/// </summary>
		/// <returns>返回系统参数受影响的行数</returns>
		public virtual int Update(Parameter parameter)
		{
			return db.ExecuteNoQuery("UPDATE T_BASE_PARAMETER SET PARAM_NAME = @PARAM_NAME, PARAM_VALUE = @PARAM_VALUE, PARAM_DESC = @PARAM_DESC WHERE PARAM_CODE = @PARAM_CODE", 
				db.GetDataParameter("@PARAM_CODE", parameter.ParamCode),
				db.GetDataParameter("@PARAM_NAME", parameter.ParamName),
				db.GetDataParameter("@PARAM_VALUE", parameter.ParamValue),
				db.GetDataParameter("@PARAM_DESC", parameter.ParamDesc));
		}

		/// <summary>
		/// 根据 ParamCode 删除系统参数表记录
		/// </summary>
		/// <param name="paramCode">参数编码</param>
		/// <returns>返回系统参数受影响的行数</returns>
		public virtual int Delete(string paramCode)
		{
			return db.ExecuteNoQuery("DELETE FROM T_BASE_PARAMETER WHERE PARAM_CODE = @PARAM_CODE", 
				db.GetDataParameter("@PARAM_CODE", paramCode));
		}
	}
}
