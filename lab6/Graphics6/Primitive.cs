using System.Drawing;

namespace Graphics6
{
    interface Primitive
    {
        void Draw(Graphics g, Transform projection, int width, int height);

        void Apply(Transform t);       
    }
}
