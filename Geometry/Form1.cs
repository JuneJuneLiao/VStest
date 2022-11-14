using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        IGeometry geometrySector = new Sector();
        IGeometry geometryCircle = new Circle();
        IGeometry geometryRectangle = new Rectangle();
        IGeometry geometrySquare = new Square();

        public void Sector(int radius = 2, int angle = 120)
        {
            geometrySector.Perimeter();
            geometrySector.Area();
            return;
        }

        public void Circle(int radius = 3)
        {
            geometryCircle.Perimeter();
            geometryCircle.Area();
            return;
        }

        public void Rectangle(int length = 4 , int width = 5)
        {
            geometryRectangle.Perimeter();
            geometryRectangle.Area();
            return;
        }

        public void Square(int length = 2)
        {
            geometrySquare.Perimeter();
            geometrySquare.Area();
            return;
        }
    }
}
