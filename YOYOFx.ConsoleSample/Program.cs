using System;

namespace YOYOFx.ConsoleSample
{
    public class Application
    {
        static void Main(string[] args)
        {
            YOYOFx.Boot.Application.Run(typeof(Application),args);

            Console.ReadKey();


        }
    }
}
