using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Square : Rectangle
    {
        public override double Width
        {
            get { return Length; }
            set { width = value; }
        }

        public Square(double length) : base(length, length)
        {  
        }
    }
}
