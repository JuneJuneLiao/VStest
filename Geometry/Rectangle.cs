using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Rectangle : IGeometry
    {
        protected double length;
        protected double width;
        private double _length;

        public Rectangle(double _length, double _width)
        {
            length = _length;
            width = _width;
        }

        public Rectangle(double length)
        {
            _length = length;
        }

        public virtual double Perimeter()
        {
            return 2 * (length + width);
        }

        public virtual double Area()
        {
            return length * width;
        }
    }
}
