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
        private Stream _fileStream;
        private string _fileName;

        public FileResult(string fileName)
        {
            this._fileName = fileName;
        }

        public FileResult(Stream stream)
        {
            this._fileStream = stream;
        }

        public async Task ProcessAsync(IOwinContext context)
        {
            
            context.Response.Headers.ContentType = "application/octet-stream";
            context.Response.Headers.Add("Content-Disposition", "attachment; filename=" + this._fileName);
            if (this._fileStream == null)
            {
                using (Stream input = File.OpenRead(this._fileName))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;
                    while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        await context.Response.WriteAsync(buffer);
                    }

                }
            }
            else
            {
                
                //await context.Response.WriteAsync(buffer);
            }

        }
    }
}
