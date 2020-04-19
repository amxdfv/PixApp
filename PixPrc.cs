using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixApp
{
    class PixPrc
    {

        public Bitmap ImgProc(Bitmap picture, int itr)
        {
            
            Bitmap pic_one = picture;
            

            for (int i = 0; i < itr; i = i + 1)
            {
                int height = pic_one.Height;
                int width = pic_one.Width;
                Bitmap pic_f = new Bitmap(width / 2, height / 2);
                for (int y = 0; y < height / 2; y = y + 1)
                {
                    for (int x = 0; x < width / 2; x = x + 1)
                    {
                        int x1 = 2 * x;
                        int y1 = 2 * y;
                        int r = (pic_one.GetPixel(x1, y1).R + pic_one.GetPixel(x1 + 1, y1).R
                            + pic_one.GetPixel(x1, y1 + 1).R + pic_one.GetPixel(x1 + 1, y1 + 1).R) / 4;
                        int g = (pic_one.GetPixel(x1, y1).G + pic_one.GetPixel(x1 + 1, y1).G
                            + pic_one.GetPixel(x1, y1 + 1).G + pic_one.GetPixel(x1 + 1, y1 + 1).G) / 4;
                        int b = (picture.GetPixel(x1, y).B + pic_one.GetPixel(x1 + 1, y).B
                            + pic_one.GetPixel(x1, y1 + 1).B + pic_one.GetPixel(x1 + 1, y1 + 1).B) / 4;
                        int a = (picture.GetPixel(x1, y).A + pic_one.GetPixel(x1 + 1, y).A
                            + pic_one.GetPixel(x1, y1 + 1).A + pic_one.GetPixel(x1 + 1, y1 + 1).A) / 4;
                        Color clr = Color.FromArgb(a, r, g, b);
                        pic_f.SetPixel(x, y, clr);
                    }
                }
                pic_one = pic_f;
            }
            return pic_one;

        }

    }
}
