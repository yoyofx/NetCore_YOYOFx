using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class DefaultTemplateService : ITemplateService
    {
        private static IDictionary<string, IRazorView> viewCache = new ConcurrentDictionary<string, IRazorView>();


        public IRazorView GetTemplate(RenderTemplateContext context)
        {
            IRazorView view = default(IRazorView);

            if (!viewCache.TryGetValue(context.TemplateName, out view))
            {
                string viewTemplate = TemplateLocator.LoadTemplateContent(context.TemplateName);

                IRazorCompileService complileService = new RoslynCompileService();

                CodeGenerateService codeGenerater = new CodeGenerateService();
                var generateResult = codeGenerater.Generate(context.ModelType, viewTemplate);


                if (context.GenerateResult != null)
                {
                    context.GenerateResult.Success = generateResult.Success;
                    context.GenerateResult.Errors.AddRange(
                        generateResult.ParserErrors.Select(pe=>pe.ToString()));
                }
                else
                {
                    context.GenerateResult = new CodeGenerateResult() {
                                        Success = generateResult.Success,
                                        Errors = generateResult. ParserErrors.
                                                    Select(pe => pe.ToString()).ToList()  };
                }

                RoslynCompileService service = new RoslynCompileService();
                var type = service.Compile(generateResult.GeneratedCode);

                if (context.BuildResult != null)
                {
                    context.BuildResult.Success = service.CompileResult.Success;
                    context.BuildResult.Errors.AddRange(service.CompileResult.Errors);
                }
                else
                {
                    context.BuildResult = service.CompileResult;
                }

                if (type == null) return null;

                var tb = (RazorViewTemplate)Activator.CreateInstance(type);

                view = new RazorView(tb, this);
                viewCache.Add(context.TemplateName,view);

            }
            return view;
        }
    }
}
