using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab2
{ 
    public partial class Form1 : Form
    {
        PictureBox currentPB; 

        public Form1()
        {
            InitializeComponent();
            currentPB = pictureBox1;
        }

        private void refresh_histogram(bool pb)
        {
            Chart currentChart;
            if (pb)
            {
                currentPB = pictureBox1;
                currentChart = chart1;
            }
            else
            {
                currentPB = pictureBox2;
                currentChart = chart2;
            }

            currentChart.Series[0].Points.Clear();
            currentChart.Series[1].Points.Clear();
            currentChart.Series[2].Points.Clear();
            currentChart.Series[3].Points.Clear();

            if (currentPB.Image != null)
            {
                for (int i = 0; i < 256; ++i)
                {
                    currentChart.Series[0].Points.Add(0);
                    currentChart.Series[1].Points.Add(0);
                    currentChart.Series[2].Points.Add(0);
                    currentChart.Series[3].Points.Add(0);
                }

                Bitmap bmp = currentPB.Image as Bitmap;

                // Lock the bitmap's bits. 
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp.PixelFormat);

                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                byte[] rgbValues = new byte[bytes];

                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                for (int i = 0; i < rgbValues.Length; i += 3)
                {
                    int avg = (rgbValues[i + 0] + rgbValues[i + 1] + rgbValues[i + 2]) / 3;
                    currentChart.Series[0].Points[rgbValues[i + 2]].YValues[0] += 1;
                    currentChart.Series[1].Points[rgbValues[i + 1]].YValues[0] += 1;
                    currentChart.Series[2].Points[rgbValues[i + 0]].YValues[0] += 1;
                    currentChart.Series[3].Points[avg].YValues[0] += 1;
                }
                
                // Unlock the bits.
                bmp.UnlockBits(bmpData);
            }
        }

        private void load_image()
        {
            Bitmap image;

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = image;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            pictureBox2.Image = (Image)pictureBox1.Image.Clone();
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            refresh_histogram(true);
            refresh_histogram(false);
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            load_image();
        }

        private void grayscale_transform(bool pb)
        {
            if (pb)
                currentPB = pictureBox1;
            else
                currentPB = pictureBox2;

            if (currentPB.Image == null)
                load_image();
            else
            {
                Bitmap bmp = currentPB.Image as Bitmap;

                // Lock the bitmap's bits.  
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp.PixelFormat);

                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                byte[] rgbValues = new byte[bytes];

                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                //int i = 0;
                for (int counter = 0; counter < rgbValues.Length; counter += 3)
                {
                    int gray;
                    if (pb)
                        gray = Convert.ToInt32(
                            0.299 * rgbValues[counter + 0] +
                            0.587 * rgbValues[counter + 1] +
                            0.114 * rgbValues[counter + 2]);
                    else
                        gray = Convert.ToInt32(
                            0.0722 * rgbValues[counter + 0] +
                            0.7152 * rgbValues[counter + 1] +
                            0.2126 * rgbValues[counter + 2]);
                    rgbValues[counter + 0] = (byte)gray;
                    rgbValues[counter + 1] = (byte)gray;
                    rgbValues[counter + 2] = (byte)gray;           
                }
                // Copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                // Unlock the bits.
                bmp.UnlockBits(bmpData);
                currentPB.Refresh();
                refresh_histogram(pb);
            }
        }        

        private void Button1_Click(object sender, EventArgs e)
        {
            grayscale_transform(true);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            grayscale_transform(false);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && pictureBox2.Image != null)
            {
                Bitmap bmp1 = pictureBox1.Image as Bitmap;
                Bitmap bmp2 = pictureBox2.Image as Bitmap;

                // Lock the bitmap's bits.  
                Rectangle rect1 = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
                System.Drawing.Imaging.BitmapData bmpData1 =
                    bmp1.LockBits(rect1, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp1.PixelFormat);
                Rectangle rect2 = new Rectangle(0, 0, bmp2.Width, bmp2.Height);
                System.Drawing.Imaging.BitmapData bmpData2 =
                    bmp2.LockBits(rect2, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp2.PixelFormat);

                // Get the address of the first line.
                IntPtr ptr1 = bmpData1.Scan0;
                IntPtr ptr2 = bmpData2.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                int bytes1 = Math.Abs(bmpData1.Stride) * bmp1.Height;
                byte[] rgbValues1 = new byte[bytes1];
                int bytes2 = Math.Abs(bmpData1.Stride) * bmp2.Height;
                byte[] rgbValues2 = new byte[bytes2];

                // Copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr1, rgbValues1, 0, bytes1);
                System.Runtime.InteropServices.Marshal.Copy(ptr2, rgbValues2, 0, bytes2);

                for (int i = 0; i < rgbValues1.Length; i += 3)
                {
                    rgbValues2[i + 0] = (byte)Math.Abs(rgbValues1[i + 0] - rgbValues2[i + 0]);
                    rgbValues2[i + 1] = (byte)Math.Abs(rgbValues1[i + 1] - rgbValues2[i + 1]);
                    rgbValues2[i + 2] = (byte)Math.Abs(rgbValues1[i + 2] - rgbValues2[i + 2]);
                }

                // Copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(rgbValues2, 0, ptr2, bytes2);
                // Unlock the bits.
                bmp1.UnlockBits(bmpData1);
                bmp2.UnlockBits(bmpData2);
                pictureBox2.Refresh();
                refresh_histogram(false);
            }
            else
                load_image();
        }
    }
}
