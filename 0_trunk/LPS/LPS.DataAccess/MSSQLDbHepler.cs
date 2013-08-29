using System;
using System.Data.SqlClient;

namespace LPS.DataAccess
{
    /// <summary>
    /// SQL Server 数据库访问类
    /// </summary>
    public class MSSQLDbHepler : DbHelper
    {
        // 保存连接字符串
        private readonly string _connectionString;

        /// <summary>
        /// 定义名变量的符号
        /// </summary>
        protected override char Symbol { get; set; }

        public MSSQLDbHepler(string connectionString)
        {
            _connectionString = connectionString;
            Symbol = '@';
        }
        /// <summary>
        /// 获取一个数据源连接
        /// </summary>
        /// <returns>数据源连接</returns>
        protected override System.Data.IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// 获取一个 SQL 语句命令执行对象
        /// </summary>
        /// <returns>SQL 语句命令执行对象</returns>
        protected override System.Data.IDbCommand GetCommand()
        {
            return new SqlCommand();
        }

        /// <summary>
        /// 获取一个更新和填充 DataSet 的对象
        /// </summary>
        /// <returns>更新和填充 DataSet 的对象</returns>
        protected override System.Data.IDbDataAdapter GetDataAdapter()
        {
            return new SqlDataAdapter();
        }

        /// <summary>
        /// 获取一个 Command 对象的参数
        /// </summary>
        /// <returns>Command 对象的参数</returns>
        public override System.Data.IDataParameter GetDataParameter(string parameterName, object value)
        {
            return new SqlParameter(string.Concat(Symbol, parameterName), value ?? DBNull.Value);
        }
    }
}
