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




        public static Type Compile<T>(string template_path)
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
                                                             "YourNameSpace.TemplateBase",new GeneratedTagHelperContext())

            };
            host.NamespaceImports.Add("System");
            host.NamespaceImports.Add("YourNameSpaces");

            var engine = new RazorTemplateEngine(host);



            var gc = engine.GenerateCode(new StringReader(template_path));

            //编译成功后， 返回编译后的动态Type
            return null;

        }




    }




    public abstract class TemplateBase
    {
        public string Layout { get; set; }
 
        public Func<string> RenderBody { get; set; }
        public string Path { get; internal set; }
        public string Result { get { return Writer.ToString(); } }

        protected TemplateBase()
        {
        }

        public TextWriter Writer
        {
            get
            {
                if (writer == null)
                {
                    writer = new StringWriter();
                }
                return writer;
            }
            set
            {
                writer = value;
            }
        }

        private TextWriter writer;

        public void Clear()
        {
            Writer.Flush();
        }

        public virtual void Execute() { }

        public void Write(object @object)
        {
            if (@object == null)
            {
                return;
            }
            Writer.Write(@object);
        }

        public void WriteLiteral(string @string)
        {
            if (@string == null)
            {
                return;
            }
            Writer.Write(@string);
        }

        public static void WriteLiteralTo(TextWriter writer, string literal)
        {
            if (literal == null)
            {
                return;
            }
            writer.Write(literal);
        }

        public static void WriteTo(TextWriter writer, object obj)
        {
            if (obj == null)
            {
                return;
            }
            writer.Write(obj);
        }
    }
    public abstract class TemplateBase<T> : TemplateBase
    {
        public T Model { get; set; }
    }
}
