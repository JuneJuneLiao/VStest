using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
    class Square : Rectangle
    {
        public override double Width
        {
            get { return Length; }
            set { MessageBox.Show("Invalid Width Input"); }
        }

        public Square(double length) : base(length, length)
        {  
        }
    }
}
