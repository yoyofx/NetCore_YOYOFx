using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc
{
    public class FileResult : IActionResult
    {
        private MemoryStream _fileStream;
        private string _fileName;
        private string _contentType;
        public FileResult(string fileName,string contentType)
        {
            this._fileName = fileName;
            this._contentType = contentType;
        }

        public FileResult(string fileName, string contentType,MemoryStream stream) : this(fileName,contentType)
        {
            this._fileStream = stream;
        }

        public async Task ProcessAsync(IOwinContext context)
        {
            context.Response.Headers.ContentType = _contentType;
            string fileName = System.IO.Path.GetFileName(this._fileName);
            context.Response.Headers.Add("Content-Disposition", "attachment; filename=" + fileName);

            if (this._fileStream == null)
            {
                using (Stream input = File.OpenRead(this._fileName))
                {
                    context.Response.Headers.ContentLength = input.Length;
                    byte[] buffer = new byte[8192];
                    int bytesRead;
                    while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        await context.Response.WriteAsync(buffer, buffer.Length);
                    }

                }
            }
            else
            {
                long length = this._fileStream.Length;
                context.Response.Headers.ContentLength = length;
                await context.Response.WriteAsync(this._fileStream.ToArray(),(int)length);
                this._fileStream.Dispose();
            }

        }
    }
}
