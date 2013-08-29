using LPS.Model.Base;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_dictronary)实体类
	/// 数据字典表
	/// </summary>
	public abstract class DictronaryDALBase : DALBase
	{
		/// <summary>
		/// 根据 DictCode 获取数据字典对象
		/// </summary>
		/// <param name="dictCode"></param>
		/// <returns>返回数据字典对象</returns>
		public virtual Dictronary Get(string dictCode)
		{
			return db.ExecuteGet<Dictronary>("SELECT DICT_TYPE, DICT_CODE, DICT_NAME, DICT_VALUE, DICT_DESCFROM T_BASE_DICTRONARY WHERE DICT_CODE = @DICT_CODE",
				(dr) => { return new Dictronary(dr); },
				db.GetDataParameter("@DICT_CODE", dictCode));
		}

		/// <summary>
		/// 查询数据字典表的所有对象列表
		/// </summary>
		/// <returns>返回数据字典对象列表</returns>
		public virtual ObservableCollection<Dictronary> Query()
		{
			return db.ExecuteQuery<Dictronary>("SELECT DICT_TYPE, DICT_CODE, DICT_NAME, DICT_VALUE, DICT_DESC FROM T_BASE_DICTRONARY ",
				(dr) => { return new Dictronary(dr); });
		}

		/// <summary>
		/// 新增一条数据字典记录
		/// </summary>
		/// <param name="dictronary">System.String[]<param>
		/// <returns>返回数据字典受影响的行数</returns>
		public virtual int Add(Dictronary dictronary)
		{
			return db.ExecuteNoQuery("INSERT INTO T_BASE_DICTRONARY (DICT_TYPE, DICT_CODE, DICT_NAME, DICT_VALUE, DICT_DESC) VALUES (@DICT_TYPE, @DICT_CODE, @DICT_NAME, @DICT_VALUE, @DICT_DESC)", 
				db.GetDataParameter("@DICT_TYPE", dictronary.DictType),
				db.GetDataParameter("@DICT_CODE", dictronary.DictCode),
				db.GetDataParameter("@DICT_NAME", dictronary.DictName),
				db.GetDataParameter("@DICT_VALUE", dictronary.DictValue),
				db.GetDataParameter("@DICT_DESC", dictronary.DictDesc));
		}
		/// <summary>
		/// 根据 DictCode 更新数据字典表记录
		/// </summary>
		/// <returns>返回数据字典受影响的行数</returns>
		public virtual int Update(Dictronary dictronary)
		{
			return db.ExecuteNoQuery("UPDATE T_BASE_DICTRONARY SET DICT_TYPE = @DICT_TYPE, DICT_NAME = @DICT_NAME, DICT_VALUE = @DICT_VALUE, DICT_DESC = @DICT_DESC WHERE DICT_CODE = @DICT_CODE", 
				db.GetDataParameter("@DICT_TYPE", dictronary.DictType),
				db.GetDataParameter("@DICT_CODE", dictronary.DictCode),
				db.GetDataParameter("@DICT_NAME", dictronary.DictName),
				db.GetDataParameter("@DICT_VALUE", dictronary.DictValue),
				db.GetDataParameter("@DICT_DESC", dictronary.DictDesc));
		}

		/// <summary>
		/// 根据 DictCode 删除数据字典表记录
		/// </summary>
		/// <param name="dictCode"></param>
		/// <returns>返回数据字典受影响的行数</returns>
		public virtual int Delete(string dictCode)
		{
			return db.ExecuteNoQuery("DELETE FROM T_BASE_DICTRONARY WHERE DICT_CODE = @DICT_CODE", 
				db.GetDataParameter("@DICT_CODE", dictCode));
		}
	}
}
