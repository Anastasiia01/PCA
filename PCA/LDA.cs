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
            foreach (LDAclass myclass in classes)
            {
                meanTotal = (Matrix)meanTotal.Addition(myclass.ComputeMean());
                Sw = (Matrix)Sw.Addition(myclass.ComputeSi());
            }

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
