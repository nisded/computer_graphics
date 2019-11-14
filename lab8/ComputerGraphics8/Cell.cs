using System.Drawing;

namespace ComputerGraphics8
{
    class Cell
    {
        public Color Color { get; set; }
        public double Z { get; set; }

        public Cell(Color color, double z)
        {
            Color = color;
            Z = z;
        }

        public Cell()
        {
            Color = SystemColors.Control;
            Z = double.MinValue;
        }
    }
}
