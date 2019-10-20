using Shapes.Comparers;
using Shapes.ShapePatterns;
using System;
using System.Collections.Generic;

namespace Shapes
{
    class Shapes
    {
        public static List<IShape> InitShapesList()
        {
            var random = new Random();

            List<IShape> shapesList = new List<IShape>
            {
                new Circle(random.Next(1, 10)),
                new Circle(random.Next(1, 10)),
                new Circle(random.Next(1, 10)),

                new Square(random.Next(1, 10)),
                new Square(random.Next(1, 10)),
                new Square(random.Next(1, 10)),

                new Rectangle(random.Next(1, 10), random.Next(1, 10)),
                new Rectangle(random.Next(1, 10), random.Next(1, 10)),
                new Rectangle(random.Next(1, 10), random.Next(1, 10)),

                new Triangle(random.Next(1, 10), random.Next(1, 10),
                             random.Next(1, 10), random.Next(1, 10),
                             random.Next(1, 10), random.Next(1, 10)),
                new Triangle(random.Next(1, 10), random.Next(1, 10),
                             random.Next(1, 10), random.Next(1, 10),
                             random.Next(1, 10), random.Next(1, 10)),
                new Triangle(random.Next(1, 10), random.Next(1, 10),
                             random.Next(1, 10), random.Next(1, 10),
                             random.Next(1, 10), random.Next(1, 10))
            };
            return shapesList;
        }

        static void Main(string[] args)
        {
            List<IShape> shapesList = InitShapesList();

            foreach (var shape in shapesList)
            {
                Console.WriteLine(shape.ToString());
                Console.WriteLine($"Area = \t {shape.GetArea()} \t Perimeter = {shape.GetPerimeter()}.");
            }

            ShapesAreaComparer comparer1 = new ShapesAreaComparer();
            shapesList.Sort(comparer1);

            Console.Write("Shape with largest area: ");
            IShape shapeLargeArea = shapesList[0];
            Console.WriteLine(shapeLargeArea.ToString());

            ShapesPerimeterComparer comparer2 = new ShapesPerimeterComparer();
            shapesList.Sort(comparer2);
            
            Console.Write("Second shape with largest perimeter: ");
            IShape secondShapeLargePerimeter = shapesList[1];
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
