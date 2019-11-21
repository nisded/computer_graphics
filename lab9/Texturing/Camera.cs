namespace Texturing
{
    public class Camera
    {
        public Vector Position { get; set; }
        public double AngleY { get; set; }
        public double AngleX { get; set; }
        public Matrix Projection { get; set; }

        public Vector Forward { get { return new Vector(0, 0, -1) * Transformations.RotateX(AngleX) * Transformations.RotateY(AngleY);  } }
        public Vector Left { get { return new Vector(-1, 0, 0) * Transformations.RotateX(AngleX) * Transformations.RotateY(AngleY); } }
        public Vector Up { get { return new Vector(0, 1, 0) * Transformations.RotateX(AngleX) * Transformations.RotateY(AngleY); } }
        public Vector Right { get { return -Left; } }
        public Vector Backward { get { return -Forward; } }
        public Vector Down { get { return -Up; } }

        public Matrix ViewProjection
        {
            get
            {
                return Transformations.Translate(-Position)
                    * Transformations.RotateY(-AngleY)
                    * Transformations.RotateX(-AngleX)
                    * Projection;
            }
        }

        public Camera(Vector position, double angleY, double angleX, Matrix projection)
        {
            Position = position;
            AngleY = angleY;
            AngleX = angleX;
            Projection = projection;
        }
    }
}
