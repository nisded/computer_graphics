using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace affine_transformations2D
{
    /// <summary>
    /// Класс Segment для задания отрезка (две точки - начало и конец отрезка) 
    /// </summary>
    class Segment
    {
        public Point leftP, rightP;

        public Segment() { leftP = new Point(); rightP = new Point(); }

        public Segment(Point l, Point r) { leftP = l; rightP = r; }
    }
}
