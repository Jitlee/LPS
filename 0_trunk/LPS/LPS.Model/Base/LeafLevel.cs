using System;
using System.Data;

namespace LPS.Model.Base
{
	// 添加 Jitlee 2013-08-29
	/// <summary>
	/// (t_base_leaf_level)实体类
	/// 烟叶等级表
	/// </summary>
	public class LeafLevel : EntityObject
	{

		// 保存烟叶等级
		private string _leafLevel;

		/// <summary>
		/// 获取或设置烟叶等级
		/// </summary>
		public string Level
		{
			get
			{

				return _leafLevel;
			}
			set
			{
				_leafLevel = value;
				RaisePropertyChanged("Level");
			}
		}

		// 保存烟叶等级名称
		private string _leafLevelName;

		/// <summary>
		/// 获取或设置烟叶等级名称
		/// </summary>
		public string LeafLevelName
		{
			get
			{

				return _leafLevelName;
			}
			set
			{
				_leafLevelName = value;
				RaisePropertyChanged("LeafLevelName");
			}
		}

		// 保存烟叶等级描述
		private string _leafLevelDesc;

		/// <summary>
		/// 获取或设置烟叶等级描述
		/// </summary>
		public string LeafLevelDesc
		{
			get
			{

				return _leafLevelDesc;
			}
			set
			{
				_leafLevelDesc = value;
				RaisePropertyChanged("LeafLevelDesc");
			}
		}

		// 保存烟叶等级价格
		private double? _leafLevelPrice;

		/// <summary>
		/// 获取或设置烟叶等级价格
		/// </summary>
		public double? LeafLevelPrice
		{
			get
			{

				return _leafLevelPrice;
			}
			set
			{
				_leafLevelPrice = value;
				RaisePropertyChanged("LeafLevelPrice");
			}
		}

		// 保存烟叶等级排序
		private int _leafLevelSort;

		/// <summary>
		/// 获取或设置烟叶等级排序
		/// </summary>
		public int LeafLevelSort
		{
			get
			{

				return _leafLevelSort;
			}
			set
			{
				_leafLevelSort = value;
				RaisePropertyChanged("LeafLevelSort");
			}
		}

		// 保存烟叶等级是否删除
		private string _leafLevelIsDeleted;

		/// <summary>
		/// 获取或设置烟叶等级是否删除
		/// </summary>
		public string LeafLevelIsDeleted
		{
			get
			{

				return _leafLevelIsDeleted;
			}
			set
			{
				_leafLevelIsDeleted = value;
				RaisePropertyChanged("LeafLevelIsDeleted");
			}
		}

		// 保存烟叶等级删除日期
		private DateTime? _leafLevelDeletedDate;

		/// <summary>
		/// 获取或设置烟叶等级删除日期
		/// </summary>
		public DateTime? LeafLevelDeletedDate
		{
			get
			{

				return _leafLevelDeletedDate;
			}
			set
			{
				_leafLevelDeletedDate = value;
				RaisePropertyChanged("LeafLevelDeletedDate");
			}
		}

		#region 构造函数

		/// <summary>
		/// 烟叶等级表构造函数
		/// </summary>
		public LeafLevel()
		{
		}

		/// <summary>
		/// 烟叶等级表构造函数
		/// </summary>
		/// <param name="dr">数据行</param>
		public LeafLevel(DataRow dr)
		{
			if (null != dr["LEAF_LEVEL"])
			{
				_leafLevel = dr["LEAF_LEVEL"].ToString();
			}
			if (null != dr["LEAF_LEVEL_NAME"])
			{
				_leafLevelName = dr["LEAF_LEVEL_NAME"].ToString();
			}
			if (null != dr["LEAF_LEVEL_DESC"])
			{
				_leafLevelDesc = dr["LEAF_LEVEL_DESC"].ToString();
			}
			if (null != dr["LEAF_LEVEL_PRICE"])
			{
				_leafLevelPrice = Convert.ToDouble(dr["LEAF_LEVEL_PRICE"]);
			}
			if (null != dr["LEAF_LEVEL_SORT"])
			{
				_leafLevelSort = Convert.ToInt32(dr["LEAF_LEVEL_SORT"]);
			}
			if (null != dr["LEAF_LEVEL_IS_DELETED"])
			{
				_leafLevelIsDeleted = dr["LEAF_LEVEL_IS_DELETED"].ToString();
			}
			if (null != dr["LEAF_LEVEL_DELETED_DATE"])
			{
				_leafLevelDeletedDate = Convert.ToDateTime(dr["LEAF_LEVEL_DELETED_DATE"]);
			}
		}

		#endregion 构造函数

	}
}
