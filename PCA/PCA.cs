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
        public int ReducedDim {get;set;}
        public List<MyImage> TrainingSet { get; set; }
        public Matrix I { get; set; }
        public IMatrix I_avg { get; set; }
        public IMatrix Covarience { get; set; }

        public IMatrix Evecs { get; set; }

        public IMatrix EV { get; set; }

        public IMatrix EF { get; set; }

        public double[][] Top5EF;
        public double[] Evals { get; set; }

        public double[] MeanVector { get; set; }

        public PCA(List<MyImage> images, int reduced_dim)
        {
            this.TrainingSet = images;
            this.ReducedDim = reduced_dim;// 30 in our case

        }

        public void Train()
        {
            this.I = AssembleI(this.TrainingSet);
            this.MeanVector = ComputeRowMean(I);
            this.ApplyMean(this.TrainingSet);
            this.I_avg = this.MeanAdjust(I);
            this.Covarience = this.ComputeCov(I_avg);
            IEigenvalueDecomposition eigen = Covarience.GetEigenvalueDecomposition();
            this.Evecs = new Matrix(Covarience.Rows, Covarience.Columns);//Covarience.Rows = Covarience.Columns
            this.Evals = new double[Covarience.Rows];
            this.Evecs = eigen.EigenvectorMatrix;
            this.Evals = eigen.RealEigenvalues;
            //Reduce to top eigen vectors, first sort by eigen values and get top indices, then asseble them into EV
            //  int[] topIndices= this.ReduceDim(Evecs, Evals, ReducedDim);
            //  this.EV = this.GetTopEVecs(Evecs, topIndices);
            //Since our GetEigenvalueDecomposition() returns vectors in order of ascending eigen values,
            //we can use last ReducedDim columns of EigenVectorMatrix
            this.EV = Evecs.Submatrix(0, Evecs.Rows-1, Evecs.Columns - ReducedDim, Evecs.Columns - 1);//reduce to 30 top eigen vectors
            NormalizeVectors(EV);
            if (I_avg.Rows > I_avg.Columns)
            {
                this.EF = I_avg.Multiply(EV);
            }
            else
            {
                this.EF = EV;
            }
            this.Top5EF = GetTop5EF(this.EF);


        }

        public double[][] GetTop5EF(IMatrix ef)
        {
            double[][] top5=new double[5][];
            double[] arr = new double[ef.Rows];
            for(int k = 0; k < 5; k++)
            {
                top5[k]= new double[ef.Rows];
                for (int i = 0; i < ef.Rows; i++)
                {
                    top5[k][i] = ef[i, (ef.Columns-1)-k];
                }
               //Array.Copy(arr, top5[k], arr.Length);
            }
            return top5;
        }

        public void NormalizeVectors(IMatrix ev)
        {
            double[] magnitudes = new double[ev.Columns];
            double magnitude;
            for(int j = 0; j < ev.Columns; j++)
            {
                magnitude = 0;
                for (int i = 0; i < ev.Rows; i++)
                {
                    magnitude += ev[i, j] * ev[i, j];
                }
                magnitudes[j] = Math.Sqrt(magnitude);
                for (int i = 0; i < ev.Rows; i++)
                {
                    ev[i,j] = ev[i, j]/magnitudes[j];
                }
            }
        }
        public int[] ReduceDim(IMatrix eigenVec, double[] eigenVals, int ReducedDim)
        {
            int count = 0;
            double[]eigVals=(double[])eigenVals.Clone();
            int[] indices = new int[ReducedDim];//contains indices of vectors with top magnitude of eigen values 
            double max;
            int maxIdx;
            while (count<ReducedDim)
            {
                max = 0;
                maxIdx = -1;
                for (int i = 0; i < eigVals.Length; i++)
                {
                    if (Math.Abs(eigVals[i]) > max)
                    {
                        max = Math.Abs(eigVals[i]);
                        maxIdx = i;                        
                    }
                }
                eigVals[maxIdx] = 0;
                indices[count] = maxIdx;
                count++;
            }
            return indices;            
        }

        public IMatrix GetTopEVecs(IMatrix eigenVec, int[] indices)
        {
            int columnIdx;
            IMatrix Res = new Matrix(eigenVec.Rows, ReducedDim);
            for (int c = 0; c < indices.Length; c++)
            {
                columnIdx = indices[c];
                for (int r = 0; r < Res.Rows; r++)
                {
                    Res[r,c] = eigenVec[r, columnIdx];
                }
            }
            return Res;
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

        public double[] MeanAdjust(int[] vector)
        {
            double[] adjusted = new double[vector.Length];
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

        

        public IMatrix ComputeCov(IMatrix m)
        {
            IMatrix Covarience;
            IMatrix mTranspose = m.Transpose();
            if (m.Rows <= m.Columns)
            {
                Covarience = m.Multiply(mTranspose);
            }
            else
            {
                Covarience = mTranspose.Multiply(m);
            }
            return Covarience;
        }

    }
}
