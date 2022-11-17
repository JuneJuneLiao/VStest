using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Rectangle : IGeometry
    {
        public double Length;
        public double Width;

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double Perimeter()
        {
            return 2 * (Length + Width);
        }

        public double Area()
        {
            return Length * Width;
        }
    }
}
