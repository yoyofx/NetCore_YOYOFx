using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class CompileResult
    {
        public bool Success { set; get; }

        public List<string> Errors { set; get; }


    }
}
