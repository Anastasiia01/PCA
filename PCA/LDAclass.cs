using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCA
{
    class LDAclass
    {
        public int id;
        public Matrix Mean;//50x1
        public Matrix Si;//50x50
        public List<MyImage> lst;//to get the number of images in class: lst.Count
        public LDAclass(int id)
        {
            this.id = id;
            lst = new List<MyImage>();
        }

        public Matrix ComputeMean()
        {
            if (lst.Count != 0)
            {
                //double[] mean = new double[lst[0].projectedCoefVector.Length];
                Mean = new Matrix(lst[0].projectedCoefVector.Length, 1);//50 x 1 is our case
                foreach(MyImage img in lst)
                {
                    for(int i = 0; i < Mean.Rows; i++)
                    {
                        Mean[i, 0] += img.projectedCoefVector[i];
                    }
                }
                Mean=(Matrix)Mean.Multiply(1.0/lst.Count);                
            }
            return Mean;
        }
        public Matrix ComputeSi()
        {
            if (this.Mean != null)
            {
                Matrix temp = new Matrix(Mean.Rows, Mean.Columns);
                this.Si = new Matrix(temp.Rows, temp.Rows);
                foreach (MyImage img in lst)
                {
                    for (int i = 0; i < Mean.Rows; i++)
                    {
                        temp[i, 0] = img.projectedCoefVector[i] - Mean[i, 0];
                    }
                    this.Si = (Matrix)this.Si.Addition(temp.Multiply(temp.Transpose()));
                }
                    
            }
            return Si;
        }
    }
}
