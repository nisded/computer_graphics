using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            load_image();
        }

        private void grayscale_transform(bool button)
        {
            if (button)
                currentPB = pictureBox1;
            else
                currentPB = pictureBox2;

            if (currentPB.Image != null)
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
                    if (button)
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

                    /*bmp.SetPixel(i % bmp.Width, i / bmp.Width,
                        Color.FromArgb(
                            (Int32)(0.299*rgbValues[counter]), 
                            (Int32)(0.587*rgbValues[counter + 1]), 
                            (Int32)(0.114*rgbValues[counter + 2]))
                        );
                    i++;*/

                }
                // Copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                // Unlock the bits.
                bmp.UnlockBits(bmpData);
                currentPB.Refresh();
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


    }
}
