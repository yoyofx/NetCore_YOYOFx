using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YOYO.AspNetCore.ViewEngine.Razor;
using YOYO.AspNetCore.Mvc;

namespace YOYO.AspNetCore.ViewEngine.Razor
{

    public abstract class RazorViewTemplate<T> : RazorViewTemplate
    {
        public T Model { private set; get; }

       


        public override void SetModel(object model, DynamicDictionary viewbag = null)
        {
            this.Model = (T)model;
            base.SetModel(model, viewbag);
        }

    }
}
