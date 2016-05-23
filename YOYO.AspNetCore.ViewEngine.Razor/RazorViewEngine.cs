using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor;
using YOYO.Mvc;
using Microsoft.AspNetCore.Razor.CodeGenerators;
using Microsoft.AspNetCore.Razor.Compilation;
using Microsoft.AspNetCore.Razor.Parser;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class RazorViewEngine : IViewEngine
    {
        public RazorViewEngine()
        {


            var host = new RazorEngineHost(new CSharpRazorCodeLanguage());


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


            throw new NotImplementedException();
        }




       



    }




}
