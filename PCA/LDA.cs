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
        public double[] Evals;
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
            Evals = eigen.RealEigenvalues;
            projectionMatrix= (Matrix)Evecs.Submatrix(0, Evecs.Rows - 1,0, classes.Length-1);//reduce to 30 top eigen vectors
            pca.NormalizeVectors(projectionMatrix);
            ProjectTrainingSet(pca.TrainingSet);
        }

        public void ComputeProjectionCoef(MyImage img)
        {
            if (img.projectedCoefVector == null)
            {
                img.meanAdjustedVector = pca.MeanAdjust(img.imgVector);
                pca.ComputeCoefToReconstruct(img);
            }
            Matrix vecToProject = pca.ArrayToHorizontalVector(img.projectedCoefVector);
            Matrix coeff = (Matrix)(vecToProject.Multiply(projectionMatrix));
            img.ldaProjectionCoef = pca.HorizontalVectorToArray(coeff);
        }
        public void ProjectTrainingSet(List<MyImage> images)// sets all MyImage.projectedImgVector
        {
            foreach(MyImage img in images)
            {
                ComputeProjectionCoef(img);
            }
        }

        public int ClassifyLDA(MyImage test, ref Match[] bestmatches)
        {
            ComputeProjectionCoef(test);
            Match[] matches = new Match[pca.TrainingSet.Count];
            double dist;
            int minIdx=0;
            double mindist= pca.GetDistance(test.ldaProjectionCoef, pca.TrainingSet[0].ldaProjectionCoef);
            for (int i = 0; i < pca.TrainingSet.Count; i++)
            {
                dist = pca.GetDistance(test.ldaProjectionCoef, pca.TrainingSet[i].ldaProjectionCoef);
                if (dist < mindist)
                {
                    minIdx = i;
                    mindist = dist;
                }
                matches[i] = new Match(pca.TrainingSet[i], dist);
            }
            Array.Sort(matches);
            bestmatches = matches;
            return matches[0].id;
            //return minIdx;
        }


        public double GetAccuracy(List<MyImage> testSet)
        {
            int count = 0;
            foreach (MyImage img in testSet)
            {
                Match[] bestMatches = new Match[pca.TrainingSet.Count];
                int predictedId = ClassifyLDA(img, ref bestMatches);
                if (img.Id == predictedId)
                {
                    count++;
                }
            }
            double accuracy = ((double)count / testSet.Count) * 100;
            return accuracy;
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
