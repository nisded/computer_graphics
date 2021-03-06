﻿using System.Collections.Generic;
using System.Drawing;

namespace Graphics6
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
