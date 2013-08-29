using System;
using MySql.Data.MySqlClient;

namespace LPS.DataAccess
{
    /// <summary>
    /// MySQL 数据库访问类
    /// </summary>
    public class MySQLDbHepler : DbHelper
    {
        // 保存连接字符串
        private readonly string _connectionString;
        
        /// <summary>
        /// 定义名变量的符号
        /// </summary>
        protected override char Symbol { get; set; }

        public MySQLDbHepler(string connectionString)
        {
            _connectionString = connectionString;
            Symbol = '@'; // MySQL 同时支持@和?
        }
        /// <summary>
        /// 获取一个数据源连接
        /// </summary>
        /// <returns>数据源连接</returns>
        protected override System.Data.IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        /// <summary>
        /// 获取一个 SQL 语句命令执行对象
        /// </summary>
        /// <returns>SQL 语句命令执行对象</returns>
        protected override System.Data.IDbCommand GetCommand()
        {
            return new MySqlCommand();
        }

        /// <summary>
        /// 获取一个更新和填充 DataSet 的对象
        /// </summary>
        /// <returns>更新和填充 DataSet 的对象</returns>
        protected override System.Data.IDbDataAdapter GetDataAdapter()
        {
            return new MySqlDataAdapter();
        }

        /// <summary>
        /// 获取一个 Command 对象的参数
        /// </summary>
        /// <returns>Command 对象的参数</returns>
        public override System.Data.IDataParameter GetDataParameter(string parameterName, object value)
        {
            return new MySqlParameter(parameterName, value ?? DBNull.Value);
        }
    }
}
