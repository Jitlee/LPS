using System;
using System.Data;

namespace LPS.Model.Sys
{
	// 添加 Jitlee 2013-08-29
	/// <summary>
	/// (t_sys_permision)实体类
	/// 权限表
	/// </summary>
	public class Permision : EntityObject
	{

		// 保存权限编码
		private string _permCode;

		/// <summary>
		/// 获取或设置权限编码
		/// </summary>
		public string PermCode
		{
			get
			{

				return _permCode;
			}
			set
			{
				_permCode = value;
				RaisePropertyChanged("PermCode");
			}
		}

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

		// 保存权限名称
		private string _permName;

		/// <summary>
		/// 获取或设置权限名称
		/// </summary>
		public string PermName
		{
			get
			{

				return _permName;
			}
			set
			{
				_permName = value;
				RaisePropertyChanged("PermName");
			}
		}

		// 保存权限描述
		private string _permDesc;

		/// <summary>
		/// 获取或设置权限描述
		/// </summary>
		public string PermDesc
		{
			get
			{

				return _permDesc;
			}
			set
			{
				_permDesc = value;
				RaisePropertyChanged("PermDesc");
			}
		}

		// 保存PERM_SORT
		private int _permSort;

		/// <summary>
		/// 获取或设置PERM_SORT
		/// </summary>
		public int PermSort
		{
			get
			{

				return _permSort;
			}
			set
			{
				_permSort = value;
				RaisePropertyChanged("PermSort");
			}
		}

		// 保存权限是否可用
		private string _permIsEnabled;

		/// <summary>
		/// 获取或设置权限是否可用
		/// </summary>
		public string PermIsEnabled
		{
			get
			{

				return _permIsEnabled;
			}
			set
			{
				_permIsEnabled = value;
				RaisePropertyChanged("PermIsEnabled");
			}
		}

		// 保存是否为系统默认权限(系统默认权限在重建模块列表时会被删除)
		private string _permIsDefault;

		/// <summary>
		/// 获取或设置是否为系统默认权限(系统默认权限在重建模块列表时会被删除)
		/// </summary>
		public string PermIsDefault
		{
			get
			{

				return _permIsDefault;
			}
			set
			{
				_permIsDefault = value;
				RaisePropertyChanged("PermIsDefault");
			}
		}

		#region 构造函数

		/// <summary>
		/// 权限表构造函数
		/// </summary>
		public Permision()
		{
		}

		/// <summary>
		/// 权限表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public Permision(DataRow dr)
		{
			if (null != dr["PERM_CODE"])
			{
				_permCode = dr["PERM_CODE"].ToString();
			}
			if (null != dr["FUNC_CODE"])
			{
				_funcCode = dr["FUNC_CODE"].ToString();
			}
			if (null != dr["PERM_NAME"])
			{
				_permName = dr["PERM_NAME"].ToString();
			}
			if (null != dr["PERM_DESC"])
			{
				_permDesc = dr["PERM_DESC"].ToString();
			}
			if (null != dr["PERM_SORT"])
			{
				_permSort = Convert.ToInt32(dr["PERM_SORT"]);
			}
			if (null != dr["PERM_IS_ENABLED"])
			{
				_permIsEnabled = dr["PERM_IS_ENABLED"].ToString();
			}
			if (null != dr["PERM_IS_DEFAULT"])
			{
				_permIsDefault = dr["PERM_IS_DEFAULT"].ToString();
			}
		}

		#endregion 构造函数

	}
}
