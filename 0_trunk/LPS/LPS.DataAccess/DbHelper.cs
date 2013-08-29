using System;
using System.Collections.ObjectModel;
using System.Data;

namespace LPS.DataAccess
{
    /// <summary>
    /// 数据库访问类
    /// </summary>
    public abstract class DbHelper
    {
        /// <summary>
        /// 定义名变量的符号
        /// </summary>
        protected abstract char Symbol { get; set;}

        #region 抽象方法

        /// <summary>
        /// 获取一个数据源连接
        /// </summary>
        /// <returns>数据源连接</returns>
        protected abstract IDbConnection GetConnection();

        /// <summary>
        /// 获取一个 SQL 语句命令执行对象
        /// </summary>
        /// <returns>SQL 语句命令执行对象</returns>
        protected abstract IDbCommand GetCommand();

        /// <summary>
        /// 获取一个更新和填充 DataSet 的对象
        /// </summary>
        /// <returns>更新和填充 DataSet 的对象</returns>
        protected abstract IDbDataAdapter GetDataAdapter();

        /// <summary>
        /// 获取一个 Command 对象的参数
        /// </summary>
        /// <returns>Command 对象的参数</returns>
        public abstract IDataParameter GetDataParameter(string parameterName, object value);

        #endregion 抽象方法

        #region 公共方法

        #region 执行单条 SQL 语句

        /// <summary>
        /// 执行 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string cmdText)
        {
            return ExecuteNoQuery(cmdText, CommandType.Text);
        }

        /// <summary>
        /// 执行 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string cmdText, CommandType commandType)
        {
            return ExecuteCommand<int>(cmd =>
            {
                cmd.CommandText = cmdText;
                return cmd.ExecuteNonQuery();
            }, cmdText, commandType);
        }

        /// <summary>
        /// 执行 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string cmdText, IDataParameter parameter)
        {
            return ExecuteNoQuery(cmdText,CommandType.Text, parameter);
        }

        /// <summary>
        /// 执行 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string cmdText, CommandType commandType, IDataParameter parameter)
        {
            return ExecuteCommand<int>(cmd =>
            {
                return cmd.ExecuteNonQuery();
            }, cmdText, commandType, parameter);
        }

