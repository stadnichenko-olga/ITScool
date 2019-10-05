using System;

namespace Shapes
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
            IShape shape2 = obj as IShape;

            if (!(shape2 is Circle))
            {
                return false;
            }

            return (GetArea() == shape2.GetArea());
        }

        public override int GetHashCode()
        {
            return 2;
        }

        public override string ToString()
        {
            return ($"Circle, radius = {radius}");
        }
    }
}
