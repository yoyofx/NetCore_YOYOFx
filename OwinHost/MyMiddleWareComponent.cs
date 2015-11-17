using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinHost
{

    using System.IO;
    using YOYO.Owin;

    public class MyMiddleWareComponent : PipelineComponent
    {
        public override async Task Do(IDictionary<string, object> requestEnvironment)
        {
            var response = requestEnvironment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                await writer.WriteAsync("<h1>Hello from My First Middleware</h1>");
            }
        }

    }
}
