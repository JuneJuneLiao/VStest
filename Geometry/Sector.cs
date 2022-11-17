using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Sector : IGeometry
    {
        protected double angle;

        public double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public double Radius;

        public Sector(double radius, double angle)
        {
            Angle = angle;
            Radius = radius;
        }

        public double Perimeter()
        {    
            return 2 * Radius * Math.PI * (Angle / 360);    
        }

        public double Area()
        {
            return Radius * Radius * Math.PI * (Angle / 360);  
        }
    }
}
