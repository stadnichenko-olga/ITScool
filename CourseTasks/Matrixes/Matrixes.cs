using System;
using Vectors;

namespace Matrixes
{
    class Matrixes
    {
        static void Main(string[] args)
        {
            double[,] initMatrix = new double[3, 3];
            initMatrix[0, 0] = 1;
            initMatrix[0, 1] = 2;
            initMatrix[0, 2] = 3;
            initMatrix[1, 0] = 4;
            initMatrix[1, 1] = 5;
            initMatrix[1, 2] = 6;
            initMatrix[2, 0] = 7;
            initMatrix[2, 1] = 8;
            initMatrix[2, 2] = 9;

            Matrix matrix1 = new Matrix(initMatrix);

            initMatrix[0, 0] = 1;
            initMatrix[0, 1] = 3;
            initMatrix[0, 2] = 5;
            initMatrix[1, 0] = 1;
            initMatrix[1, 1] = 3;
            initMatrix[1, 2] = 2;
            initMatrix[2, 0] = 0;
            initMatrix[2, 1] = 1;
            initMatrix[2, 2] = 2;

            Matrix matrix2 = new Matrix(initMatrix);

            double[] coordinates1 = { 1, 3, 4 };
            double[] coordinates2 = { 6, 3, 9 };
            Vector[] initVector = new Vector[2];
            initVector[0] = new Vector(coordinates1);
            initVector[1] = new Vector(coordinates2);

            Matrix matrix3 = new Matrix(initVector);

            Console.WriteLine($"Determinant of matrix 1 = {Matrix.GetDeterminant(matrix1)}");

            Console.ReadKey();
        }       
    }
}
