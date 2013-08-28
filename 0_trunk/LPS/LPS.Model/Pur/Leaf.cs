using System;
using System.Data;

namespace LPS.Model.Pur
{
	// 添加 Jitlee 2013-08-29
	/// <summary>
	/// (t_pur_leaf)实体类
	/// 烟农和烟叶框的电子标签对应表，此表为流水线表
	/// </summary>
	public class Leaf : EntityObject
	{

		// 保存烟叶ID
		private string _leafId;

		/// <summary>
		/// 获取或设置烟叶ID
		/// </summary>
		public string LeafId
		{
			get
			{

				return _leafId;
			}
			set
			{
				_leafId = value;
				RaisePropertyChanged("LeafId");
			}
		}

		// 保存烟叶RFID
		private string _leafRfid;

		/// <summary>
		/// 获取或设置烟叶RFID
		/// </summary>
		public string LeafRfid
		{
			get
			{

				return _leafRfid;
			}
			set
			{
				_leafRfid = value;
				RaisePropertyChanged("LeafRfid");
			}
		}

		// 保存烟农ID
		private string _farmerId;

		/// <summary>
		/// 获取或设置烟农ID
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

		// 保存烟叶标签创建时间
		private DateTime _leafDate;

		/// <summary>
		/// 获取或设置烟叶标签创建时间
		/// </summary>
		public DateTime LeafDate
		{
			get
			{

				return _leafDate;
			}
			set
			{
				_leafDate = value;
				RaisePropertyChanged("LeafDate");
			}
		}

		// 保存烟叶等级
		private string _leafLevel;

		/// <summary>
		/// 获取或设置烟叶等级
		/// </summary>
		public string LeafLevel
		{
			get
			{

				return _leafLevel;
			}
			set
			{
				_leafLevel = value;
				RaisePropertyChanged("LeafLevel");
			}
		}

		// 保存烟叶等级确认时间
		private DateTime? _leafLevelDate;

		/// <summary>
		/// 获取或设置烟叶等级确认时间
		/// </summary>
		public DateTime? LeafLevelDate
		{
			get
			{

				return _leafLevelDate;
			}
			set
			{
				_leafLevelDate = value;
				RaisePropertyChanged("LeafLevelDate");
			}
		}

		// 保存烟叶等级确认员工
		private string _leafLevelEmpolyee;

		/// <summary>
		/// 获取或设置烟叶等级确认员工
		/// </summary>
		public string LeafLevelEmpolyee
		{
			get
			{

				return _leafLevelEmpolyee;
			}
			set
			{
				_leafLevelEmpolyee = value;
				RaisePropertyChanged("LeafLevelEmpolyee");
			}
		}

		// 保存烟叶重量
		private double? _leafWeight;

		/// <summary>
		/// 获取或设置烟叶重量
		/// </summary>
		public double? LeafWeight
		{
			get
			{

				return _leafWeight;
			}
			set
			{
				_leafWeight = value;
				RaisePropertyChanged("LeafWeight");
			}
		}

		// 保存烟叶过磅时间
		private DateTime? _leafWeightDate;

		/// <summary>
		/// 获取或设置烟叶过磅时间
		/// </summary>
		public DateTime? LeafWeightDate
		{
			get
			{

				return _leafWeightDate;
			}
			set
			{
				_leafWeightDate = value;
				RaisePropertyChanged("LeafWeightDate");
			}
		}

		// 保存烟叶过磅员
		private string _leafWeightEmpolyee;

		/// <summary>
		/// 获取或设置烟叶过磅员
		/// </summary>
		public string LeafWeightEmpolyee
		{
			get
			{

				return _leafWeightEmpolyee;
			}
			set
			{
				_leafWeightEmpolyee = value;
				RaisePropertyChanged("LeafWeightEmpolyee");
			}
		}

		// 保存烟叶状态
		private int _leafState;

		/// <summary>
		/// 获取或设置烟叶状态
		/// </summary>
		public int LeafState
		{
			get
			{

				return _leafState;
			}
			set
			{
				_leafState = value;
				RaisePropertyChanged("LeafState");
			}
		}

		// 保存烟叶是否删除
		private string _leafIsDeleted;

		/// <summary>
		/// 获取或设置烟叶是否删除
		/// </summary>
		public string LeafIsDeleted
		{
			get
			{

				return _leafIsDeleted;
			}
			set
			{
				_leafIsDeleted = value;
				RaisePropertyChanged("LeafIsDeleted");
			}
		}

		// 保存烟叶删除日期
		private DateTime? _leafDeletedDate;

		/// <summary>
		/// 获取或设置烟叶删除日期
		/// </summary>
		public DateTime? LeafDeletedDate
		{
			get
			{

				return _leafDeletedDate;
			}
			set
			{
				_leafDeletedDate = value;
				RaisePropertyChanged("LeafDeletedDate");
			}
		}

		#region 构造函数

		/// <summary>
		/// 烟农和烟叶框的电子标签对应表，此表为流水线表构造函数
		/// </summary>
		public Leaf()
		{
		}

		/// <summary>
		/// 烟农和烟叶框的电子标签对应表，此表为流水线表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public Leaf(DataRow dr)
		{
			if (null != dr["LEAF_ID"])
			{
				_leafId = dr["LEAF_ID"].ToString();
			}
			if (null != dr["LEAF_RFID"])
			{
				_leafRfid = dr["LEAF_RFID"].ToString();
			}
			if (null != dr["FARMER_ID"])
			{
				_farmerId = dr["FARMER_ID"].ToString();
			}
			if (null != dr["LEAF_DATE"])
			{
				_leafDate = Convert.ToDateTime(dr["LEAF_DATE"]);
			}
			if (null != dr["LEAF_LEVEL"])
			{
				_leafLevel = dr["LEAF_LEVEL"].ToString();
			}
			if (null != dr["LEAF_LEVEL_DATE"])
			{
				_leafLevelDate = Convert.ToDateTime(dr["LEAF_LEVEL_DATE"]);
			}
			if (null != dr["LEAF_LEVEL_EMPOLYEE"])
			{
				_leafLevelEmpolyee = dr["LEAF_LEVEL_EMPOLYEE"].ToString();
			}
			if (null != dr["LEAF_WEIGHT"])
			{
				_leafWeight = Convert.ToDouble(dr["LEAF_WEIGHT"]);
			}
			if (null != dr["LEAF_WEIGHT_DATE"])
			{
				_leafWeightDate = Convert.ToDateTime(dr["LEAF_WEIGHT_DATE"]);
			}
			if (null != dr["LEAF_WEIGHT_EMPOLYEE"])
			{
				_leafWeightEmpolyee = dr["LEAF_WEIGHT_EMPOLYEE"].ToString();
			}
			if (null != dr["LEAF_STATE"])
			{
				_leafState = Convert.ToInt32(dr["LEAF_STATE"]);
			}
			if (null != dr["LEAF_IS_DELETED"])
			{
				_leafIsDeleted = dr["LEAF_IS_DELETED"].ToString();
			}
			if (null != dr["LEAF_DELETED_DATE"])
			{
				_leafDeletedDate = Convert.ToDateTime(dr["LEAF_DELETED_DATE"]);
			}
		}

		#endregion 构造函数

	}
}
