using System;
using System.Data;

namespace LPS.Model.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_farmer)实体类
	/// 烟农表
	/// </summary>
	public class Farmer : EntityObject
	{

		// 保存烟农唯一标识
		private string _farmerId;

		/// <summary>
		/// 获取或设置烟农唯一标识
		/// </summary>
		public string FarmerId
		{
			get
			{

				return _farmerId;
			}
			set
			{
				_farmerId = value;
				RaisePropertyChanged("FarmerId");
			}
		}

		// 保存烟农编码
		private string _farmarCode;

		/// <summary>
		/// 获取或设置烟农编码
		/// </summary>
		public string FarmarCode
		{
			get
			{

				return _farmarCode;
			}
			set
			{
				_farmarCode = value;
				RaisePropertyChanged("FarmarCode");
			}
		}

		// 保存烟农RFID标识
		private string _farmerRfid;

		/// <summary>
		/// 获取或设置烟农RFID标识
		/// </summary>
		public string FarmerRfid
		{
			get
			{

				return _farmerRfid;
			}
			set
			{
				_farmerRfid = value;
				RaisePropertyChanged("FarmerRfid");
			}
		}

		// 保存烟农名称
		private string _farmerName;

		/// <summary>
		/// 获取或设置烟农名称
		/// </summary>
		public string FarmerName
		{
			get
			{

				return _farmerName;
			}
			set
			{
				_farmerName = value;
				RaisePropertyChanged("FarmerName");
			}
		}

		// 保存烟农拼音缩写
		private string _farmerPy;

		/// <summary>
		/// 获取或设置烟农拼音缩写
		/// </summary>
		public string FarmerPy
		{
			get
			{

				return _farmerPy;
			}
			set
			{
				_farmerPy = value;
				RaisePropertyChanged("FarmerPy");
			}
		}

		// 保存烟农电话
		private string _farmerPhone;

		/// <summary>
		/// 获取或设置烟农电话
		/// </summary>
		public string FarmerPhone
		{
			get
			{

				return _farmerPhone;
			}
			set
			{
				_farmerPhone = value;
				RaisePropertyChanged("FarmerPhone");
			}
		}

		// 保存烟农电子邮箱
		private string _farmerEmail;

		/// <summary>
		/// 获取或设置烟农电子邮箱
		/// </summary>
		public string FarmerEmail
		{
			get
			{

				return _farmerEmail;
			}
			set
			{
				_farmerEmail = value;
				RaisePropertyChanged("FarmerEmail");
			}
		}

		// 保存烟农地址
		private string _farmerAddress;

		/// <summary>
		/// 获取或设置烟农地址
		/// </summary>
		public string FarmerAddress
		{
			get
			{

				return _farmerAddress;
			}
			set
			{
				_farmerAddress = value;
				RaisePropertyChanged("FarmerAddress");
			}
		}

		// 保存烟农备注
		private string _farmerRmark;

		/// <summary>
		/// 获取或设置烟农备注
		/// </summary>
		public string FarmerRmark
		{
			get
			{

				return _farmerRmark;
			}
			set
			{
				_farmerRmark = value;
				RaisePropertyChanged("FarmerRmark");
			}
		}

		// 保存
		private string _farmerSex;

		/// <summary>
		/// 获取或设置
		/// </summary>
		public string FarmerSex
		{
			get
			{

				return _farmerSex;
			}
			set
			{
				_farmerSex = value;
				RaisePropertyChanged("FarmerSex");
			}
		}

		// 保存烟农出生日期
		private DateTime? _farmerBirth;

		/// <summary>
		/// 获取或设置烟农出生日期
		/// </summary>
		public DateTime? FarmerBirth
		{
			get
			{

				return _farmerBirth;
			}
			set
			{
				_farmerBirth = value;
				RaisePropertyChanged("FarmerBirth");
			}
		}

		// 保存
		private string _farmerCardId;

		/// <summary>
		/// 获取或设置
		/// </summary>
		public string FarmerCardId
		{
			get
			{

				return _farmerCardId;
			}
			set
			{
				_farmerCardId = value;
				RaisePropertyChanged("FarmerCardId");
			}
		}

		// 保存
		private DateTime? _farmerCreateDate;

		/// <summary>
		/// 获取或设置
		/// </summary>
		public DateTime? FarmerCreateDate
		{
			get
			{

				return _farmerCreateDate;
			}
			set
			{
				_farmerCreateDate = value;
				RaisePropertyChanged("FarmerCreateDate");
			}
		}

		// 保存表示已删除
		private string _farmerIsDeleted;

		/// <summary>
		/// 获取或设置表示已删除
		/// </summary>
		public string FarmerIsDeleted
		{
			get
			{

				return _farmerIsDeleted;
			}
			set
			{
				_farmerIsDeleted = value;
				RaisePropertyChanged("FarmerIsDeleted");
			}
		}

		// 保存
		private DateTime? _farmerDeletedDate;

		/// <summary>
		/// 获取或设置
		/// </summary>
		public DateTime? FarmerDeletedDate
		{
			get
			{

				return _farmerDeletedDate;
			}
			set
			{
				_farmerDeletedDate = value;
				RaisePropertyChanged("FarmerDeletedDate");
			}
		}

		#region 构造函数

		/// <summary>
		/// 烟农表构造函数
		/// </summary>
		public Farmer()
		{
		}

		/// <summary>
		/// 烟农表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public Farmer(IDataReader dr)
		{
			if (DBNull.Value != dr["FARMER_ID"])
			{
				_farmerId = dr["FARMER_ID"].ToString();
			}
			if (DBNull.Value != dr["FARMAR_CODE"])
			{
				_farmarCode = dr["FARMAR_CODE"].ToString();
			}
			if (DBNull.Value != dr["FARMER_RFID"])
			{
				_farmerRfid = dr["FARMER_RFID"].ToString();
			}
			if (DBNull.Value != dr["FARMER_NAME"])
			{
				_farmerName = dr["FARMER_NAME"].ToString();
			}
			if (DBNull.Value != dr["FARMER_PY"])
			{
				_farmerPy = dr["FARMER_PY"].ToString();
			}
			if (DBNull.Value != dr["FARMER_PHONE"])
			{
				_farmerPhone = dr["FARMER_PHONE"].ToString();
			}
			if (DBNull.Value != dr["FARMER_EMAIL"])
			{
				_farmerEmail = dr["FARMER_EMAIL"].ToString();
			}
			if (DBNull.Value != dr["FARMER_ADDRESS"])
			{
				_farmerAddress = dr["FARMER_ADDRESS"].ToString();
			}
			if (DBNull.Value != dr["FARMER_RMARK"])
			{
				_farmerRmark = dr["FARMER_RMARK"].ToString();
			}
			if (DBNull.Value != dr["FARMER_SEX"])
			{
				_farmerSex = dr["FARMER_SEX"].ToString();
			}
			if (DBNull.Value != dr["FARMER_BIRTH"])
			{
				_farmerBirth = Convert.ToDateTime(dr["FARMER_BIRTH"]);
			}
			if (DBNull.Value != dr["FARMER_CARD_ID"])
			{
				_farmerCardId = dr["FARMER_CARD_ID"].ToString();
			}
			if (DBNull.Value != dr["FARMER_CREATE_DATE"])
			{
				_farmerCreateDate = Convert.ToDateTime(dr["FARMER_CREATE_DATE"]);
			}
			if (DBNull.Value != dr["FARMER_IS_DELETED"])
			{
				_farmerIsDeleted = dr["FARMER_IS_DELETED"].ToString();
			}
			if (DBNull.Value != dr["FARMER_DELETED_DATE"])
			{
				_farmerDeletedDate = Convert.ToDateTime(dr["FARMER_DELETED_DATE"]);
			}
		}

		#endregion 构造函数

	}
}
