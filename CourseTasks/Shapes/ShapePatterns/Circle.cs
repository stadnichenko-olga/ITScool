using System;

namespace Shapes.ShapePatterns
{
    public class Circle : IShape
    {
        private double radius;

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
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            return obj is Circle shape && this.radius == shape.radius;
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
