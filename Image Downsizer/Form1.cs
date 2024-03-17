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
using static System.Net.Mime.MediaTypeNames;

namespace Image_Downsizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap originalImageBitmap;
        Bitmap downsizedImageBitmap;
        BitmapData originalImageBitmapData;
        BitmapData downsizedImageBitmapData;
        int originalWidth;
        int originalHeight;
        int bytesPerPixel;
        byte[] row;
        private void UploadImageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImageBitmap = new Bitmap(fileDialog.FileName);
                    pictureBox1.ImageLocation = fileDialog.FileName;
                    originalWidth = originalImageBitmap.Width;
                    originalHeight = originalImageBitmap.Height;
                    originalImageBitmapData = originalImageBitmap.LockBits(new Rectangle(0, 0, originalWidth, originalHeight), ImageLockMode.ReadOnly, originalImageBitmap.PixelFormat);

                    IntPtr ptr = originalImageBitmapData.Scan0;
                    int bytes = originalImageBitmapData.Stride * originalImageBitmapData.Height;
                    row = new byte[bytes];

                    Marshal.Copy(ptr, row, 0, bytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
                Console.WriteLine(ex.Message);
            }

        }

        private void Resize_Click(object sender, EventArgs e)
        {
            Stopwatch consequenceResizeTime = new Stopwatch();
            consequenceResizeTime.Start();
            double downscalingFactor =  getDownscalingFactor();
            int newWidth = (int)(originalWidth * downscalingFactor);
            int newHeight = (int)(originalHeight * downscalingFactor);
            byte[] downsizedImageData = new byte[(newWidth * newHeight) * 3];
            downsizedImageBitmap = new Bitmap(newWidth, newHeight, originalImageBitmap.PixelFormat);
            downsizedImageBitmapData = downsizedImageBitmap.LockBits(new Rectangle(0, 0, newWidth, newHeight), ImageLockMode.WriteOnly, originalImageBitmap.PixelFormat);

            // Nearest Neighbor Downsizing
            calculateNewPixelData(newWidth, downscalingFactor, downsizedImageData, 0,newHeight);
          
            String pictureName = "downsized_image.jpg";

            savePicture(downsizedImageData, pictureName);
            ConsTime.Text = "Resizing time with consequence algorithm is: " + consequenceResizeTime.Elapsed.ToString();
            consequenceResizeTime.Reset();

        }

        private void resizeParallelBTN_Click(object sender, EventArgs e)
        {
            Stopwatch parallelResizeTime = new Stopwatch();
            parallelResizeTime.Start();
            double downscalingFactor = getDownscalingFactor();
            int newWidth = (int)(originalWidth * downscalingFactor);
            int newHeight = (int)(originalHeight * downscalingFactor);
            byte[] downsizedImageData = new byte[(newWidth * newHeight) * 3];
            downsizedImageBitmap = new Bitmap(newWidth, newHeight, originalImageBitmap.PixelFormat);
            downsizedImageBitmapData = downsizedImageBitmap.LockBits(new Rectangle(0, 0, newWidth, newHeight), ImageLockMode.WriteOnly, originalImageBitmap.PixelFormat);

            int numThreads = Environment.ProcessorCount;
            int rowsPerThread = newHeight / numThreads;


            List<Thread> threads = new List<Thread>();
            // Nearest Neighbor Downsizing

            for (int i = 0; i < numThreads; i++)
            {
                int startY = i * rowsPerThread;
                int endY = (i == numThreads - 1) ? newHeight : (i + 1) * rowsPerThread;
            
                Thread thread = new Thread(() => calculateNewPixelData(newWidth, downscalingFactor, downsizedImageData, startY,endY));
                
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            String pictureName = "downsized_image_parallel.jpg";

            savePicture(downsizedImageData, pictureName);

            ParallelTimeL.Text =  "Resizing time with parallel algorithm is: " + parallelResizeTime.Elapsed.ToString();
            parallelResizeTime.Reset();
        }

        private double getDownscalingFactor()
        {
            return (double)downscalingFactorTB.Value / 100.0;
        }

        private void calculateNewPixelData(int newWidth, double downscalingFactor, byte[] downsizedImageData, int startY,int endY)
        {
            unsafe
            {
                    for (int y = startY; y < endY; y++)
                    {
                        for (int x = 0; x < newWidth; x++)
                        {
                            int originalX = (int)(x / downscalingFactor);
                            int originalY = (int)(y / downscalingFactor);

                            int originalIndex = (originalY * originalWidth + originalX) * 3;
                            int downsizedIndex = (y * newWidth + x) * 3;
                            downsizedImageData[downsizedIndex] = row[originalIndex];
                            downsizedImageData[downsizedIndex + 1] = row[originalIndex + 1];
                            downsizedImageData[downsizedIndex + 2] = row[originalIndex + 2];
                        }
                    }
            }
        }

        private void savePicture(byte[] downsizedImageData, String pictureName)
        {          
            Marshal.Copy(downsizedImageData, 0, downsizedImageBitmapData.Scan0, downsizedImageData.Length);
            downsizedImageBitmap.UnlockBits(downsizedImageBitmapData);
            downsizedImageBitmap.Save(pictureName);
            resizedImagePictureBox.ImageLocation = pictureName;
        }

    }
}
