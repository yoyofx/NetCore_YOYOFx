using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class RazorView : IRazorView
    {
        public string Content { private set;get; }


        public RazorViewTemplate Template { private set; get; }

        protected ITemplateService TemplateService { set; get; }


        public RazorView(RazorViewTemplate template, ITemplateService templateService)
        {
            this.Template = template;
            this.TemplateService = templateService;
        }



        public void Render(TemplateContext context)
        {

            //not set writer by context , i have result of the template.
            this.Template.SetModel(context.Model, context.ViewBag);
            this.Template.Execute().Wait();


            if (!string.IsNullOrEmpty(this.Template.Layout))
            {

                var layoutTemplateView = this.TemplateService.GetTemplate(this.Template.Layout, null);

                context.IsRenderLayout = true;

                layoutTemplateView.Template.Writer = context.Writer;

                //RenderBody is this template result ;
                layoutTemplateView.Template.RenderBody = () => this.Template.Result; 

                layoutTemplateView.Template.SetModel(context.Model, context.ViewBag);

                layoutTemplateView.Render(context);

            }
            else
            {
                context.Writer = this.Template.Writer;
            }
 



        }


    }
}
