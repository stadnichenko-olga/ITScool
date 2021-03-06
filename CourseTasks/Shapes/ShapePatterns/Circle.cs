﻿using System;

namespace Shapes.ShapePatterns
{
    public class Circle : IShape
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetWidth()
        {
            return 2 * radius;
        }

        public double GetHeight()
        {
            return 2 * radius;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Circle shape = (Circle)obj;

            return radius == shape.radius;
        }

        public override int GetHashCode()
        {
            return radius.GetHashCode();
        }

        public override string ToString()
        {
            return $"Circle, radius = {radius}";
        }
    }
}
