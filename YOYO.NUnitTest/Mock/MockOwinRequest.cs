using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.NUnitTest.Mock
{
   internal  class MockOwinRequest : IOwinRequest
    {
        public MockOwinRequest(string path,string httpmethod)
        {
            this.Path = path;
            this.Method = httpmethod;
        }

        public string this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Stream Body
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public RequestCookieCollection Cookie
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IFormData Form
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Uri FullUri
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRequestHeaders Headers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Method
        {
            set; get;
        }

        public string Path
        {
            set; get;
        }

        public string PathBase
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Protocol
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public QueryString QueryString
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IDictionary<string, string> RouteValues
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Scheme
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IPrincipal User
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public T GetEnvironmentValue<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void SetEnvironmentValue<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}
