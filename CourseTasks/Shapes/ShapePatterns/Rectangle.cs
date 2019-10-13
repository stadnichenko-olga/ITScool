﻿namespace Shapes.ShapePatterns
{
    public class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetArea()
        {
            return height * width;
        }

        public double GetPerimeter()
        {
            return 2 * (height + width);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return obj is Rectangle shape && this.width == shape.width && this.height == shape.height;
        }

        public override int GetHashCode()
        {
            return width.GetHashCode() ^ height.GetHashCode();
        }

        public override string ToString()
        {
            return $"Rectangle, height = {height}, width = {width}";
        }
    }
}