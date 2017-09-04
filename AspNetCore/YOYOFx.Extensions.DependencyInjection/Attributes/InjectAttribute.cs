using System;
using System.Collections.Generic;
using System.Text;

namespace YOYOFx.Extensions.DependencyInjection.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]

    public class InjectAttribute : Attribute
    {
    }
}
