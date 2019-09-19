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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Не удалось получить картинку", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap input = new Bitmap(pictureBox1.Image);
            Bitmap[] result = new Bitmap[3] { new Bitmap(input.Width, input.Height), new Bitmap(input.Width, input.Height), new Bitmap(input.Width, input.Height) };

            int[,] colors = new int[3, 256];

            for (int i = 0; i < input.Width; i++)
            {
                for (int j = 0; j < input.Height; j++)
                {
                    Color color = input.GetPixel(i, j);
                    result[0].SetPixel(i, j, Color.FromArgb(color.A, color.R, 0, 0));
                    colors[0, color.R]++;
                    result[1].SetPixel(i, j, Color.FromArgb(color.A, 0, color.G, 0));
                    colors[1, color.G]++;
                    result[2].SetPixel(i, j, Color.FromArgb(color.A, 0, 0, color.B));
                    colors[2, color.B]++;
                }
            }
            pictureBox2.Image = result[0];
            pictureBox3.Image = result[1];
            pictureBox4.Image = result[2];

            string s = comboBox1.SelectedItem.ToString();
            if (s == "R")
            {
                chart1.Series[0].Points.Clear();
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series[0].Points.AddXY(i, colors[0, i]);
                }
            }
            else if (s == "G")
            {
                chart1.Series[0].Points.Clear();
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series[0].Points.AddXY(i, colors[1, i]);
                }
            }
            else if (s == "B")
            {
                chart1.Series[0].Points.Clear();
                for (int i = 0; i < 256; i++)
                {
                    chart1.Series[0].Points.AddXY(i, colors[2, i]);
                }
            }
        }
    }
}
