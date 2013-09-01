using LPS.Model.Sys;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Sys
{
	public class EmpolyeeDAL : DALBase
	{

		public ObservableCollection<EmpolyeeOR> Select(string strFilter)
		{
			if (!string.IsNullOrEmpty(strFilter))
			{
				strFilter = " where " + strFilter;
			}
			string sql = @"select * from t_base_empolyee order by USER_ID";
			sql = string.Format(sql, strFilter);

			return db.ExecuteQuery<EmpolyeeOR>(sql, (dr) => { return new EmpolyeeOR(dr); });
		}


		public EmpolyeeOR selectARowDateByGuid(string m_id)
		{
			string sql = string.Format(@"select * from t_base_empolyee  where EMPOLYEE_ID=@EMPOLYEE_ID");
			return db.ExecuteGet<EmpolyeeOR>(sql,(dr) => { return new EmpolyeeOR(dr); }
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
				throw new Exception("用户名或密码错误！");
			}
			return m_User;
		}

		#region DELETE
		/// <summary>
		/// 删除T_YGB
		/// </summary>
		public virtual int Delete(string strGuid)
		{
			return db.ExecuteNoQuery("DELETE FROM t_base_empolyee WHERE EMPOLYEE_ID = @EMPOLYEE_ID",
				db.GetDataParameter("@EMPOLYEE_ID", strGuid));
				 
		}
		#endregion

	}
}
