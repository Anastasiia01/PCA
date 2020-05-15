using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCA
{
    class LDA
    {
        public LDAclass[] classes { get; set; }
        public Matrix Sw;
        public Matrix Sb;
        public Matrix meanTotal;
        public Matrix projectionMatrix;//W*
        public PCA pca;
        public LDA(List<MyImage> trainingSet)
        {
            pca = new PCA(trainingSet, 50);
            pca.Train();
            this.classes = new LDAclass[40];//40 classes in AT&T dataset
        }

        public void GetProjectionMatrix()
        {
            SplitIntoClasses();//All classes[i] are initialized
            meanTotal = new Matrix(classes[0].lst[0].projectedCoefVector.Length, 1);
            Sw = new Matrix(classes[0].lst[0].projectedCoefVector.Length, classes[0].lst[0].projectedCoefVector.Length);
            Sb = new Matrix(classes[0].lst[0].projectedCoefVector.Length, classes[0].lst[0].projectedCoefVector.Length);
            foreach (LDAclass myclass in classes)
            {
                meanTotal = (Matrix) meanTotal.Addition(myclass.ComputeMean().Multiply(myclass.lst.Count));
                Sw = (Matrix)Sw.Addition(myclass.ComputeSi());
            }
            meanTotal = (Matrix)meanTotal.Multiply(1.0 / pca.TrainingSet.Count);
            foreach (LDAclass myclass in classes)
            {
                Matrix meanDiff = (Matrix)myclass.Mean.Subtraction(meanTotal);
                Sb = (Matrix)Sb.Addition(meanDiff.Multiply(meanDiff.Transpose()).Multiply(myclass.lst.Count));
            }
            Matrix SwInverse = (Matrix)Sw.Inverse;
            Matrix Covarience = (Matrix)SwInverse.Multiply(Sb);
            IEigenvalueDecomposition eigen = Covarience.GetEigenvalueDecomposition();
            Matrix Evecs = (Matrix) eigen.EigenvectorMatrix;
            double[]Evals = eigen.RealEigenvalues;
            projectionMatrix= (Matrix)(Evecs.Submatrix(0, Evecs.Rows - 1, Evecs.Columns - classes.Length + 1, Evecs.Columns - 1));//reduce to 30 top eigen vectors
        }

        public void SplitIntoClasses()
        {
            int imgId;
            foreach (MyImage img in pca.TrainingSet)
            {
                imgId = img.Id - 1;
                if (this.classes[imgId] == null)
                {
                    this.classes[imgId] = new LDAclass(imgId);
                }
                this.classes[imgId].lst.Add(img);
            }

        }


    }
}
