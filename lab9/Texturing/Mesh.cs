using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Texturing
{
    public class Mesh
    {
        public Vector[] Coordinates { get; set; }
		public int[][] Indices { get; set; }

        public Mesh(Vector[] vertices, int[][] indices)
        {
            Coordinates = vertices;
            Indices = indices;
        }

        public virtual void Apply(Matrix transformation)
        {
            for (int i = 0; i < Coordinates.Length; ++i)
                Coordinates[i] *= transformation;
        }

        public virtual void Draw(Graphics3D graphics)
        {
            foreach (var facet in Indices)
                for (int i = 0; i < facet.Length; ++i)
                {
                    var a = new Vertex(Coordinates[facet[i]]);
                    var b = new Vertex(Coordinates[facet[(i + 1) % facet.Length]]);
                    graphics.DrawLine(a, b);
                }
        }
    }
}