        /// <summary>
        /// 执行 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="parameters">Command 对象的参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string cmdText, params IDataParameter[] parameters)
        {
            return ExecuteNoQuery(cmdText, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="parameters">Command 对象的参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string cmdText, CommandType commandType, params IDataParameter[] parameters)
        {
            return ExecuteCommand<int>(cmd =>
            {
                return cmd.ExecuteNonQuery();
            }, cmdText, commandType, parameters);
        }

        #endregion 执行单条 SQL 语句

        #region 执行多条 SQL 语句

        /// <summary>
        /// 执行多条 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdTexts">SQL 语句数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string[] cmdTexts)
        {
            return ExecuteNoQuery(cmdTexts, CommandType.Text);
        }

        /// <summary>
        /// 执行多条 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdTexts">SQL 语句数组</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string[] cmdTexts, CommandType commandType)
        {
            return ExecuteMutiCommand(cmd =>
            {
                int result = 0;
                cmd.CommandType = commandType;
                foreach (string cmdText in cmdTexts)
                {
                    cmd.CommandText = cmdText;
                    result += cmd.ExecuteNonQuery();
                }
                return result;
            });
        }

        /// <summary>
        /// 执行多条 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdTexts">SQL 语句数组</param>
        /// <param name="commandTypes">指定如何解释命令字符串数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string[] cmdTexts, CommandType[] commandTypes)
        {
            return ExecuteMutiCommand(cmd =>
            {
                int result = 0;
                for (int i = 0; i < cmdTexts.Length;i++)
                {
                    cmd.CommandText = cmdTexts[i];
                    cmd.CommandType = commandTypes[i];
                    result += cmd.ExecuteNonQuery();
                }
                return result;
            });
        }

        /// <summary>
        /// 执行多条 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdTexts">SQL 语句数组</param>
        /// <param name="parameters">Command 对象的参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string[] cmdTexts, IDataParameter[][] parameters)
        {
            return ExecuteNoQuery(cmdTexts, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行多条 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdTexts">SQL 语句数组</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="parameters">Command 对象的参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string[] cmdTexts, CommandType commandType, IDataParameter[][] parameters)
        {
            return ExecuteMutiCommand(cmd =>
            {
                int result = 0;
                cmd.CommandType = commandType;
                for (int i = 0; i < cmdTexts.Length; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = cmdTexts[i].Replace('@', Symbol);
                    if (null != parameters[i])
                    {
                        foreach (IDataParameter parameter in parameters[i])
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    result += cmd.ExecuteNonQuery();
                }
                return result;
            });
        }

        /// <summary>
        /// 执行多条 SQL 语句，并返回受影响的行数
        /// </summary>
        /// <param name="cmdTexts">SQL 语句数组</param>
        /// <param name="commandTypes">指定如何解释命令字符串数组</param>
        /// <param name="parameters">Command 对象的参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string[] cmdTexts, CommandType[] commandTypes, IDataParameter[][] parameters)
        {
            return ExecuteMutiCommand(cmd =>
            {
                int result = 0;
                for (int i = 0; i < cmdTexts.Length; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = cmdTexts[i].Replace('@', Symbol);
                    cmd.CommandType = commandTypes[i];
                    foreach (IDataParameter parameter in parameters[i])
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    result += cmd.ExecuteNonQuery();
                }
                return result;
            });
        }

        #endregion 执行多条 SQL 语句

        #region 查询单个字段

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <returns>结果集中第一行的第一列</returns>
        public object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(cmdText, CommandType.Text);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <returns>结果集中第一行的第一列</returns>
        public object ExecuteScalar(string cmdText, CommandType commandType)
        {
            return ExecuteCommand<object>(cmd => {
                return cmd.ExecuteScalar();
            }, cmdText, commandType);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public object ExecuteScalar(string cmdText, IDataParameter parameter)
        {
            return ExecuteScalar(cmdText, CommandType.Text, parameter);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public object ExecuteScalar(string cmdText, CommandType commandType, IDataParameter parameter)
        {
            return ExecuteCommand<object>(cmd =>
            {
                return cmd.ExecuteScalar();
            }, cmdText, commandType, parameter);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="parameters">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public object ExecuteScalar(string cmdText, IDataParameter[] parameters)
        {
            return ExecuteScalar(cmdText, CommandType.Text, parameters);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="parameters">Command 对象的参数数组</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public object ExecuteScalar(string cmdText, CommandType commandType, params IDataParameter[] parameters)
        {
            return ExecuteCommand<object>(cmd =>
            {
                foreach (IDataParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                return cmd.ExecuteScalar();
            }, cmdText, commandType, parameters);
        }

        #endregion 查询单个字段

        #region 查询单条记录

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <returns>结果集中第一行的第一列</returns>
        public T ExecuteGet<T>(string cmdText, Func<IDataReader, T> readFunc) where T:class
        {
            return ExecuteGet<T>(cmdText, CommandType.Text, readFunc);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <returns>结果集中第一行的第一列</returns>
        public T ExecuteGet<T>(string cmdText, CommandType commandType, Func<IDataReader, T> readFunc) where T : class
        {
            return ExecuteCommand<T>(cmd =>
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return readFunc(dr);
                    }
                }
                return null;
            }, cmdText, commandType);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public T ExecuteGet<T>(string cmdText, Func<IDataReader, T> readFunc, IDataParameter parameter) where T:  class
        {
            return ExecuteGet<T>(cmdText, CommandType.Text, readFunc, parameter);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public T ExecuteGet<T>(string cmdText, CommandType commandType, Func<IDataReader, T> readFunc, IDataParameter parameter) where T : class
        {
            return ExecuteCommand<T>(cmd =>
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return readFunc(dr);
                    }
                    return null;
                }
            }, cmdText, commandType, parameter);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public T ExecuteGet<T>(string cmdText, Func<IDataReader, T> readFunc, params IDataParameter[] parameters) where T:class
        {
            return ExecuteGet<T>(cmdText, CommandType.Text, readFunc, parameters);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public T ExecuteGet<T>(string cmdText, CommandType commandType, Func<IDataReader, T> readFunc, params IDataParameter[] parameters) where T : class
        {
            return ExecuteCommand<T>(cmd =>
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                         return readFunc(dr);
                    }
                    return null;
                }
            }, cmdText, commandType, parameters);
        }

        #endregion 查询多条记录

        #region 查询多条记录

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <returns>结果集中第一行的第一列</returns>
        public ObservableCollection<T> ExecuteQuery<T>(string cmdText, Func<IDataReader, T> readFunc)
        {
            return ExecuteQuery<T>(cmdText, CommandType.Text, readFunc);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <returns>结果集中第一行的第一列</returns>
        public ObservableCollection<T> ExecuteQuery<T>(string cmdText, CommandType commandType, Func<IDataReader, T> readFunc)
        {
            return ExecuteCommand<ObservableCollection<T>>(cmd =>
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    ObservableCollection<T> collection = new ObservableCollection<T>();
                    while (dr.Read())
                    {
                        collection.Add(readFunc(dr));
                    }
                    return collection;
                }
            }, cmdText, commandType);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public ObservableCollection<T> ExecuteQuery<T>(string cmdText, Func<IDataReader, T> readFunc, IDataParameter parameter)
        {
            return ExecuteQuery<T>(cmdText, CommandType.Text, readFunc, parameter);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public ObservableCollection<T> ExecuteQuery<T>(string cmdText, CommandType commandType, Func<IDataReader, T> readFunc, IDataParameter parameter)
        {
            return ExecuteCommand<ObservableCollection<T>>(cmd =>
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    ObservableCollection<T> collection = new ObservableCollection<T>();
                    while (dr.Read())
                    {
                        collection.Add(readFunc(dr));
                    }
                    return collection;
                }
            }, cmdText, commandType, parameter);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public ObservableCollection<T> ExecuteQuery<T>(string cmdText, Func<IDataReader, T> readFunc, params IDataParameter[] parameters)
        {
            return ExecuteQuery<T>(cmdText, CommandType.Text, readFunc, parameters);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行
        /// </summary>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType">指定如何解释命令字符串</param>
        /// <param name="readFunc">读取 DataReader 回调方法</param>
        /// <param name="parameter">Command 对象的参数</param>
        /// <returns>结果集中第一行的第一列</returns>
        public ObservableCollection<T> ExecuteQuery<T>(string cmdText, CommandType commandType, Func<IDataReader, T> readFunc, params IDataParameter[] parameters)
        {
            return ExecuteCommand<ObservableCollection<T>>(cmd =>
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    ObservableCollection<T> collection = new ObservableCollection<T>();
                    while (dr.Read())
                    {
                        collection.Add(readFunc(dr));
                    }
                    return collection;
                }
            }, cmdText, commandType, parameters);
        }

        #endregion 查询多条记录

        #endregion 公共方法

        #region 私有方法

        /// <summary>
        /// 执行 Command 命令
        /// </summary>
        /// <param name="commandAction">需要执行Command的方法</param>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType"></param>
        private T ExecuteCommand<T>(Func<IDbCommand, T> commandAction, string cmdText, CommandType commandType)
        {
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();
                using (IDbCommand cmd = GetCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = commandType;
                    cmd.CommandText = cmdText;
                    return commandAction(cmd);
                }
            }
        }

        /// <summary>
        /// 执行 Command 命令
        /// </summary>
        /// <param name="commandAction">需要执行Command的方法</param>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType"></param>
        private T ExecuteCommand<T>(Func<IDbCommand, T> commandAction, string cmdText, CommandType commandType, IDataParameter parameter)
        {
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();
                using (IDbCommand cmd = GetCommand())
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add(parameter);
                    cmd.CommandType = commandType;
                    cmd.CommandText = cmdText.Replace('@', Symbol);
                    return commandAction(cmd);
                }
            }
        }

        /// <summary>
        /// 执行 Command 命令
        /// </summary>
        /// <param name="commandAction">需要执行Command的方法</param>
        /// <param name="cmdText">SQL 语句</param>
        /// <param name="commandType"></param>
        /// <param name="parameter">Command 对象的参数</param>
        private T ExecuteCommand<T>(Func<IDbCommand, T> commandAction, string cmdText, CommandType commandType, IDataParameter[] parameters)
        {
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();
                using (IDbCommand cmd = GetCommand())
                {
                    cmd.Connection = conn;
                    foreach (IDataParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    cmd.CommandType = commandType;
                    cmd.CommandText = cmdText.Replace('@', Symbol);
                    return commandAction(cmd);
                }
            }
        }

        /// <summary>
        /// 采用事物执行多条Sql 语句
        /// </summary>
        /// <param name="commandAction"></param>
        /// <returns></returns>
        private int ExecuteMutiCommand(Func<IDbCommand, int> commandAction)
        {
            using (IDbConnection conn = GetConnection())
            {
                conn.Open();
                using (IDbTransaction trans = conn.BeginTransaction())
                {
                    using (IDbCommand cmd = GetCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;
                        try
                        {
                            int result = commandAction(cmd);
                            trans.Commit();
                            return result;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            //throw ex;
                            return -1;
                        }
                    }
                }
            }
        }

        #endregion 私有方法
    }
}
