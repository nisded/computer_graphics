using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diamond_square.Primitives;
using System.Threading;

namespace Diamond_square
{
    public partial class Form1 : Form
    {
        private Graphics graphics;

        // Список все точек, находящихся на PictureBox
        private List<Point2D> points = new List<Point2D>();

        // Список точек для midpoint displacement
        LinkedList<Point2D> llist;
        Random rand = new Random();

        // Время ожидания при построении ломаной
        int milSec = 50;

        private Primitive SelectedPrimitive
        {
            get
            {
                if (null == treeView1.SelectedNode) return null;
                var p = (Primitive)treeView1.SelectedNode.Tag;
                return p;
            }
            set
            {
                Redraw();
            }
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(2048, 2048);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;
            Point2D p = Point2D.FromPoint(args.Location);

            TreeNode node = treeView1.Nodes.Add("Точка");
            node.Tag = p;
            points.Add(p);
            Redraw();
        }

        private void Redraw()
        {
            graphics.Clear(Color.White);
            points.ForEach((p) => p.Draw(graphics, p == SelectedPrimitive));
            pictureBox1.Invalidate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedPrimitive = (Primitive)e.Node.Tag;
            Redraw();
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete != e.KeyCode && Keys.Back != e.KeyCode) return;
            if (null == SelectedPrimitive) return;
            if (SelectedPrimitive is Point2D) points.Remove((Point2D)SelectedPrimitive);
            
            treeView1.SelectedNode.Remove();
            if (null != treeView1.SelectedNode)
                SelectedPrimitive = (Primitive)treeView1.SelectedNode.Tag;
            else
                SelectedPrimitive = null;
            Redraw();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var start = (Point2D)SelectedPrimitive;
            float firstLength;
            int iter;
            double r;

            if (start == null)
                MessageBox.Show("Выберите начальную точку");
            else
            {
                if (!double.TryParse(textBox1.Text, out r))
                    MessageBox.Show("Введите другое значение шероховатости");
                else
                {
                    if (!int.TryParse(textBox3.Text, out iter))
                        MessageBox.Show("Введите другую глубину рекурсии");
                    else
                    {
                        if (!float.TryParse(textBox2.Text, out firstLength))
                            MessageBox.Show("Введите другую начальную длину отрезка");
                        else
                        {
                            llist = new LinkedList<Point2D>();
                            var end = new Point2D(start.X + firstLength, start.Y);
                            end.Draw(graphics);
                            pictureBox1.Refresh();
                            Thread.Sleep(milSec);

                            llist.AddFirst(start);
                            llist.AddLast(end);

                            graphics.Clear(Color.White);
                            (new Edge(start, end)).Draw(graphics);
                            pictureBox1.Refresh();
                            Thread.Sleep(milSec);

                            var hl = llist.First; //левая точка
                            var hr = hl.Next; //правая точка

                            midpoint(llist, hl, hr, r, iter);
                            pictureBox1.Refresh();
                            MessageBox.Show("Построение завершено");

                        }
                    }
                }
            }
        }

        
        // vector — список точек, изначально заполнены только первая и последняя
        // r -  шероховатость
        // iter - глубина рекурсии
        private void midpoint(LinkedList<Point2D> vector, LinkedListNode<Point2D> hl, LinkedListNode<Point2D> hr, double r, int iter)
        {
            if (iter == 0)
                return;
            Math.Pow((hr.Value.X - hl.Value.X), 2);
            var len = Math.Sqrt(Math.Pow((hr.Value.X - hl.Value.X), 2) - Math.Pow((hr.Value.Y - hl.Value.Y), 2));
            
            var h = (hl.Value.Y + hr.Value.Y) / 2;
            var randPart = rand.Next((int)(-r * len), (int)(+r * len));
            //h += randPart;
            int neg = rand.Next(10, 25)*iter;
            h = (h + randPart) < 0 ? h+neg : (h + randPart);
            var np = new Point2D((hr.Value.X - hl.Value.X) / 2 + hl.Value.X, h);
            llist.AddAfter(hl, np);

            Redraw(pictureBox1, graphics, llist);

            //выполняем алгоритм для получившихся половин
            midpoint(vector, hl, hl.Next, r, iter - 1);
            midpoint(vector, hr.Previous, hr, r, iter - 1);
        }


        // Перерисовываем ломаную линию
        private void Redraw(PictureBox pb, Graphics g, LinkedList<Point2D> list)
        {
            g.Clear(Color.White);
            var p = list.First;
            while (p.Next != null)
            {
                (new Edge(p.Value, p.Next.Value)).Draw(g);
                p = p.Next;
            }
            pb.Refresh();
            Thread.Sleep(milSec);
        }

    }
}
