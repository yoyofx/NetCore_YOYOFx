using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using YOYO.AspNetCore.ViewEngine.Razor;
namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CodeGenerateService codeGenerater = new CodeGenerateService();
            string code = codeGenerater.Generate<UserInfo>("<p>@Model.Name</p>").GeneratedCode;

            RoslynCompileService service = new RoslynCompileService();
            var type = service.Compile(code);

            var tb = (TemplateBase)Activator.CreateInstance(type);
            tb.Execute();


        }





    }

    public class UserInfo
    {
        public string Name { set; get; }
    }


}
