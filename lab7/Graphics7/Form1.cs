using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics6
{
    public partial class Form1 : Form
    {
        private Graphics perspective_g;
        private Bitmap   perspective_bmp;

        private Graphics orthographic_g;
        private Bitmap   orthographic_bmp;

        private Primitive cur_primitive;



        private Transform get_perpective_transform()
        {
            switch(PerspectiveComboBox.SelectedItem.ToString())
            {
                case "Перспективная":
                    {
                        return Transform.PerspectiveProjection();
                    }
                case "Изометрическая":
                    {
                        return Transform.IsometricProjection();
                    }
                default:
                    {
                        return Transform.PerspectiveProjection();
                    }
            }
        }

        private Transform get_orthographic_transform()
        {
            switch (OrthographicComboBox.SelectedItem.ToString())
            {
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
                        return Transform.OrthographicXYProjection();
                    }
            }
        }

        //Рисует координатные оси 
        private void DrawAxis(Graphics g, Transform t, int width, int height)
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

            p.Add(cur_primitive);

            foreach(Primitive x in p)
            {
                x.Draw(g, t, width, height);
            }
        }

        private void GetPrimitive()
        {
            switch(PrimitiveComboBox.SelectedItem.ToString())
            {
                case "Тетраэдр":
                    {
                        cur_primitive = new Tetrahedron(0.5);
                        break;
                    }
                case "Гексаэдр":
                    {
                        cur_primitive = new Hexahedron(0.5);
                        break;
                    }
                case "Октаэдр":
                    {
                        cur_primitive = new Octahedron(0.5);
                        break;
                    }
                case "Икосаэдр":
                    {
                        cur_primitive = new Icosahedron(0.5);
                        break;
                    }
                case "Додекаэдр":
                    {
                        cur_primitive = new Dodecahedron(0.5);
                        break;
                    }
                default:
                    {
                        cur_primitive = new Tetrahedron(0.5);
                        break;
                    }
            }
        }

        private void Clear()
        {
            perspective_bmp = new Bitmap(PerspectiveBox.Width, PerspectiveBox.Height);
            perspective_g = Graphics.FromImage(perspective_bmp);
            PerspectiveBox.Image = perspective_bmp;

            orthographic_bmp = new Bitmap(OrthographicBox.Width, OrthographicBox.Height);
            orthographic_g = Graphics.FromImage(orthographic_bmp);
            OrthographicBox.Image = orthographic_bmp;
        }
        public Form1()
        {
            InitializeComponent();

            //Создаем Bitmap и Graphics для двух PictureBox
            perspective_bmp = new Bitmap(PerspectiveBox.Width, PerspectiveBox.Height);
            perspective_g = Graphics.FromImage(perspective_bmp);
            PerspectiveBox.Image = perspective_bmp;

            orthographic_bmp = new Bitmap(OrthographicBox.Width, OrthographicBox.Height);
            orthographic_g = Graphics.FromImage(orthographic_bmp);
            OrthographicBox.Image = orthographic_bmp;

            //Инициализируем ComboBox для отображения проекций
            PerspectiveComboBox.SelectedItem = PerspectiveComboBox.Items[1];
            OrthographicComboBox.SelectedItem = OrthographicComboBox.Items[0];
            PrimitiveComboBox.SelectedItem = PrimitiveComboBox.Items[0];
            ReflectionComboBox.SelectedItem = ReflectionComboBox.Items[0];

            GetPrimitive();
            DrawAxis(perspective_g, get_perpective_transform(), PerspectiveBox.Width, PerspectiveBox.Height);
            DrawAxis(orthographic_g, get_orthographic_transform(), OrthographicBox.Width, OrthographicBox.Height);
        }

        private void ApplyPerspective_Click(object sender, EventArgs e)
        {
            perspective_bmp = new Bitmap(PerspectiveBox.Width, PerspectiveBox.Height);
            perspective_g = Graphics.FromImage(perspective_bmp);
            PerspectiveBox.Image = perspective_bmp;
            DrawAxis(perspective_g, get_perpective_transform(), PerspectiveBox.Width, PerspectiveBox.Height);
        }

        private void ApplyOrthographic_Click(object sender, EventArgs e)
        {
            orthographic_bmp = new Bitmap(OrthographicBox.Width, OrthographicBox.Height);
            orthographic_g = Graphics.FromImage(orthographic_bmp);
            OrthographicBox.Image = orthographic_bmp;
            DrawAxis(orthographic_g, get_orthographic_transform(), OrthographicBox.Width, OrthographicBox.Height);
        }

        private void ApplyPrimitive_Click(object sender, EventArgs e)
        {
            Clear();
            GetPrimitive();
            DrawAxis(perspective_g, get_perpective_transform(), PerspectiveBox.Width, PerspectiveBox.Height);
            DrawAxis(orthographic_g, get_orthographic_transform(), OrthographicBox.Width, OrthographicBox.Height);
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

        //Масштаб
        private void Scale()
        {
            double X = (double)numericUpDown7.Value;
            double Y = (double)numericUpDown8.Value;
            double Z = (double)numericUpDown9.Value;
            cur_primitive.Apply(Transform.Scale(X, Y, Z));

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

        private void RotateCenter()
        {
            double X = (double)numericUpDown11.Value / 180 * Math.PI;
            double Y = (double)numericUpDown12.Value / 180 * Math.PI;
            double Z = (double)numericUpDown13.Value / 180 * Math.PI;
            cur_primitive.Apply(Transform.RotateX(X) * Transform.RotateY(Y) * Transform.RotateZ(Z));
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
            Scale();

            DrawAxis(perspective_g, get_perpective_transform(), PerspectiveBox.Width, PerspectiveBox.Height);
            DrawAxis(orthographic_g, get_orthographic_transform(), OrthographicBox.Width, OrthographicBox.Height);
        }

        private void ApplyReflection_Click(object sender, EventArgs e)
        {
            Clear();
            Reflect();

            DrawAxis(perspective_g, get_perpective_transform(), PerspectiveBox.Width, PerspectiveBox.Height);
            DrawAxis(orthographic_g, get_orthographic_transform(), OrthographicBox.Width, OrthographicBox.Height);
        }

        private void ApplyScaleCenter_Click(object sender, EventArgs e)
        {
            Clear();
            ScaleCenter();

            DrawAxis(perspective_g, get_perpective_transform(), PerspectiveBox.Width, PerspectiveBox.Height);
            DrawAxis(orthographic_g, get_orthographic_transform(), OrthographicBox.Width, OrthographicBox.Height);
        }

        private void ApplyRotationCenter_Click(object sender, EventArgs e)
        {
            Clear();
            RotateCenter();

            DrawAxis(perspective_g, get_perpective_transform(), PerspectiveBox.Width, PerspectiveBox.Height);
            DrawAxis(orthographic_g, get_orthographic_transform(), OrthographicBox.Width, OrthographicBox.Height);
        }

        private void ApplyLineRotation_Click(object sender, EventArgs e)
        {
            Clear();
            RotateLine();

            DrawAxis(perspective_g, get_perpective_transform(), PerspectiveBox.Width, PerspectiveBox.Height);
            DrawAxis(orthographic_g, get_orthographic_transform(), OrthographicBox.Width, OrthographicBox.Height);
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
                        case "Tetrahedron":
                            {
                                cur_primitive = new Tetrahedron(points);
                                break;
                            }
                        case "Octahedron":
                            {
                                cur_primitive = new Octahedron(points);
                                break;
                            }
                        case "Hexahedron":
                            {
                                cur_primitive = new Hexahedron(points);
                                break;
                            }
                        case "Icosahedron":
                            {
                                cur_primitive = new Icosahedron(points);
                                break;
                            }
                        default:
                            {
                                cur_primitive = new Tetrahedron(points);
                                break;
                            }
                    }

                    DrawAxis(perspective_g, get_perpective_transform(), PerspectiveBox.Width, PerspectiveBox.Height);
                    DrawAxis(orthographic_g, get_orthographic_transform(), OrthographicBox.Width, OrthographicBox.Height);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
