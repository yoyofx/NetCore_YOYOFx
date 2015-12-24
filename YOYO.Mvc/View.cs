using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc
{
    public class View
    {
        public View(string path) { Path = path; }

        public string Path { set; get; }

        public string ControllerName { set; get; }

        public string ActionName { set; get; }

        public dynamic Model { set; get; }

        public DynamicDictionary ViewBag { set; get; }

    }
}
