using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Sector : IGeometry
    {
        private double angle;
        public  double radius;
        public double _angle;

        public Sector(double radius, double angle)
        {
            this.angle = angle;
            this.radius = radius;
            _angle = angle;
        }

        public double Perimeter()
        {    
            return 2 * radius * Math.PI * (angle / 360);    
        }

        public double Area()
        {
            return radius * radius * Math.PI * (angle / 360);  
        }
    }
}
