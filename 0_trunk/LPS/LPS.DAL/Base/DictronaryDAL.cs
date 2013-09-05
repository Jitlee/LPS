

using LPS.Model.Base;
using System.Collections.ObjectModel;
namespace LPS.DAL.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_dictronary)实体类
	/// 数据字典表
	/// </summary>
	public class DictronaryDAL : DictronaryDALBase
	{
        public   ObservableCollection<Dictronary> QueryByType(string TypeCode)
        {
            return db.ExecuteQuery<Dictronary>(string.Format("SELECT DICT_TYPE, DICT_CODE, DICT_NAME, DICT_VALUE, DICT_DESC FROM T_BASE_DICTRONARY WHERE DICT_TYPE='{0}'", TypeCode),
                (dr) => { return new Dictronary(dr); });
        }

        public ObservableCollection<Dictronary> SelectSubWithoutSelf(string TypeCode,string strCode)
        {
            return db.ExecuteQuery<Dictronary>(string.Format("SELECT * FROM T_BASE_DICTRONARY WHERE DICT_TYPE='{0}' and DICT_CODE <>'{1}'", TypeCode, strCode),
                (dr) => { return new Dictronary(dr); });
        }
	}
}
