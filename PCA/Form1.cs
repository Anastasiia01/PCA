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
                MessageBox.Show(img.Id.ToString());
                img.meanAdjustedVector = pca.MeanAdjust(img.imgVector);
                this.picMeanAdjusted.Image = ArrayToBitmap(AdjustToDisplay(img.meanAdjustedVector), bmp.Width, bmp.Height);
                double[] recImg = pca.ComputeReconstructedImg(img);
                this.picReconstructed.Image = ArrayToBitmap(AdjustToDisplay(recImg), bmp.Width, bmp.Height);
                int bestMatchIdx = pca.GetBestMatch(img);
                picBestMatch.Image = trainingImages[bestMatchIdx].ImgBitmap;
                lbBestMatch.Text = trainingImages[bestMatchIdx].Id.ToString();

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

        public Bitmap ArrayToBitmap(int[] vector, int width, int height)
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

        private void btnComputeEF_Click(object sender, EventArgs e)
        {
            this.ReadData();//initializes List<MyImage> trainingImages
            pca = new PCA(trainingImages,30);
            pca.Train();              
            this.picEV0.Image=ArrayToBitmap(AdjustToDisplay(pca.Top5EF[0]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            this.picEV1.Image=ArrayToBitmap(AdjustToDisplay(pca.Top5EF[1]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            this.picEV2.Image=ArrayToBitmap(AdjustToDisplay(pca.Top5EF[2]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            this.picEV3.Image=ArrayToBitmap(AdjustToDisplay(pca.Top5EF[3]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            this.picEV4.Image=ArrayToBitmap(AdjustToDisplay(pca.Top5EF[4]), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            this.picAvgImage.Image = ArrayToBitmap(AdjustToDisplay(pca.MeanVector), trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            //this.picOriginal.Image = ArrayToBitmap(trainingImages[7].imgVector, trainingImages[0].ImgBitmap.Width, trainingImages[0].ImgBitmap.Height);
            
            /*for(int i=0;i< trainingImages[0].projectedCoefVector.Length; i++)
            {
                MessageBox.Show(trainingImages[0].projectedCoefVector[i].ToString());
            }*/
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
