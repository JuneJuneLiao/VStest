using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Square : Rectangle, IGeometry
    {
        public Square(double _length) : base(_length)
        {
            length = _length;
        }
            
        public override double Perimeter()
        {
            return 2 * (length + length);            
        }

        public override double Area()
        {
            return length * length;
        }
    }
}
