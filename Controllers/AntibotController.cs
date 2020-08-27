using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewDawnWeb.Controllers
{
    [Route("ItemShopGame")]
    public class AntibotController : Controller
    {
        [HttpGet]
        public IActionResult Index(string userid,int servernum,string charactername)
        {
            return View("View1",new NewDawnWeb.Models.AntibotModel() { Character=charactername,Username=userid,
            Captcha=GetCaptcha(5)
            });
        }
        private static byte[] BitmapToBytes(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private string GetCaptcha(int length)
        {

            Random random = new Random((int)DateTime.Now.Ticks);

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            Bitmap img = new Bitmap(310, 100);
        
            Graphics GFX = Graphics.FromImage(img);
            FontStyle style = FontStyle.Italic | FontStyle.Strikeout | FontStyle.Underline;
            Font font = new Font("Arial", 50f, style);
            GFX.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            GFX.FillRectangle(Brushes.LightBlue, 0, 0, img.Width, img.Height);
            GFX.DrawString(randomString, font, Brushes.CornflowerBlue, new Point(0, 0));
            GFX.DrawLine(new Pen(Brushes.CornflowerBlue,3), new Point(0, random.Next()%100), new Point(310, random.Next() % 100));
            GFX.DrawLine(new Pen(Brushes.CornflowerBlue,4), new Point(0, random.Next() % 100), new Point(310, random.Next() % 100));
            return Convert.ToBase64String(BitmapToBytes(img));
        }
    }
}