using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.PlatformAbstractions;

namespace YOYO.DotnetCore
{

   
    public class CaptchaImageCore
    {

        [DllImport("libcaptchaimage.so", EntryPoint = "GCaptcha")]
        public static extern void libCaptcha(string file_o, string captcha_text, int count, int width, int height, int offset, int quality, int isjpeg, int fontSize);


        [DllImport("CaptchaImage.dll", EntryPoint = "GCaptcha")]
        public static extern void GCaptcha(string file_o, string captcha_text, int count, int width, int height, int offset, int quality, int isjpeg, int fontSize);

        public string Text { set; get; }

        public int ImageWidth { set; get; }
        public int ImageHeight { set; get; }

        public int ImageOffset { set; get; }

        public int ImageQuality { set; get; }

        public int FontSize { set; get; }


        public CaptchaImageCore(int w,int h,int fontSize)
        {
            this.ImageWidth = w;
            this.ImageHeight = h;
            this.FontSize = fontSize;
            this.ImageOffset = 40;
            this.ImageQuality = 100;
            
        }

        public void Save(string fileName)
        {
            


            if (string.IsNullOrEmpty(fileName))
                throw new NullReferenceException("file name is null");
            if(string.IsNullOrEmpty(this.Text))
                throw new NullReferenceException("Text is null");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                GCaptcha(fileName, this.Text, this.Text.Length, this.ImageWidth, this.ImageHeight,
                                          this.ImageOffset, this.ImageQuality, 0, this.FontSize);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                libCaptcha(fileName, this.Text, this.Text.Length, this.ImageWidth, this.ImageHeight,
                                         this.ImageOffset, this.ImageQuality, 0, this.FontSize);
            }
        }




    }
}
