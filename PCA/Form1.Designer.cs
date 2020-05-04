namespace PCA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picMatch3 = new System.Windows.Forms.PictureBox();
            this.picEV0 = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnComputeEF = new System.Windows.Forms.Button();
            this.picReconstructed = new System.Windows.Forms.PictureBox();
            this.picMatch1 = new System.Windows.Forms.PictureBox();
            this.picMatch2 = new System.Windows.Forms.PictureBox();
            this.picBestMatch = new System.Windows.Forms.PictureBox();
            this.picMeanAdjusted = new System.Windows.Forms.PictureBox();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.btnGetAccuracy = new System.Windows.Forms.Button();
            this.picEV1 = new System.Windows.Forms.PictureBox();
            this.picEV2 = new System.Windows.Forms.PictureBox();
            this.picEV3 = new System.Windows.Forms.PictureBox();
            this.picEV4 = new System.Windows.Forms.PictureBox();
            this.picAvgImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imgNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnTestImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMatch3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReconstructed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeanAdjusted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picMatch3
            // 
            this.picMatch3.Location = new System.Drawing.Point(1080, 12);
            this.picMatch3.Name = "picMatch3";
            this.picMatch3.Size = new System.Drawing.Size(104, 124);
            this.picMatch3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMatch3.TabIndex = 5;
            this.picMatch3.TabStop = false;
            // 
            // picEV0
            // 
            this.picEV0.Location = new System.Drawing.Point(230, 269);
            this.picEV0.Name = "picEV0";
            this.picEV0.Size = new System.Drawing.Size(164, 196);
            this.picEV0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEV0.TabIndex = 6;
            this.picEV0.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 70);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(122, 41);
            this.btnLoadImage.TabIndex = 11;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnComputeEF
            // 
            this.btnComputeEF.Location = new System.Drawing.Point(12, 12);
            this.btnComputeEF.Name = "btnComputeEF";
            this.btnComputeEF.Size = new System.Drawing.Size(122, 41);
            this.btnComputeEF.TabIndex = 12;
            this.btnComputeEF.Text = "Compute EF";
            this.btnComputeEF.UseVisualStyleBackColor = true;
            this.btnComputeEF.Click += new System.EventHandler(this.btnComputeEF_Click);
            // 
            // picReconstructed
            // 
            this.picReconstructed.Location = new System.Drawing.Point(530, 12);
            this.picReconstructed.Name = "picReconstructed";
            this.picReconstructed.Size = new System.Drawing.Size(155, 193);
            this.picReconstructed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReconstructed.TabIndex = 13;
            this.picReconstructed.TabStop = false;
            // 
            // picMatch1
            // 
            this.picMatch1.Location = new System.Drawing.Point(837, 12);
            this.picMatch1.Name = "picMatch1";
            this.picMatch1.Size = new System.Drawing.Size(104, 124);
            this.picMatch1.TabIndex = 15;
            this.picMatch1.TabStop = false;
            // 
            // picMatch2
            // 
            this.picMatch2.Location = new System.Drawing.Point(957, 12);
            this.picMatch2.Name = "picMatch2";
            this.picMatch2.Size = new System.Drawing.Size(104, 124);
            this.picMatch2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMatch2.TabIndex = 16;
            this.picMatch2.TabStop = false;
            // 
            // picBestMatch
            // 
            this.picBestMatch.Location = new System.Drawing.Point(716, 12);
            this.picBestMatch.Name = "picBestMatch";
            this.picBestMatch.Size = new System.Drawing.Size(104, 124);
            this.picBestMatch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBestMatch.TabIndex = 17;
            this.picBestMatch.TabStop = false;
            // 
            // picMeanAdjusted
            // 
            this.picMeanAdjusted.Location = new System.Drawing.Point(350, 12);
            this.picMeanAdjusted.Name = "picMeanAdjusted";
            this.picMeanAdjusted.Size = new System.Drawing.Size(155, 193);
            this.picMeanAdjusted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMeanAdjusted.TabIndex = 18;
            this.picMeanAdjusted.TabStop = false;
            // 
            // picOriginal
            // 
            this.picOriginal.Location = new System.Drawing.Point(169, 12);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(155, 193);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 19;
            this.picOriginal.TabStop = false;
            // 
            // btnGetAccuracy
            // 
            this.btnGetAccuracy.Location = new System.Drawing.Point(12, 183);
            this.btnGetAccuracy.Name = "btnGetAccuracy";
            this.btnGetAccuracy.Size = new System.Drawing.Size(122, 41);
            this.btnGetAccuracy.TabIndex = 20;
            this.btnGetAccuracy.Text = "Get Accuracy";
            this.btnGetAccuracy.UseVisualStyleBackColor = true;
            this.btnGetAccuracy.Click += new System.EventHandler(this.btnGetAccuracy_Click);
            // 
            // picEV1
            // 
            this.picEV1.Location = new System.Drawing.Point(416, 269);
            this.picEV1.Name = "picEV1";
            this.picEV1.Size = new System.Drawing.Size(164, 196);
            this.picEV1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEV1.TabIndex = 21;
            this.picEV1.TabStop = false;
            // 
            // picEV2
            // 
            this.picEV2.Location = new System.Drawing.Point(606, 269);
            this.picEV2.Name = "picEV2";
            this.picEV2.Size = new System.Drawing.Size(164, 196);
            this.picEV2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEV2.TabIndex = 22;
            this.picEV2.TabStop = false;
            // 
            // picEV3
            // 
            this.picEV3.Location = new System.Drawing.Point(797, 269);
            this.picEV3.Name = "picEV3";
            this.picEV3.Size = new System.Drawing.Size(164, 196);
            this.picEV3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEV3.TabIndex = 23;
            this.picEV3.TabStop = false;
            // 
            // picEV4
            // 
            this.picEV4.Location = new System.Drawing.Point(984, 269);
            this.picEV4.Name = "picEV4";
            this.picEV4.Size = new System.Drawing.Size(164, 196);
            this.picEV4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEV4.TabIndex = 24;
            this.picEV4.TabStop = false;
            // 
            // picAvgImage
            // 
            this.picAvgImage.Location = new System.Drawing.Point(12, 269);
            this.picAvgImage.Name = "picAvgImage";
            this.picAvgImage.Size = new System.Drawing.Size(122, 142);
            this.picAvgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvgImage.TabIndex = 25;
            this.picAvgImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Average Image";
            // 
            // imgNameLabel
            // 
            this.imgNameLabel.AutoSize = true;
            this.imgNameLabel.Location = new System.Drawing.Point(184, 224);
            this.imgNameLabel.Name = "imgNameLabel";
            this.imgNameLabel.Size = new System.Drawing.Size(121, 20);
            this.imgNameLabel.TabIndex = 27;
            this.imgNameLabel.Text = "Image to Check";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Adjusted Image";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Reconstructed Image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label5.Location = new System.Drawing.Point(732, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Best Match";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label6.Location = new System.Drawing.Point(855, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Match #2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 484);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "Eigen Vector 0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(635, 484);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 20);
            this.label11.TabIndex = 36;
            this.label11.Text = "Eigen Vector 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(827, 484);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 20);
            this.label12.TabIndex = 37;
            this.label12.Text = "Eigen Vector 3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1011, 484);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 20);
            this.label13.TabIndex = 38;
            this.label13.Text = "Eigen Vector 4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label7.Location = new System.Drawing.Point(1094, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Match #4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label8.Location = new System.Drawing.Point(980, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "Match #3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(439, 484);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 20);
            this.label14.TabIndex = 41;
            this.label14.Text = "Eigen Vector 1";
            // 
            // btnTestImage
            // 
            this.btnTestImage.Location = new System.Drawing.Point(12, 130);
            this.btnTestImage.Name = "btnTestImage";
            this.btnTestImage.Size = new System.Drawing.Size(122, 41);
            this.btnTestImage.TabIndex = 42;
            this.btnTestImage.Text = "Test Image";
            this.btnTestImage.UseVisualStyleBackColor = true;
            this.btnTestImage.Click += new System.EventHandler(this.btnTestImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 595);
            this.Controls.Add(this.btnTestImage);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imgNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picAvgImage);
            this.Controls.Add(this.picEV4);
            this.Controls.Add(this.picEV3);
            this.Controls.Add(this.picEV2);
            this.Controls.Add(this.picEV1);
            this.Controls.Add(this.btnGetAccuracy);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.picMeanAdjusted);
            this.Controls.Add(this.picBestMatch);
            this.Controls.Add(this.picMatch2);
            this.Controls.Add(this.picMatch1);
            this.Controls.Add(this.picReconstructed);
            this.Controls.Add(this.btnComputeEF);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.picEV0);
            this.Controls.Add(this.picMatch3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picMatch3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReconstructed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMatch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeanAdjusted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEV4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvgImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picMatch3;
        private System.Windows.Forms.PictureBox picEV0;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnComputeEF;
        private System.Windows.Forms.PictureBox picReconstructed;
        private System.Windows.Forms.PictureBox picMatch1;
        private System.Windows.Forms.PictureBox picMatch2;
        private System.Windows.Forms.PictureBox picBestMatch;
        private System.Windows.Forms.PictureBox picMeanAdjusted;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.Button btnGetAccuracy;
        private System.Windows.Forms.PictureBox picEV1;
        private System.Windows.Forms.PictureBox picEV2;
        private System.Windows.Forms.PictureBox picEV3;
        private System.Windows.Forms.PictureBox picEV4;
        private System.Windows.Forms.PictureBox picAvgImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label imgNameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnTestImage;
    }
}

