using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YOYO.Mvc;
using YOYO.Mvc.Filters;
using YOYO.Extensions.DI;
using Microsoft.Extensions.DependencyInjection;
using LibCaptchaImageWarp;

namespace CoreHost.Controllers
{
    public class Home : Controller
    {
        public Home(IUser user)
        {


        }


        public dynamic Login()
        {
            return View("/Views/Login.cshtml");
        }

        public dynamic UserLoginAction(string name, string password,string code)
        {
            if (name == "maxzhang" && password == "123" && code == Session["captchacode"].ToString())
            {
                this.Session["username"] = "maxzhang";
                return Redirect("/Home/Index/1");
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


        public dynamic Index(string id)
        {
            var model = new List<MyUser>();
            for (int i = 0; i <= 10; i++)
                model.Add(new MyUser() { Name = "maxzhang 张磊" + i.ToString() });

            var username = Session["username"]?.ToString();

            ViewBag.Title = "welcome" + username;


            return View("/Views/Home.cshtml", model);
        }


        public dynamic Demo()
        {
            var model = new List<MyUser>();
            for (int i = 0; i <= 10; i++)
                model.Add(new MyUser() { Name = "maxzhang 张磊" + i.ToString() });

            ViewBag.userList = model;
            return View("/Views/Home.cshtml");
        }



        public dynamic Captcha()
        {
            string fileName = Guid.NewGuid().ToString() + ".bmp";
            string filePath = HostingEnvronment.GetMapPath("/wwwroot/" + fileName);
            CaptchaImageCore image = new CaptchaImageCore(220,60,57);
            var stream = image.GetStream(filePath);
            this.Session["captchacode"] = image.Text;
            return new FileResult(filePath, "image/jpg", stream);
        }

    }

    public interface IUser
    {
        string Name { set; get; }
    }

    [ServiceDescriptor(typeof(IUser),ServiceLifetime.Transient)]
    public class MyUser : IUser
    {  
        public string Name { set; get; }

    }
}
