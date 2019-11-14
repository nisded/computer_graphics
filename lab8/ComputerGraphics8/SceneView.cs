using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphics8
{
    class SceneView : Control
    {
        public Camera ViewCamera { get; set; }
        public Primitive current_primitive { get; set; }

        public bool without_colors = false;

        public Vector View { get; set; }

        public SceneView() : base()
        {
            var flags = ControlStyles.AllPaintingInWmPaint
                      | ControlStyles.DoubleBuffer
                      | ControlStyles.UserPaint;
            SetStyle(flags, true);
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);
            if (current_primitive == null)
            {
                return;
            }
            e.Graphics.Clear(SystemColors.Control);
            e.Graphics.DrawLines(Pens.Black, new Point[]
                {
                    new Point(1, 1),
                    new Point(1, Height - 1),
                    new Point(Width - 1, Height - 1),
                    new Point(Width - 1, 1),
                    new Point(1, 1)
                });

            if (current_primitive == null)
            {
                return;
            }

            var graphics3D = new Graphics3D(e.Graphics, ViewCamera.ViewProjection, Width, Height);


			if (without_colors)
				current_primitive.Draw_without_colors(graphics3D);
			else
			{
				var x = new Vector(0.8, 0, 0);
				var y = new Vector(0, 0.8, 0);
				var z = new Vector(0, 0, 0.8);
				graphics3D.DrawLine(new Vector(0, 0, 0), x, new Pen(Color.Red, 2));
				graphics3D.DrawPoint(x, Color.Red);
				graphics3D.DrawLine(new Vector(0, 0, 0), y, new Pen(Color.Green, 2));
				graphics3D.DrawPoint(y, Color.Green);
				graphics3D.DrawLine(new Vector(0, 0, 0), z, new Pen(Color.Blue, 2));
				graphics3D.DrawPoint(z, Color.Blue);
				current_primitive.Draw(graphics3D);
			}

            e.Graphics.DrawImage(graphics3D.ColorBuffer, 0, 0);
        }
    }
}
