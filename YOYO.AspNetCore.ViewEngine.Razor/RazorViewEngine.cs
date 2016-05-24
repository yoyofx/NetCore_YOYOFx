using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc;
using YOYO.Owin;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class RazorViewEngine : IViewEngine
    {
        public RazorViewEngine()
        {

        }


        ~RazorViewEngine()
        {
            //.Dispose();
        }

        public string ExtensionName
        {
            get
            {
                return ".cshtml";
            }
        }

        public string RenderView(YOYO.Owin.IOwinContext context, string viewName, object model, DynamicDictionary viewbag)
        {

            string templatePath = HostingEnvronment.GetMapPath(viewName);

            if(!File.Exists(templatePath)) return "";

            string viewTemplate = null;
            using (StreamReader reader = new StreamReader(new FileStream(templatePath, FileMode.Open, FileAccess.Read), Encoding.UTF8))
            {
                viewTemplate = reader.ReadToEnd();
            }


            IRazorCompileService complileService = new RoslynCompileService();

            CodeGenerateService codeGenerater = new CodeGenerateService();
            string code = codeGenerater.Generate(model?.GetType(), viewTemplate).GeneratedCode;

            RoslynCompileService service = new RoslynCompileService();
            var type = service.Compile(code);

            if (type == null) return "";
            
            var tb = (RazorViewTemplate)Activator.CreateInstance(type);
            tb.SetModel(model,viewbag);
            tb.Execute().Wait();
            return tb.Result;
           
        }


        public  Task<string> RenderViewAsync(IOwinContext context, string viewName, object model, DynamicDictionary viewbag)
        {
            return Task.Factory.StartNew(() => RenderView(context, viewName, model, viewbag) );
        }

       



    }




}
