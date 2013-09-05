using LPS.Model.Base;

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DAL.Base
{
	// 添加 Jitlee 2013-08-30
	/// <summary>
	/// (t_base_dictronary_type)实体类
	/// 数据字典类型表
	/// </summary>
	public abstract class DictronaryTypeDALBase : DALBase
	{
		/// <summary>
		/// 根据 DictType 获取数据字典类型对象
		/// </summary>
		/// <param name="dictType">字典类型</param>
		/// <returns>返回数据字典类型对象</returns>
		public virtual DictronaryType Get(string dictType)
		{
            return db.ExecuteGet<DictronaryType>("SELECT * FROM t_base_dictronary_type   WHERE DICT_TYPE = @DICT_TYPE",
				(dr) => { return new DictronaryType(dr); },
				db.GetDataParameter("@DICT_TYPE", dictType));
		}

		/// <summary>
		/// 查询数据字典类型表的所有对象列表
		/// </summary>
		/// <returns>返回数据字典类型对象列表</returns>
		public virtual ObservableCollection<DictronaryType> Query()
		{
			return db.ExecuteQuery<DictronaryType>("SELECT DICT_TYPE, DICT_TYPE_NAME, DICT_TYPE_DESC FROM T_BASE_DICTRONARY_TYPE ",
				(dr) => { return new DictronaryType(dr); });
		}

		/// <summary>
		/// 新增一条数据字典类型记录
		/// </summary>
		/// <param name="dictronarytype">System.String[]<param>
		/// <returns>返回数据字典类型受影响的行数</returns>
		public virtual int Add(DictronaryType dictronarytype)
		{
			return db.ExecuteNoQuery("INSERT INTO T_BASE_DICTRONARY_TYPE (DICT_TYPE, DICT_TYPE_NAME, DICT_TYPE_DESC) VALUES (@DICT_TYPE, @DICT_TYPE_NAME, @DICT_TYPE_DESC)", 
				db.GetDataParameter("@DICT_TYPE", dictronarytype.DictType),
				db.GetDataParameter("@DICT_TYPE_NAME", dictronarytype.DictTypeName),
				db.GetDataParameter("@DICT_TYPE_DESC", dictronarytype.DictTypeDesc));
		}
		/// <summary>
		/// 根据 DictType 更新数据字典类型表记录
		/// </summary>
		/// <returns>返回数据字典类型受影响的行数</returns>
		public virtual int Update(DictronaryType dictronarytype)
		{
			return db.ExecuteNoQuery("UPDATE T_BASE_DICTRONARY_TYPE SET DICT_TYPE_NAME = @DICT_TYPE_NAME, DICT_TYPE_DESC = @DICT_TYPE_DESC WHERE DICT_TYPE = @DICT_TYPE", 
				db.GetDataParameter("@DICT_TYPE", dictronarytype.DictType),
				db.GetDataParameter("@DICT_TYPE_NAME", dictronarytype.DictTypeName),
				db.GetDataParameter("@DICT_TYPE_DESC", dictronarytype.DictTypeDesc));
		}

		/// <summary>
		/// 根据 DictType 删除数据字典类型表记录
		/// </summary>
		/// <param name="dictType">字典类型</param>
		/// <returns>返回数据字典类型受影响的行数</returns>
		public virtual int Delete(string dictType)
		{
			return db.ExecuteNoQuery("DELETE FROM T_BASE_DICTRONARY_TYPE WHERE DICT_TYPE = @DICT_TYPE", 
				db.GetDataParameter("@DICT_TYPE", dictType));
		}
	}
}
