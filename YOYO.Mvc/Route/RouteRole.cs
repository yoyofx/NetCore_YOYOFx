using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YOYOFx.Mvc.Route
{
    public class RouteRole
    {
        private static readonly string routeRoleMatchString = @"{(?<name>\w+)}";
        private IDictionary<string, string> routeRoleValues = new Dictionary<string, string>();
        private IDictionary<string, string> routeValues = new Dictionary<string, string>();
        private string roleString = string.Empty;

        public RouteRole(string role)
        {
            this.MapRouteValues(role);
        }

        public virtual void MapRouteValues(string role)
        {
            var matches = Regex.Matches(role, routeRoleMatchString, RegexOptions.IgnoreCase);
            if (matches != null)
            {
                foreach (Match m in matches)
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


        public virtual bool IsMatch(string url)
        {


            return true;
        }

        public IDictionary<string, string> GetRouteValues(string url)
        {
           string[] sp = url.Split('\\');
            

            return null;
        }




    }
}
