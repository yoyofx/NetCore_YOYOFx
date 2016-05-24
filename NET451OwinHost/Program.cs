using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET451OwinHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://*:9001"))
            {
                Console.WriteLine("Press [enter] to quit......");
                Console.ReadLine();
            }



        }
    }
}
