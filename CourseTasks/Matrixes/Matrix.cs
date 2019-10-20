using System;
using Vectors;

namespace Matrixes
{
    public class Matrix
    {
        private Vector[] matrix;

        public Matrix(int m, int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException($"Dimension {nameof(n)} is less than 1");
            }
            else if (m <= 0)
            {
                throw new ArgumentException($"Dimension {nameof(m)} is less than 1");
            }
            matrix = new Vector[m];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new Vector(n);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Dimensions of {nameof(array)} is less than 1");
            }
            int m = array.GetUpperBound(0) + 1;
            int n = array.GetUpperBound(1) + 1;
            matrix = new Vector[m];
            for (int i = 0; i < m; i++)
            {
                double[] vector = new double[n];
                for (int j = 0; j < n; j++)
                {
                    vector[j] = array[i, j];
                }
                matrix[i] = new Vector(vector);
            }
        }

        public Matrix(Vector[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Dimensions of {nameof(array)} is less than 1");
            }
            matrix = new Vector[array.Length];
            int i = 0;
            foreach (Vector vector in array)
            {
                matrix[i] = new Vector(vector);
                i++;
            }
        }

        public Matrix(Matrix matrixToCopy)
        {
            matrix = new Vector[matrixToCopy.GetFirstDimension()];
            int i = 0;

            foreach (Vector line in matrixToCopy.matrix)
            {
                matrix[i] = new Vector(line);
                i++;
            }
        }

        public int GetFirstDimension()
        {
            return matrix.Length;
        }

        public int GetSecondDimension()
        {
            return matrix[0].GetSize();
        }

        public Matrix MultiplyByScalar(double scalar)
        {
            Matrix result = new Matrix(GetFirstDimension(), GetSecondDimension());

            for (int i = 0; i < GetFirstDimension(); i++)
            {
                result.matrix[i] = matrix[i].GetMultiplicationByScalar(scalar);
            }

            return result;
        }

        public Vector MultiplyByVector(Vector vectorToMultiplicate)
        {           
            double[] result = new double[GetFirstDimension()];

            for (int i = 0; i < GetFirstDimension(); i++)
            {
                result[i] = Vector.GetMultiplication(matrix[i], vectorToMultiplicate);
            }

            return new Vector(result);
        }

        public Matrix GetSum(Matrix matrix2)
        {
            int m = Math.Max(GetFirstDimension(), matrix2.GetFirstDimension());
            int n = Math.Max(GetSecondDimension(), matrix2.GetSecondDimension());
            Matrix result = new Matrix(m, n);

            int mMin = Math.Min(GetFirstDimension(), matrix2.GetFirstDimension());

            for (int i = 0; i < mMin; i++)
            {
                result.matrix[i] = matrix[i].GetSum(matrix2.matrix[i]);
            }

            if (GetFirstDimension() != matrix2.GetFirstDimension())
            {
                for (int i = mMin; i < GetFirstDimension(); i++)
                {
                    Vector zero = new Vector(n);
                    result.matrix[i] = matrix[i].GetSum(zero);
                }

                for (int i = mMin; i < matrix2.GetFirstDimension(); i++)
                {
                    Vector zero = new Vector(n);
                    result.matrix[i] = matrix2.matrix[i].GetSum(zero);
                }
            }

            return result;
        }

        public Matrix GetDifference(Matrix matrix2)
        {
            Matrix matrixTemp = new Matrix(matrix2);
            return GetSum(matrixTemp.MultiplyByScalar(-1));
        }

        public Vector GetVectorIndex(int i)
        {
            if (i < 0 || i >= GetFirstDimension())
            {
                throw new ArgumentException($"Index of vector {nameof(i)} is invalid");
            }

            return new Vector(matrix[i]);
        }

        public Vector GetColumnIndex(int i)
        {
            if (i < 0 || i >= GetFirstDimension())
            {
                throw new ArgumentException($"Index of column {nameof(i)} is invalid");
            }


            double[] column = new double[GetFirstDimension()];
            int j = 0;

            foreach (Vector line in matrix)
            {
                column[j] = line.GetCoordinate(i);
                j++;
            }
            return new Vector(column);
        }

        public void SetVectorIndex(int i, Vector value)
        {
            if (i < 0 || i >= GetFirstDimension())
            {
                throw new ArgumentException($"Value of {nameof(i)} is invalid");
            }           

            matrix[i] = new Vector(new Vector(GetSecondDimension(), Vector.ConvertToArray(value)));
        }
        
        public Matrix GetTranspanentMatrix()
        {
            Matrix result = new Matrix(GetSecondDimension(),GetFirstDimension());

            for (int i=0; i< GetSecondDimension(); i++)
            {
                result.matrix[i] = new Vector(GetColumnIndex(i));
            }

            return result;
        }

        private Matrix ExtractVectorFromMatrix(int i)
        {
            if (i < 0 || i >= GetSecondDimension())
            {
                throw new ArgumentException($"Index of extracted column {nameof(i)} is invalid");
            }

            Matrix result = new Matrix(GetFirstDimension(), GetSecondDimension()-1);

            for (int j = 0; j < i; j++)
            {
                result.matrix[j] = new Vector(matrix[j]);
            }
            for (int j=i; j< GetFirstDimension()-1; j++)
            {
                matrix[j] = new Vector(matrix[j + 1]);
            }    
            
            return result;
        }

        private Matrix ExtractColumnFromMatrix(int i)
        {
            if (i < 0 || i >= GetSecondDimension())
            {
                throw new ArgumentException($"Index of extracted column {nameof(i)} is invalid");
            }

            Matrix result = GetTranspanentMatrix().ExtractVectorFromMatrix(i);

            return result.GetTranspanentMatrix();
        }

        public override string ToString()
        {
            string result = "{ ";
            foreach (Vector line in matrix)
            {
                result += string.Join("; ", line);                
            }

            return result+" }";
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixTemp = new Matrix(matrix1);
            return matrixTemp.GetSum(matrix2);
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixTemp = new Matrix(matrix1);
            return matrixTemp.GetDifference(matrix2);
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            int m = matrix1.GetFirstDimension();
            int n = matrix2.GetSecondDimension();
            double[,] result = new double[m, n];

            for (int i=0; i<m; i++)
            {
                for (int j=0; j<n; j++)
                {
                    result[i, j] = Vector.GetMultiplication(matrix1.GetVectorIndex(i), matrix2.GetColumnIndex(j));
                }
            }

            return new Matrix(result);
        }

        public static double GetDeterminant(Matrix matrix)
        {
            Matrix matrixD = new Matrix(matrix);
            if (matrixD.GetFirstDimension() != matrixD.GetSecondDimension())
            {
                throw new ArgumentException($"{nameof(matrixD)} is not squared");
            }
            int n = matrixD.GetFirstDimension();
            if (n == 2)
            {
                return matrixD.matrix[0].GetCoordinate(0) * matrixD.matrix[1].GetCoordinate(1) -
                       matrixD.matrix[1].GetCoordinate(0) * matrixD.matrix[0].GetCoordinate(1);
            }
            double result = 0;
            for (var j = 0; j < n; j++)
            {
                result += Math.Pow(-1, j+1) * matrixD.matrix[1].GetCoordinate(j) *
                    GetDeterminant(matrixD.ExtractColumnFromMatrix(j).ExtractVectorFromMatrix(1));
            }
            return result;
        }
    }
}
