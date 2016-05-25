using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class DefaultTemplateService : ITemplateService
    {
        public IRazorView GetTemplate(string name , Type modelType = null)
        {
            string viewTemplate = TemplateLocator.LoadTemplateContent(name);

            IRazorCompileService complileService = new RoslynCompileService();

            CodeGenerateService codeGenerater = new CodeGenerateService();
            string code = codeGenerater.Generate(modelType, viewTemplate).GeneratedCode;

            RoslynCompileService service = new RoslynCompileService();
            var type = service.Compile(code);

            if (type == null) return null;

            var tb = (RazorViewTemplate)Activator.CreateInstance(type);

            return new RazorView(tb,this);
        }
    }
}
