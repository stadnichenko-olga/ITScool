﻿using Shapes.ShapePatterns;
using System.Collections.Generic;

namespace Shapes.Comparers
{
    public class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape2.GetArea().CompareTo(shape1.GetArea());
        }
    }
}
