using System;

namespace Shapes
{
    public class Square : IShape
    {
        private double side;

        public Square(double side)
        {
            this.side = side;
        }

        public double GetWidth()
        {
            return side;
        }

        public double GetHeight()
        {
            return side;
        }

        public double GetArea()
        {
            return side * side;
        }
        public double GetPerimeter()
        {
            return 4 * side;
        }
        
        public override bool Equals(object obj)
        {
            IShape shape2 = obj as IShape;

            if (!(shape2 is Square))
            {
                return false;
            }

            return (GetArea() == shape2.GetArea());
        }

        public override int GetHashCode()
        {
            return 1;
        }
        public override string ToString()
        {
            return ($"Square, side = {side}");
        }
    }
}
