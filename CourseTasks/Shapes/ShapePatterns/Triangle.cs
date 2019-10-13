﻿using System;

namespace Shapes.ShapePatterns
{
    public class Triangle : IShape
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public double GetWidth() //max(x1, x2, x3) – min(x1, x2, x3)
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
        }

        public double GetHeight() //max(y1, y2, y3) – min(y1, y2, y3)
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
        }

        public double GetArea()
        {
            return 0.5 * Math.Abs((x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1));
        }

        public double GetPerimeter()
        {
            double a = GetLength(x1, x2, y1, y2);
            double b = GetLength(x1, x3, y1, y3);
            double c = GetLength(x2, x3, y2, y3);
            return a + b + c;
        }

        private double GetLength(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return obj is Triangle shape &&
                   shape.x1 == this.x1 && shape.y1 == this.y1 &&
                   shape.x2 == this.x2 && shape.y2 == this.y2 &&
                   shape.x3 == this.x3 && shape.y3 == this.y3;
        }

        public override int GetHashCode()
        {
            return x1.GetHashCode() ^ y1.GetHashCode() ^
                   x2.GetHashCode() ^ y2.GetHashCode() ^
                   x3.GetHashCode() ^ y3.GetHashCode();
        }

        public override string ToString()
        {
            return $"Triangle, x1 = {x1}, y1 = {y1}, x2 = {x2}, y2 = {y2}, x3 = {x3}, y3 = {y3}";
        }
    }
}