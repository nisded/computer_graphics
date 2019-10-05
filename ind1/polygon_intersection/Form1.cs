using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polygon_intersection
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        LinkedList<PolygonNode> polygon1 = new LinkedList<PolygonNode>();
        LinkedList<PolygonNode> polygon2 = new LinkedList<PolygonNode>();
        LinkedList<PolygonNode> polygonIntersection = new LinkedList<PolygonNode>();
        
        PointF leftPoint = new PointF(-1, -1);    // leftPoint, rightPoint - концы ребра для отрисовки
        PointF rightPoint = new PointF(-1, -1);   // этого ребра, пока тянем его мышкой при рисовании

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
            {
                if (polygon1RB.Checked && polygon1.Count == 0)
                {
                    polygon1.AddLast(new PolygonNode(e.Location));
                    leftPoint = e.Location;
                }
                else if (polygon2RB.Checked && polygon2.Count == 0)
                {
                    polygon2.AddLast(new PolygonNode(e.Location));
                    leftPoint = e.Location;
                }
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
            {
                rightPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
            {
                //если нажали и отпустили сразу
                if (rightPoint.X == -1 && rightPoint.Y == -1)
                    return;
                if (polygon1RB.Checked)
                    polygon1.AddLast(new PolygonNode(rightPoint));
                else if (polygon2RB.Checked)
                    polygon2.AddLast(new PolygonNode(rightPoint));
                leftPoint = rightPoint;
                rightPoint.X = -1;
                rightPoint.Y = -1;
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            //пока тянешь ребро
            if (leftPoint.X != -1 && leftPoint.Y != -1 && rightPoint.X != -1 && rightPoint.Y != -1)
                g.DrawLine(Pens.Silver, leftPoint, rightPoint);
            if (polygon1.Count > 1)
            {
                List<PolygonNode> pointList = polygon1.ToList();
                for (int i = 0; i < pointList.Count - 1; ++i)
                    g.DrawLine(Pens.Red, pointList[i].p, pointList[i + 1].p);
                g.DrawLine(Pens.Red, pointList[0].p, pointList[pointList.Count - 1].p);            
            }
            if (polygon2.Count > 1)
            {
                List<PolygonNode> pointList = polygon2.ToList();
                for (int i = 0; i < pointList.Count - 1; ++i)
                    g.DrawLine(Pens.Blue, pointList[i].p, pointList[i + 1].p);
                g.DrawLine(Pens.Blue, pointList[0].p, pointList[pointList.Count - 1].p);
            }         
        }

        private void Polygon1RB_CheckedChanged(object sender, EventArgs e)
        {
            if (polygon1RB.Checked)
                polygon1.Clear();
        }

        private void Polygon2RB_CheckedChanged(object sender, EventArgs e)
        {
            if (polygon2RB.Checked)
                polygon2.Clear();
        }
    }
}
