using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Circle : Sector, IGeometry
    {
        public Circle(double radius, double angle) :base(radius, angle)
        {
            this.angle = 360;
            this.radius = radius;
        }
    }
}
