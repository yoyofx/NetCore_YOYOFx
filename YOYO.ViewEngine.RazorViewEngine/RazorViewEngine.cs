using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using YOYO.Mvc;
using YOYO.Owin;

namespace YOYO.ViewEngine.RazorViewEngine
{
    public class RazorViewEngine : IViewEngine
    {

        public RazorViewEngine()
        {

        }

        public string ExtensionName
        {
            get
            {
                return "cshtml";
            }
        }

        public string RenderView(IOwinContext context, string viewName, object model)
        {
            string result = string.Empty;

            var config = new TemplateServiceConfiguration();


            using (var service = RazorEngineService.Create(config))
            {
                string templatePath = HostingEnvronment.GetMapPath(viewName);
                if (!File.Exists(templatePath))
                    throw new FileNotFoundException("not found view template . " + viewName);

                using (StreamReader reader = new StreamReader(new FileStream(templatePath, FileMode.Open), Encoding.UTF8))
                {
                    string templateContent = reader.ReadToEnd();

                    result = service.RunCompile(templateContent, viewName, null, model, null);
                }

                return result;
            }
            
        }
    }
}
