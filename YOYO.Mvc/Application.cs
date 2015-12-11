using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc
{
    public class Application
    {
        private static object lockobject = new object();
        private static Application _app;

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


        public  YOYOFxOptions Options {private set; get; }


    }
}
