using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Sector : IGeometry
    {
        private string name { get; }

        private double angle;

        public virtual double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public double Radius;

        public Sector(double radius, double angle)
        {
            this.angle = angle;
            Radius = radius;
            name = "Sector";
        }

        public double Perimeter()
        {    
            return 2 * Radius * Math.PI * (Angle / 360);    
        }

        public double Area()
        {
            return Radius * Radius * Math.PI * (Angle / 360);  
        }

        public virtual string Name()
        {
            return name; 
        }
    }
}
