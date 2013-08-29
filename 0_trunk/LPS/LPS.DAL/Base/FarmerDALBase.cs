using LPS.Model.Base;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_farmer)实体类
	/// 烟农表
	/// </summary>
	public abstract class FarmerDALBase : DALBase
	{
		/// <summary>
		/// 根据 FarmerId 获取烟农对象
		/// </summary>
		/// <param name="farmerId">烟农唯一标识</param>
		/// <returns>返回烟农对象</returns>
		public virtual Farmer Get(string farmerId)
		{
			return db.ExecuteGet<Farmer>("SELECT FARMER_ID, FARMAR_CODE, FARMER_RFID, FARMER_NAME, FARMER_PY, FARMER_PHONE, FARMER_EMAIL, FARMER_ADDRESS, FARMER_RMARK, FARMER_SEX, FARMER_BIRTH, FARMER_CARD_ID, FARMER_CREATE_DATE, FARMER_IS_DELETED, FARMER_DELETED_DATEFROM T_BASE_FARMER WHERE FARMER_ID = @FARMER_ID",
				(dr) => { return new Farmer(dr); },
				db.GetDataParameter("@FARMER_ID", farmerId));
		}

		/// <summary>
		/// 查询烟农表的所有对象列表
		/// </summary>
		/// <returns>返回烟农对象列表</returns>
		public virtual ObservableCollection<Farmer> Query()
		{
			return db.ExecuteQuery<Farmer>("SELECT FARMER_ID, FARMAR_CODE, FARMER_RFID, FARMER_NAME, FARMER_PY, FARMER_PHONE, FARMER_EMAIL, FARMER_ADDRESS, FARMER_RMARK, FARMER_SEX, FARMER_BIRTH, FARMER_CARD_ID, FARMER_CREATE_DATE, FARMER_IS_DELETED, FARMER_DELETED_DATE FROM T_BASE_FARMER ",
				(dr) => { return new Farmer(dr); });
		}

		/// <summary>
		/// 新增一条烟农记录
		/// </summary>
		/// <param name="farmer">System.String[]<param>
		/// <returns>返回烟农受影响的行数</returns>
		public virtual int Add(Farmer farmer)
		{
			return db.ExecuteNoQuery("INSERT INTO T_BASE_FARMER (FARMER_ID, FARMAR_CODE, FARMER_RFID, FARMER_NAME, FARMER_PY, FARMER_PHONE, FARMER_EMAIL, FARMER_ADDRESS, FARMER_RMARK, FARMER_SEX, FARMER_BIRTH, FARMER_CARD_ID, FARMER_CREATE_DATE, FARMER_IS_DELETED, FARMER_DELETED_DATE) VALUES (@FARMER_ID, @FARMAR_CODE, @FARMER_RFID, @FARMER_NAME, @FARMER_PY, @FARMER_PHONE, @FARMER_EMAIL, @FARMER_ADDRESS, @FARMER_RMARK, @FARMER_SEX, @FARMER_BIRTH, @FARMER_CARD_ID, @FARMER_CREATE_DATE, @FARMER_IS_DELETED, @FARMER_DELETED_DATE)", 
				db.GetDataParameter("@FARMER_ID", farmer.FarmerId),
				db.GetDataParameter("@FARMAR_CODE", farmer.FarmarCode),
				db.GetDataParameter("@FARMER_RFID", farmer.FarmerRfid),
				db.GetDataParameter("@FARMER_NAME", farmer.FarmerName),
				db.GetDataParameter("@FARMER_PY", farmer.FarmerPy),
				db.GetDataParameter("@FARMER_PHONE", farmer.FarmerPhone),
				db.GetDataParameter("@FARMER_EMAIL", farmer.FarmerEmail),
				db.GetDataParameter("@FARMER_ADDRESS", farmer.FarmerAddress),
				db.GetDataParameter("@FARMER_RMARK", farmer.FarmerRmark),
				db.GetDataParameter("@FARMER_SEX", farmer.FarmerSex),
				db.GetDataParameter("@FARMER_BIRTH", farmer.FarmerBirth),
				db.GetDataParameter("@FARMER_CARD_ID", farmer.FarmerCardId),
				db.GetDataParameter("@FARMER_CREATE_DATE", farmer.FarmerCreateDate),
				db.GetDataParameter("@FARMER_IS_DELETED", farmer.FarmerIsDeleted),
				db.GetDataParameter("@FARMER_DELETED_DATE", farmer.FarmerDeletedDate));
		}
		/// <summary>
		/// 根据 FarmerId 更新烟农表记录
		/// </summary>
		/// <returns>返回烟农受影响的行数</returns>
		public virtual int Update(Farmer farmer)
		{
			return db.ExecuteNoQuery("UPDATE T_BASE_FARMER SET FARMAR_CODE = @FARMAR_CODE, FARMER_RFID = @FARMER_RFID, FARMER_NAME = @FARMER_NAME, FARMER_PY = @FARMER_PY, FARMER_PHONE = @FARMER_PHONE, FARMER_EMAIL = @FARMER_EMAIL, FARMER_ADDRESS = @FARMER_ADDRESS, FARMER_RMARK = @FARMER_RMARK, FARMER_SEX = @FARMER_SEX, FARMER_BIRTH = @FARMER_BIRTH, FARMER_CARD_ID = @FARMER_CARD_ID, FARMER_CREATE_DATE = @FARMER_CREATE_DATE, FARMER_IS_DELETED = @FARMER_IS_DELETED, FARMER_DELETED_DATE = @FARMER_DELETED_DATE WHERE FARMER_ID = @FARMER_ID", 
				db.GetDataParameter("@FARMER_ID", farmer.FarmerId),
				db.GetDataParameter("@FARMAR_CODE", farmer.FarmarCode),
				db.GetDataParameter("@FARMER_RFID", farmer.FarmerRfid),
				db.GetDataParameter("@FARMER_NAME", farmer.FarmerName),
				db.GetDataParameter("@FARMER_PY", farmer.FarmerPy),
				db.GetDataParameter("@FARMER_PHONE", farmer.FarmerPhone),
				db.GetDataParameter("@FARMER_EMAIL", farmer.FarmerEmail),
				db.GetDataParameter("@FARMER_ADDRESS", farmer.FarmerAddress),
				db.GetDataParameter("@FARMER_RMARK", farmer.FarmerRmark),
				db.GetDataParameter("@FARMER_SEX", farmer.FarmerSex),
				db.GetDataParameter("@FARMER_BIRTH", farmer.FarmerBirth),
				db.GetDataParameter("@FARMER_CARD_ID", farmer.FarmerCardId),
				db.GetDataParameter("@FARMER_CREATE_DATE", farmer.FarmerCreateDate),
				db.GetDataParameter("@FARMER_IS_DELETED", farmer.FarmerIsDeleted),
				db.GetDataParameter("@FARMER_DELETED_DATE", farmer.FarmerDeletedDate));
		}

		/// <summary>
		/// 根据 FarmerId 删除烟农表记录
		/// </summary>
		/// <param name="farmerId">烟农唯一标识</param>
		/// <returns>返回烟农受影响的行数</returns>
		public virtual int Delete(string farmerId)
		{
			return db.ExecuteNoQuery("DELETE FROM T_BASE_FARMER WHERE FARMER_ID = @FARMER_ID", 
				db.GetDataParameter("@FARMER_ID", farmerId));
		}
	}
}
