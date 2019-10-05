﻿using System.Collections.Generic;

namespace Shapes
{
    public class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape2.GetPerimeter().CompareTo(shape1.GetPerimeter());
        }
    }
}
