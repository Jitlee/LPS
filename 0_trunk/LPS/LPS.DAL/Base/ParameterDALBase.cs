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
        public virtual ParameterOR Get(string paramCode)
		{
            return db.ExecuteGet<ParameterOR>("SELECT * FROM T_BASE_PARAMETER WHERE PARAM_CODE = @PARAM_CODE",
                (dr) => { return new ParameterOR(dr); },
				db.GetDataParameter("@PARAM_CODE", paramCode));
		}

		/// <summary>
		/// 查询系统参数表的所有对象列表
		/// </summary>
		/// <returns>返回系统参数对象列表</returns>
        public virtual ObservableCollection<ParameterOR> Query()
		{
            return db.ExecuteQuery<ParameterOR>("SELECT * FROM T_BASE_PARAMETER ",
                (dr) => { return new ParameterOR(dr); });
		}

		
		/// <summary>
		/// 根据 ParamCode 更新系统参数表记录
		/// </summary>
		/// <returns>返回系统参数受影响的行数</returns>
        public virtual int Update(ParameterOR parameter)
		{
			return db.ExecuteNoQuery("UPDATE T_BASE_PARAMETER SET   PARAM_VALUE = @PARAM_VALUE  WHERE PARAM_CODE = @PARAM_CODE", 
				db.GetDataParameter("@PARAM_CODE", parameter.ParamCode),
				db.GetDataParameter("@PARAM_VALUE", parameter.ParamValue)
				);
		}

	
	}
}
