using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin.Pipeline;

namespace YOYO.Owin
{
    public class OwinMiddleware : PipelineComponent
    {

        public override async Task Invoke(IOwinContext context, AppFunc next)
        {
            

        }

    }
}
