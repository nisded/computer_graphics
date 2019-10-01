using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        [DllImport("kernel32.dll",
            EntryPoint = "GetStdHandle",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;

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

        private void BiasXNumUD_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AllocConsole();
            Matrix M = new Matrix(3, 3);
            M[0, 2] = 0;
            M[1, 2] = 0;
            M[2, 2] = 1;
            M[0, 0] = 4;
            M[1, 1] = 4;
            M[0, 1] = 0;
            M[1, 0] = 0;
            M[2, 0] = 0;
            M[2, 1] = 0;






            for (int i = 0; i < M.M; ++i)
            {
                for (int j = 0; j < M.N; ++j)
                {
                    Console.Write(M[i, j]);
                    Console.Write(' ');

                }
                Console.WriteLine();
            }
        }

        private void translation(double x, double y)
        {
            Matrix M = new Matrix(3, 3);
            M[0, 2] = 0;
            M[1, 2] = 0;
            M[2, 2] = 1;
            M[0, 0] = 1;
            M[0, 1] = 0;
            M[1, 0] = 0;
            M[1, 1] = 1;
            M[2, 0] = x;
            M[2, 1] = y;
            for (int i = 0; i < segments.Count; ++i)
            {
                Matrix vec = new Matrix(1, 3);
                vec[0, 0] = segments[i].leftP.X;
                vec[0, 1] = segments[i].leftP.Y;
                vec[0, 2] = 1;
                vec *= M;
                Point leftP = new Point((int)vec[0, 0], (int)vec[0, 1]);
                vec[0, 0] = segments[i].rightP.X;
                vec[0, 1] = segments[i].rightP.Y;
                vec[0, 2] = 1;
                vec *= M;
                Point rightP = new Point((int)vec[0, 0], (int)vec[0, 1]);
                segments[i] = new Segment(leftP, rightP);
            }
        }

        private void BiasBtn_Click(object sender, EventArgs e)
        {
            int x = (int)biasXNumUD.Value;
            int y = (int)biasYNumUD.Value;
            translation(x, y);
            pictureBox1.Invalidate();
        }

        private void ScaleBtn_Click(object sender, EventArgs e)
        {
            double x = (double)scaleXNumUD.Value / 100;
            double y = (double)scaleYNumUD.Value / 100;
            Matrix M = new Matrix(3, 3);
            M[0, 2] = 0;
            M[1, 2] = 0;
            M[2, 2] = 1;
            M[0, 0] = x;
            M[1, 1] = y;
            M[0, 1] = 0;
            M[1, 0] = 0;
            M[2, 0] = 0;
            M[2, 1] = 0;
            if (segmentRB.Checked)
            {
                
                for (int i = 0; i < segments.Count; ++i)
                {
                    PointF centerSegment;
                    if (scaleAroundPointCB.Checked)
                    {
                        if (pointLocation == Point.Empty)
                            return;
                        centerSegment = pointLocation;
                    }
                    else
                        centerSegment = new PointF((segments[i].leftP.X + segments[i].rightP.X) / 2,
                                                          (segments[i].leftP.Y + segments[i].rightP.Y) / 2);
                    translation(-1 * centerSegment.X, -1 * centerSegment.Y);
                    Matrix vec = new Matrix(1, 3);
                    vec[0, 0] = segments[i].leftP.X;
                    vec[0, 1] = segments[i].leftP.Y;
                    vec[0, 2] = 1;
                    vec *= M;
                    Point leftP = new Point((int)vec[0, 0], (int)vec[0, 1]);
                    vec[0, 0] = segments[i].rightP.X;
                    vec[0, 1] = segments[i].rightP.Y;
                    vec[0, 2] = 1;
                    vec *= M;
                    Point rightP = new Point((int)vec[0, 0], (int)vec[0, 1]);
                    segments[i] = new Segment(leftP, rightP);
                    translation(centerSegment.X, centerSegment.Y);

                }
            }
            else if (polygonRB.Checked)
            {

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
