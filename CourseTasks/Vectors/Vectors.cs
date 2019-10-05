using System;

namespace Vectors
{
    class Vectors
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(3);
            double[] coordinates = { 1, 3, 4, 6.5, 3, 9.9 };
            vector1 = new Vector(coordinates);
            Console.WriteLine("vector1: " + vector1.ToString());
            Console.WriteLine($"Dimension = {vector1.GetSize()}");
            Console.WriteLine($"Length = {vector1.GetLength()}");

            Vector vector2 = new Vector(vector1);
            Console.WriteLine("vector2: " + vector2.ToString());
            if (vector1.Equals(vector2))
            {
                Console.WriteLine("Vectors are the same.");
            }
            else
            {
                Console.WriteLine("Vectors are not the same.");
            }

            vector2.GetReverseVector();
            Console.WriteLine("Reverse vector2: " + vector2.ToString());
            vector2.GetVectorMultiplicationByScalar(3);
            Console.WriteLine("Vector2 * 3: "  + vector2.ToString());
            Console.WriteLine($"Vector2[3] = {vector2.GetVectorCoordinate(3)}");
            if (vector1.Equals(vector2))
            {
                Console.WriteLine("Vectors are the same.");
            }
            else
            {
                Console.WriteLine("Vectors are not the same.");
            }

            Console.WriteLine($"Vector1*Vector2 = {Vector.GetVectorsMultiplication(vector1, vector2)}");
            Console.WriteLine();

            Console.WriteLine("Check static and dynamic. Second vector is longer.");
            vector2 = new Vector(vector1.GetSize() + 2, coordinates);            
            Console.WriteLine("vector2: " + vector2.ToString());
            Console.WriteLine($"Set {vector1.GetSize() + 1}-th coordinate equal to 10.");
            vector2.SetVectorCoordinate(vector1.GetSize() + 1, 10);
            Console.WriteLine("vector2: " + vector2.ToString());
            Console.WriteLine("vector1: " + vector1.ToString());

            Vector vector3 = new Vector(vector2);
            vector2.GetVectorsSumm(vector1);
            Console.WriteLine("Dynamic: vector1 + vector2 = " + vector2.ToString());
            Console.WriteLine("Static:  vector1 + vector2 = " + Vector.GetVectorsSumm(vector3, vector1).ToString());

            vector2.GetVectorMultiplicationByScalar(2);
            vector3 = new Vector(vector2);
            Console.WriteLine("vector2: " + vector2.ToString());
            Console.WriteLine("vector1: " + vector1.ToString());
            vector2.GetVectorsDifference(vector1);
            Console.WriteLine("Dynamic: vector2 - vector1 = " + vector2.ToString());
            Console.WriteLine("Static:  vector2 - vector1 = " + Vector.GetVectorsDifference(vector3, vector1).ToString());

            Console.WriteLine();
            Console.WriteLine("Check static and dynamic. Second vector is shorter.");
            vector2 = new Vector(vector1.GetSize() - 1, coordinates);
            vector2.GetVectorMultiplicationByScalar(3);
            Console.WriteLine("vector2: " + vector2.ToString());
            Console.WriteLine("vector1: " + vector1.ToString());

            vector3 = new Vector(vector2);
            vector2.GetVectorsSumm(vector1);
            Console.WriteLine("Dynamic: vector1 + vector2 = " + vector2.ToString());
            Console.WriteLine("Static:  vector1 + vector2 = " + Vector.GetVectorsSumm(vector3, vector1).ToString());

            vector2.GetVectorMultiplicationByScalar(2);
            vector3 = new Vector(vector2);
            Console.WriteLine("vector2: " + vector2.ToString());
            Console.WriteLine("vector1: " + vector1.ToString());
            vector2.GetVectorsDifference(vector1);
            Console.WriteLine("Dynamic: vector2 - vector1 = " + vector2.ToString());
            Console.WriteLine("Static:  vector2 - vector1 = " + Vector.GetVectorsDifference(vector3, vector1).ToString());

            Console.ReadKey();
        }
    }
}
