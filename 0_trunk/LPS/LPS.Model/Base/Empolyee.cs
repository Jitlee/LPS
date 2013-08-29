using System;
using System.Data;

namespace LPS.Model.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_empolyee)实体类
	/// 员工表
	/// </summary>
	public class Empolyee : EntityObject
	{

		// 保存
		private string _empolyeeId;

		/// <summary>
		/// 获取或设置
		/// </summary>
		public string EmpolyeeId
		{
			get
			{

				return _empolyeeId;
			}
			set
			{
				_empolyeeId = value;
				RaisePropertyChanged("EmpolyeeId");
			}
		}

		// 保存员工编号
		private string _empolyeeCode;

		/// <summary>
		/// 获取或设置员工编号
		/// </summary>
		public string EmpolyeeCode
		{
			get
			{

				return _empolyeeCode;
			}
			set
			{
				_empolyeeCode = value;
				RaisePropertyChanged("EmpolyeeCode");
			}
		}

		// 保存员工RFID
		private string _empolyeeRfid;

		/// <summary>
		/// 获取或设置员工RFID
		/// </summary>
		public string EmpolyeeRfid
		{
			get
			{

				return _empolyeeRfid;
			}
			set
			{
				_empolyeeRfid = value;
				RaisePropertyChanged("EmpolyeeRfid");
			}
		}

		// 保存员工名称
		private string _empolyeeName;

		/// <summary>
		/// 获取或设置员工名称
		/// </summary>
		public string EmpolyeeName
		{
			get
			{

				return _empolyeeName;
			}
			set
			{
				_empolyeeName = value;
				RaisePropertyChanged("EmpolyeeName");
			}
		}

		// 保存员工拼音缩写
		private string _empolyeePy;

		/// <summary>
		/// 获取或设置员工拼音缩写
		/// </summary>
		public string EmpolyeePy
		{
			get
			{

				return _empolyeePy;
			}
			set
			{
				_empolyeePy = value;
				RaisePropertyChanged("EmpolyeePy");
			}
		}

		// 保存员工性别(‘男’,’女’)
		private string _empolyeeSex;

		/// <summary>
		/// 获取或设置员工性别(‘男’,’女’)
		/// </summary>
		public string EmpolyeeSex
		{
			get
			{

				return _empolyeeSex;
			}
			set
			{
				_empolyeeSex = value;
				RaisePropertyChanged("EmpolyeeSex");
			}
		}

		// 保存员工出生日期
		private DateTime? _empolyeeBirth;

		/// <summary>
		/// 获取或设置员工出生日期
		/// </summary>
		public DateTime? EmpolyeeBirth
		{
			get
			{

				return _empolyeeBirth;
			}
			set
			{
				_empolyeeBirth = value;
				RaisePropertyChanged("EmpolyeeBirth");
			}
		}

		// 保存员工入职日期
		private DateTime? _empolyeeEntryDate;

		/// <summary>
		/// 获取或设置员工入职日期
		/// </summary>
		public DateTime? EmpolyeeEntryDate
		{
			get
			{

				return _empolyeeEntryDate;
			}
			set
			{
				_empolyeeEntryDate = value;
				RaisePropertyChanged("EmpolyeeEntryDate");
			}
		}

		// 保存员工手机号
		private string _empolyeePhone;

		/// <summary>
		/// 获取或设置员工手机号
		/// </summary>
		public string EmpolyeePhone
		{
			get
			{

				return _empolyeePhone;
			}
			set
			{
				_empolyeePhone = value;
				RaisePropertyChanged("EmpolyeePhone");
			}
		}

		// 保存员工电子邮箱
		private string _empolyeeEmail;

		/// <summary>
		/// 获取或设置员工电子邮箱
		/// </summary>
		public string EmpolyeeEmail
		{
			get
			{

				return _empolyeeEmail;
			}
			set
			{
				_empolyeeEmail = value;
				RaisePropertyChanged("EmpolyeeEmail");
			}
		}

		// 保存员工联系地址
		private string _empolyeeAddress;

		/// <summary>
		/// 获取或设置员工联系地址
		/// </summary>
		public string EmpolyeeAddress
		{
			get
			{

				return _empolyeeAddress;
			}
			set
			{
				_empolyeeAddress = value;
				RaisePropertyChanged("EmpolyeeAddress");
			}
		}

		// 保存员工籍贯
		private string _empolyeeHometown;

		/// <summary>
		/// 获取或设置员工籍贯
		/// </summary>
		public string EmpolyeeHometown
		{
			get
			{

				return _empolyeeHometown;
			}
			set
			{
				_empolyeeHometown = value;
				RaisePropertyChanged("EmpolyeeHometown");
			}
		}

		// 保存员工身份证号
		private string _empolyeeCardId;

		/// <summary>
		/// 获取或设置员工身份证号
		/// </summary>
		public string EmpolyeeCardId
		{
			get
			{

				return _empolyeeCardId;
			}
			set
			{
				_empolyeeCardId = value;
				RaisePropertyChanged("EmpolyeeCardId");
			}
		}

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

		// 保存用户密码
		private string _userPwd;

		/// <summary>
		/// 获取或设置用户密码
		/// </summary>
		public string UserPwd
		{
			get
			{

				return _userPwd;
			}
			set
			{
				_userPwd = value;
				RaisePropertyChanged("UserPwd");
			}
		}

		// 保存员工创建日期
		private DateTime _empolyeeCreateDate;

		/// <summary>
		/// 获取或设置员工创建日期
		/// </summary>
		public DateTime EmpolyeeCreateDate
		{
			get
			{

				return _empolyeeCreateDate;
			}
			set
			{
				_empolyeeCreateDate = value;
				RaisePropertyChanged("EmpolyeeCreateDate");
			}
		}

		// 保存表示已删除
		private string _empolyeeIsDeleted;

		/// <summary>
		/// 获取或设置表示已删除
		/// </summary>
		public string EmpolyeeIsDeleted
		{
			get
			{

				return _empolyeeIsDeleted;
			}
			set
			{
				_empolyeeIsDeleted = value;
				RaisePropertyChanged("EmpolyeeIsDeleted");
			}
		}

		// 保存员工删除日期
		private DateTime? _empolyeeDeletedDate;

		/// <summary>
		/// 获取或设置员工删除日期
		/// </summary>
		public DateTime? EmpolyeeDeletedDate
		{
			get
			{

				return _empolyeeDeletedDate;
			}
			set
			{
				_empolyeeDeletedDate = value;
				RaisePropertyChanged("EmpolyeeDeletedDate");
			}
		}

		#region 构造函数

		/// <summary>
		/// 员工表构造函数
		/// </summary>
		public Empolyee()
		{
		}

		/// <summary>
		/// 员工表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public Empolyee(IDataReader dr)
		{
			if (DBNull.Value != dr["EMPOLYEE_ID"])
			{
				_empolyeeId = dr["EMPOLYEE_ID"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_CODE"])
			{
				_empolyeeCode = dr["EMPOLYEE_CODE"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_RFID"])
			{
				_empolyeeRfid = dr["EMPOLYEE_RFID"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_NAME"])
			{
				_empolyeeName = dr["EMPOLYEE_NAME"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_PY"])
			{
				_empolyeePy = dr["EMPOLYEE_PY"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_SEX"])
			{
				_empolyeeSex = dr["EMPOLYEE_SEX"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_BIRTH"])
			{
				_empolyeeBirth = Convert.ToDateTime(dr["EMPOLYEE_BIRTH"]);
			}
			if (DBNull.Value != dr["EMPOLYEE_ENTRY_DATE"])
			{
				_empolyeeEntryDate = Convert.ToDateTime(dr["EMPOLYEE_ENTRY_DATE"]);
			}
			if (DBNull.Value != dr["EMPOLYEE_PHONE"])
			{
				_empolyeePhone = dr["EMPOLYEE_PHONE"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_EMAIL"])
			{
				_empolyeeEmail = dr["EMPOLYEE_EMAIL"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_ADDRESS"])
			{
				_empolyeeAddress = dr["EMPOLYEE_ADDRESS"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_HOMETOWN"])
			{
				_empolyeeHometown = dr["EMPOLYEE_HOMETOWN"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_CARD_ID"])
			{
				_empolyeeCardId = dr["EMPOLYEE_CARD_ID"].ToString();
			}
			if (DBNull.Value != dr["USER_ID"])
			{
				_userId = dr["USER_ID"].ToString();
			}
			if (DBNull.Value != dr["USER_PWD"])
			{
				_userPwd = dr["USER_PWD"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_CREATE_DATE"])
			{
				_empolyeeCreateDate = Convert.ToDateTime(dr["EMPOLYEE_CREATE_DATE"]);
			}
			if (DBNull.Value != dr["EMPOLYEE_IS_DELETED"])
			{
				_empolyeeIsDeleted = dr["EMPOLYEE_IS_DELETED"].ToString();
			}
			if (DBNull.Value != dr["EMPOLYEE_DELETED_DATE"])
			{
				_empolyeeDeletedDate = Convert.ToDateTime(dr["EMPOLYEE_DELETED_DATE"]);
			}
		}

		#endregion 构造函数

	}
}
