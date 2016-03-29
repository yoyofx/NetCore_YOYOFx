using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MaxZhang.EasyEntities.Persistence.Provider
{
    public class StoredProcCommandBuilder
    {

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        public static IDbCommand BuildQueryCommand(IDbConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = storedProcName;
            command.CommandType = CommandType.StoredProcedure;
            foreach (IDataParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        public static IDbCommand BuildQueryCommand(IDbConnection connection, string storedProcName, Parameter[] parameters)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = storedProcName;
            command.CommandType = CommandType.StoredProcedure;
            foreach (Parameter parameter in parameters)
            {
                if (parameter != null)
                {
                    IDataParameter dataParameter = command.CreateParameter();
                    dataParameter.DbType = parameter.Type;
                    dataParameter.Direction = parameter.Direction;
                    dataParameter.ParameterName = parameter.Name;
                    dataParameter.Value = parameter.Value;

                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(dataParameter);
                }
            }

            return command;
        }



    }
}
