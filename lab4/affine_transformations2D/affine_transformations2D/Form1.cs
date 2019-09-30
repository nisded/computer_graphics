using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace affine_transformations2D
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Point pointLocation;
        List<Segment> segments = new List<Segment>();
        List<Point> polygon = new List<Point>();
        Boolean isMouseDown = false;
        Point startPoint, endPoint;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            segmentRB.Checked = true;
            startPoint = Point.Empty;
            endPoint = Point.Empty;
            pointLocation = Point.Empty;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            segments.Clear();
            polygon.Clear();
            pointLocation = Point.Empty;
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (segmentRB.Checked)
            {
                isMouseDown = true;
                startPoint = e.Location;
            }
            else if (polygonRB.Checked)
            {
                isMouseDown = true;
                if (polygon.Count == 0)
                {
                    startPoint = e.Location;
                    polygon.Add(startPoint);
                }
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (segmentRB.Checked && isMouseDown)
            {
                endPoint = e.Location;
            }
            else if (polygonRB.Checked && isMouseDown)
            {
                endPoint = e.Location;
            }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (segmentRB.Checked && isMouseDown)
            {
                isMouseDown = false;
                //если нажали и отпустили сразу
                if (endPoint == Point.Empty)
                    return;
                segments.Add(new Segment(startPoint, endPoint));
                startPoint = Point.Empty;
                endPoint = Point.Empty;

            }
            else if (polygonRB.Checked && isMouseDown)
            {
                isMouseDown = false;
                //если нажали и отпустили сразу
                if (endPoint == Point.Empty)
                    return;
                polygon.Add(endPoint);
                startPoint = endPoint;
                endPoint = Point.Empty;
            }
            else if (pointRB.Checked)
            {
                pointLocation = e.Location;
            }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            if (segments.Count > 0)
            {
                foreach (Segment seg in segments)
                    g.DrawLine(Pens.Red, seg.leftP, seg.rightP);
            }

            if (polygon.Count > 1)
            {
                for (int i = 0; i < polygon.Count - 1; ++i)
                {
                    g.DrawLine(Pens.Red, polygon[i], polygon[i + 1]);
                }
                g.DrawLine(Pens.Red, polygon[0], polygon[polygon.Count - 1]);

            }
            //пока тянешь ребро
            if (startPoint != Point.Empty && endPoint != Point.Empty)
                g.DrawLine(Pens.Red, startPoint, endPoint);
            //точка
            if (pointLocation != Point.Empty)
            {
                g.DrawEllipse(Pens.Blue, pointLocation.X - 1, pointLocation.Y - 1, 3, 3);
                g.FillEllipse(Brushes.Blue, pointLocation.X - 1, pointLocation.Y - 1, 3, 3);
            }
        }
    }
}
