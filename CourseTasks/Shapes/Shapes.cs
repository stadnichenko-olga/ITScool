using System;
using System.Collections.Generic;

namespace Shapes
{
    class Shapes
    {
        public static List<IShape> InitShapeArray()
        {
            var rand = new Random();

            List<IShape> shapesArray = new List<IShape>()
            {
            new Circle(rand.Next(1, 10)),
            new Circle(rand.Next(1, 10)),
            new Circle(rand.Next(1, 10)),

            new Square(rand.Next(1, 10)),
            new Square(rand.Next(1, 10)),
            new Square(rand.Next(1, 10)),

            new Rectangle(rand.Next(1, 10), rand.Next(1, 10)),
            new Rectangle(rand.Next(1, 10), rand.Next(1, 10)),
            new Rectangle(rand.Next(1, 10), rand.Next(1, 10)),

            new Triangle(rand.Next(1, 10), rand.Next(1, 10),
                         rand.Next(1, 10), rand.Next(1, 10),
                         rand.Next(1, 10), rand.Next(1, 10)),
            new Triangle(rand.Next(1, 10), rand.Next(1, 10),
                         rand.Next(1, 10), rand.Next(1, 10),
                         rand.Next(1, 10), rand.Next(1, 10)),
            new Triangle(rand.Next(1, 10), rand.Next(1, 10),
                         rand.Next(1, 10), rand.Next(1, 10),
                         rand.Next(1, 10), rand.Next(1, 10)),
            };
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
            
            Console.Write("Second shape with largest perimeter: ");
            IShape secondShapeLargePerimeter = shapesArray[1];
            Console.WriteLine(secondShapeLargePerimeter.ToString());

            if (shapeLargeArea.Equals(secondShapeLargePerimeter))
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
