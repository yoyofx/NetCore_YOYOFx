using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Mvc.ResponseProcessor;


namespace YOYO.AspNetCore.Mvc
{
    public class Application
    {
        private static object lockobject = new object();
        private static Application _app;

        public Application()
        {

        }


        public static Application CurrentApplication
        {
            get
            {
                lock(lockobject)
                {
                    if (_app == null)
                        _app = new Application();
                }
                return _app;

            }
        }

        public void SetOptions(YOYOFxOptions options)
        {
            this.Options = options;
        }


        public IServiceProvider ServiceProvider { set; get; }



        public  YOYOFxOptions Options {private set; get; }


    }
}
