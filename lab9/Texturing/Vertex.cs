using System.Drawing;

namespace Texturing
{
    public class Vertex
    {
        public Vector Coordinate { get; set; }
        public Color Color { get; set; }
        public Vector Normal { get; set; }
        public Vector UVCoordinate { get; set; }

        public Vertex(Vector coordinate) : this(coordinate, Color.White) { }

        public Vertex(Vector coordinate, Color color) : this(coordinate, color, new Vector(0, 0, 0)) { }

        public Vertex(Vector coordinate, Color color, Vector normal) : this(coordinate, color, normal, new Vector(0, 0, 0)) { }

        public Vertex(Vector coordinate, Color color, Vector normal, Vector textureCoordinate)
        {
            Coordinate = coordinate;
            Color = color;
            Normal = normal;
            UVCoordinate = textureCoordinate;
        }

        public Vertex(Vector coordinate, Vector textureCoordinate) : this(coordinate, Color.Black, new Vector(0, 0, 0), textureCoordinate)
        { }
    }
}
