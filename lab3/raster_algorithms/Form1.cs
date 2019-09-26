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

        Point mouseCoord;

        public Form1()
        {           
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);

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
            if (radioButton4.Checked)
            {
                selectBorder(Color.Red);
            }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton2.Checked)
                isMouseDown = true;
            prevPoint = e.Location;
            mouseCoord = e.Location;
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
            mouseCoord = Point.Empty;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                pictureBox1.Cursor = Cursors.Cross;
            else
                pictureBox1.Cursor = Cursors.Default;
        }

        // найти точку, принадлежащую границе
        private Point findStartPoint()
        {
            int x = mouseCoord.X;
            int y = mouseCoord.Y;

            Color bgColor = bmp.GetPixel(mouseCoord.X, mouseCoord.Y);
            Color currColor = bgColor;
            while (x < bmp.Width - 2 && currColor.ToArgb() == bgColor.ToArgb())
            {
                x++;
                currColor = bmp.GetPixel(x, y);
            }

            return new Point(x, y);
        }

        // выделить границу
        private void selectBorder(Color c)
        {
            List<Point> pixels = new List<Point>();
            Point curr = findStartPoint();
            Point start = curr;
            pixels.Add(start);
            Color borderColor = bmp.GetPixel(curr.X, curr.Y);

            Point next = new Point();
            int currDir = 6;
            int nextDir = -1;
            int moveTo = 0;
            // определяем направление движения
            do
            {
                // двигаемся в выбранном направлении
                moveTo = (currDir - 2 + 8) % 8;
                int mt = moveTo;
                do
                {
                    next = curr;
                    switch (moveTo)
                    {
                        case 0: next.X++; nextDir = 0; break;
                        case 1: next.X++; next.Y--; nextDir = 1; break;
                        case 2: next.Y--; nextDir = 2; break;
                        case 3: next.X--; next.Y--; nextDir = 3; break;
                        case 4: next.X--; nextDir = 4; break;
                        case 5: next.X--; next.Y++; nextDir = 5; break;
                        case 6: next.Y++; nextDir = 6; break;
                        case 7: next.X++; next.Y++; nextDir = 7; break;
                    }

                    if (next == start)
                        break;

                    if (bmp.GetPixel(next.X, next.Y) == borderColor)
                    {
                        pixels.Add(next);
                        curr = next;
                        currDir = nextDir;
                        break;
                    }
                    moveTo = (moveTo + 1) % 8;
                } while (moveTo != mt);
            } while (next != start);

            // меняем цвет грацицы
            foreach (var p in pixels)
                bmp.SetPixel(p.X, p.Y, c);
        }
    }
}

// Ограничить возможность рисования границы

// Выделение границы после удаления текстуры