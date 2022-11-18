using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Circle : Sector
    {
        public override double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public Circle(double radius) : base(radius, 360)
        {
        }
    }
}
