using LPS.Model.Sys;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Sys
{
	public class EmpolyeeDA : DALBase
	{
		#region 插入
		/// <summary>
		/// 插入t_Base_Empolyee
		/// </summary>
		public virtual bool Insert(EmpolyeeOR baseEmpolyee)
		{
			string sql = @"insert into t_Base_Empolyee (EMPOLYEE_ID, EMPOLYEE_CODE, EMPOLYEE_RFID, EMPOLYEE_NAME, EMPOLYEE_PY, EMPOLYEE_SEX,
EMPOLYEE_BIRTH, EMPOLYEE_ENTRY_DATE, EMPOLYEE_PHONE, EMPOLYEE_EMAIL, EMPOLYEE_ADDRESS, EMPOLYEE_HOMETOWN, EMPOLYEE_CARD_ID, USER_ID, USER_PWD, 
EMPOLYEE_CREATE_DATE, EMPOLYEE_IS_DELETED) 
values (@EMPOLYEE_ID, @EMPOLYEE_CODE, @EMPOLYEE_RFID, @EMPOLYEE_NAME, @EMPOLYEE_PY, @EMPOLYEE_SEX, @EMPOLYEE_BIRTH, @EMPOLYEE_ENTRY_DATE, 
@EMPOLYEE_PHONE, @EMPOLYEE_EMAIL, @EMPOLYEE_ADDRESS, @EMPOLYEE_HOMETOWN, @EMPOLYEE_CARD_ID, @USER_ID, @USER_PWD
,now(), 'N')";
			return db.ExecuteNoQuery(sql,
				db.GetDataParameter("@EMPOLYEE_ID", baseEmpolyee.EmpolyeeId),
				db.GetDataParameter("@EMPOLYEE_CODE", baseEmpolyee.EmpolyeeCode),
				db.GetDataParameter("@EMPOLYEE_RFID", baseEmpolyee.EmpolyeeRfid),
				db.GetDataParameter("@EMPOLYEE_NAME", baseEmpolyee.EmpolyeeName),
				db.GetDataParameter("@EMPOLYEE_PY", baseEmpolyee.EmpolyeePy),
				db.GetDataParameter("@EMPOLYEE_SEX", baseEmpolyee.EmpolyeeSex),
				db.GetDataParameter("@EMPOLYEE_BIRTH", baseEmpolyee.EmpolyeeBirth),
				db.GetDataParameter("@EMPOLYEE_ENTRY_DATE", baseEmpolyee.EmpolyeeEntryDate),
				db.GetDataParameter("@EMPOLYEE_PHONE", baseEmpolyee.EmpolyeePhone),
				db.GetDataParameter("@EMPOLYEE_EMAIL", baseEmpolyee.EmpolyeeEmail),
				db.GetDataParameter("@EMPOLYEE_ADDRESS", baseEmpolyee.EmpolyeeAddress),
				db.GetDataParameter("@EMPOLYEE_HOMETOWN", baseEmpolyee.EmpolyeeHometown),
				db.GetDataParameter("@EMPOLYEE_CARD_ID", baseEmpolyee.EmpolyeeCardId),
				db.GetDataParameter("@USER_ID", baseEmpolyee.UserId),
				db.GetDataParameter("@USER_PWD", baseEmpolyee.UserPwd)
                //db.GetDataParameter("@EMPOLYEE_CREATE_DATE", baseEmpolyee.EmpolyeeCreateDate),
                //db.GetDataParameter("@EMPOLYEE_IS_DELETED", baseEmpolyee.EmpolyeeIsDeleted),
                //db.GetDataParameter("@EMPOLYEE_DELETED_DATE", baseEmpolyee.EmpolyeeDeletedDate)
			) > 0;

		}
		#endregion

		#region 修改
		/// <summary>
		/// 更新t_Base_Empolyee
		/// </summary>
		public virtual bool Update(EmpolyeeOR baseEmpolyee)
		{
			string sql = @"update t_Base_Empolyee set  EMPOLYEE_CODE = @EMPOLYEE_CODE,  EMPOLYEE_RFID = @EMPOLYEE_RFID,  EMPOLYEE_NAME = @EMPOLYEE_NAME,  EMPOLYEE_PY = @EMPOLYEE_PY
,EMPOLYEE_SEX = @EMPOLYEE_SEX,  EMPOLYEE_BIRTH = @EMPOLYEE_BIRTH,  EMPOLYEE_ENTRY_DATE = @EMPOLYEE_ENTRY_DATE,  EMPOLYEE_PHONE = @EMPOLYEE_PHONE,  EMPOLYEE_EMAIL = @EMPOLYEE_EMAIL
,EMPOLYEE_ADDRESS = @EMPOLYEE_ADDRESS,  EMPOLYEE_HOMETOWN = @EMPOLYEE_HOMETOWN,  EMPOLYEE_CARD_ID = @EMPOLYEE_CARD_ID,  USER_ID = @USER_ID,  USER_PWD = @USER_PWD
where  EMPOLYEE_ID = @EMPOLYEE_ID";
			return db.ExecuteNoQuery(sql,
				db.GetDataParameter("@EMPOLYEE_ID", baseEmpolyee.EmpolyeeId),
				db.GetDataParameter("@EMPOLYEE_CODE", baseEmpolyee.EmpolyeeCode),
				db.GetDataParameter("@EMPOLYEE_RFID", baseEmpolyee.EmpolyeeRfid),
				db.GetDataParameter("@EMPOLYEE_NAME", baseEmpolyee.EmpolyeeName),
				db.GetDataParameter("@EMPOLYEE_PY", baseEmpolyee.EmpolyeePy),
				db.GetDataParameter("@EMPOLYEE_SEX", baseEmpolyee.EmpolyeeSex),
				db.GetDataParameter("@EMPOLYEE_BIRTH", baseEmpolyee.EmpolyeeBirth),
				db.GetDataParameter("@EMPOLYEE_ENTRY_DATE", baseEmpolyee.EmpolyeeEntryDate),
				db.GetDataParameter("@EMPOLYEE_PHONE", baseEmpolyee.EmpolyeePhone),
				db.GetDataParameter("@EMPOLYEE_EMAIL", baseEmpolyee.EmpolyeeEmail),
				db.GetDataParameter("@EMPOLYEE_ADDRESS", baseEmpolyee.EmpolyeeAddress),
				db.GetDataParameter("@EMPOLYEE_HOMETOWN", baseEmpolyee.EmpolyeeHometown),
				db.GetDataParameter("@EMPOLYEE_CARD_ID", baseEmpolyee.EmpolyeeCardId),
				db.GetDataParameter("@USER_ID", baseEmpolyee.UserId),
				db.GetDataParameter("@USER_PWD", baseEmpolyee.UserPwd)
                //db.GetDataParameter("@EMPOLYEE_CREATE_DATE", baseEmpolyee.EmpolyeeCreateDate),
                //db.GetDataParameter("@EMPOLYEE_IS_DELETED", baseEmpolyee.EmpolyeeIsDeleted),
                //db.GetDataParameter("@EMPOLYEE_DELETED_DATE", baseEmpolyee.EmpolyeeDeletedDate)
			) > 0;
		}
		#endregion

		public ObservableCollection<EmpolyeeOR> Select(string strFilter)
		{
			if (!string.IsNullOrEmpty(strFilter))
			{
				strFilter = " where " + strFilter;
			}
			string sql = @"select * from t_Base_Empolyee where EMPOLYEE_IS_DELETED='N' order by USER_ID";
			sql = string.Format(sql, strFilter);

			return db.ExecuteQuery<EmpolyeeOR>(sql, (dr) => { return new EmpolyeeOR(dr); });
		}


		public EmpolyeeOR selectARowDateByGuid(string m_id)
		{
			string sql = string.Format(@"select * from t_base_empolyee  where EMPOLYEE_ID=@EMPOLYEE_ID");
			return db.ExecuteGet<EmpolyeeOR>(sql, (dr) => { return new EmpolyeeOR(dr); }
				, db.GetDataParameter("@EMPOLYEE_ID", m_id));
		}



		public EmpolyeeOR sp_UserLogin(string userID, string UsrPwd)
		{
			string sql = "select * from t_base_empolyee WHERE EMPOLYEE_CODE=@EMPOLYEE_CODE and USER_PWD=@USER_PWD";

			EmpolyeeOR m_User = db.ExecuteGet<EmpolyeeOR>(sql, (dr) => { return new EmpolyeeOR(dr); }
					, db.GetDataParameter("@EMPOLYEE_CODE", userID)
					, db.GetDataParameter("@USER_PWD", UsrPwd));
			if (m_User == null)
			{
				//UsersOR user = this.selectARowDate(userID);
				//if (user != null)
				//    throw new Exception("密码错误！");
				//else
                m_User = new EmpolyeeOR();
                m_User.Result = 1;
                m_User.ResultMsg="用户名或密码错误！";
			}
			return m_User;
		}

		#region DELETE
		/// <summary>
		/// 删除T_YGB
		/// </summary>
		public virtual bool Delete(string strGuid)
		{
            string sql = @"update t_Base_Empolyee set EMPOLYEE_IS_DELETED='Y',EMPOLYEE_DELETED_DATE=now() where  EMPOLYEE_ID = @EMPOLYEE_ID";
            return db.ExecuteNoQuery(sql,db.GetDataParameter("@EMPOLYEE_ID", strGuid)) > 0;
		}
		#endregion

	}
}
