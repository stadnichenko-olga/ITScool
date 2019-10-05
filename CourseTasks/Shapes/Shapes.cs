using System;
using System.Collections.Generic;

namespace Shapes
{
    class Shapes
    {
        public static List<IShape> InitShapeArray()
        {
            var rand = new Random();

            var shapesArray = new List<IShape>();
            shapesArray.Add(new Circle(rand.Next(1, 10)));
            shapesArray.Add(new Circle(rand.Next(1, 10)));
            shapesArray.Add(new Circle(rand.Next(1, 10)));

            shapesArray.Add(new Square(rand.Next(1, 10)));
            shapesArray.Add(new Square(rand.Next(1, 10)));
            shapesArray.Add(new Square(rand.Next(1, 10)));

            shapesArray.Add(new Rectangle(rand.Next(1, 10), rand.Next(1, 10)));
            shapesArray.Add(new Rectangle(rand.Next(1, 10), rand.Next(1, 10)));
            shapesArray.Add(new Rectangle(rand.Next(1, 10), rand.Next(1, 10)));

            shapesArray.Add(new Triangle(rand.Next(1, 10), rand.Next(1, 10),
                                         rand.Next(1, 10), rand.Next(1, 10),
                                         rand.Next(1, 10), rand.Next(1, 10)));
            shapesArray.Add(new Triangle(rand.Next(1, 10), rand.Next(1, 10),
                                         rand.Next(1, 10), rand.Next(1, 10),
                                         rand.Next(1, 10), rand.Next(1, 10)));
            shapesArray.Add(new Triangle(rand.Next(1, 10), rand.Next(1, 10),
                                         rand.Next(1, 10), rand.Next(1, 10),
                                         rand.Next(1, 10), rand.Next(1, 10)));
            return shapesArray;
        }

        static void Main(string[] args)
        {
            List<IShape> shapesArray = InitShapeArray();

            foreach (var shape in shapesArray)
            {
                Console.WriteLine(shape.ToString());
                Console.WriteLine($"Area = \t {shape.GetArea()} \t Perimeter = {shape.GetPerimeter()}.");
            }

            ShapesAreaComparer comparer1 = new ShapesAreaComparer();

            shapesArray.Sort(comparer1);
            Console.Write("Shape with largest area: ");
            IShape shapeLargeArea = shapesArray[0];
            Console.WriteLine(shapeLargeArea.ToString());

            ShapesPerimeterComparer comparer2 = new ShapesPerimeterComparer();

            shapesArray.Sort(comparer2);
            Console.Write("Shape with largest perimeter: ");
            IShape shapeLargePerimeter = shapesArray[0];
            Console.WriteLine(shapeLargePerimeter.ToString());

            if (shapeLargeArea.Equals(shapeLargePerimeter))
            {
                Console.Write("Shapes are the same.");
            }
            else
            {
                Console.Write("Shapes are not the same.");
            }

            Console.ReadKey();
        }
    }
}
