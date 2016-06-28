using System;

namespace MaxZhang.EasyEntities.Persistence.Provider.SQLServer
{
    /// <summary>
    /// SQL中支持的函数
    /// </summary>
    public class SQLMethod
    {
        /// <summary>
        /// 服务器当前时间
        /// </summary>
        /// <returns></returns>
        static public DateTime GetDate()
        {
            return new DateTime();
        }
        /// <summary>
        /// 字段为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(object obj)
        {
            return obj == null;
        }
        /// <summary>
        /// 字段不为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNull(object obj)
        {
            return obj != null;
        }

    }
}
