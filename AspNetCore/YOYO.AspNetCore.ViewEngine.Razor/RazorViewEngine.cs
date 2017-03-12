using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Mvc;
using YOYO.AspNetCore.Owin;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class RazorViewEngine : IViewEngine
    {

        private ITemplateService templateService = new DefaultTemplateService();

        public RenderTemplateContext RenderContext { private set; get; }

        public string ExtensionName {  get { return ".cshtml"; }  }

        public string RenderView(YOYO.AspNetCore.Owin.IOwinContext httpContext, string viewName, object model, DynamicDictionary viewbag)
        {
            using (var context = new RenderTemplateContext() {
                                            TemplateName = viewName,
                                            Path = httpContext.Request.Path,
                                            Model = model,
                                            ModelType = model?.GetType(),
                                            ViewBag = viewbag } )
            {

                IRazorView view = templateService.GetTemplate(context);
                view.Render();
                this.RenderContext = context;
                return context.ToString();
            }
        }


        public  Task<string> RenderViewAsync(IOwinContext context, string viewName, object model, DynamicDictionary viewbag)
        {
            return Task.Factory.StartNew(() => RenderView(context, viewName, model, viewbag) );
        }

       



    }




}
