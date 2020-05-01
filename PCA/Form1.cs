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
                MessageBox.Show(dialog.FileName);
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
                MyImage img = new MyImage(bmp, imageFullName);
            }
            catch (Exception)
            {
                Console.Write("Please load the picture first");
            }
        }

        private void btnComputeEF_Click(object sender, EventArgs e)
        {
            this.ReadData();//initializes List<MyImage> trainingImages
            MyImage img = trainingImages[20];
            this.picOriginal.Image = img.ImgBitmap;
            //MessageBox.Show(img.imgVector.Length.ToString());

        }

        public void ReadData()
        {
            // Directory.EnumerateFiles Returns an enumerable collection of full file names in a specified path
            foreach (string file in Directory.EnumerateFiles("C:/Users/anast/Documents/Computer-Vision/AttDataSet/ATTDataSet/Training"))
            {
                this.trainingImages.Add(new MyImage(new Bitmap(file), file));
            }
        }
    }
}
