using Texturing.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Texturing
{
    public static class Models
    {
        public static Mesh Cube(double size)
        {
            double s = size / 2;
            return new MeshWithTexture(Resources.Texture3,
                new Vector[24]
                {
                    new Vector(-s, -s, s),
                    new Vector(s, -s, s),
                    new Vector(s, s, s),
                    new Vector(-s, s, s),

                    new Vector(s, -s, s),
                    new Vector(s, -s, -s),
                    new Vector(s, s, -s),
                    new Vector(s, s, s),

                    new Vector(s, -s, -s),
                    new Vector(-s, -s, -s),
                    new Vector(-s, s, -s),
                    new Vector(s, s, -s),

                    new Vector(-s, -s, -s),
                    new Vector(-s, -s, s),
                    new Vector(-s, s, s),
                    new Vector(-s, s, -s),

                    new Vector(-s, -s, -s),
                    new Vector(s, -s, -s),
                    new Vector(s, -s, s),
                    new Vector(-s, -s, s),

                    new Vector(-s, s, s),
                    new Vector(s, s, s),
                    new Vector(s, s, -s),
                    new Vector(-s, s, -s),
                },
                new Vector[24]
                {
                    new Vector(0, 0),
                    new Vector(1, 0),
                    new Vector(1, 1),
                    new Vector(0, 1),

                    new Vector(0, 0),
                    new Vector(1, 0),
                    new Vector(1, 1),
                    new Vector(0, 1),

                    new Vector(0, 0),
                    new Vector(1, 0),
                    new Vector(1, 1),
                    new Vector(0, 1),

                    new Vector(0, 0),
                    new Vector(1, 0),
                    new Vector(1, 1),
                    new Vector(0, 1),

                    new Vector(0, 0),
                    new Vector(1, 0),
                    new Vector(1, 1),
                    new Vector(0, 1),

                    new Vector(0, 0),
                    new Vector(1, 0),
                    new Vector(1, 1),
                    new Vector(0, 1),
                },
                new int[6][]
                {
                   new int[4] { 0, 3, 2, 1 },
                   new int[4] { 4, 7, 6, 5 },
                   new int[4] { 8, 11, 10, 9 },
                   new int[4] { 12, 15, 14, 13 },
                   new int[4] { 16, 19, 18, 17 },
                   new int[4] { 20, 23, 22, 21 },
                });
        }

    }
}
