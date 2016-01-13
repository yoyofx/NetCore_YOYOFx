using System;
using System.Collections.Generic;
using System.Linq;
using YOYO.Mvc;

namespace YOYOFxMvcDemo
{
    public class Home : Controller
    {

        public dynamic Login()
        {

            return Redirect("/Home/Index");
        }


        public string Hello()
        {
            return "hello world!" + DateTime.Now.ToString();
        }

        public int Add(int a,int b)
        {
            return a + b;

        }


        public dynamic Say()
        {
            var cookie = this.Context.Request.Cookie;
            var message = this.Context.Request["m"];
            return new { HelloMessage = message };
        }


        public dynamic Index()
        {
            var cookie = this.Context.Request.Cookie;
            this.Context.Response.Cookies.Append("sessionid", Guid.NewGuid().ToString());
            var model = new List<MyUser>();
            for (int i = 0; i <= 10; i++)
                model.Add( new MyUser() { Name = "maxzhang 张磊" + i.ToString() } );

            ViewBag.Title = "My First Application Demo 哈哈";


            return View("/Views/Home.cshtml", model);
        }

    }
}
