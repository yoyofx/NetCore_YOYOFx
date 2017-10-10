using System;

namespace YOYOFx.Boot
{
    public interface IApplication
    {
        IApplication Configure(string[] args);
        void Start(string[] args);
        void Stop();
    }
}