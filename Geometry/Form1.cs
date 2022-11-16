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

            IGeometry newGeometrySector = NewSector(5, 150);
            IGeometry newGeometryCircle = NewCircle(4, 120);
            IGeometry newGeometryRectangle = NewRectangle(6, 5);
            IGeometry newGeometrySquare = NewSquare(2, 6);

            Console.WriteLine("Sector Perimeter: " + newGeometrySector.Perimeter());
            Console.WriteLine("Sector Area: " + newGeometrySector.Area());
            Console.WriteLine("Circle Perimeter: " + newGeometryCircle.Perimeter());
            Console.WriteLine("Circle Area: " + newGeometryCircle.Area());
            Console.WriteLine("Rectangle Perimeter: " + newGeometryRectangle.Perimeter());
            Console.WriteLine("Rectangle Area: " + newGeometryRectangle.Area());
            Console.WriteLine("Square Perimeter: " + newGeometrySquare.Perimeter());
            Console.WriteLine("Square Area: " + newGeometrySquare.Area());   
        }

        public Sector NewSector(int radius, int angle)
        {
            Sector geometrySector = new Sector(radius, angle);
            return geometrySector;
        }

        public Circle NewCircle(int radius, int angle)
        {
            Circle geometryCircle = new Circle(radius, angle);
            return geometryCircle;
        }

        public Rectangle NewRectangle(int length, int width)
        {
            Rectangle geometryRectangle = new Rectangle(length, width);
            return geometryRectangle;
        }

        public Square NewSquare(int length, int width)
        {
            Square geometrySquare = new Square(length, width);
            return geometrySquare;
        }
    }
}
