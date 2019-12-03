using System.Drawing;
using System.Windows.Forms;
using System;

namespace GuroLightning
{
    public class SceneView : Control
    {
        public Camera Camera { get; set; }
        public Mesh Drawable { get; set; }

        public Graphics3D Graphics3D { get; private set; }

        public SceneView() : base()
        {
            var flags = ControlStyles.AllPaintingInWmPaint
                      | ControlStyles.DoubleBuffer
                      | ControlStyles.UserPaint;
            SetStyle(flags, true);
            ResizeRedraw = true;
            Graphics3D = new Graphics3D(this);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Graphics3D.Resize();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (null == Camera)
                return;
            var zero = new Vector(0, 0, 0);
            var x = new Vector(0.8, 0, 0);
            var y = new Vector(0, 0.8, 0);
            var z = new Vector(0, 0, 0.8);
            Graphics3D.StartDrawing();
            Graphics3D.DrawLine(
                new Vertex(zero, Color.Red), 
                new Vertex(x, Color.Red));
            Graphics3D.DrawPoint(new Vertex(x, Color.Red));
            Graphics3D.DrawLine(
                new Vertex(zero, Color.Green), 
                new Vertex(y, Color.Green));
            Graphics3D.DrawPoint(new Vertex(y, Color.Green));
            Graphics3D.DrawLine(
                new Vertex(zero, Color.Blue), 
                new Vertex(z, Color.Blue));
            Graphics3D.DrawPoint(new Vertex(z, Color.Blue));
            Drawable.Draw(Graphics3D);
            e.Graphics.DrawImage(Graphics3D.FinishDrawing(), 0, 0);
        }
    }
}
