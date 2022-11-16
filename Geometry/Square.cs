using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Square : Rectangle, IGeometry
    {
        public Square(double length, double width) : base(length, width)
        {
            this.length = length;
            this.width = length;
        }
    }
}
