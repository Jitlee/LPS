using System;
using System.Data;

namespace LPS.Model.Sys
{
	// 添加 Jitlee 2013-08-29
	/// <summary>
	/// (t_sys_user_permision)实体类
	/// </summary>
	public class UserPermision : EntityObject
	{

		// 保存用户ID
		private string _userId;

		/// <summary>
		/// 获取或设置用户ID
		/// </summary>
		public string UserId
		{
			get
			{

				return _userId;
			}
			set
			{
				_userId = value;
				RaisePropertyChanged("UserId");
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
		/// 构造函数
		/// </summary>
		public UserPermision()
		{
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public UserPermision(DataRow dr)
		{
			if (null != dr["USER_ID"])
			{
				_userId = dr["USER_ID"].ToString();
			}
			if (null != dr["PERM_CODE"])
			{
				_permCode = dr["PERM_CODE"].ToString();
			}
		}

		#endregion 构造函数

	}
}
