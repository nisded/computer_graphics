using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polygon_intersection
{
    public class PolygonNode
    {
        public PointF p;
        public bool isIntersection;
        public LinkedListNode<PolygonNode> intersectionInOtherPolygon;

        public PolygonNode(PointF p, bool isIntersection = false)
        {
            this.p = p;
            this.isIntersection = isIntersection;
        }
    }
}
