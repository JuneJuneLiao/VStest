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
            get { return 360; }
            set
            {
                /*if (angle == 0)
                    angle = 360;*/
               
               Console.WriteLine("Error");
            }
        }

        public Circle(double radius) : base(radius, 360)
        {
        }
    }
}
