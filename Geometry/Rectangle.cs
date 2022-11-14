using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Rectangle : IGeometry
    {
        protected int length;
        protected int width;

        public virtual int Perimeter()
        {
            return Convert.ToInt32(2 * (length + width));
        }

        public virtual int Area()
        {
            return Convert.ToInt32(length * width);
        }
    }
}
