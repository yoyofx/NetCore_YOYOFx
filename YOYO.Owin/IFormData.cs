using System.Collections.Generic;

namespace YOYO.Owin
{
    internal interface IFormData
    {
        IList<IPostedFile> Files { get; }

        bool IsValid { get; }

        string this[string name] { get; }

        IDictionary<string, string> Values { get; }
    }
}