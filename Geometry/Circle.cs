using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
    class Circle : Sector
    {
        public override double Angle
        {
            get { return 360; }
            set { MessageBox.Show("Invalid Angle Input"); }
        }

        public Circle(double radius) : base(radius, 360)
        {
        }
    }
}
