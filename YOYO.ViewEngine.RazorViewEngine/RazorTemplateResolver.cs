using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Templating;
using YOYO.Mvc;

namespace YOYO.ViewEngine.RazorViewEngine
{



    public class RazorTemplateManager : ITemplateManager
    {
        public ITemplateSource Resolve(ITemplateKey key)
        {
            string templatePath = HostingEnvronment.GetMapPath(key.Name);
            string templateContent = null;
            using (StreamReader reader = new StreamReader(new FileStream(templatePath, FileMode.Open, FileAccess.Read), Encoding.UTF8))
            {
                templateContent = reader.ReadToEnd();
            }


            return new LoadedTemplateSource(templateContent, null);
           
        }

        public ITemplateKey GetKey(string name, ResolveType resolveType, ITemplateKey context)
        {
    
            return new NameOnlyTemplateKey(name, resolveType, context);
            // template is specified by full path
            //return new FullPathTemplateKey(name, fullPath, resolveType, context);
        }

        public void AddDynamic(ITemplateKey key, ITemplateSource source)
        {
            // You can disable dynamic templates completely. 
            // This just means all convenience methods (Compile and RunCompile) with
            // a TemplateSource will no longer work (they are not really needed anyway).
            throw new NotImplementedException("dynamic templates are not supported!");
        }
    }


}
