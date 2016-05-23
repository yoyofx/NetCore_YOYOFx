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
        public  static void Main(string[] args)
        {

            RazorViewEngine engine = new RazorViewEngine();
            UserInfo user = new UserInfo() { Name = "Hello world" };

            string result =  engine.RenderViewAsync(null, "<p>@Model.Name</p><mydiv name=\"hello tag\"></mydiv>", user, null).Result;


        }





    }

    public class UserInfo
    {
        public string Name { set; get; }
    }


}
