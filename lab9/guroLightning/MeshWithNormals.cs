using System.Drawing;

namespace GuroLightning
{
    public class MeshWithNormals : Mesh
    {
        public Vector[] Normals { get; set; }
        public bool VisibleNormals { get; set; } = false;

        public MeshWithNormals(Vector[] vertices, Vector[] normals, int[][] indices) : base(vertices, indices)
        {
            Normals = normals;
        }

        public override void Apply(Matrix transformation)
        {
            var normalTransformation = transformation.Inverse().Transpose();
            for (int i = 0; i < Coordinates.Length; ++i)
            {
                Coordinates[i] *= transformation;
                Normals[i] = (Normals[i] * normalTransformation).Normalize();
            }
        }

        public override void Draw(Graphics3D graphics)
        {
            foreach (var verge in Indices)
            {
                for (int i = 1; i < verge.Length - 1; ++i)
                {
                    var a = new Vertex(Coordinates[verge[0]], Color.White, Normals[verge[0]]);
                    var b = new Vertex(Coordinates[verge[i]], Color.White, Normals[verge[i]]);
                    var c = new Vertex(Coordinates[verge[i + 1]], Color.White, Normals[verge[i + 1]]);
                    graphics.DrawTriangle(a, b, c);
                }
                if (VisibleNormals)
                    for (int i = 0; i < Coordinates.Length; ++i)
                    {
                        var a = new Vertex(Coordinates[i], Color.White, Normals[i]);
                        var b = new Vertex(Coordinates[i] + Normals[i], Color.White, Normals[i]);
                        graphics.DrawLine(a, b);
                    }
            }
        }
    }
}
