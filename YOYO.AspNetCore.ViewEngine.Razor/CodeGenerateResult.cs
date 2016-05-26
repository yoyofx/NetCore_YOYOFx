using System.Collections.Generic;

namespace YOYO.AspNetCore.ViewEngine.Razor
{
    public class CodeGenerateResult
    {
        public bool Success { set; get; }

        public List<string> Errors { set; get; }

    }
}