using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.Razor.CodeGenerators;
using Microsoft.AspNetCore.Razor.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class CodeGenerateService
    {
        public GeneratorResults Generate<T>(string template)
        {
            //准备临时类名，读取模板文件和Razor代码生成器
            var class_name = "c" + Guid.NewGuid().ToString("N");
            var host = new RazorEngineHost(new CSharpRazorCodeLanguage(), () => new HtmlMarkupParser())
            {

                DefaultBaseClass = string.Format("AspNetCore.ViewEngine.Razor.TemplateBase<{0}>", typeof(T).FullName),
                DefaultClassName = class_name,
                DefaultNamespace = "YOYO.Dynamic",
                GeneratedClassContext =
                                   new GeneratedClassContext("Execute", "Write", "WriteLiteral", "WriteTo",
                                                             "WriteLiteralTo",
                                                             "YOYO.TemplateBase", new GeneratedTagHelperContext())

            };
            host.NamespaceImports.Add("System");

            var engine = new RazorTemplateEngine(host);

            var gc = engine.GenerateCode(new StringReader(template));
           
            return gc;
        }


    }
}
