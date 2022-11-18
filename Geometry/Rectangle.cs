using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Rectangle : IGeometry
    {
        protected double length;

        public virtual double Length { get; set; }

        protected double width;

        public virtual double Width
        {
            get { return width; }
            set { width = value; }
        }

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public double Perimeter()
        {
            return 2 * (Length + Width);
        }

        public double Area()
        {
            return Length * Width;
        }

        public virtual string Name
        {
            get { return "Rectangle"; }
        }
    }
}
