using LPS.Model.Base;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_leaf_level)实体类
	/// 烟叶等级表
	/// by zcs 120904: 应该去掉，LEAF_LEVEL_IS_DELETED,LEAF_LEVEL_DELETED_DATE 因类它采用的是Code 可以找到。
	/// </summary>
	public abstract class LeafLevelDALBase : DALBase
	{
		/// <summary>
		/// 根据 Level 获取烟叶等级对象
		/// </summary>
		/// <param name="leafLevel">烟叶等级</param>
		/// <returns>返回烟叶等级对象</returns>
		public virtual LeafLevel Get(string leafLevel)
		{
			return db.ExecuteGet<LeafLevel>("SELECT LEAF_LEVEL, LEAF_LEVEL_NAME, LEAF_LEVEL_DESC, LEAF_LEVEL_PRICE, LEAF_LEVEL_SORT, LEAF_LEVEL_IS_DELETED, LEAF_LEVEL_DELETED_DATEFROM T_BASE_LEAF_LEVEL WHERE LEAF_LEVEL = @LEAF_LEVEL",
				(dr) => { return new LeafLevel(dr); },
				db.GetDataParameter("@LEAF_LEVEL", leafLevel));
		}

		/// <summary>
		/// 查询烟叶等级表的所有对象列表
		/// </summary>
		/// <returns>返回烟叶等级对象列表</returns>
		public virtual ObservableCollection<LeafLevel> Query()
		{
			return db.ExecuteQuery<LeafLevel>("SELECT LEAF_LEVEL, LEAF_LEVEL_NAME, LEAF_LEVEL_DESC, LEAF_LEVEL_PRICE, LEAF_LEVEL_SORT, LEAF_LEVEL_IS_DELETED, LEAF_LEVEL_DELETED_DATE FROM T_BASE_LEAF_LEVEL ",
				(dr) => { return new LeafLevel(dr); });
		}

		/// <summary>
		/// 新增一条烟叶等级记录
		/// </summary>
		/// <param name="leaflevel">System.String[]<param>
		/// <returns>返回烟叶等级受影响的行数</returns>
		public virtual int Add(LeafLevel leaflevel)
		{
			return db.ExecuteNoQuery(@"INSERT INTO T_BASE_LEAF_LEVEL (LEAF_LEVEL, LEAF_LEVEL_NAME, LEAF_LEVEL_DESC, LEAF_LEVEL_PRICE, LEAF_LEVEL_SORT,LEAF_LEVEL_IS_DELETED) 
VALUES (@LEAF_LEVEL, @LEAF_LEVEL_NAME, @LEAF_LEVEL_DESC, @LEAF_LEVEL_PRICE, @LEAF_LEVEL_SORT, 'N')", 
				db.GetDataParameter("@LEAF_LEVEL", leaflevel.Level),
				db.GetDataParameter("@LEAF_LEVEL_NAME", leaflevel.LeafLevelName),
				db.GetDataParameter("@LEAF_LEVEL_DESC", leaflevel.LeafLevelDesc),
				db.GetDataParameter("@LEAF_LEVEL_PRICE", leaflevel.LeafLevelPrice),
				db.GetDataParameter("@LEAF_LEVEL_SORT", leaflevel.LeafLevelSort)
				//db.GetDataParameter("@LEAF_LEVEL_IS_DELETED", leaflevel.LeafLevelIsDeleted),
				//db.GetDataParameter("@LEAF_LEVEL_DELETED_DATE", leaflevel.LeafLevelDeletedDate)
				);
		}
		/// <summary>
		/// 根据 Level 更新烟叶等级表记录
		/// </summary>
		/// <returns>返回烟叶等级受影响的行数</returns>
		public virtual int Update(LeafLevel leaflevel)
		{
			return db.ExecuteNoQuery(@"UPDATE T_BASE_LEAF_LEVEL SET LEAF_LEVEL_NAME = @LEAF_LEVEL_NAME, LEAF_LEVEL_DESC = @LEAF_LEVEL_DESC, 
LEAF_LEVEL_PRICE = @LEAF_LEVEL_PRICE, LEAF_LEVEL_SORT = @LEAF_LEVEL_SORT WHERE LEAF_LEVEL = @LEAF_LEVEL", 
				db.GetDataParameter("@LEAF_LEVEL", leaflevel.Level),
				db.GetDataParameter("@LEAF_LEVEL_NAME", leaflevel.LeafLevelName),
				db.GetDataParameter("@LEAF_LEVEL_DESC", leaflevel.LeafLevelDesc),
				db.GetDataParameter("@LEAF_LEVEL_PRICE", leaflevel.LeafLevelPrice),
				db.GetDataParameter("@LEAF_LEVEL_SORT", leaflevel.LeafLevelSort)
				//db.GetDataParameter("@LEAF_LEVEL_IS_DELETED", leaflevel.LeafLevelIsDeleted),
				//db.GetDataParameter("@LEAF_LEVEL_DELETED_DATE", leaflevel.LeafLevelDeletedDate)
				);
		}

		/// <summary>
		/// 根据 Level 删除烟叶等级表记录
		/// </summary>
		/// <param name="leafLevel">烟叶等级</param>
		/// <returns>返回烟叶等级受影响的行数</returns>
		public virtual int Delete(string leafLevel)
		{
			return db.ExecuteNoQuery("DELETE FROM T_BASE_LEAF_LEVEL WHERE LEAF_LEVEL = @LEAF_LEVEL", 
				db.GetDataParameter("@LEAF_LEVEL", leafLevel));
		}
	}
}
