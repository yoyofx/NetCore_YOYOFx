using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YOYO.AspNetCore.ViewEngine.Razor;
namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            RazorViewEngine.Compile<UserInfo>("<p>@Model.Name</p>");

        }





    }

    public class UserInfo
    {
        public string Name { set; get; }
    }


}
