using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texturing
{
    public partial class Form1 : Form
    {
        private Mesh cur_obj;

        private Camera camera;

        public Form1()
        {
            InitializeComponent();
            ProjectionBox.SelectedItem = ProjectionBox.Items[0];
            cur_obj = Models.Cube(0.5);
            Matrix projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
            camera = new Camera(new Vector(1, 1, 1), Math.PI / 4, -Math.Atan(1 / Math.Sqrt(3)), projection);
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees / 180 * Math.PI;
        }

        private void Scale()
        {
            double scalingX = (double)numericUpDown1.Value;
            double scalingY = (double)numericUpDown2.Value;
            double scalingZ = (double)numericUpDown3.Value;
            cur_obj.Apply(Transformations.Scale(scalingX, scalingY, scalingZ));
            pictureBox1.Invalidate();
        }

        private void Rotate()
        {
            double rotatingX = DegreesToRadians((double)numericUpDown4.Value);
            double rotatingY = DegreesToRadians((double)numericUpDown5.Value);
            double rotatingZ = DegreesToRadians((double)numericUpDown6.Value);
            cur_obj.Apply(Transformations.RotateX(rotatingX)
                * Transformations.RotateY(rotatingY)
                * Transformations.RotateZ(rotatingZ));
            pictureBox1.Invalidate();
        }

        private void Translate()
        {
            double translatingX = (double)numericUpDown7.Value;
            double translatingY = (double)numericUpDown8.Value;
            double translatingZ = (double)numericUpDown9.Value;
            cur_obj.Apply(Transformations.Translate(translatingX, translatingY, translatingZ));
            pictureBox1.Invalidate();
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
                case Keys.Left: camera.AngleY += delta; break;
                case Keys.Right: camera.AngleY -= delta; break;
                case Keys.Up: camera.AngleX += delta; break;
                case Keys.Down: camera.AngleX -= delta; break;
            }
            pictureBox1.Invalidate();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ApplyProjection_Click(object sender, EventArgs e)
        {
            switch (ProjectionBox.SelectedItem.ToString())
            {
                case ("Перспективная"):
                    {
                        Matrix projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
                        camera = new Camera(new Vector(1, 1, 1), Math.PI / 4, -Math.Atan(1 / Math.Sqrt(3)), projection);
                        break;
                    }
                case ("Ортографическая XY"):
                    {
                        camera = new Camera(new Vector(0, 0, 0), 0, 0, Transformations.OrthogonalProjection());
                        break;
                    }
                case ("Ортографическая XZ"):
                    {
                        camera = new Camera(new Vector(0, 0, 0), 0, 0, Transformations.RotateX(Math.PI / 2) * Transformations.OrthogonalProjection());
                        break;
                    }
                case ("Ортографическая YZ"):
                    {
                        camera = new Camera(new Vector(0, 0, 0), 0, 0, Transformations.RotateY(-Math.PI / 2) * Transformations.OrthogonalProjection());
                        break;
                    }
                default:
                    {
                        Matrix projection = Transformations.PerspectiveProjection(-0.1, 0.1, -0.1, 0.1, 0.1, 20);
                        camera = new Camera(new Vector(1, 1, 1), Math.PI / 4, -Math.Atan(1 / Math.Sqrt(3)), projection);
                        break;
                    }
            }
            pictureBox1.Invalidate();
        }

        private void ApplyAffin_Click(object sender, EventArgs e)
        {
            Scale();
            Rotate();
            Translate();
            pictureBox1.Invalidate();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.FillRectangle(Brushes.Black, 0, 0, pictureBox1.Width, pictureBox1.Height);
            var graphics3D = new Graphics3D(e.Graphics, camera.ViewProjection, pictureBox1.Width, pictureBox1.Height, cur_obj.Center, camera.Position);
            var zero = new Vector(0, 0, 0);
            var x = new Vector(0.8, 0, 0);
            var y = new Vector(0, 0.8, 0);
            var z = new Vector(0, 0, 0.8);
            graphics3D.DrawLine(
                new Vertex(zero, Color.Red),
                new Vertex(x, Color.Red));
            graphics3D.DrawPoint(new Vertex(x, Color.Red));
            graphics3D.DrawLine(
                new Vertex(zero, Color.Green),
                new Vertex(y, Color.Green));
            graphics3D.DrawPoint(new Vertex(y, Color.Green));
            graphics3D.DrawLine(
                new Vertex(zero, Color.Blue),
                new Vertex(z, Color.Blue));
            graphics3D.DrawPoint(new Vertex(z, Color.Blue));
            cur_obj.Draw(graphics3D);
            e.Graphics.DrawImage(graphics3D.colorBuffer, 0, 0);
        }
    }
}
