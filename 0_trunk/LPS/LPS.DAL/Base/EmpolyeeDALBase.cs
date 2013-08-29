using LPS.Model.Base;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_empolyee)实体类
	/// 员工表
	/// </summary>
	public abstract class EmpolyeeDALBase : DALBase
	{
		/// <summary>
		/// 根据 EmpolyeeId 获取员工对象
		/// </summary>
		/// <param name="empolyeeId"></param>
		/// <returns>返回员工对象</returns>
		public virtual Empolyee Get(string empolyeeId)
		{
			return db.ExecuteGet<Empolyee>("SELECT EMPOLYEE_ID, EMPOLYEE_CODE, EMPOLYEE_RFID, EMPOLYEE_NAME, EMPOLYEE_PY, EMPOLYEE_SEX, EMPOLYEE_BIRTH, EMPOLYEE_ENTRY_DATE, EMPOLYEE_PHONE, EMPOLYEE_EMAIL, EMPOLYEE_ADDRESS, EMPOLYEE_HOMETOWN, EMPOLYEE_CARD_ID, USER_ID, USER_PWD, EMPOLYEE_CREATE_DATE, EMPOLYEE_IS_DELETED, EMPOLYEE_DELETED_DATEFROM T_BASE_EMPOLYEE WHERE EMPOLYEE_ID = @EMPOLYEE_ID",
				(dr) => { return new Empolyee(dr); },
				db.GetDataParameter("@EMPOLYEE_ID", empolyeeId));
		}

		/// <summary>
		/// 查询员工表的所有对象列表
		/// </summary>
		/// <returns>返回员工对象列表</returns>
		public virtual ObservableCollection<Empolyee> Query()
		{
			return db.ExecuteQuery<Empolyee>("SELECT EMPOLYEE_ID, EMPOLYEE_CODE, EMPOLYEE_RFID, EMPOLYEE_NAME, EMPOLYEE_PY, EMPOLYEE_SEX, EMPOLYEE_BIRTH, EMPOLYEE_ENTRY_DATE, EMPOLYEE_PHONE, EMPOLYEE_EMAIL, EMPOLYEE_ADDRESS, EMPOLYEE_HOMETOWN, EMPOLYEE_CARD_ID, USER_ID, USER_PWD, EMPOLYEE_CREATE_DATE, EMPOLYEE_IS_DELETED, EMPOLYEE_DELETED_DATE FROM T_BASE_EMPOLYEE ",
				(dr) => { return new Empolyee(dr); });
		}

		/// <summary>
		/// 新增一条员工记录
		/// </summary>
		/// <param name="empolyee">System.String[]<param>
		/// <returns>返回员工受影响的行数</returns>
		public virtual int Add(Empolyee empolyee)
		{
			return db.ExecuteNoQuery("INSERT INTO T_BASE_EMPOLYEE (EMPOLYEE_ID, EMPOLYEE_CODE, EMPOLYEE_RFID, EMPOLYEE_NAME, EMPOLYEE_PY, EMPOLYEE_SEX, EMPOLYEE_BIRTH, EMPOLYEE_ENTRY_DATE, EMPOLYEE_PHONE, EMPOLYEE_EMAIL, EMPOLYEE_ADDRESS, EMPOLYEE_HOMETOWN, EMPOLYEE_CARD_ID, USER_ID, USER_PWD, EMPOLYEE_CREATE_DATE, EMPOLYEE_IS_DELETED, EMPOLYEE_DELETED_DATE) VALUES (@EMPOLYEE_ID, @EMPOLYEE_CODE, @EMPOLYEE_RFID, @EMPOLYEE_NAME, @EMPOLYEE_PY, @EMPOLYEE_SEX, @EMPOLYEE_BIRTH, @EMPOLYEE_ENTRY_DATE, @EMPOLYEE_PHONE, @EMPOLYEE_EMAIL, @EMPOLYEE_ADDRESS, @EMPOLYEE_HOMETOWN, @EMPOLYEE_CARD_ID, @USER_ID, @USER_PWD, @EMPOLYEE_CREATE_DATE, @EMPOLYEE_IS_DELETED, @EMPOLYEE_DELETED_DATE)", 
				db.GetDataParameter("@EMPOLYEE_ID", empolyee.EmpolyeeId),
				db.GetDataParameter("@EMPOLYEE_CODE", empolyee.EmpolyeeCode),
				db.GetDataParameter("@EMPOLYEE_RFID", empolyee.EmpolyeeRfid),
				db.GetDataParameter("@EMPOLYEE_NAME", empolyee.EmpolyeeName),
				db.GetDataParameter("@EMPOLYEE_PY", empolyee.EmpolyeePy),
				db.GetDataParameter("@EMPOLYEE_SEX", empolyee.EmpolyeeSex),
				db.GetDataParameter("@EMPOLYEE_BIRTH", empolyee.EmpolyeeBirth),
				db.GetDataParameter("@EMPOLYEE_ENTRY_DATE", empolyee.EmpolyeeEntryDate),
				db.GetDataParameter("@EMPOLYEE_PHONE", empolyee.EmpolyeePhone),
				db.GetDataParameter("@EMPOLYEE_EMAIL", empolyee.EmpolyeeEmail),
				db.GetDataParameter("@EMPOLYEE_ADDRESS", empolyee.EmpolyeeAddress),
				db.GetDataParameter("@EMPOLYEE_HOMETOWN", empolyee.EmpolyeeHometown),
				db.GetDataParameter("@EMPOLYEE_CARD_ID", empolyee.EmpolyeeCardId),
				db.GetDataParameter("@USER_ID", empolyee.UserId),
				db.GetDataParameter("@USER_PWD", empolyee.UserPwd),
				db.GetDataParameter("@EMPOLYEE_CREATE_DATE", empolyee.EmpolyeeCreateDate),
				db.GetDataParameter("@EMPOLYEE_IS_DELETED", empolyee.EmpolyeeIsDeleted),
				db.GetDataParameter("@EMPOLYEE_DELETED_DATE", empolyee.EmpolyeeDeletedDate));
		}
		/// <summary>
		/// 根据 EmpolyeeId 更新员工表记录
		/// </summary>
		/// <returns>返回员工受影响的行数</returns>
		public virtual int Update(Empolyee empolyee)
		{
			return db.ExecuteNoQuery("UPDATE T_BASE_EMPOLYEE SET EMPOLYEE_CODE = @EMPOLYEE_CODE, EMPOLYEE_RFID = @EMPOLYEE_RFID, EMPOLYEE_NAME = @EMPOLYEE_NAME, EMPOLYEE_PY = @EMPOLYEE_PY, EMPOLYEE_SEX = @EMPOLYEE_SEX, EMPOLYEE_BIRTH = @EMPOLYEE_BIRTH, EMPOLYEE_ENTRY_DATE = @EMPOLYEE_ENTRY_DATE, EMPOLYEE_PHONE = @EMPOLYEE_PHONE, EMPOLYEE_EMAIL = @EMPOLYEE_EMAIL, EMPOLYEE_ADDRESS = @EMPOLYEE_ADDRESS, EMPOLYEE_HOMETOWN = @EMPOLYEE_HOMETOWN, EMPOLYEE_CARD_ID = @EMPOLYEE_CARD_ID, USER_ID = @USER_ID, USER_PWD = @USER_PWD, EMPOLYEE_CREATE_DATE = @EMPOLYEE_CREATE_DATE, EMPOLYEE_IS_DELETED = @EMPOLYEE_IS_DELETED, EMPOLYEE_DELETED_DATE = @EMPOLYEE_DELETED_DATE WHERE EMPOLYEE_ID = @EMPOLYEE_ID", 
				db.GetDataParameter("@EMPOLYEE_ID", empolyee.EmpolyeeId),
				db.GetDataParameter("@EMPOLYEE_CODE", empolyee.EmpolyeeCode),
				db.GetDataParameter("@EMPOLYEE_RFID", empolyee.EmpolyeeRfid),
				db.GetDataParameter("@EMPOLYEE_NAME", empolyee.EmpolyeeName),
				db.GetDataParameter("@EMPOLYEE_PY", empolyee.EmpolyeePy),
				db.GetDataParameter("@EMPOLYEE_SEX", empolyee.EmpolyeeSex),
				db.GetDataParameter("@EMPOLYEE_BIRTH", empolyee.EmpolyeeBirth),
				db.GetDataParameter("@EMPOLYEE_ENTRY_DATE", empolyee.EmpolyeeEntryDate),
				db.GetDataParameter("@EMPOLYEE_PHONE", empolyee.EmpolyeePhone),
				db.GetDataParameter("@EMPOLYEE_EMAIL", empolyee.EmpolyeeEmail),
				db.GetDataParameter("@EMPOLYEE_ADDRESS", empolyee.EmpolyeeAddress),
				db.GetDataParameter("@EMPOLYEE_HOMETOWN", empolyee.EmpolyeeHometown),
				db.GetDataParameter("@EMPOLYEE_CARD_ID", empolyee.EmpolyeeCardId),
				db.GetDataParameter("@USER_ID", empolyee.UserId),
				db.GetDataParameter("@USER_PWD", empolyee.UserPwd),
				db.GetDataParameter("@EMPOLYEE_CREATE_DATE", empolyee.EmpolyeeCreateDate),
				db.GetDataParameter("@EMPOLYEE_IS_DELETED", empolyee.EmpolyeeIsDeleted),
				db.GetDataParameter("@EMPOLYEE_DELETED_DATE", empolyee.EmpolyeeDeletedDate));
		}

		/// <summary>
		/// 根据 EmpolyeeId 删除员工表记录
		/// </summary>
		/// <param name="empolyeeId"></param>
		/// <returns>返回员工受影响的行数</returns>
		public virtual int Delete(string empolyeeId)
		{
			return db.ExecuteNoQuery("DELETE FROM T_BASE_EMPOLYEE WHERE EMPOLYEE_ID = @EMPOLYEE_ID", 
				db.GetDataParameter("@EMPOLYEE_ID", empolyeeId));
		}
	}
}
