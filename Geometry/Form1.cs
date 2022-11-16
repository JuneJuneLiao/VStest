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
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            IGeometry newGeometrySector = NewSector();
            IGeometry newGeometryCircle = NewCircle();
            IGeometry newGeometryRectangle = NewRectangle();
            IGeometry newGeometrySquare = NewSquare();

            Console.WriteLine("Sector Perimeter: " + newGeometrySector.Perimeter());
            Console.WriteLine("Sector Area: " + newGeometrySector.Area());
            Console.WriteLine("Circle Perimeter: " + newGeometryCircle.Perimeter());
            Console.WriteLine("Circle Area: " + newGeometryCircle.Area());
            Console.WriteLine("Rectangle Perimeter: " + newGeometryRectangle.Perimeter());
            Console.WriteLine("Rectangle Area: " + newGeometryRectangle.Area());
            Console.WriteLine("Square Perimeter: " + newGeometrySquare.Perimeter());
            Console.WriteLine("Square Area: " + newGeometrySquare.Area());
            
        }

        public Sector NewSector(int radius = 5, int angle = 150)
        {
            Sector geometrySector = new Sector(angle, radius);
            return geometrySector;
        }

        public Circle NewCircle(int radius = 3)
        {
            Circle geometryCircle = new Circle(radius);
            return geometryCircle;
        }

        public Rectangle NewRectangle(int length = 4 , int width = 5)
        {
            Rectangle geometryRectangle = new Rectangle(length, width);
            return geometryRectangle;
        }

        public Square NewSquare(int length = 2)
        {
            Square geometrySquare = new Square(length);
            return geometrySquare;
        }
    }
}
