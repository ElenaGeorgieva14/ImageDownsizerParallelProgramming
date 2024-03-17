using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Downsizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Bitmap originalImageBitmap;
        int originalWidth;
        int originalHeight;
        byte[] row;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = fileDialog.FileName;
                    string path = Path.Combine(@"~\image");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var fileName = Path.GetFileName(fileDialog.FileName);
                    Console.WriteLine("fileName: " + fileName);
                    path = path + fileName;
                    Console.WriteLine("path: " + path);
                    File.Copy(fileDialog.FileName, path, true);

                    originalImageBitmap = new Bitmap(path);
               
                    originalWidth = originalImageBitmap.Width;
                    originalHeight = originalImageBitmap.Height;

                    Rectangle originalImageRect = new Rectangle(0, 0, originalImageBitmap.Width, originalImageBitmap.Height);

                    BitmapData originalImageBitmapData = originalImageBitmap.LockBits(originalImageRect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                    originalImageBitmap.UnlockBits(originalImageBitmapData);

                    IntPtr ptr = originalImageBitmapData.Scan0;
                    int bytes = originalImageBitmapData.Stride * originalImageBitmapData.Height;
                    row = new byte[bytes ];

                    Marshal.Copy(ptr, row, 0, bytes);

                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
                Console.WriteLine(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double downscalingFactor =  getDownscalingFactor();
            int newWidth = (int)(originalWidth * downscalingFactor);
            int newHeight = (int)(originalHeight * downscalingFactor);
            byte[] downsizedImageData = new byte[(newWidth * newHeight) * 3];
            
            // Nearest Neighbor Downsizing
            for (int y = 0; y < newHeight; y++)
            {
                calculateNewPixelData(newWidth, downscalingFactor, downsizedImageData, y);
            }

            String pictureName = "downsized_image.jpg";

            savePicture(newWidth, newHeight, downsizedImageData, pictureName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double downscalingFactor = getDownscalingFactor();
            int newWidth = (int)(originalWidth * downscalingFactor);
            int newHeight = (int)(originalHeight * downscalingFactor);
            byte[] downsizedImageData = new byte[(newWidth * newHeight) * 3];

            // Nearest Neighbor Downsizing
            for (int y = 0; y < newHeight; y++)
            {
                Thread thread = new Thread(() => calculateNewPixelData(newWidth, downscalingFactor, downsizedImageData, y));
                
                thread.Start();
                thread.Join();
            }

            String pictureName = "downsized_image_parallel.jpg";

            savePicture(newWidth, newHeight, downsizedImageData, pictureName);
        }

        private double getDownscalingFactor()
        {
            int selectedPercentage = 100 - (int)downscalingFactorTB.Value;
            double downscalingFactor = selectedPercentage / 100.0;

            return downscalingFactor;
        }

        private void calculateNewPixelData(int newWidth, double downscalingFactor, byte[] downsizedImageData, int y)
        {
            for (int x = 0; x < newWidth; x++)
            {
                int originalX = (int)(x * downscalingFactor);
                int originalY = (int)(y * downscalingFactor);

                int originalIndex = (originalY * originalWidth + originalX) * 3;
                int downsizedIndex = (y * newWidth + x) * 3;

                downsizedImageData[downsizedIndex] = row[originalIndex];
                downsizedImageData[downsizedIndex + 1] = row[originalIndex + 1];
                downsizedImageData[downsizedIndex + 2] = row[originalIndex + 2];
            }
        }

        private void savePicture(int newWidth, int newHeight, byte[] downsizedImageData, String pictureName)
        {
            Bitmap downsizedImageBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            BitmapData downsizedImageBitmapData = downsizedImageBitmap.LockBits(new Rectangle(0, 0, newWidth, newHeight), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Marshal.Copy(downsizedImageData, 0, downsizedImageBitmapData.Scan0, downsizedImageData.Length);
            downsizedImageBitmap.UnlockBits(downsizedImageBitmapData);
            downsizedImageBitmap.Save(pictureName);
        }

    }
}
