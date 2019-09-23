using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raster_algorithms
{
    public partial class Form1 : Form
    {
        Graphics g;
        Color fillColor;
        Bitmap bmp;
        Boolean isMouseDown;
        Point prevPoint;

        public Form1()
        {           
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            fillColor = panel1.BackColor = Color.Blue;
            isMouseDown = false;
            prevPoint = Point.Empty;
        }        

        private void Button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDial = new ColorDialog();
            if (colorDial.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDial.Color;
                fillColor = colorDial.Color;
            }
        }

        private Color get_point_color(Point p)
        {
            if (pictureBox1.ClientRectangle.Contains(p))
                return ((Bitmap)pictureBox1.Image).GetPixel(p.X, p.Y);
            else
                return Color.Black;
        }

        void flood_fill(Point p)
        {
            Color curColor = get_point_color(p);
            Color oldColor = curColor;
            Point leftP = p;
            Point rightP = p;
            if (!pictureBox1.ClientRectangle.Contains(p))
                return;
            if (curColor != fillColor && curColor == oldColor)
            {
                while (curColor == oldColor && pictureBox1.ClientRectangle.Contains(p))
                {
                    leftP.X -= 1;
                    curColor = get_point_color(leftP);
                }
                leftP.X += 1;
                curColor = get_point_color(p);
                while (curColor == oldColor && pictureBox1.ClientRectangle.Contains(p))
                {
                    rightP.X += 1;
                    curColor = get_point_color(rightP);
                }
                rightP.X -= 1;
                Pen pen = new Pen(fillColor, 1);
                g.DrawLine(pen, leftP, rightP);

                for (int i = leftP.X; i <= rightP.X; ++i)
                {
                    Point pAbove = new Point(i, p.Y + 1);
                    Color curC = get_point_color(pAbove);
                    if (curC.ToArgb() != Color.Black.ToArgb() && curC.ToArgb() != fillColor.ToArgb() && pictureBox1.ClientRectangle.Contains(pAbove)) 
                        flood_fill(pAbove);
                }
                for (int i = leftP.X; i <= rightP.X; ++i)
                {
                    Point pBelow = new Point(i, p.Y - 1);
                    Color curC = get_point_color(pBelow);
                    if (curC.ToArgb() != Color.Black.ToArgb() && curC.ToArgb() != fillColor.ToArgb() && pictureBox1.ClientRectangle.Contains(pBelow))
                        flood_fill(pBelow);
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) {
                MouseEventArgs m = (MouseEventArgs)e;
                Point p = m.Location;
                flood_fill(p);
            }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!radioButton2.Checked)
                return;
            isMouseDown = true;
            prevPoint = e.Location;

        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && prevPoint != Point.Empty)
            {
                Pen p = new Pen(Color.Black, 1);
                g.DrawLine(p, prevPoint, e.Location);
                prevPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            prevPoint = Point.Empty;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            pictureBox1.Invalidate();
        }
    }
}
