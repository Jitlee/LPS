using System;
using System.Data;

namespace LPS.Model.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_parameter)实体类
	/// 系统参数表
	/// </summary>
	public class Parameter : EntityObject
	{

		// 保存参数编码
		private string _paramCode;

		/// <summary>
		/// 获取或设置参数编码
		/// </summary>
		public string ParamCode
		{
			get
			{

				return _paramCode;
			}
			set
			{
				_paramCode = value;
				RaisePropertyChanged("ParamCode");
			}
		}

		// 保存参数名称
		private string _paramName;

		/// <summary>
		/// 获取或设置参数名称
		/// </summary>
		public string ParamName
		{
			get
			{

				return _paramName;
			}
			set
			{
				_paramName = value;
				RaisePropertyChanged("ParamName");
			}
		}

		// 保存参数值
		private string _paramValue;

		/// <summary>
		/// 获取或设置参数值
		/// </summary>
		public string ParamValue
		{
			get
			{

				return _paramValue;
			}
			set
			{
				_paramValue = value;
				RaisePropertyChanged("ParamValue");
			}
		}

		// 保存参数描述
		private string _paramDesc;

		/// <summary>
		/// 获取或设置参数描述
		/// </summary>
		public string ParamDesc
		{
			get
			{

				return _paramDesc;
			}
			set
			{
				_paramDesc = value;
				RaisePropertyChanged("ParamDesc");
			}
		}

		#region 构造函数

		/// <summary>
		/// 系统参数表构造函数
		/// </summary>
		public Parameter()
		{
		}

		/// <summary>
		/// 系统参数表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public Parameter(IDataReader dr)
		{
			if (DBNull.Value != dr["PARAM_CODE"])
			{
				_paramCode = dr["PARAM_CODE"].ToString();
			}
			if (DBNull.Value != dr["PARAM_NAME"])
			{
				_paramName = dr["PARAM_NAME"].ToString();
			}
			if (DBNull.Value != dr["PARAM_VALUE"])
			{
				_paramValue = dr["PARAM_VALUE"].ToString();
			}
			if (DBNull.Value != dr["PARAM_DESC"])
			{
				_paramDesc = dr["PARAM_DESC"].ToString();
			}
		}

		#endregion 构造函数

	}
}
