using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GuroLightning
{
    public static class Models
    {
        public static Mesh Sphere(double diameter, int slices, int stacks)
        {
            var radius = diameter / 2;
            var vertices = new Vector[slices * stacks];
            var normals = new Vector[slices * stacks];
            var indices = new int[slices * (stacks - 1)][];
            for (int stack = 0; stack < stacks; ++stack)
                for (int slice = 0; slice < slices; ++slice)
                {
                    var theta = Math.PI * stack / (stacks - 1.0);
                    var phi = 2 * Math.PI * (slice / (slices - 1.0));
                    vertices[stack * slices + slice] = new Vector(
                        radius * Math.Sin(theta) * Math.Cos(phi),
                        radius * Math.Sin(theta) * Math.Sin(phi),
                        radius * Math.Cos(theta));
                    normals[stack * slices + slice] = vertices[stack * slices + slice].Normalize();
                }
            for (int stack = 0; stack < stacks - 1; ++stack)
                for (int slice = 0; slice < slices; ++slice)
                    indices[stack * slices + slice] = new int[4] {
                        stack * slices + ((slice + 1) % slices),
                        (stack + 1) * slices + ((slice + 1) % slices),
                        (stack + 1) * slices + slice,
                        stack * slices + slice,};
            return new MeshWithNormals(vertices, normals, indices);
        }
    }
}
