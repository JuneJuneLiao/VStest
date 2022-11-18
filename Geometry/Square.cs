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
        private string name { get; }

        public override double Length
        {
            get { return width; }
            set { width = value; }
        }

        public override double Width
        {
            set { MessageBox.Show("Invalid Width Input"); }
        }

        public Square(double length) : base(length, length)
        {
            name = "Square";
        }

        public override string Name()
        {
            return name;
        }
    }
}
