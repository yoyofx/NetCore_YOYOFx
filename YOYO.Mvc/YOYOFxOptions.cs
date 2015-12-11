using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc
{
    public class YOYOFxOptions
    {
        public YOYOFxOptions()
        {
            this.Bootstrapper = new DefaultBootstrapper();
        }


        public IYOYOBootstrapper Bootstrapper { set; get; }


    }
}
