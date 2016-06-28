using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class TemplateLocator
    {

        public static string LoadTemplateContent(string viewName)
        {
            string templatePath = HostingEnvronment.GetMapPath(viewName);

            if (!File.Exists(templatePath)) throw new FileNotFoundException("view template file can't find.");

            string viewTemplate = null;
            using (StreamReader reader = new StreamReader(new FileStream(templatePath, FileMode.Open, FileAccess.Read), Encoding.UTF8))
            {
                viewTemplate = reader.ReadToEnd();
            }

            return viewTemplate;
        }



    }
}
