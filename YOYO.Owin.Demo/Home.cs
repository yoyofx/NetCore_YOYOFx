using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YOYO.Mvc;
using YOYO.Mvc.Filters;

namespace YOYO.Owin.Demo
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Home : Controller
    {


        public dynamic Login()
        {
            return View("/Views/Login.cshtml");
        }

        public dynamic UserLoginAction(string name, string password)
        {
            if (name == "maxzhang" && password == "123")
            {
                this.Session["username"] = "maxzhang";
                return Redirect("/Home/Index");
            }
            else
                return View("/Views/Login.cshtml");

        }



        public async Task<string> Hello()
        {
            return await Task.FromResult("hello world!" + DateTime.Now.ToString());
        }

        public int Add(int a, int b)
        {
            return a + b;

        }

        [TimeStampEncrypt]
        public dynamic Say()
        {
            var cookie = this.Context.Request.Cookie;
            var message = this.Context.Request["m"];
            return new { HelloMessage = message };
        }


        public dynamic Index()
        {
            var model = new List<MyUser>();
            for (int i = 0; i <= 10; i++)
                model.Add(new MyUser() { Name = "maxzhang 张磊" + i.ToString() });

            var username = Session["username"]?.ToString();

            ViewBag.Title = "welcome" + username;


            return View("/Views/Home.cshtml", model);
        }

    }



    public class MyUser
    {
        public string Name { set; get; }

    }
}
