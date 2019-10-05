using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polygon_intersection
{
    class PolygonNode
    {
        public PointF p;
        public bool isIntersection;
        public LinkedList<PolygonNode> otherNode;

        public PolygonNode(PointF p, bool isIntersection = false)
        {
            this.p = p;
            this.isIntersection = isIntersection;
        }
    }
}
