﻿using System;
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
            IGeometry newGeometryCircle = NewCircle(3);
            IGeometry newGeometryRectangle = NewRectangle(6, 2);
            IGeometry newGeometrySquare = NewSquare(3);

            Console.WriteLine("Sector Perimeter: " + newGeometrySector.Perimeter());
            Console.WriteLine("Sector Area: " + newGeometrySector.Area());
            Console.WriteLine("Circle Perimeter: " + newGeometryCircle.Perimeter());
            Console.WriteLine("Circle Area: " + newGeometryCircle.Area());
            Console.WriteLine("Rectangle Perimeter: " + newGeometryRectangle.Perimeter());
            Console.WriteLine("Rectangle Area: " + newGeometryRectangle.Area());
            Console.WriteLine("Square Perimeter: " + newGeometrySquare.Perimeter());
            Console.WriteLine("Square Area: " + newGeometrySquare.Area());   
        }

        public Sector NewSector(double radius, double angle)
        {
            Sector geometrySector = new Sector(radius, angle);
            return geometrySector;
        }

        public Circle NewCircle(double radius)
        {
            //radius = 8;
            Circle geometryCircle = new Circle(radius);
            geometryCircle.RadiusUpgrade();
            return geometryCircle;
        }

        public Rectangle NewRectangle(double length, double width)
        {
            Rectangle geometryRectangle = new Rectangle(length, width);
            return geometryRectangle;
        }

        public Square NewSquare(double length)
        {
            //length = 7;
            Square geometrySquare = new Square(length);
            geometrySquare.LengthUpgrade();
            return geometrySquare;
        }
    }
}
