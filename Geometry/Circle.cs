using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Circle : Sector, IGeometry
    {
        public Circle()
        {
            angle = 360;    
        }

        public override int Perimeter()
        {
            return Convert.ToInt32(2 * radius * Math.PI * (angle / 360));
        }

        public override int Area()
        {
            return Convert.ToInt32(radius * radius * Math.PI * (angle / 360));
        }
    }
}
