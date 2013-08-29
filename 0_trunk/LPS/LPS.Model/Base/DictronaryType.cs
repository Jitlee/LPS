using System;
using System.Data;

namespace LPS.Model.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_dictronary_type)实体类
	/// 数据字典类型表
	/// </summary>
	public class DictronaryType : EntityObject
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

		// 保存字典类型名称
		private string _dictTypeName;

		/// <summary>
		/// 获取或设置字典类型名称
		/// </summary>
		public string DictTypeName
		{
			get
			{

				return _dictTypeName;
			}
			set
			{
				_dictTypeName = value;
				RaisePropertyChanged("DictTypeName");
			}
		}

		// 保存字典类型描述
		private string _dictTypeDesc;

		/// <summary>
		/// 获取或设置字典类型描述
		/// </summary>
		public string DictTypeDesc
		{
			get
			{

				return _dictTypeDesc;
			}
			set
			{
				_dictTypeDesc = value;
				RaisePropertyChanged("DictTypeDesc");
			}
		}

		#region 构造函数

		/// <summary>
		/// 数据字典类型表构造函数
		/// </summary>
		public DictronaryType()
		{
		}

		/// <summary>
		/// 数据字典类型表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public DictronaryType(IDataReader dr)
		{
			if (DBNull.Value != dr["DICT_TYPE"])
			{
				_dictType = dr["DICT_TYPE"].ToString();
			}
			if (DBNull.Value != dr["DICT_TYPE_NAME"])
			{
				_dictTypeName = dr["DICT_TYPE_NAME"].ToString();
			}
			if (DBNull.Value != dr["DICT_TYPE_DESC"])
			{
				_dictTypeDesc = dr["DICT_TYPE_DESC"].ToString();
			}
		}

		#endregion 构造函数

	}
}
