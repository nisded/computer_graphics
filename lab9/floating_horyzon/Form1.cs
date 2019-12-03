using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace floating_horyzon
{
    public partial class Form1 : Form
    {
        private Mesh current_primitive
        {
            get
            {
                return sceneView1.Drawable;
            }
            set
            {
                sceneView1.Drawable = value;
                sceneView1.Refresh();
            }
        }

        //Camera variable
        private Camera camera;

        public Form1()
        {
            InitializeComponent();
            ProjectionBox.SelectedItem = ProjectionBox.Items[0];
            current_primitive = Plot.get_plot(-0.8, 0.8, 0.1, -0.8, 0.8, 0.1);
            Matrix projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
            camera = new Camera(new Vector(1, 1, 1), Math.PI / 4, -Math.Atan(1 / Math.Sqrt(3)), projection);
            sceneView1.Camera = camera;
        }

        //Change current view to Plot
        private void ApplyProjection_Click(object sender, EventArgs e)
        {
            switch(ProjectionBox.SelectedItem.ToString())
            {
                case ("Перспективная"):
                    {
                        Matrix projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
                        camera = new Camera(new Vector(1, 1, 1), Math.PI / 4, -Math.Atan(1 / Math.Sqrt(3)), projection);
                        sceneView1.Camera = camera;
                        break;
                    }
                case ("Ортографическая XY"):
                    {
                        camera = new Camera(new Vector(0, 0, 0), 0, 0, Transformations.OrthogonalProjection());
                        sceneView1.Camera = camera;
                        break;
                    }
                case ("Ортографическая XZ"):
                    {
                        camera = new Camera(new Vector(0, 0, 0), 0, 0,Transformations.RotateX(Math.PI / 2) * Transformations.OrthogonalProjection());
                        sceneView1.Camera = camera;
                        break;
                    }
                case ("Ортографическая YZ"):
                    {
                        camera = new Camera(new Vector(0, 0, 0), 0, 0, Transformations.RotateY(-Math.PI / 2) * Transformations.OrthogonalProjection());
                        sceneView1.Camera = camera;
                        break;
                    }
                default:
                    {
                        Matrix projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
                        camera = new Camera(new Vector(1, 1, 1), Math.PI / 4, -Math.Atan(1 / Math.Sqrt(3)), projection);
                        sceneView1.Camera = camera;
                        break;
                    }
            }
            sceneView1.Refresh();
        }

        //Moves values in degrees to radians
        private static double DegreesToRadians(double degrees)
        {
            return degrees / 180 * Math.PI;
        }

        //Scale current primitive
        private void Scale()
        {
            double scalingX = (double)numericUpDown1.Value;
            double scalingY = (double)numericUpDown2.Value;
            double scalingZ = (double)numericUpDown3.Value;
            current_primitive.Apply(Transformations.Scale(scalingX, scalingY, scalingZ));
            sceneView1.Refresh();
        }

        //Rotate current primitive
        private void Rotate()
        {
            double rotatingX = DegreesToRadians((double)numericUpDown4.Value);
            double rotatingY = DegreesToRadians((double)numericUpDown5.Value);
            double rotatingZ = DegreesToRadians((double)numericUpDown6.Value);
            current_primitive.Apply(Transformations.RotateX(rotatingX)
                * Transformations.RotateY(rotatingY)
                * Transformations.RotateZ(rotatingZ));
            sceneView1.Refresh();
        }

        //Translate current primitive
        private void Translate()
        {
            double translatingX = (double)numericUpDown7.Value;
            double translatingY = (double)numericUpDown8.Value;
            double translatingZ = (double)numericUpDown9.Value;
            current_primitive.Apply(Transformations.Translate(translatingX, translatingY, translatingZ));
            sceneView1.Refresh();
        }

        //Overriding keyboard keys for camera moves
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            double delta = 0.3;
            switch (keyData)
            {
                case Keys.W: camera.Position *= Transformations.Translate(0.1 * camera.Forward); break;
                case Keys.A: camera.Position *= Transformations.Translate(0.1 * camera.Left); break;
                case Keys.S: camera.Position *= Transformations.Translate(0.1 * camera.Backward); break;
                case Keys.D: camera.Position *= Transformations.Translate(0.1 * camera.Right); break;
                case Keys.Left: camera.AngleY += delta; break;
                case Keys.Right: camera.AngleY -= delta; break;
                case Keys.Up: camera.AngleX += delta; break;
                case Keys.Down: camera.AngleX -= delta; break;
            }
            sceneView1.Refresh();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ApplyAffin_Click(object sender, EventArgs e)
        {
            Scale();
            Rotate();
            Translate();
            sceneView1.Refresh();
        }

        private void SaveFile()
        {
            if (!(current_primitive is Mesh)) return;
            var mesh = current_primitive;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Object Files(*.obj)|*.obj|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    mesh.Save(saveDialog.FileName);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно сохранить файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadFile()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Object Files(*.obj)|*.obj|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                current_primitive = new Mesh(openDialog.FileName);
            }
            catch
            {
                MessageBox.Show("Ошибка при чтении файла",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadFile();
        }
    }
}
