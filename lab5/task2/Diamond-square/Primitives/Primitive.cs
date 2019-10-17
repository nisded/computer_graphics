using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Diamond_square.Primitives
{
    interface Primitive
    {
        void Draw(Graphics g, bool selected);
        void Apply(Transformation t);
    }
}
