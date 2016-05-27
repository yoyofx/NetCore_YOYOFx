using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class RazorView : IRazorView
    {
        public RazorViewTemplate Template { private set; get; }

        protected ITemplateService TemplateService { set; get; }


        public RazorView(RazorViewTemplate template, ITemplateService templateService , RenderTemplateContext context)
        {
            this.Template = template;
            this.TemplateService = templateService;
            this.Context = context;
        }

        protected RenderTemplateContext Context { set; get; }

        public void Render()
        {
            //not set writer by context , i have result of the template.
            this.Template.SetModel(Context.Model, Context.ViewBag);
            this.Template.Execute().Wait();


            if (!string.IsNullOrEmpty(this.Template.Layout))
            {

                using (var layoutContext = new RenderTemplateContext() {
                                                TemplateName = this.Template.Layout,
                                                ModelType = null, ViewBag = Context.ViewBag })
                {

                    var layoutTemplateView = this.TemplateService.GetTemplate(layoutContext);

                    Context.IsRenderLayout = true;


                    //RenderBody is this template result ;
                    layoutTemplateView.Template.RenderBody = () => this.Template.Result;

                    layoutTemplateView.Template.SetModel(null, Context.ViewBag);

                    layoutTemplateView.Render();

                    Context.Result = layoutTemplateView.Template.Result;

                }

            }

        }

        public void SetContext(RenderTemplateContext context)
        {
            this.Context = null;
            this.Context = context;
            this.Template.Writer = context.Writer;

        }
    }
}
