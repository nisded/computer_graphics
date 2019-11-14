namespace ComputerGraphics8
{
    public class PrimitiveWithNormals : Primitive
    {
        public Vector[][] Normals { get; set; }

        public PrimitiveWithNormals(Vector[] vertices, int[][] verges, Vector[][] normals) : base(vertices, verges)
        {
            Normals = normals;
        }

        public override void Draw(Graphics3D graphics)
        {
            base.Draw(graphics);
        }
        

    }
}
