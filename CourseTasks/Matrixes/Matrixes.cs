using System;
using Vectors;

namespace Matrixes
{
    class Matrixes
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(new double[,]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            });

            Console.WriteLine("Matrix 1 = " + Environment.NewLine + matrix1);

            Matrix matrix2 = new Matrix(new double[,]
            {
                {1, 3, 5 },
                {1, 3, 2 },
                {0, 1, 2 }
            });

            Console.WriteLine("Matrix 2 = " + Environment.NewLine + matrix2);

            Vector[] initVector = new Vector[2];
            initVector[0] = new Vector(new double[] { 1, 3, 4 });
            initVector[1] = new Vector(new double[] { 6, 3, 9 });

            Matrix matrix3 = new Matrix(initVector);
            Console.WriteLine("Matrix 3 = " + Environment.NewLine + matrix3);

            Vector[] initVector2 = new Vector[4];
            initVector2[0] = new Vector(new double[] { 2, 5, 4 });
            initVector2[1] = new Vector(new double[] { 3, 3, 8 });
            initVector2[2] = new Vector(new double[] { 6, 7, 2 });
            initVector2[3] = new Vector(new double[] { 5, 3, 1 });

            Matrix matrix4 = new Matrix(initVector2);
            Console.WriteLine("Matrix 4 = " + Environment.NewLine + matrix4);

            Console.WriteLine();
            Console.WriteLine($"Matrix 4 sizes are: {matrix4.GetStringsNumber()} X {matrix4.GetColumnsNumber()}");

            Console.WriteLine("(Matrix 1)*2 = " + Environment.NewLine + matrix1.MultiplyByScalar(2));
            matrix1.MultiplyByScalar(0.5);

            Console.WriteLine();
            Console.WriteLine("Matrix2 transperented = " + Environment.NewLine + matrix2.Transpose());
            matrix2.Transpose();

            Console.WriteLine("Matrix3 transperented = " + Environment.NewLine + matrix3.Transpose());
            matrix3.Transpose();

            Console.WriteLine();
            Vector vector = new Vector(new double[] { 1, 2, 3, 4, 5 });
            Console.WriteLine("Matrix3 * Vector " + vector + Environment.NewLine + matrix3.MultiplyByVector(vector));

            Console.WriteLine("(Matrix 4) 1 vector = " + matrix4.GetString(1));
            Console.WriteLine("(Matrix 4) 2 column = " + matrix4.GetColumn(1));

            Console.WriteLine("Set 2 vector in Matrix 4 = " + vector);
            matrix4.SetString(2, vector);
            Console.WriteLine("Matrix 4 = " + Environment.NewLine + matrix4);

            Console.WriteLine();
            Console.WriteLine("matrix1 + matrix2 = " + Environment.NewLine + Matrix.Append(matrix1, matrix2));
            Console.WriteLine("matrix1 - matrix2 = " + Environment.NewLine + Matrix.Deduct(matrix1, matrix2));
            Console.WriteLine("matrix1 * matrix2 = " + Environment.NewLine + Matrix.GetMultiplication(matrix1, matrix2));

            Console.WriteLine();
            Console.WriteLine("Matrix 3 = " + Environment.NewLine + matrix3);
            Console.WriteLine("Matrix 4 = " + Environment.NewLine + matrix4);

            Console.WriteLine();
            Console.WriteLine("matrix3 + matrix4 = " + Environment.NewLine + Matrix.Append(matrix3, matrix4));
            Console.WriteLine("matrix3 - matrix4 = " + Environment.NewLine + Matrix.Deduct(matrix3, matrix4));
            Console.WriteLine("matrix3 * matrix4 = " + Environment.NewLine + Matrix.GetMultiplication(matrix3, matrix4));

            Console.WriteLine();

            initVector = new Vector[2];
            initVector[0] = new Vector(new double[] { 1, 3 });
            initVector[1] = new Vector(new double[] { 6, 2 });

            matrix3 = new Matrix(initVector);
            Console.WriteLine("Matrix 2X2 = " + Environment.NewLine + matrix3);
            Console.WriteLine($"Determinant of matrix 2X2 = {matrix3.GetDeterminant()}");

            Console.WriteLine("Matrix 1 = " + Environment.NewLine + matrix1);
            Console.WriteLine($"Determinant of matrix 1 = {matrix1.GetDeterminant()}");

            Console.WriteLine("Matrix 2 = " + Environment.NewLine + matrix2);
            Console.WriteLine($"Determinant of matrix 1 = {matrix2.GetDeterminant()}");

            Console.ReadKey();
        }
    }
}
