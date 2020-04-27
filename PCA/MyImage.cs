using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCA
{
    class MyImage
    {
        public Bitmap ImgBitmap { get; set; }
        public String Filename { get; set; }
        public String Id { get; set; }
        public double[] imgVector;
        public double[] meanAdjustedVector;
        public double[] projectedImgVector;

        public MyImage(Bitmap bmp, string filename)
        {
            this.ImgBitmap = bmp;
            this.Filename = filename;
            this.imgVector = BitmapToArray(this.ImgBitmap);
        }

        public double[] BitmapToArray(Bitmap bmp)
        {
            double[] vector = new double[bmp.Width*bmp.Height];
            for(int i = 0; i < bmp.Height; i++)
            {
                for(int j = 0; j < bmp.Width; j++)
                {
                    vector[i * (bmp.Width - 1) + j] = bmp.GetPixel(i, j).R;
                }
            }
            return vector;

        }




    }
}
