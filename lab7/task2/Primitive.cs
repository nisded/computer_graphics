using System.Collections.Generic;
using System.Drawing;

namespace RotationFigure
{
    interface Primitive
    {
        List<XYZPoint> Points { get; }

        List<Verge> Verges { get; }

        void Draw(Graphics g, Transform projection, int width, int height);

        void Apply(Transform t);

        string ToString();
    }
}
