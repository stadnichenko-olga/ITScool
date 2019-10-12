namespace Shapes.ShapePatterns
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

            return obj is Square shape && this.side == shape.side;
        }

        public override int GetHashCode()
        {
            return side.GetHashCode();
        }

        public override string ToString()
        {
            return $"Square, side = {side}";
        }
    }
}
