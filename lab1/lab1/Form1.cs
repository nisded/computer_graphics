using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        private Graphics g;
        List<PointF> points = new List<PointF>();

        float leftX = -10;
        float rightX = 10;
        float step = 0.1f;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
           
            listBox1.SelectedIndex = 0;
            numericUpDown1.Value = -10;
            numericUpDown2.Value = 10;
        }

        //private void draw_axis()
        //{
        //    Pen p = new Pen(Color.Black);
        //    g.DrawLine(p, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
        //    g.DrawLine(p, pictureBox1.Width/2, pictureBox1.Height, pictureBox1.Width/2, 0);
        //}

        private void draw_func(Func<float, float> fun)
        {
            points.Clear();
            //draw_axis();

            float y_max = 0;
            for (float x = leftX; x < rightX; x += step)
            {
                float y = fun(x);
                if (y > y_max)
                    y_max = y;
                points.Add(new PointF(x, y*(-1)));
            }

            float xScal = pictureBox1.Width / (rightX - leftX);
            float yScal;
            if (y_max != 0)
                yScal = pictureBox1.Height / (y_max * 2);
            else
                yScal = pictureBox1.Height;

            //масштабирование в единицы измерения заданного диапазона значений
            g.ScaleTransform(xScal, yScal);

            //сдвиг начала координат
            g.TranslateTransform(pictureBox1.Width/xScal - rightX, pictureBox1.Height/yScal / 2);

            Pen p = new Pen(Color.Black, 1 / xScal);
            g.DrawLine(p, new Point(-10000, 0), new Point(10000, 0));
            g.DrawLine(p, new Point(0, 10000), new Point(0, -10000));

            p.Color = Color.Red;
            for (int i = 0; i < points.Count()-1; ++i)
                g.DrawLine(p, points[i], points[i + 1]);
        }

        private Func<float, float> choose_fun(int ind)
        {
            switch (ind)
            {
                case 0:
                    return x => x * x;               
                case 1:
                    return x => (float)Math.Sin((double)x);
                case 2:
                    return x => x;
                default:
                    return x => 0;
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            draw_func(choose_fun(listBox1.SelectedIndex));
            pictureBox1.Image = bmp;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= numericUpDown2.Value)
                numericUpDown2.Value = numericUpDown1.Value + 1;
            leftX = (float)numericUpDown1.Value;
            pictureBox1.Invalidate();
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= numericUpDown2.Value)
                numericUpDown2.Value = numericUpDown1.Value - 1;
            rightX = (float)numericUpDown2.Value;
            pictureBox1.Invalidate();
        }
    }
}
