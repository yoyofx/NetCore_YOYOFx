using System;
using System.Collections.Generic;
using Microsoft.Owin.Builder;
using System.Threading.Tasks;
using YOYOFxMvcDemo;

namespace TinyfoxAdapter
{

    public class Adapter
    {
       private  static Func<IDictionary<string, object>, Task> _owinApp;
   
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public  Adapter()
        {
         
            var builder = new AppBuilder();
            var startup = new Startup();
            startup.Configuration(builder);
            _owinApp = builder.Build();
       

        }


        /// <summary>
        /// *** JWS所需要的关键函数 ***
        /// </summary>
        /// <param name="env">新请求的环境字典，具体内容参见OWIN标准</param>
        /// <returns>返回一个正在运行或已经完成的任务</returns>
        public Task OwinMain(IDictionary<string, object> env)
        {
            //如果为空
            if (_owinApp == null) return null;

            //将请求交给Microsoft.Owin处理
            return _owinApp(env);
        }


    } //end class


} //end namespace
