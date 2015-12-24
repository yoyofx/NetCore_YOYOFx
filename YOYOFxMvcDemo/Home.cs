using System;
using System.Collections.Generic;
using System.Linq;
using YOYO.Mvc;

namespace YOYOFxMvcDemo
{
    public class Home : Controller
    {

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
            var message = this.Context.Request["m"];
            return new { HelloMessage = message };
        }


        public dynamic Index()
        {
            var model = new List<MyUser>();
            for (int i = 0; i <= 10; i++)
                model.Add( new MyUser() { Name = "maxzhang" + i.ToString() } );

            ViewBag.Title = "My First Application Demo";


            return View("/Views/Home.cshtml", model);
        }

    }
}
