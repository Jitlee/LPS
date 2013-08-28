using System;
using System.Data;

namespace LPS.Model.Base
{
	// 添加 Jitlee 2013-08-29
	/// <summary>
	/// (t_base_dictronary)实体类
	/// 数据字典表
	/// </summary>
	public class Dictronary : EntityObject
	{

		// 保存字典类型
		private string _dictType;

		/// <summary>
		/// 获取或设置字典类型
		/// </summary>
		public string DictType
		{
			get
			{

				return _dictType;
			}
			set
			{
				_dictType = value;
				RaisePropertyChanged("DictType");
			}
		}

		// 保存
		private string _dictCode;

		/// <summary>
		/// 获取或设置
		/// </summary>
		public string DictCode
		{
			get
			{

				return _dictCode;
			}
			set
			{
				_dictCode = value;
				RaisePropertyChanged("DictCode");
			}
		}

		// 保存字典名称
		private string _dictName;

		/// <summary>
		/// 获取或设置字典名称
		/// </summary>
		public string DictName
		{
			get
			{

				return _dictName;
			}
			set
			{
				_dictName = value;
				RaisePropertyChanged("DictName");
			}
		}

		// 保存字典值
		private string _dictValue;

		/// <summary>
		/// 获取或设置字典值
		/// </summary>
		public string DictValue
		{
			get
			{

				return _dictValue;
			}
			set
			{
				_dictValue = value;
				RaisePropertyChanged("DictValue");
			}
		}

		// 保存字典描述
		private string _dictDesc;

		/// <summary>
		/// 获取或设置字典描述
		/// </summary>
		public string DictDesc
		{
			get
			{

				return _dictDesc;
			}
			set
			{
				_dictDesc = value;
				RaisePropertyChanged("DictDesc");
			}
		}

		#region 构造函数

		/// <summary>
		/// 数据字典表构造函数
		/// </summary>
		public Dictronary()
		{
		}

		/// <summary>
		/// 数据字典表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public Dictronary(DataRow dr)
		{
			if (null != dr["DICT_TYPE"])
			{
				_dictType = dr["DICT_TYPE"].ToString();
			}
			if (null != dr["DICT_CODE"])
			{
				_dictCode = dr["DICT_CODE"].ToString();
			}
			if (null != dr["DICT_NAME"])
			{
				_dictName = dr["DICT_NAME"].ToString();
			}
			if (null != dr["DICT_VALUE"])
			{
				_dictValue = dr["DICT_VALUE"].ToString();
			}
			if (null != dr["DICT_DESC"])
			{
				_dictDesc = dr["DICT_DESC"].ToString();
			}
		}

		#endregion 构造函数

	}
}
