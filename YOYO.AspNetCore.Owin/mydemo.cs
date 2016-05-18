using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.Owin
{
    public class mydemo
    {
        public mydemo()
        {
            string hello = "";

            Console.WriteLine(hello);
        }



        public void APP_Main()
        {

            string hello = string.Empty;



#if NET451
            hello = "hello dotnet 4.5.1";

#endif

#if NETCOREAPP1_0
            hello = "hello dotnet core";
#endif


            Console.WriteLine(hello);
        }



    }
}
