using System;

namespace Shapes
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
            IShape shape2 = obj as IShape;

            if (!(shape2 is Rectangle))
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
            return ($"Rectangle, height = {height}, width = {width}");
        }
    }
}
