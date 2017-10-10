using System;

namespace YOYOFx.Boot
{
    public class Application : IApplication
    {
        private static readonly IApplication application = new Application();

        public IApplication Current { get; } = application;




        public IApplication Configure(string[] args)
        {


            return this;
        }

        private void PrintLogo()
        {
            var sb = new System.Text.StringBuilder(698);
            sb.AppendLine(@"                                                                    ");
            sb.AppendLine(@"      ___    ___ ________      ___    ___ ________  ________ ___    ___ ");
            sb.AppendLine(@"     |\  \  /  /|\   __  \    |\  \  /  /|\   __  \|\  _____\\  \  /  /|");
            sb.AppendLine(@"     \ \  \/  / | \  \|\  \   \ \  \/  / | \  \|\  \ \  \__/\ \  \/  / /");
            sb.AppendLine(@"      \ \    / / \ \  \\\  \   \ \    / / \ \  \\\  \ \   __\\ \    / / ");
            sb.AppendLine(@"       \/  /  /   \ \  \\\  \   \/  /  /   \ \  \\\  \ \  \_| /     \/  ");
            sb.AppendLine(@"     __/  / /      \ \_______\__/  / /      \ \_______\ \__\ /  /\   \  ");
            sb.AppendLine(@"    |\___/ /        \|_______|\___/ /        \|_______|\|__|/__/ /\ __\ ");
            sb.AppendLine(@"    \|___|/                  \|___|/                        |__|/ \|__| ");
            sb.AppendLine(@"                                                                    ");
            sb.AppendLine(@"    :: YOYOFx Boot ::                                   <v2.0.1.RELEASE>");

            Console.Write(sb.ToString());


        }



        public static void Run(Type applicationType,string[] args)
        {
            application.Configure(args);
            application.Start(args);

            //throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Start(string[] args)
        {
            this.PrintLogo();
        }
    }
}
