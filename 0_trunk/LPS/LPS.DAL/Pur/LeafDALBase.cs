using LPS.Model.Pur;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Pur
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_pur_leaf)实体类
	/// 烟农和烟叶框的电子标签对应表，此表为流水线表
	/// </summary>
	public abstract class LeafDALBase : DALBase
	{
		/// <summary>
		/// 根据 LeafId 获取烟农和烟叶框的电子标签对应表，此表为流水线对象
		/// </summary>
		/// <param name="leafId">烟叶ID</param>
		/// <returns>返回烟农和烟叶框的电子标签对应表，此表为流水线对象</returns>
		public virtual Leaf Get(string leafId)
		{
			return db.ExecuteGet<Leaf>("SELECT LEAF_ID, LEAF_RFID, FARMER_ID, LEAF_DATE, LEAF_LEVEL, LEAF_LEVEL_DATE, LEAF_LEVEL_EMPOLYEE, LEAF_WEIGHT, LEAF_WEIGHT_DATE, LEAF_WEIGHT_EMPOLYEE, LEAF_STATE, LEAF_IS_DELETED, LEAF_DELETED_DATEFROM T_PUR_LEAF WHERE LEAF_ID = @LEAF_ID",
				(dr) => { return new Leaf(dr); },
				db.GetDataParameter("@LEAF_ID", leafId));
		}

		/// <summary>
		/// 查询烟农和烟叶框的电子标签对应表，此表为流水线表的所有对象列表
		/// </summary>
		/// <returns>返回烟农和烟叶框的电子标签对应表，此表为流水线对象列表</returns>
		public virtual ObservableCollection<Leaf> Query()
		{
			return db.ExecuteQuery<Leaf>("SELECT LEAF_ID, LEAF_RFID, FARMER_ID, LEAF_DATE, LEAF_LEVEL, LEAF_LEVEL_DATE, LEAF_LEVEL_EMPOLYEE, LEAF_WEIGHT, LEAF_WEIGHT_DATE, LEAF_WEIGHT_EMPOLYEE, LEAF_STATE, LEAF_IS_DELETED, LEAF_DELETED_DATE FROM T_PUR_LEAF ",
				(dr) => { return new Leaf(dr); });
		}

		/// <summary>
		/// 新增一条烟农和烟叶框的电子标签对应表，此表为流水线记录
		/// </summary>
		/// <param name="leaf">System.String[]<param>
		/// <returns>返回烟农和烟叶框的电子标签对应表，此表为流水线受影响的行数</returns>
		public virtual int Add(Leaf leaf)
		{
			return db.ExecuteNoQuery("INSERT INTO T_PUR_LEAF (LEAF_ID, LEAF_RFID, FARMER_ID, LEAF_DATE, LEAF_LEVEL, LEAF_LEVEL_DATE, LEAF_LEVEL_EMPOLYEE, LEAF_WEIGHT, LEAF_WEIGHT_DATE, LEAF_WEIGHT_EMPOLYEE, LEAF_STATE, LEAF_IS_DELETED, LEAF_DELETED_DATE) VALUES (@LEAF_ID, @LEAF_RFID, @FARMER_ID, @LEAF_DATE, @LEAF_LEVEL, @LEAF_LEVEL_DATE, @LEAF_LEVEL_EMPOLYEE, @LEAF_WEIGHT, @LEAF_WEIGHT_DATE, @LEAF_WEIGHT_EMPOLYEE, @LEAF_STATE, @LEAF_IS_DELETED, @LEAF_DELETED_DATE)", 
				db.GetDataParameter("@LEAF_ID", leaf.LeafId),
				db.GetDataParameter("@LEAF_RFID", leaf.LeafRfid),
				db.GetDataParameter("@FARMER_ID", leaf.FarmerId),
				db.GetDataParameter("@LEAF_DATE", leaf.LeafDate),
				db.GetDataParameter("@LEAF_LEVEL", leaf.LeafLevel),
				db.GetDataParameter("@LEAF_LEVEL_DATE", leaf.LeafLevelDate),
				db.GetDataParameter("@LEAF_LEVEL_EMPOLYEE", leaf.LeafLevelEmpolyee),
				db.GetDataParameter("@LEAF_WEIGHT", leaf.LeafWeight),
				db.GetDataParameter("@LEAF_WEIGHT_DATE", leaf.LeafWeightDate),
				db.GetDataParameter("@LEAF_WEIGHT_EMPOLYEE", leaf.LeafWeightEmpolyee),
				db.GetDataParameter("@LEAF_STATE", leaf.LeafState),
				db.GetDataParameter("@LEAF_IS_DELETED", leaf.LeafIsDeleted),
				db.GetDataParameter("@LEAF_DELETED_DATE", leaf.LeafDeletedDate));
		}
		/// <summary>
		/// 根据 LeafId 更新烟农和烟叶框的电子标签对应表，此表为流水线表记录
		/// </summary>
		/// <returns>返回烟农和烟叶框的电子标签对应表，此表为流水线受影响的行数</returns>
		public virtual int Update(Leaf leaf)
		{
			return db.ExecuteNoQuery("UPDATE T_PUR_LEAF SET LEAF_RFID = @LEAF_RFID, FARMER_ID = @FARMER_ID, LEAF_DATE = @LEAF_DATE, LEAF_LEVEL = @LEAF_LEVEL, LEAF_LEVEL_DATE = @LEAF_LEVEL_DATE, LEAF_LEVEL_EMPOLYEE = @LEAF_LEVEL_EMPOLYEE, LEAF_WEIGHT = @LEAF_WEIGHT, LEAF_WEIGHT_DATE = @LEAF_WEIGHT_DATE, LEAF_WEIGHT_EMPOLYEE = @LEAF_WEIGHT_EMPOLYEE, LEAF_STATE = @LEAF_STATE, LEAF_IS_DELETED = @LEAF_IS_DELETED, LEAF_DELETED_DATE = @LEAF_DELETED_DATE WHERE LEAF_ID = @LEAF_ID", 
				db.GetDataParameter("@LEAF_ID", leaf.LeafId),
				db.GetDataParameter("@LEAF_RFID", leaf.LeafRfid),
				db.GetDataParameter("@FARMER_ID", leaf.FarmerId),
				db.GetDataParameter("@LEAF_DATE", leaf.LeafDate),
				db.GetDataParameter("@LEAF_LEVEL", leaf.LeafLevel),
				db.GetDataParameter("@LEAF_LEVEL_DATE", leaf.LeafLevelDate),
				db.GetDataParameter("@LEAF_LEVEL_EMPOLYEE", leaf.LeafLevelEmpolyee),
				db.GetDataParameter("@LEAF_WEIGHT", leaf.LeafWeight),
				db.GetDataParameter("@LEAF_WEIGHT_DATE", leaf.LeafWeightDate),
				db.GetDataParameter("@LEAF_WEIGHT_EMPOLYEE", leaf.LeafWeightEmpolyee),
				db.GetDataParameter("@LEAF_STATE", leaf.LeafState),
				db.GetDataParameter("@LEAF_IS_DELETED", leaf.LeafIsDeleted),
				db.GetDataParameter("@LEAF_DELETED_DATE", leaf.LeafDeletedDate));
		}

		/// <summary>
		/// 根据 LeafId 删除烟农和烟叶框的电子标签对应表，此表为流水线表记录
		/// </summary>
		/// <param name="leafId">烟叶ID</param>
		/// <returns>返回烟农和烟叶框的电子标签对应表，此表为流水线受影响的行数</returns>
		public virtual int Delete(string leafId)
		{
			return db.ExecuteNoQuery("DELETE FROM T_PUR_LEAF WHERE LEAF_ID = @LEAF_ID", 
				db.GetDataParameter("@LEAF_ID", leafId));
		}
	}
}
