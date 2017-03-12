using System.Collections.Generic;

namespace YOYO.AspNetCore.Owin
{
    public interface IFormData
    {
        IList<IPostedFile> Files { get; }

        bool IsValid { get; }

        string this[string name] { get; }

        IDictionary<string, string> Values { get; }
    }
}