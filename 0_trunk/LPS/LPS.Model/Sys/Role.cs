using System;
using System.Data;

namespace LPS.Model.Sys
{
	// 添加 Jitlee 2013-08-29
	/// <summary>
	/// (t_sys_role)实体类
	/// 用户角色表
	/// </summary>
	public class Role : EntityObject
	{

		// 保存角色ID
		private string _roleId;

		/// <summary>
		/// 获取或设置角色ID
		/// </summary>
		public string RoleId
		{
			get
			{

				return _roleId;
			}
			set
			{
				_roleId = value;
				RaisePropertyChanged("RoleId");
			}
		}

		// 保存角色名称
		private string _roleName;

		/// <summary>
		/// 获取或设置角色名称
		/// </summary>
		public string RoleName
		{
			get
			{

				return _roleName;
			}
			set
			{
				_roleName = value;
				RaisePropertyChanged("RoleName");
			}
		}

		// 保存角色描述
		private string _roleDesc;

		/// <summary>
		/// 获取或设置角色描述
		/// </summary>
		public string RoleDesc
		{
			get
			{

				return _roleDesc;
			}
			set
			{
				_roleDesc = value;
				RaisePropertyChanged("RoleDesc");
			}
		}

		#region 构造函数

		/// <summary>
		/// 用户角色表构造函数
		/// </summary>
		public Role()
		{
		}

		/// <summary>
		/// 用户角色表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public Role(DataRow dr)
		{
			if (null != dr["ROLE_ID"])
			{
				_roleId = dr["ROLE_ID"].ToString();
			}
			if (null != dr["ROLE_NAME"])
			{
				_roleName = dr["ROLE_NAME"].ToString();
			}
			if (null != dr["ROLE_DESC"])
			{
				_roleDesc = dr["ROLE_DESC"].ToString();
			}
		}

		#endregion 构造函数

	}
}
