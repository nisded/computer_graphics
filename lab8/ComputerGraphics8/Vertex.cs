using System.Drawing;

namespace ComputerGraphics8
{
    public class Vertex
    {
        public Vector Coordinate { get; set; }
        public Vector Normal { get; set; }
        public Color Color { get; set; }

        public Vertex() { }

        public Vertex(Vector coordinate, Vector normal, Color color)
        {
            Coordinate = coordinate;
            Normal = normal;
            Color = color;
        }
    }
}
