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
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
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
            if (polygonIntersection.Count > 1)
            {
                Pen pen = new Pen(Color.Green, 3);
                List<PolygonNode> pointList = polygonIntersection.ToList();
                for (int i = 0; i < pointList.Count - 1; ++i)
                    g.DrawLine(pen, pointList[i].p, pointList[i + 1].p);
                g.DrawLine(pen, pointList[0].p, pointList[pointList.Count - 1].p);
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

        private void IntersectBtn_Click(object sender, EventArgs e)
        {
            sort_vertices_clockwise(ref polygon1);
            sort_vertices_clockwise(ref polygon2);
            add_intersection_points();
            find_polygon_intersection();
        }

        public class VertexComparer : IComparer<PointF>
        {
            //начало полярной системы координат
            private PointF origin;

            public VertexComparer(PointF origin)
            {
                this.origin = origin;
            }

            public int Compare(PointF p1, PointF p2)
            {
                double res = Math.Atan2(origin.Y - p1.Y, p1.X - origin.X) - Math.Atan2(origin.Y - p2.Y, p2.X - origin.X);
                if (res == 0)
                    return 0;
                return res < 0 ? -1 : 1;
            }
        }

        private void sort_vertices_clockwise(ref LinkedList<PolygonNode> polygon)
        {
            if (polygon.Count == 0)
                return;
            PointF origin = new PointF(-1, -1);
            foreach (PolygonNode vertex in polygon)
            {
                if (vertex.p.Y > origin.Y)
                    origin = vertex.p;
            }
            polygon = new LinkedList<PolygonNode>(polygon.OrderByDescending(i => i.p, new VertexComparer(origin)));
        }

        private bool on_segment(PointF p, PointF a, PointF b)
        {
            if (p.X <= Math.Max(a.X, b.X) && p.X >= Math.Min(a.X, b.X) &&
                p.Y <= Math.Max(a.Y, b.Y) && p.Y >= Math.Min(a.Y, b.Y))
                return true;
            return false;
        }

        PointF find_intersection_point(PointF p0, PointF p1, PointF p2, PointF p3)
        {
            PointF i = new PointF(-1, -1);
            PointF intersection = new PointF(-1, -1);
            float x1 = p0.X;
            float y1 = p0.Y;
            float x2 = p1.X;
            float y2 = p1.Y;
            float x3 = p2.X;
            float y3 = p2.Y;
            float x4 = p3.X;
            float y4 = p3.Y;

            float denominator = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            //прямые параллельны или совпадают
            if (denominator == 0)
                return i;
            intersection.X = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denominator;
            intersection.Y = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denominator;

            if (on_segment(intersection, p0, p1) && on_segment(intersection, p2, p3))
                return intersection;
            else
                return i;
        }

        private float distance_between_points(PointF a, PointF b)
        {
            return (float)Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
        }

        private void add_intersection_points()
        {
            if (polygon1.Count == 0 || polygon2.Count == 0)
                return;

            PolygonNode[] pol1 = new PolygonNode[polygon1.Count + 1];
            polygon1.CopyTo(pol1, 0);
            pol1[pol1.Length - 1] = pol1[0];

            PolygonNode[] pol2 = new PolygonNode[polygon2.Count + 1];
            polygon2.CopyTo(pol2, 0);
            pol2[pol2.Length - 1] = pol2[0];

            for (int i = 0; i < pol1.Length - 1; ++i)
            {
                for (int j = 0; j < pol2.Length - 1; ++j)
                {
                    PointF intersection = find_intersection_point(pol1[i].p, pol1[i + 1].p, pol2[j].p, pol2[j + 1].p);
                    if (intersection.X != -1)
                    {
                        //узел в первом полигоне, после которого нужно вставить точку пересечения
                        LinkedListNode<PolygonNode> previous_node1 = polygon1.Find(pol1[i]);
                        //если для текущего ребра уже вставлено одно пересечение,
                        //то проверяется - до или после предыдущего пересечения должно быть вставлено новое
                        if (previous_node1.Next != null && previous_node1.Next.Value.isIntersection &&
                                distance_between_points(previous_node1.Value.p, intersection) >
                                distance_between_points(previous_node1.Value.p, previous_node1.Next.Value.p))
                            previous_node1 = previous_node1.Next;
                        LinkedListNode<PolygonNode> intersectionNode1 = polygon1.AddAfter(previous_node1, new PolygonNode(intersection, true));

                        LinkedListNode<PolygonNode> previous_node2 = polygon2.Find(pol2[j]);
                        if (previous_node2.Next != null && previous_node2.Next.Value.isIntersection &&
                                distance_between_points(previous_node2.Value.p, intersection) >
                                distance_between_points(previous_node2.Value.p, previous_node2.Next.Value.p))
                            previous_node2 = previous_node2.Next;
                        LinkedListNode<PolygonNode> intersectionNode2 = polygon2.AddAfter(previous_node2, new PolygonNode(intersection, true));

                        intersectionNode1.Value.intersectionInOtherPolygon = intersectionNode2;
                        intersectionNode2.Value.intersectionInOtherPolygon = intersectionNode1;
                    }
                }
            }
        }

        bool is_point_inside(List<PointF> polygon, PointF p)
        {
            int n = polygon.Count;
            if (n < 3) return false;

            PointF extreme = new PointF(pictureBox1.Width, p.Y);

            int count = 0, i = 0;
            do
            {
                int next = (i + 1) % n;
                PointF intersection = find_intersection_point(polygon[i], polygon[next], p, extreme);
                if (intersection.X != -1)
                    count++;
                i = next;
            } while (i != 0);

            // Return true if count is odd, false otherwise
            return count % 2 == 1;
        }

        private void find_polygon_intersection()
        {
            if (polygon1.Count == 0 || polygon2.Count == 0)
                return;
            LinkedListNode<PolygonNode> curNode = polygon1.First;
            bool isInside = is_point_inside(polygon2.Where(i => !i.isIntersection).Select(i => i.p).ToList(), curNode.Value.p);            

            while (curNode.Next != null && !curNode.Value.isIntersection)
                curNode = curNode.Next;

            if (curNode.Value.isIntersection)
            {
                polygonIntersection.AddLast(curNode.Value);
                PolygonNode start = curNode.Value;
                if (isInside)
                    curNode = curNode.Value.intersectionInOtherPolygon;
                curNode = curNode.Next;
                while (curNode.Value.p != start.p)
                {
                    polygonIntersection.AddLast(curNode.Value);
                    if (curNode.Value.isIntersection)
                        curNode = curNode.Value.intersectionInOtherPolygon;
                    curNode = curNode.Next == null ? curNode.List.First : curNode.Next;  
                }
                label1.Text = "Есть пересечение";
            }
            else //если обошли весь полигон и точки пересечения не нашлось
            {
                List<PointF> pol1 = polygon1.Where(i => !i.isIntersection).Select(i => i.p).ToList();
                List<PointF> pol2 = polygon2.Where(i => !i.isIntersection).Select(i => i.p).ToList();
                bool polygonInsideOtherPolygon = false;
                //все вершины второго полигона внутри первого полигона?
                foreach (PointF p in pol2)
                {
                    polygonInsideOtherPolygon = is_point_inside(pol1, p);
                    if (!polygonInsideOtherPolygon)
                        break;                    
                }
                //да => пересечение = полигон2
                if (polygonInsideOtherPolygon)
                {
                    label1.Text = "Полигоны пересекаются";
                    polygonIntersection = polygon2;
                    return;
                }
                //нет => все вершины первого полигона внутри второго полигона?
                foreach (PointF p in pol1)
                {
                    polygonInsideOtherPolygon = is_point_inside(pol2, p);
                    if (!polygonInsideOtherPolygon)
                        break;
                }
                //да => пересечение = полигон1
                if (polygonInsideOtherPolygon)
                {
                    label1.Text = "Полигоны пересекаются";
                    polygonIntersection = polygon1;
                    return;
                }
                //нет => не пересекаются
                label1.Text = "Полигоны не пересекаются";
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            polygon1 = new LinkedList<PolygonNode>();
            polygon2 = new LinkedList<PolygonNode>();
            polygonIntersection.Clear();
            polygon1RB.Checked = true;
            label1.Text = "";
        }
    }
}
