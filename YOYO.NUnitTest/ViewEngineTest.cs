using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using YOYO.Mvc;
using YOYO.ViewEngine.RazorViewEngine;

namespace YOYO.NUnitTest
{
    
	[TestFixture]
    public class ViewEngineTest
    {
        [Test]
        public void TestRazorViewEngine()
        {
            IViewEngine engine = new RazorViewEngine();

            //engine.RenderView(“”，“”，)




        }


    }
}
