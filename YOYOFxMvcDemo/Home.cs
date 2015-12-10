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


    }
}
