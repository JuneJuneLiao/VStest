using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Sector : IGeometry
    {
        protected int angle;
        protected int radius;

        public virtual int Perimeter()
        {    
            return Convert.ToInt32(2 * radius * Math.PI * (angle / 360));    
        }

        public virtual int Area()
        {
            return Convert.ToInt32(radius * radius * Math.PI * (angle / 360));  
        }
    }
}
