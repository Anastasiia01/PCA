using Mapack;
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
        public Matrix imgVector; // 10000 x 1
        public Matrix meanAdjustedVector;
        public double[] projectedImgVector;

        public MyImage(Bitmap bmp, string filename)
        {
            this.ImgBitmap = bmp;
            this.Filename = filename;
            this.imgVector = BitmapToMatrix(this.ImgBitmap);
            //this.meanAdjustedVector=
        }

        public Matrix BitmapToArray(Bitmap bmp)
        {
            double[][]vector = new double[2][3];

            /*for(int i = 0; i < bmp.Height; i++)
            {
                for(int j = 0; j < bmp.Width; j++)
                {
                    vector.data[i * (bmp.Width - 1) + j,1] = bmp.GetPixel(i, j).R;
                
            }*/
            return vector;

        }




    }
}
