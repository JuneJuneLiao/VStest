using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Sector : IGeometry
    {
        public virtual string Name { get { return "Sector"; } }

        public double Radius;

        private double angle;
        public virtual double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public Sector(double radius, double angle)
        {
            Radius = radius;
            this.angle = angle;   
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
