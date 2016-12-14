using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMirrorInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var src = new Bitmap("D:/Shared/test.jpg"))
            using (var bmp = new Bitmap("D:/Shared/bg.jpg"))
            using (var gr = Graphics.FromImage(bmp))
            {
                var scaled = ScaleImage(src, 300, 300);
                var drawPoint = new Point(Convert.ToInt32(bmp.Width / 2 - scaled.Width / 2), Convert.ToInt32(bmp.Height / 2 - scaled.Height / 2));
                var drawSize = new Size(scaled.Width, scaled.Height);

                //gr.Clear(Color.Blue);
                gr.DrawImage(scaled, new Rectangle(drawPoint, drawSize));
                bmp.Save("d:/Shared/result.png", ImageFormat.Png);
            }

            System.Console.ReadLine();
        }

        /// <summary>
        /// Scales an image proportionally.  Returns a bitmap.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public static Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }
    }
}
