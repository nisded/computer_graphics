﻿using System;
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
        Point minPolygonCoord, maxPolygonCoord;

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
                    minPolygonCoord = e.Location;
                    maxPolygonCoord = e.Location;
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
                if (endPoint.X < minPolygonCoord.X)
                    minPolygonCoord.X = endPoint.X;
                if (endPoint.Y < minPolygonCoord.Y)
                    minPolygonCoord.Y = endPoint.Y;
                if (endPoint.X > maxPolygonCoord.X)
                    maxPolygonCoord.X = endPoint.X;
                if (endPoint.Y > maxPolygonCoord.Y)
                    maxPolygonCoord.Y = endPoint.Y;

                startPoint = endPoint;
                endPoint = Point.Empty;
            }
            else if (pointRB.Checked)
            {
                pointLocation = e.Location;
            }
            pictureBox1.Invalidate();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void translate_coordinates(double dx, double dy)
        {
            //матрица переноса
            Matrix M = new Matrix(3, 3);
            M[0, 2] = 0;
            M[1, 2] = 0;
            M[2, 2] = 1;
            M[0, 0] = 1;
            M[0, 1] = 0;
            M[1, 0] = 0;
            M[1, 1] = 1;
            M[2, 0] = dx;
            M[2, 1] = dy;
            if (segmentRB.Checked)
            {
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
            else if (polygonRB.Checked)
            {
                for (int i = 0; i < polygon.Count; ++i)
                {
                    Matrix vec = new Matrix(1, 3);
                    vec[0, 0] = polygon[i].X;
                    vec[0, 1] = polygon[i].Y;
                    vec[0, 2] = 1;
                    vec *= M;
                    polygon[i] = new Point((int)vec[0, 0], (int)vec[0, 1]);
                }
            }
        }

        private void BiasBtn_Click(object sender, EventArgs e)
        {
            int x = (int)biasXNumUD.Value;
            int y = (int)biasYNumUD.Value;
            translate_coordinates(x, y);
            pictureBox1.Invalidate();
        }

        private void scale_or_rotate_primitive(Matrix M, Boolean action)
        {
            CheckBox aroundPointCB;
            if (action)
                aroundPointCB = scaleAroundPointCB;
            else
                aroundPointCB = rotationAroundPointCB;

            if (segmentRB.Checked)
            {
                for (int i = 0; i < segments.Count; ++i)
                {
                    //точка, относительно которой масштабировать
                    PointF translationPoint;
                    //вокруг заданной точки
                    if (aroundPointCB.Checked)
                    {
                        if (pointLocation == Point.Empty)
                            return;
                        translationPoint = pointLocation;
                    }
                    //вокруг центра отрезка
                    else
                        translationPoint = new PointF((segments[i].leftP.X + segments[i].rightP.X) / 2,
                                                          (segments[i].leftP.Y + segments[i].rightP.Y) / 2);
                    //перенос в начало координат
                    translate_coordinates(-1 * translationPoint.X, -1 * translationPoint.Y);
                    //масштабирование
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
                    //перенос обратно
                    translate_coordinates(translationPoint.X, translationPoint.Y);
                }
            }
            else if (polygonRB.Checked)
            {
                for (int i = 0; i < polygon.Count; ++i)
                {
                    //точка, относительно которой масштабировать
                    PointF translationPoint;
                    //вокруг заданной точки
                    if (aroundPointCB.Checked)
                    {
                        if (pointLocation == Point.Empty)
                            return;
                        translationPoint = pointLocation;
                    }
                    //вокруг центра полигона
                    else
                        translationPoint = new PointF((minPolygonCoord.X + maxPolygonCoord.X) / 2,
                                                      (minPolygonCoord.Y + maxPolygonCoord.Y) / 2);
                    //перенос в начало координат
                    translate_coordinates(-1 * translationPoint.X, -1 * translationPoint.Y);
                    //масштабирование
                    Matrix vec = new Matrix(1, 3);
                    vec[0, 0] = polygon[i].X;
                    vec[0, 1] = polygon[i].Y;
                    vec[0, 2] = 1;
                    vec *= M;
                    polygon[i] = new Point((int)vec[0, 0], (int)vec[0, 1]);
                    //перенос обратно
                    translate_coordinates(translationPoint.X, translationPoint.Y);
                }
            }
        }

        private void ScaleBtn_Click(object sender, EventArgs e)
        {
            double x = (double)scaleXNumUD.Value / 100;
            double y = (double)scaleYNumUD.Value / 100;
            //матрица сжатия/растяжения
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
            scale_or_rotate_primitive(M, true);
            pictureBox1.Invalidate();
        }

        private void Angle90_Click(object sender, EventArgs e)
        {
            angleNumUD.Value = 90;
        }

        private void RotationBtn_Click(object sender, EventArgs e)
        {
            double angle = (double)angleNumUD.Value;
            //матрица сжатия/растяжения
            Matrix M = new Matrix(3, 3);
            M[0, 2] = 0;
            M[1, 2] = 0;
            M[2, 2] = 1;
            M[0, 0] = Math.Cos(angle * Math.PI / 180);
            M[0, 1] = Math.Sin(angle * Math.PI / 180);
            M[1, 0] = -Math.Sin(angle * Math.PI / 180);
            M[1, 1] = Math.Cos(angle * Math.PI / 180);
            M[2, 0] = 0;
            M[2, 1] = 0;         
            scale_or_rotate_primitive(M, false);
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
