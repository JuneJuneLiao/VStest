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

            IGeometry sector = NewSector(5, 150);
            IGeometry circle = NewCircle(3);
            IGeometry rectangle = NewRectangle(6, 2);
            IGeometry square = NewSquare(3);

            Console.WriteLine($"{sector.Name}, Perimeter: {sector.Perimeter()}, Area: {sector.Area()}");
            Console.WriteLine($"{circle.Name}, Perimeter: {circle.Perimeter()}, Area: {circle.Area()}");
            Console.WriteLine($"{rectangle.Name}, Perimeter: {rectangle.Perimeter()}, Area: {rectangle.Area()}");
            Console.WriteLine($"{square.Name}, Perimeter: {square.Perimeter()}, Area: {square.Area()}");
        }

        public Sector NewSector(double radius, double angle)
        {
            Sector geometrySector = new Sector(radius, angle);
            geometrySector.Radius = 6;
            geometrySector.Angle = 120;
            return geometrySector;
        }

        public Circle NewCircle(double radius)
        {
            Circle geometryCircle = new Circle(radius);
            geometryCircle.Radius = 4;
            geometryCircle.Angle = 10;
            return geometryCircle;
        }

        public Rectangle NewRectangle(double length, double width)
        {
            Rectangle geometryRectangle = new Rectangle(length, width);
            geometryRectangle.Length = 10;
            geometryRectangle.Width = 5;
            return geometryRectangle;
        }

        public Square NewSquare(double length)
        {
            Square geometrySquare = new Square(length);
            geometrySquare.Length = 12;
            geometrySquare.Width = 7;
            return geometrySquare;
        }
    }
}
