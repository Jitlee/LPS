using System;
using System.Data;

namespace LPS.Model.Sys
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_sys_role_permision)实体类
	/// 角色权限表
	/// </summary>
	public class RolePermision : EntityObject
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

		#region 构造函数

		/// <summary>
		/// 角色权限表构造函数
		/// </summary>
		public RolePermision()
		{
		}

		/// <summary>
		/// 角色权限表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public RolePermision(IDataReader dr)
		{
			if (DBNull.Value != dr["ROLE_ID"])
			{
				_roleId = dr["ROLE_ID"].ToString();
			}
			if (DBNull.Value != dr["PERM_CODE"])
			{
				_permCode = dr["PERM_CODE"].ToString();
			}
		}

		#endregion 构造函数

	}
}
