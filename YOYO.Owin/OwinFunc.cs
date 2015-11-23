using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Owin
{
    /// <summary>
    /// owin app func 应用入口函数
    /// </summary>
    /// <param name="env">环境字典</param>
    /// <returns>异步任务</returns>
    public delegate Task AppFunc(IDictionary<String, object> env);

    /// <summary>
    /// Owin 中间件函数
    /// </summary>
    /// <param name="env">环境字典</param>
    /// <param name="appfunc">上一个应用或中间件函数</param>
    /// <returns>异步任务</returns>
    public delegate Task MiddlewareFunc(IDictionary<string, object> env, AppFunc appfunc);
    
    
}
