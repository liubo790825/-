using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace LeaRun.Application.Code
{
   public class UnicodeFontFactory:FontFactoryImp
    {
        private static readonly string arialFontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
            "arialuni.ttf");//arial unicode MS是完整的unicode字型。
        private static readonly string biktPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
          "KAIU.TTF");//标楷体

        public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color, bool cached)
        {
            BaseFont bfChiness = BaseFont.CreateFont(@"C:\Windows\Fonts\SIMSUN.TTC,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //可用Arial或标楷体，自己选一个  
            BaseFont baseFont = BaseFont.CreateFont(biktPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            return new Font(bfChiness, size, style, color);
        }

    }
}
