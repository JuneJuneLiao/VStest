using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Square : Rectangle, IGeometry
    {
        public Square()
        {
            length = width;
        }
            
        public override int Perimeter()
        {
            return Convert.ToInt32(2 * (length + length));            
        }

        public override int Area()
        {
            return Convert.ToInt32(length * length);
        }
    }
}
