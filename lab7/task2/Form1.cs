using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotationFigure
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private Bitmap bmp;

        private Primitive cur_primitive;

        private int count_start_points_in_rotation_figure;

        private Transform get_projection_transform()
        {
            switch(projectionComboBox.SelectedItem.ToString())
            {
                case "Перспективная":
                    {
                        return Transform.PerspectiveProjection();
                    }
                case "Изометрическая":
                    {
                        return Transform.IsometricProjection();
                    }
                case "Ортографическая XY":
                    {
                        return Transform.OrthographicXYProjection();
                    }
                case "Ортографическая XZ":
                    {
                        return Transform.OrthographicXZProjection();
                    }
                case "Ортографическая YZ":
                    {
                        return Transform.OrthographicYZProjection();
                    }
                default:
                    {
                        return Transform.IsometricProjection();
                    }
            }
        }

        //Рисует координатные оси 
        private void DrawScene(Graphics g, Transform t, int width, int height)
        {
            List<Primitive> p = new List<Primitive>();
            XYZPoint a = new XYZPoint(0, 0, 0);
            XYZPoint b = new XYZPoint(0.8, 0, 0);
            XYZPoint c = new XYZPoint(0, 0.8, 0);
            XYZPoint d = new XYZPoint(0, 0, 0.8);

            p.Add(a);
            p.Add(b);
            p.Add(c);
            p.Add(d);

            p.Add(new XYZLine(a, b));
            p.Add(new XYZLine(a, c));
            p.Add(new XYZLine(a, d));

            if (cur_primitive != null)
                p.Add(cur_primitive);

            foreach(Primitive x in p)
            {
                x.Draw(g, t, width, height);
            }
        }

        private void Clear()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
        }

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            projectionComboBox.SelectedItem = projectionComboBox.Items[1];
            ReflectionComboBox.SelectedItem = ReflectionComboBox.Items[0];
            rotationAxisCB.SelectedItem = rotationAxisCB.Items[1];

            DrawScene(g, get_projection_transform(), pictureBox1.Width, pictureBox1.Height);
        }

        private void ApplyProjection_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            DrawScene(g, get_projection_transform(), pictureBox1.Width, pictureBox1.Height);
        }

        //Смещение
        private void Translate()
        {
            double X = (double)numericUpDown1.Value;
            double Y = (double)numericUpDown2.Value;
            double Z = (double)numericUpDown3.Value;
            cur_primitive.Apply(Transform.Translate(X, Y, Z));
        }

        //Поворот
        private void Rotate()
        {
            double X = (double)numericUpDown4.Value / 180 * Math.PI;
            double Y = (double)numericUpDown5.Value / 180 * Math.PI;
            double Z = (double)numericUpDown6.Value / 180 * Math.PI;
            cur_primitive.Apply(Transform.RotateX(X) * Transform.RotateY(Y) * Transform.RotateZ(Z));
        }

        //Отражение
        private void Reflect()
        {
            switch(ReflectionComboBox.SelectedItem.ToString())
            {
                case "Отражение по X":
                    {
                        cur_primitive.Apply(Transform.ReflectX());
                        break;
                    }
                case "Отражение по Y":
                    {
                        cur_primitive.Apply(Transform.ReflectY());
                        break;
                    }
                case "Отражение по Z":
                    {
                        cur_primitive.Apply(Transform.ReflectZ());
                        break;
                    }
                default:
                    {
                        cur_primitive.Apply(Transform.ReflectX());
                        break;
                    }
            }
        }

        //Масштабирование относительно центра
        private void ScaleCenter()
        {
            double C = (double)numericUpDown10.Value;
            cur_primitive.Apply(Transform.Scale(C, C, C));
        }


        private void RotateLine()
        {
            double X1 = (double)numericUpDown14.Value;
            double Y1 = (double)numericUpDown15.Value;
            double Z1 = (double)numericUpDown16.Value;

            double X2 = (double)numericUpDown17.Value;
            double Y2 = (double)numericUpDown18.Value;
            double Z2 = (double)numericUpDown19.Value;

            XYZLine l = new XYZLine(new XYZPoint(X1, Y1, Z1), new XYZPoint(X2, Y2, Z2));

            double ang = (double)numericUpDown20.Value / 180 * Math.PI;

            cur_primitive.Apply(Transform.RotateLine(l, ang));
        }

        private void ApplyAffin_Click(object sender, EventArgs e)
        {
            Clear();
            Translate();
            Rotate();
            ScaleCenter();

            DrawScene(g, get_projection_transform(), pictureBox1.Width, pictureBox1.Height);
        }

        private void ApplyReflection_Click(object sender, EventArgs e)
        {
            Clear();
            Reflect();

            DrawScene(g, get_projection_transform(), pictureBox1.Width, pictureBox1.Height);
        }


        private void ApplyLineRotation_Click(object sender, EventArgs e)
        {
            Clear();
            RotateLine();

            DrawScene(g, get_projection_transform(), pictureBox1.Width, pictureBox1.Height);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Object Files(*.obj)| *.obj | Text files(*.txt) | *.txt | All files(*.*) | *.* ";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string info = "";
                    info += cur_primitive.ToString() + "\r\n" + "\r\n";
                 


                    int num = 1;
                    foreach (XYZPoint point in cur_primitive.Points)
                    {
                        info += "Point #" + num;
                        info += "\r\n";
                        info += point.X + " ";
                        info += point.Y + " ";
                        info += point.Z;
                        info += "\r\n";
                        ++num;
                    }
                    info += "# " + cur_primitive.Points.Count + " points\r\n";
                    info += "\r\n";

                    num = 1;
                    foreach (Verge v in cur_primitive.Verges)
                    {
                        info += v.ToString() + " #" + num;

                        info += "\r\n";
                        for (int i = 0; i < v.Points.Count; ++i)
                        {
                            info += v.Points[i].X + " " + v.Points[i].Y + " " + v.Points[i].Z;
                            info += "\r\n";
                        }
                        if (num != cur_primitive.Verges.Count)
                            info += "\r\n";
                        ++num;
                    }
                    info += "# " + cur_primitive.Verges.Count + " verges\r\n";

                    System.IO.File.WriteAllText(saveDialog.FileName, info);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно сохранить файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadDialog = new OpenFileDialog();
            loadDialog.Filter = "Object Files(*.obj)|*.obj|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (loadDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Clear();
                    List<XYZPoint> points = new List<XYZPoint>();
                    List<Verge> verges = new List<Verge>();

                    string str = System.IO.File.ReadAllText(loadDialog.FileName).Replace("\r\n", "!");
                    string[] info = str.Split('!');

                    string type_of_primitive = info[0];

                    int cur_string = 3;
                    while (cur_string < info.Length && info[cur_string] != "")
                    {
                        string[] coordinates = info[cur_string].Split(' ');

                        double x = double.Parse(coordinates[0]);
                        double y = double.Parse(coordinates[1]);
                        double z = double.Parse(coordinates[2]);
                        points.Add(new XYZPoint(x, y, z));
                        cur_string += 2;
                    }

                    cur_string++;
                    do
                    {
                        cur_string++;
                        if (info[cur_string] == "")
                            break;

                        List<XYZPoint> vertices = new List<XYZPoint>();
                        while (cur_string < info.Length - 1 && info[cur_string] != "" && info[cur_string][0] != '#')
                        {
                            string[] coordinates = info[cur_string].Split(' ');

                            double x = double.Parse(coordinates[0]);
                            double y = double.Parse(coordinates[1]);
                            double z = double.Parse(coordinates[2]);
                            vertices.Add(new XYZPoint(x, y, z));
                            cur_string++;
                        }

                        verges.Add(new Verge(vertices));
                        cur_string++;
                    }
                    while (cur_string < info.Length - 1);

                    switch (type_of_primitive)
                    {                     
                        case "Rotation Figure":
                            {
                                cur_primitive = new RotationFigure(points, verges, count_start_points_in_rotation_figure);
                                break;
                            }
                        default:
                            {
                                cur_primitive = new RotationFigure(points, verges, count_start_points_in_rotation_figure);
                                break;
                            }
                    }

                    DrawScene(g, get_projection_transform(), pictureBox1.Width, pictureBox1.Height);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void AddPointBtn_Click(object sender, EventArgs e)
        {
            double x = (double)numericUpDown21.Value;
            double y = (double)numericUpDown22.Value;
            double z = (double)numericUpDown23.Value;
            numericUpDown21.Value = 0;
            numericUpDown22.Value = 0;
            numericUpDown23.Value = 0;
            listBox1.Items.Add(new XYZPoint(x, y, z));
        }

        private void RemovePointBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void DrawRotationFigure_Click(object sender, EventArgs e)
        {
            Clear();
            List<XYZPoint> points = new List<XYZPoint>();

            foreach (var p in listBox1.Items)
                points.Add((XYZPoint)p);
            int axis = 0;
            count_start_points_in_rotation_figure = points.Count;
            switch (rotationAxisCB.SelectedItem.ToString())
            {
                case "OX":
                    {
                        axis = 0;
                        break;
                    }
                case "OY":
                    {
                        axis = 1;
                        break;
                    }
                case "OZ":
                    {
                        axis = 2;
                        break;
                    }
                default:
                    {
                        axis = 0;
                        break;
                    }
            }
            var density = (int)densityCountNumUpDown.Value;
            cur_primitive = new RotationFigure(points, axis, density);
            DrawScene(g, get_projection_transform(), pictureBox1.Width, pictureBox1.Height);
        }
    }
}
