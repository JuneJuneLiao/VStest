﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public interface IGeometry
    {
        double Perimeter();
        double Area();
        string Name{ get; }
    }
}
