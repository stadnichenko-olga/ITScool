using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shapes.IShape;

namespace Shapes
{
    class Shapes
    {
        public static List<IShape> InitShapeArray()
        {
            var rand = new Random();

            var shapesArray = new List<IShape>();
            shapesArray.Add(new Circle((double)rand.Next(1,10)));
            shapesArray.Add(new Circle((double)rand.Next(1,10)));
            shapesArray.Add(new Circle((double)rand.Next(1,10)));

            shapesArray.Add(new Square((double)rand.Next(1,10)));
            shapesArray.Add(new Square((double)rand.Next(1,10)));
            shapesArray.Add(new Square((double)rand.Next(1,10)));

            shapesArray.Add(new Rectangle((double)rand.Next(1,10), (double)rand.Next(1,10)));
            shapesArray.Add(new Rectangle((double)rand.Next(1,10), (double)rand.Next(1,10)));
            shapesArray.Add(new Rectangle((double)rand.Next(1,10), (double)rand.Next(1,10)));

            shapesArray.Add(new Triangle( (double)rand.Next(1,10), (double)rand.Next(1,10),
                                          (double)rand.Next(1,10), (double)rand.Next(1,10),
                                          (double)rand.Next(1,10), (double)rand.Next(1,10)));
            shapesArray.Add(new Triangle( (double)rand.Next(1,10), (double)rand.Next(1,10),
                                          (double)rand.Next(1,10), (double)rand.Next(1,10),
                                          (double)rand.Next(1,10), (double)rand.Next(1,10)));
            shapesArray.Add(new Triangle( (double)rand.Next(1,10), (double)rand.Next(1,10),
                                          (double)rand.Next(1,10), (double)rand.Next(1,10),
                                          (double)rand.Next(1,10), (double)rand.Next(1,10)));
            return shapesArray;
        }

        class ShapesAreaComparer : IComparer<IShape>
        {
            public int Compare(IShape shape1, IShape shape2)
            {
                if (shape1.getArea() > shape2.getArea())
                {
                    return -1;
                }
                else if (shape1.getArea() < shape2.getArea())
                {
                    return 1;
                }

                return 0;
            }
        }
        class ShapesPerimComparer : IComparer<IShape>
        {
            public int Compare(IShape shape1, IShape shape2)
            {
                if (shape1.getPerimeter() > shape2.getPerimeter())
                {
                    return -1;
                }
                else if (shape1.getPerimeter() < shape2.getPerimeter())
                {
                    return 1;
                }

                return 0;
            }
        }

        static void Main(string[] args)
        {
            List<IShape> shapesArray = InitShapeArray();
            foreach (var shape in shapesArray)
            {
                shape.printShapeInf();
                Console.WriteLine($"Area = \t {shape.getArea()} \t Perimeter = {shape.getPerimeter()}.");
            }
            ShapesAreaComparer comparer1 = new ShapesAreaComparer();

            shapesArray.Sort(comparer1);
            Console.Write("Shape with largest area: ");
            IShape shapeLargeArea = shapesArray[0];
            shapeLargeArea.printShapeInf();

            ShapesPerimComparer comparer2 = new ShapesPerimComparer();

            shapesArray.Sort(comparer2);
            Console.Write("Shape with largest perimeter: ");
            IShape shapeLargePerimeter = shapesArray[0];
            shapeLargePerimeter.printShapeInf();

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
