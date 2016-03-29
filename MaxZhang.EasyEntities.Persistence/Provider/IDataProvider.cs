using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MaxZhang.EasyEntities.Persistence.Provider
{
    /// <summary>
    /// 数据库数据提供器
    /// </summary>
    public interface IDataProvider : IDisposable

    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        string Database { get; }
        /// <summary>
        /// 对应数据库中声明参数的标示，如SQLSERVER中声明一个参数@name,标示为@
        /// </summary>
        string ParamPrefix { get; }

        /// <summary>
        /// 日期型数据在各数据库中字符串表示方式中的符号如在SQL中为' 在Access中是#
        /// </summary>
        string DateTimeFlagString { get; }

        /// <summary>
        /// 连接字符器
        /// </summary>
        string ConnString { get; set; }
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        DbConnection DbConnection { get; }
        /// <summary>
        /// 执行一条SQL语句
        /// </summary>
        /// <param name="command"></param>
        void Execute(Command command);
        /// <summary>
        /// 执行多条SQL语句
        /// </summary>
        /// <param name="commands"></param>
        void Execute(List<Command> commands);
        /// <summary>
        /// 执行一条SQL并返回第一行第一列的值
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        object QueryScalar(Command command);
        /// <summary>
        /// 执行一条SQL并返回
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        IDataReader QueryData(Command command);
        /// <summary>
        /// 执行一条SQL并返回DataSet
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        DataSet Query(Command command);
        /// <summary>
        /// 更新DataSet，如果DataSet中有行添加、删除或数据更新则按每条数据执行相应的SQL语句。
        /// 必须对已用Query对象查询出来的DataSet或者在Command中指定TableName。
        /// </summary>
        /// <param name="ds"></param>
        void UpdateDataSet(DataSet ds, string where = null);

        /// <summary>
        /// 得到ORM支持函数名的数据库平台版本
        /// </summary>
        /// <param name="methodName">ORM函数名</param>
        /// <param name="parameters">参数名集合</param>
        /// <returns></returns>
        string GetFunctionNameCallback(string methodName, params object[] parameters);

        /// <summary>
        /// 执行日志
        /// </summary>
        string Log { set; get; }

		DataTable FillSchema (string tableName, Command command);
    }
}
