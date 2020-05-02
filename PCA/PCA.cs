﻿using Mapack;
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

        public int[] MeanVector { get; set; }
        //public Bitmap AverageImage { get; set; }

        public PCA(List<MyImage> images)
        {
            this.TrainingSet = images;
            this.I = AssembleI(images);
            this.MeanVector = ComputeRowMean(I);
            this.ApplyMean(images);
            this.I_avg = this.MeanAdjust(I);
            this.Covarience = this.ComputeCov(I_avg);

            //this.AverageImage = ArrayToBitmap(this.MeanVector,images[0].ImgBitmap.Width, images[0].ImgBitmap.Height);

        }
        public Matrix AssembleI(List<MyImage> images)
        {
            Matrix I = new Matrix(images[0].imgVector.Length, images.Count);
            for(int k=0;k<I.Columns;k++)
            {
                for(int i = 0; i < I.Rows; i++)
                    {
                        I[i, k] = images[k].imgVector[i];
                    }
            }
            return I;
        }
        public int[] ComputeRowMean(Matrix m)
        {
            int[] meanVals = new int[m.Rows];
            double sum = 0;
            for(int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    sum += m[i, j];
                }
                meanVals[i] = (int)sum / m.Columns;
                sum = 0;
            }
            return meanVals;
        }

        public Bitmap ArrayToBitmap(int[] vector, int width,int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    int pixel = vector[i * (bmp.Width) + j];
                    bmp.SetPixel(j, i, Color.FromArgb(pixel, pixel, pixel));
                }
            }
            return bmp;
        }

        public void ApplyMean(List<MyImage> images)// sets all MyImage.meanAdjustedVector
        {
            foreach(MyImage img in images)
            {
                img.meanAdjustedVector = MeanAdjust(img.imgVector);
            }
        }



        public int[] MeanAdjust(int[] vector)
        {
            int[] adjusted = new int[vector.Length];
            try
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    adjusted[i] = vector[i] - this.MeanVector[i];
                }                
            }
            catch (Exception)
            {
                Console.Write("Mean and given vector have different dimensions");
            }
            return adjusted;
        }

        public Matrix MeanAdjust(Matrix m)
        {
            Matrix adjusted = new Matrix(m.Rows,m.Columns);
            try
            {
                for (int j = 0; j < adjusted.Columns; j++) 
                {
                    for (int i = 0; i < adjusted.Rows; i++)
                    {
                        adjusted[i,j] = m[i,j] - this.MeanVector[i];
                    }
                }
                
            }
            catch (Exception)
            {
                Console.Write("Mean and given matrix.Rows have different dimensions");
            }
            return adjusted;
        }

        public int[] AdjustToDisplay(int[]vector)
        {
            int[] toDisplay = new int[vector.Length];
            try
            {
                int min = vector.Min();
                int max = vector.Max();
                int denom = max - min;
                for (int i = 0; i < vector.Length; i++)
                {
                    toDisplay[i] = (int)((vector[i] - min) * 255 / denom);
                }
            }
            catch (Exception){
                Console.Write("Given array is empty");
            }
            return toDisplay;
        }

        public Matrix ComputeCov(Matrix m)
        {
            Matrix Covarience;
            Matrix mTranspose = m.Transpose();
            if (m.Rows < m.Columns)
            {
                Covarience = m * mTranspose;
            }
            else
            {
                Covarience = mTranspose*m;
            }
            return Covarience;
        }

    }
}
