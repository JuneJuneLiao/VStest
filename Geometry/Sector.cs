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
        protected double radius;

        private double _radius;

        public Sector(double _angle, double _radius)
        {
            angle = _angle;
            radius = _radius;
        }

        public Sector(double radius)
        {
            _radius = radius;
        }

        public virtual double Perimeter()
        {    
            return 2 * radius * Math.PI * (angle / 360);    
        }

        public virtual double Area()
        {
            return radius * radius * Math.PI * (angle / 360);  
        }
    }
}
