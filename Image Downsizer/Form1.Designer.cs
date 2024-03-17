namespace Image_Downsizer
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UploadImageBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.downscalingFactorTB = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.ConsTime = new System.Windows.Forms.Label();
            this.resizedImagePictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ParallelTimeL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downscalingFactorTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizedImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(9, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(498, 293);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UploadImageBtn
            // 
            this.UploadImageBtn.Location = new System.Drawing.Point(11, 334);
            this.UploadImageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UploadImageBtn.Name = "UploadImageBtn";
            this.UploadImageBtn.Size = new System.Drawing.Size(99, 32);
            this.UploadImageBtn.TabIndex = 1;
            this.UploadImageBtn.Text = "Upload Image";
            this.UploadImageBtn.UseVisualStyleBackColor = true;
            this.UploadImageBtn.Click += new System.EventHandler(this.UploadImageBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 340);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Downscaling factor";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(334, 334);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 4;
            this.button2.Text = "Resize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Resize_Click);
            // 
            // downscalingFactorTB
            // 
            this.downscalingFactorTB.Location = new System.Drawing.Point(240, 335);
            this.downscalingFactorTB.Margin = new System.Windows.Forms.Padding(2);
            this.downscalingFactorTB.Name = "downscalingFactorTB";
            this.downscalingFactorTB.Size = new System.Drawing.Size(90, 20);
            this.downscalingFactorTB.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(410, 334);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 19);
            this.button3.TabIndex = 6;
            this.button3.Text = "Resize Parallel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.resizeParallelBTN_Click);
            // 
            // ConsTime
            // 
            this.ConsTime.AutoSize = true;
            this.ConsTime.Location = new System.Drawing.Point(331, 365);
            this.ConsTime.Name = "ConsTime";
            this.ConsTime.Size = new System.Drawing.Size(0, 13);
            this.ConsTime.TabIndex = 7;
            // 
            // resizedImagePictureBox
            // 
            this.resizedImagePictureBox.Location = new System.Drawing.Point(555, 37);
            this.resizedImagePictureBox.Name = "resizedImagePictureBox";
            this.resizedImagePictureBox.Size = new System.Drawing.Size(473, 293);
            this.resizedImagePictureBox.TabIndex = 8;
            this.resizedImagePictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(570, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Resized Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Original Image";
            // 
            // ParallelTimeL
            // 
            this.ParallelTimeL.AllowDrop = true;
            this.ParallelTimeL.AutoSize = true;
            this.ParallelTimeL.Location = new System.Drawing.Point(331, 396);
            this.ParallelTimeL.Name = "ParallelTimeL";
            this.ParallelTimeL.Size = new System.Drawing.Size(0, 13);
            this.ParallelTimeL.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 418);
            this.Controls.Add(this.ParallelTimeL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resizedImagePictureBox);
            this.Controls.Add(this.ConsTime);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.downscalingFactorTB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UploadImageBtn);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Image Downsizer";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downscalingFactorTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizedImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        private System.Windows.Forms.Button UploadImageBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown downscalingFactorTB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label ConsTime;
        private System.Windows.Forms.PictureBox resizedImagePictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ParallelTimeL;
    }
}

