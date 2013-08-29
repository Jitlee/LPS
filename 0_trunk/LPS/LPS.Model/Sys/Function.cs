using System;
using System.Data;

namespace LPS.Model.Sys
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_sys_function)实体类
	/// 系统功能表
	/// </summary>
	public class Function : EntityObject
	{

		// 保存模块URL
		private string _funcCode;

		/// <summary>
		/// 获取或设置模块URL
		/// </summary>
		public string FuncCode
		{
			get
			{

				return _funcCode;
			}
			set
			{
				_funcCode = value;
				RaisePropertyChanged("FuncCode");
			}
		}

		// 保存模块名称
		private string _funcName;

		/// <summary>
		/// 获取或设置模块名称
		/// </summary>
		public string FuncName
		{
			get
			{

				return _funcName;
			}
			set
			{
				_funcName = value;
				RaisePropertyChanged("FuncName");
			}
		}

		// 保存父模块URL
		private string _funcParentCode;

		/// <summary>
		/// 获取或设置父模块URL
		/// </summary>
		public string FuncParentCode
		{
			get
			{

				return _funcParentCode;
			}
			set
			{
				_funcParentCode = value;
				RaisePropertyChanged("FuncParentCode");
			}
		}

		// 保存排序
		private int _funcSort;

		/// <summary>
		/// 获取或设置排序
		/// </summary>
		public int FuncSort
		{
			get
			{

				return _funcSort;
			}
			set
			{
				_funcSort = value;
				RaisePropertyChanged("FuncSort");
			}
		}

		// 保存MOD_LEVEL
		private int? _funcLevel;

		/// <summary>
		/// 获取或设置MOD_LEVEL
		/// </summary>
		public int? FuncLevel
		{
			get
			{

				return _funcLevel;
			}
			set
			{
				_funcLevel = value;
				RaisePropertyChanged("FuncLevel");
			}
		}

		// 保存
		private string _funcDesc;

		/// <summary>
		/// 获取或设置
		/// </summary>
		public string FuncDesc
		{
			get
			{

				return _funcDesc;
			}
			set
			{
				_funcDesc = value;
				RaisePropertyChanged("FuncDesc");
			}
		}

		// 保存是否可用(Y:可用,N:不可用)
		private string _funcIsEnabled;

		/// <summary>
		/// 获取或设置是否可用(Y:可用,N:不可用)
		/// </summary>
		public string FuncIsEnabled
		{
			get
			{

				return _funcIsEnabled;
			}
			set
			{
				_funcIsEnabled = value;
				RaisePropertyChanged("FuncIsEnabled");
			}
		}

		#region 构造函数

		/// <summary>
		/// 系统功能表构造函数
		/// </summary>
		public Function()
		{
		}

		/// <summary>
		/// 系统功能表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public Function(IDataReader dr)
		{
			if (DBNull.Value != dr["FUNC_CODE"])
			{
				_funcCode = dr["FUNC_CODE"].ToString();
			}
			if (DBNull.Value != dr["FUNC_NAME"])
			{
				_funcName = dr["FUNC_NAME"].ToString();
			}
			if (DBNull.Value != dr["FUNC_PARENT_CODE"])
			{
				_funcParentCode = dr["FUNC_PARENT_CODE"].ToString();
			}
			if (DBNull.Value != dr["FUNC_SORT"])
			{
				_funcSort = Convert.ToInt32(dr["FUNC_SORT"]);
			}
			if (DBNull.Value != dr["FUNC_LEVEL"])
			{
				_funcLevel = Convert.ToInt32(dr["FUNC_LEVEL"]);
			}
			if (DBNull.Value != dr["FUNC_DESC"])
			{
				_funcDesc = dr["FUNC_DESC"].ToString();
			}
			if (DBNull.Value != dr["FUNC_IS_ENABLED"])
			{
				_funcIsEnabled = dr["FUNC_IS_ENABLED"].ToString();
			}
		}

		#endregion 构造函数

	}
}
