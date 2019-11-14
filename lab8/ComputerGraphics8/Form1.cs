using System.Windows.Forms;
using System;

namespace ComputerGraphics8
{
    public partial class Form1 : Form
    {
        private Primitive Current_primitive
        {
            get
            {
                return sceneView1.current_primitive;
            }
            set
            {
                sceneView1.current_primitive = value;
                sceneView1.Refresh();
            }
        }



        private Camera camera;

        public Form1()
        {
            InitializeComponent();
            Current_primitive = new Icosahedron(1);
            Matrix projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
            camera = new Camera(new Vector(1, 1, 1), Math.PI / 4, -Math.PI / 4, projection);
            sceneView1.ViewCamera = camera;
            ProjectionComboBox.SelectedItem = ProjectionComboBox.Items[0];
            PrimitiveComboBox.SelectedItem = PrimitiveComboBox.Items[0];
        }

        private static double DegToRad(double deg)
        {
            return deg / 180 * Math.PI;
        }

        private void Scale()
        {
            double scalingX = (double)numericUpDown1.Value;
            double scalingY = (double)numericUpDown2.Value;
            double scalingZ = (double)numericUpDown3.Value;
            Current_primitive.Apply(Transformations.Scale(scalingX, scalingY, scalingZ));
            sceneView1.Refresh();
        }

        private void Rotate()
        {
            double rotatingX = DegToRad((double)numericUpDown4.Value);
            double rotatingY = DegToRad((double)numericUpDown5.Value);
            double rotatingZ = DegToRad((double)numericUpDown6.Value);
            Current_primitive.Apply(Transformations.RotateX(rotatingX)
                * Transformations.RotateY(rotatingY)
                * Transformations.RotateZ(rotatingZ));
            sceneView1.Refresh();
        }

        private void Translate()
        {
            double translatingX = (double)numericUpDown7.Value;
            double translatingY = (double)numericUpDown8.Value;
            double translatingZ = (double)numericUpDown9.Value;
            Current_primitive.Apply(Transformations.Translate(translatingX, translatingY, translatingZ));
            sceneView1.Refresh();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            double delta = 0.3;
            switch (keyData)
            {
                case Keys.W: camera.Position *= Transformations.Translate(0.1 * camera.Forward); break;
                case Keys.A: camera.Position *= Transformations.Translate(0.1 * camera.Left); break;
                case Keys.S: camera.Position *= Transformations.Translate(0.1 * camera.Backward); break; 
                case Keys.D: camera.Position *= Transformations.Translate(0.1 * camera.Right); break;
                case Keys.Left: camera.Fi += delta; break;
                case Keys.Right: camera.Fi -= delta; break;
                case Keys.Up: camera.Theta += delta; break;
                case Keys.Down: camera.Theta -= delta; break;
            }
            sceneView1.Refresh();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ApplyAffin_Click(object sender, EventArgs e)
        {
            Scale();
            Rotate();
            Translate();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Object Files(*.obj)|*.obj|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Current_primitive.Save(saveDialog.FileName);
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
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Object Files(*.obj)|*.obj|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                Current_primitive = new Primitive(openDialog.FileName);
            }
            catch
            {
                MessageBox.Show("Ошибка при чтении файла",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyPrimitive_Click(object sender, EventArgs e)
        {
            sceneView1.without_colors = false;
            switch(PrimitiveComboBox.SelectedItem.ToString())
            {
                case "Тетраэдр":
                    {
                        Current_primitive = new Tetrahedron(1);
                        break;
                    }
                case "Икосаэдр":
                    {
                        Current_primitive = new Icosahedron(1);
                        break;
                    }
                case "График":
                    {
                        Current_primitive = new Plot();
                        break;
                    }
                default:
                    {
                        Current_primitive = new Tetrahedron(1);
                        break;
                    }
            }

            Matrix projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
            switch (ProjectionComboBox.SelectedItem.ToString())
            {
                case "Перспективная":
                    {
                        projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
                        camera = new Camera(new Vector(1, 1, 1), Math.PI / 4, -Math.PI / 4, projection);
                        sceneView1.ViewCamera = camera;

                        break;
                    }
                case "Ортогональная XY":
                    {
                        sceneView1.ViewCamera = new Camera(new Vector(0, 0, 0), 0, 0, Transformations.RotateX(Math.PI / 2) * Transformations.OrthogonalProjection());
                        break;
                    }
                case "Ортогональная XZ":
                    {
                        sceneView1.ViewCamera = new Camera(new Vector(0, 0, 0), 0, 0, Transformations.OrthogonalProjection());
                        break;
                    }
                case "Ортогональная YZ":
                    {
                        sceneView1.ViewCamera = new Camera(new Vector(0, 0, 0), 0, 0, Transformations.RotateY(-Math.PI / 2) * Transformations.OrthogonalProjection());
                        break;
                    }
                default:
                    {
                        projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
                        break;
                    }
            }
            sceneView1.Refresh();


        }

        private void DrawWithoutColors_Click(object sender, EventArgs e)
        {
            double vi = (double)numericUpDown10.Value;
            double vj = (double)numericUpDown11.Value;
            double vk = (double)numericUpDown12.Value;
            Current_primitive.View = new Vector(vi, vj, vk);
            sceneView1.without_colors = true;
            sceneView1.Refresh();
        }
    }
}
