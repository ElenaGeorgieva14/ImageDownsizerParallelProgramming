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
            int selectedPercentage = (int)downscalingFactorTB.Value;
            double downscalingFactor = selectedPercentage / 100.0;
            int newWidth = (int)(originalWidth * downscalingFactor);
            int newHeight = (int)(originalHeight * downscalingFactor);
            Bitmap downsizedImageBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);


            Console.WriteLine("newWidth: " + newWidth);
            Console.WriteLine("new Height: " + newHeight);

            Console.WriteLine("downscaling factor: " + downscalingFactor);



            //byte[] downsizedImageData = new byte[(newWidth * newHeight) * 3]; // 3 channels for RGB
            List<byte> downsizedImageData = new List<byte>();
            // Nearest Neighbor Downsizing
            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    // Calculate the corresponding pixel in the original image
                    int originalX = (int)(x * downscalingFactor);
                    int originalY = (int)(y * downscalingFactor);

                    // Calculate the indexes for the original and downsized arrays
                    int originalIndex = (originalY * originalWidth + originalX) * 3; // 3 channels for RGB
                    int downsizedIndex = (y * newWidth + x) * 3; // 3 channels for RGB

                    // Copy the RGB values from the original image to the downsized image

                    // downsizedImageData[downsizedIndex] = row[originalIndex];     // Red channel
                    //downsizedImageData[downsizedIndex + 1] = row[originalIndex + 1]; // Green channel
                    //downsizedImageData[downsizedIndex + 2] = row[originalIndex + 2]; // Blue channel
                    downsizedImageData.Add(row[originalIndex]);
                    downsizedImageData.Add(row[originalIndex + 1]);
                    downsizedImageData.Add(row[originalIndex + 2]);
                }

            }

            

        //    Bitmap bitmapimg = new BitmapFactory.DecodeStream(mStream);
            // if you want to use Bitmap  

            //originalImageBitmap = new Bitmap(newWidth,newHeight);


            // BitmapData downsizedImageBitmapData = originalImageBitmap.LockBits(new Rectangle(0, 0, newWidth, newHeight), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            //Marshal.Copy(downsizedImageData, 0, downsizedImageBitmapData.Scan0, downsizedImageData.Length);
            //originalImageBitmap.UnlockBits(downsizedImageBitmapData);
            // Save or display the downsized image as needed
            //originalImageBitmap.Save(@"C:\Users\Lenovo\OneDrive\Desktop\downsized_image.jpg");

            // BitmapData downsizedImageBitmapData = downsizedImageBitmap.LockBits(new Rectangle(0, 0, newWidth, newHeight), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            //Marshal.Copy(downsizedImageData, 0, downsizedImageBitmapData.Scan0, downsizedImageData.Length);
            //downsizedImageBitmap.UnlockBits(downsizedImageBitmapData);
            // Save or display the downsized image as needed
            //downsizedImageBitmap.Save(@"C:\Users\Lenovo\OneDrive\Desktop\downsized_image.jpg");
        }
    }
    }
