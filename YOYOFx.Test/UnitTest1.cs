using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YOYOFx.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRouteUrl()
        {
            string roleUrl = "/{controller}/{action}/{id}";
            string matchString = @"{(?<name>\w+)}";

            IDictionary<string,string> routeRoleValues = new  Dictionary<string, string>();


            var matches = Regex.Matches(roleUrl,  matchString, RegexOptions.IgnoreCase);
            if(matches!=null)
            {
                foreach(Match m in matches)
                {
                    if (m.Success)
                    {
                        string value = m.Groups["name"].Value.ToLower();
                        if (value == "controller" || value == "action")
                            routeRoleValues.Add(value, value);
                        else
                            routeRoleValues.Add("params", value);

                    }

                }
            }





        }
    }
}
