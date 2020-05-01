using Mapack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCA
{
    class PCA
    {
        public List<MyImage> TrainingSet { get; set; }
        public Matrix I { get; set; }
        public Matrix I_avg { get; set; }
        public Matrix Covarience { get; set; }

        public double[] MeanVector { get; set; }
        public Bitmap AverageImage { get; set; }

        public PCA(List<MyImage> images)
        {
            this.TrainingSet = images;
            this.I = AssembleI(images);
            this.MeanVector = ComputeRowMean(I);
            this.AverageImage = ArrayToBitmap(this.MeanVector,images[0].ImgBitmap.Width, images[0].ImgBitmap.Height);

        }
        public Matrix AssembleI(List<MyImage> images)
        {
            Matrix I = new Matrix(images[0].imgVector.Length, images.Count);
            for(int k=0;k<images.Count;k++)
            {
                for(int i = 0; i < I.Rows; i++)
                    {
                        I[i, k] = images[k].imgVector[i];
                    }
            }
            return I;
        }
        public double[] ComputeRowMean(Matrix m)
        {
            double[] meanVals = new double[m.Rows];
            double sum = 0;
            for(int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    sum += m[i, j];
                }
                meanVals[i] = sum / m.Columns;
                sum = 0;
            }
            return meanVals;
        }

        public Bitmap ArrayToBitmap(double[] vector, int width,int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            //double[] vector = new double[bmp.Width * bmp.Height];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    int pixel = (int)vector[i * (bmp.Width) + j];
                    bmp.SetPixel(j, i, Color.FromArgb(255, pixel, pixel, pixel));
                }
            }
            return bmp;

            return null;
        }

        //public void ApplyMean(List<MyImage> images) sets all MyImage.meanAdjustedVector

    }
}
