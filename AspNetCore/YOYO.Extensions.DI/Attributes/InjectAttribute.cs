using System;
using System.Collections.Generic;
using System.Text;

namespace YOYO.Extensions.DI.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]

    public class InjectAttribute : Attribute
    {
    }
}
