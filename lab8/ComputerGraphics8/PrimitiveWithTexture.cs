using System.Drawing;

namespace ComputerGraphics8
{
    public class PrimitiveWithTexture : Primitive
    {
        PointF[][] textureCoordinates;

        public PrimitiveWithTexture(Vector[] vertices, int[][] verges, PointF[][] textureCoordinates) : base(vertices, verges)
        {
            this.textureCoordinates = textureCoordinates;
        }
    }
}
