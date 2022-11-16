using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Circle : Sector, IGeometry
    {
        public Circle(double _radius) : base(_radius)
        {
            angle = 360;
            radius = _radius;
        }

        public override double Perimeter()
        {
            return 2 * radius * Math.PI * (angle / 360);
        }

        public override double Area()
        {
            return radius * radius * Math.PI * (angle / 360);
        }
    }
}
