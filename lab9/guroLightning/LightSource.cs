using System.Drawing;

namespace GuroLightning
{
    public class LightSource
    {
        public Vector Coordinate { get; set; }
        public Color Color { get; set; }

        public LightSource(Vector coordinate, Color color)
        {
            Coordinate = coordinate;
            Color = color;
        }
    }
}
