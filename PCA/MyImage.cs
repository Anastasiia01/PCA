﻿using System;
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
        public int Id { get; set; }
        public int[] imgVector; // 10000 x 1
        public double[] meanAdjustedVector;
        public double[] projectedCoefVector;//1 x reduced_dimensionsx
        public double[] ldaProjectionCoef;
        

        public MyImage(Bitmap bmp, string filename)
        {
            this.ImgBitmap = bmp;
            this.Filename = filename;
            this.imgVector = BitmapToArray(this.ImgBitmap);
            int found = Filename.IndexOf("_");
            this.Id= Int32.Parse(Filename.Substring(1,found-1));//substring(start,length)
        }

        public int[] BitmapToArray(Bitmap bmp)
        {
            int[] vector = new int[bmp.Width * bmp.Height];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    vector[i * (bmp.Width) + j] = bmp.GetPixel(j, i).R;
                }
            }
            return vector;
        }


    }
}
