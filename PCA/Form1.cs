using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCA
{
    public partial class Form1 : Form
    {
        List<MyImage> trainingImages = new List<MyImage>();
        PCA pca;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                //MessageBox.Show(dialog.FileName);
                this.picOriginal.Image = new Bitmap(dialog.FileName);
                FileInfo finfo = new FileInfo(dialog.FileName);
                this.imgNameLabel.Text = finfo.Name;
            }
        }

        private void btnGetAccuracy_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTestImage_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(this.picOriginal.Image);
                String imageFullName = this.imgNameLabel.Text;
                //MessageBox.Show(imageFullName);
                MyImage img = new MyImage(bmp, imageFullName);
                img.meanAdjustedVector = pca.MeanAdjust(img.imgVector);
                int[] adjustedToDisplay = AdjustToDisplay(img.meanAdjustedVector);
                Bitmap bmpMean = pca.ArrayToBitmap(adjustedToDisplay, bmp.Width, bmp.Height);
                this.picMeanAdjusted.Image = bmpMean;
            }
            catch (Exception)
            {
                Console.Write("Please load the picture first");
            }
        }

        public int[] AdjustToDisplay(double[] vector)
        {
            int[] toDisplay = new int[vector.Length];
            try
            {
                double min = vector.Min();
                double max = vector.Max();
                double denom = max - min;
                for (int i = 0; i < vector.Length; i++)
                {
                    toDisplay[i] = (int)((vector[i] - min) * 255 / denom);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Given array is empty");
            }
            return toDisplay;
        }


        private void btnComputeEF_Click(object sender, EventArgs e)
        {
            this.ReadData();//initializes List<MyImage> trainingImages
            pca = new PCA(trainingImages,30);
            pca.Train();              
            this.picEV0.Image=pca.ArrayToBitmap(AdjustToDisplay(pca.Top5EF[0]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            this.picEV1.Image=pca.ArrayToBitmap(AdjustToDisplay(pca.Top5EF[1]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            this.picEV2.Image=pca.ArrayToBitmap(AdjustToDisplay(pca.Top5EF[2]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            this.picEV3.Image=pca.ArrayToBitmap(AdjustToDisplay(pca.Top5EF[3]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            this.picEV4.Image=pca.ArrayToBitmap(AdjustToDisplay(pca.Top5EF[4]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            int[] meanToDisplay = AdjustToDisplay(pca.MeanVector);
            this.picAvgImage.Image = pca.ArrayToBitmap(meanToDisplay, trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
        }

        public void ReadData()
        {
            // Directory.EnumerateFiles Returns an enumerable collection of full file names in a specified path
            foreach (string file in Directory.EnumerateFiles("C:/Users/anast/Documents/Computer-Vision/AttDataSet/ATTDataSet/Training"))
            {
                FileInfo finfo = new FileInfo(file);
                String fileName = finfo.Name;
                this.trainingImages.Add(new MyImage(new Bitmap(file), fileName));
            }
        }
    }
}
