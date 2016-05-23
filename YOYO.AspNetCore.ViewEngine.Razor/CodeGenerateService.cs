using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.Razor.CodeGenerators;
using Microsoft.AspNetCore.Razor.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class CodeGenerateService
    {
        public string Generate<T>(string template_path)
        {
            //准备临时类名，读取模板文件和Razor代码生成器
            var class_name = "c" + Guid.NewGuid().ToString("N");
            var base_type = typeof(TemplateBase<>).MakeGenericType(typeof(T));
            //var template = File.ReadAllText(template_path);

            var host = new RazorEngineHost(new CSharpRazorCodeLanguage(), () => new HtmlMarkupParser())
            {

                DefaultBaseClass = base_type.FullName,
                DefaultClassName = class_name,
                DefaultNamespace = "YourNameSpace.dynamic",
                GeneratedClassContext =
                                   new GeneratedClassContext("Execute", "Write", "WriteLiteral", "WriteTo",
                                                             "WriteLiteralTo",
                                                             "YOYO.TemplateBase", new GeneratedTagHelperContext())

            };
            host.NamespaceImports.Add("System");
            host.NamespaceImports.Add("YOYO");

            var engine = new RazorTemplateEngine(host);



            var gc = engine.GenerateCode(new StringReader(template_path));

            return gc.GeneratedCode;
        }


    }
}
