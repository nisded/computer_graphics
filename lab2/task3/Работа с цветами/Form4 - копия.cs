using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Работа_с_цветами
{

    
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image == null)
            {
                MessageBox.Show("Не удалось получить картинку", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Bitmap input = new Bitmap(pictureBox1.Image);

            Bitmap output = new Bitmap(input.Width, input.Height);

            double delta_h = 0.0;
            double delta_s = 0.0;
            double delta_v = 0.0;

            bool fl_h = Double.TryParse(textBox1.Text, out delta_h);
            bool fl_s = Double.TryParse(textBox2.Text, out delta_s);
            bool fl_v = Double.TryParse(textBox3.Text, out delta_v);

            for (int j = 0; j < input.Height; j++)
                for (int i = 0; i < input.Width; i++)
                {
                    UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                    double R = (double)((pixel & 0x00FF0000) >> 16); 
                    double G = (double)((pixel & 0x0000FF00) >> 8); 
                    double B = (double)(pixel & 0x000000FF);

                    //RGB to HSV
                    double R1 = R / 255;
                    double G1 = G / 255;
                    double B1 = B / 255;

                    double max = Math.Max(Math.Max(R1, G1), B1);
                    double min = Math.Min(Math.Min(R1, G1), B1);

                    double H = 0;
                    double S = 0;
                    double V = max;

                    if (max == R1 && G1 >= B1)
                    {
                        H = 60 * (G1 - B1) / (max - min);
                    }
                    else if (max == R1 && G1 < B1)
                    {
                        H = 60 * (G1 - B1) / (max - min) + 360;
                    }
                    else if (max == G1)
                    {
                        H = 60 * (B1 - R1) / (max - min) + 120;
                    }
                    else if (max == B1)
                    {
                        H = 60 * (R1 - G1) / (max - min) + 240;
                    }

                    if (max != 0)
                    {
                        S = 1 - (min / max);
                    }

                    V = V * 100;
                    S = S * 100;

                
                    if (fl_h)
                    {
                        H = (int)(H + int.Parse(textBox1.Text)) % 360;
                    }


                    if (fl_s)
                    {
                        S = (int)(S + int.Parse(textBox2.Text));
                        if (S > 100)
                        {
                            S = 100;
                        }
                        else if (S < 0)
                        {
                            S = 0;
                        }                        
                    }
 

                    if (fl_v)
                    {
                        V = (int)(V + int.Parse(textBox3.Text));
                        if (V > 100)
                            V = 100;
                        else if (V < 0)
                            V = 0;
                    }

                    //HSV to RGB
                    int Hi = (int)(H / 60) % 6;
                    
                    double Vmin = ((100 - S) * V) / 100;
                    double a = (V - Vmin) * (H / 60 -  Math.Truncate(H / 60));
                    double Vinc = Vmin + a;
                    double Vdec = V - a;

                    if (Hi == 0)
                    {
                        R = V * 255 / 100;
                        G = Vinc * 255 / 100;
                        B = Vmin * 255 / 100;
                    }
                    else if (Hi == 1)
                    {
                        R = Vdec * 255 / 100;
                        G = V * 255 / 100;
                        B = Vmin * 255 / 100;
                    }
                    else if (Hi == 2)
                    {
                        R = Vmin * 255 / 100;
                        G = V * 255 / 100;
                        B = Vinc * 255 / 100;
                    }
                    else if (Hi == 3)
                    {
                        R = Vmin * 255 / 100;
                        G = Vdec * 255 / 100;
                        B = V * 255 / 100;
                    }
                    else if (Hi == 4)
                    {
                        R = Vinc * 255 / 100;
                        G = Vmin * 255 / 100;
                        B = V * 255 / 100;
                    }
                    else if (Hi == 5)
                    {
                        R = V * 255 / 100;
                        G = Vmin * 255 / 100;
                        B = Vdec * 255 / 100;
                    }
                    UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                    output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                }
            pictureBox2.Image = output;
            pictureBox2.Image.Save("NewPicture.jpg");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
