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
        public override string Name { get { return "Square"; } }

        public override double Length
        {
            get { return length; }
            set
            {
                length = value;
                width = value;
            }
        }

        public override double Width
        {
            set { MessageBox.Show("Invalid Width Input"); }
        }

        public Square(double length) : base(length, length)
        {
        }
    }
}
