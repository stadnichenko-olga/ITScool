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
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Square shape = obj as Square;
            return (side == shape.side);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override string ToString()
        {
            return ($"Square, side = {side}");
        }
    }
}
