using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.Blog.Common
{
    public class VerifyImage
    {
        public string GenerateCheckCode()
        {
            int number;
            char code;
            string checkCode = String.Empty;

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                number = random.Next();
                code = (char)('0' + (char)(number % 10));
                //if (number % 2 == 0)
                //    code = (char)('0' + (char)(number % 10));
                //else
                //    code = (char)('A' + (char)(number % 26));

                checkCode += code.ToString();
            }
            return checkCode;
        }

        public byte[] CreateCheckCodeImage(string checkCode)
        {
            Bitmap image = new Bitmap(70, 30);
            Graphics g = Graphics.FromImage(image);
            try
            {
                Random random = new Random();
                g.Clear(Color.White);
                for (int i = 0; i < 2; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                Font font = new Font("arial", 18, FontStyle.Bold);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Black, Color.FromArgb(0, 0, 0), 1.2f, true);
                int k = 0;
                foreach (char s in checkCode)
                {
                    g.DrawString(s.ToString(), font, brush, k * 12, random.Next(5));
                    k++;
                }
                for (int i = 0; i < 80; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                //HttpContext.Current.Response.ClearContent();
                //HttpContext.Current.Response.ContentType = "image/Gif";
                //HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                return ms.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}
