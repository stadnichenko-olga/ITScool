using System;
using Vectors;

namespace Matrixes
{
    public class Matrix
    {
        private Vector[] vectors;

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

            vectors = new Vector[m];

            for (int i = 0; i < m; i++)
            {
                vectors[i] = new Vector(n);
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
            vectors = new Vector[m];

            for (int i = 0; i < m; i++)
            {
                double[] vector = new double[n];
                for (int j = 0; j < n; j++)
                {
                    vector[j] = array[i, j];
                }
                vectors[i] = new Vector(vector);
            }
        }

        public Matrix(Vector[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Dimensions of {nameof(array)} is less than 1");
            }

            vectors = new Vector[array.Length];
            int i = 0;

            foreach (Vector vector in array)
            {
                vectors[i] = new Vector(vector);
                i++;
            }
        }

        public Matrix(Matrix vectorsToCopy)
        {
            vectors = new Vector[vectorsToCopy.GetFirstDimension()];
            int i = 0;

            foreach (Vector line in vectorsToCopy.vectors)
            {
                vectors[i] = new Vector(line);
                i++;
            }
        }

        public int GetFirstDimension()
        {
            return vectors.Length;
        }

        public int GetSecondDimension()
        {
            return vectors[0].GetSize();
        }

        public Matrix MultiplyByScalar(double scalar)
        {
            Matrix result = new Matrix(GetFirstDimension(), GetSecondDimension());

            for (int i = 0; i < GetFirstDimension(); i++)
            {
                result.vectors[i] = vectors[i].GetMultiplicationByScalar(scalar);
            }

            return result;
        }

        public Vector MultiplyByVector(Vector vectorToMultiplicate)
        {
            double[] result = new double[GetFirstDimension()];

            for (int i = 0; i < GetFirstDimension(); i++)
            {
                result[i] = Vector.GetMultiplication(vectors[i], vectorToMultiplicate);
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
                result.vectors[i] = vectors[i].GetSum(matrix2.vectors[i]);
            }

            if (GetFirstDimension() != matrix2.GetFirstDimension())
            {
                for (int i = mMin; i < GetFirstDimension(); i++)
                {
                    Vector zero = new Vector(n);
                    result.vectors[i] = vectors[i].GetSum(zero);
                }

                for (int i = mMin; i < matrix2.GetFirstDimension(); i++)
                {
                    Vector zero = new Vector(n);
                    result.vectors[i] = matrix2.vectors[i].GetSum(zero);
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

            return new Vector(vectors[i]);
        }

        public Vector GetColumnIndex(int i)
        {
            if (i < 0 || i >= GetSecondDimension())
            {
                throw new ArgumentException($"Index of column {nameof(i)} is invalid");
            }


            double[] column = new double[GetFirstDimension()];
            int j = 0;

            foreach (Vector line in vectors)
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

            vectors[i] = new Vector(new Vector(GetSecondDimension(), value.ConvertToArray()));
        }

        public Matrix GetTranspanentMatrix()
        {
            Matrix result = new Matrix(GetSecondDimension(), GetFirstDimension());

            for (int i = 0; i < GetSecondDimension(); i++)
            {
                result.vectors[i] = new Vector(GetColumnIndex(i));
            }

            return result;
        }

        private Matrix ExtractVectorFromMatrix(int i)
        {
            if (i < 0 || i >= GetFirstDimension())
            {
                throw new ArgumentException($"Index of extracted column {nameof(i)} is invalid");
            }

            Matrix result = new Matrix(GetFirstDimension() - 1, GetSecondDimension());

            for (int j = 0; j < i; j++)
            {
                result.vectors[j] = new Vector(vectors[j]);
            }
            for (int j = i; j < GetFirstDimension() - 1; j++)
            {
                result.vectors[j] = new Vector(vectors[j + 1]);
            }

            return result;
        }

        private Matrix ExtractColumnFromMatrix(int i)
        {
            if (i < 0 || i >= GetSecondDimension())
            {
                throw new ArgumentException($"Index of extracted column {nameof(i)} is invalid");
            }

            Matrix result = new Matrix(GetTranspanentMatrix().ExtractVectorFromMatrix(i));
            return result.GetTranspanentMatrix();
        }

        public override string ToString()
        {
            string result = "{ ";

            foreach (Vector line in vectors)
            {
                result += string.Join("; ", line);
            }

            return result + " }";
        }

        public override int GetHashCode() => GetFirstDimension().GetHashCode() ^ GetSecondDimension().GetHashCode()
                                             ^ GetHashCode(vectors);

        private static int GetHashCode(Vector[] array)
        {
            unchecked
            {
                int hash = 37;
                foreach (var item in array)
                {
                    hash = 17 * hash + item.GetHashCode();
                }
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Matrix matrix2 = (Matrix)obj;

            return EqualVectors(this, matrix2);
        }

        private static bool EqualVectors(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetFirstDimension() != matrix2.GetFirstDimension())
            {
                return false;
            }

            if (matrix1.GetSecondDimension() != matrix2.GetSecondDimension())
            {
                return false;
            }

            int n = matrix1.GetFirstDimension();

            for (int i = 0; i < n; i++)
            {
                if (!matrix1.vectors[i].Equals(matrix2.vectors[i]))
                {
                    return false;
                }
            }

            return true;
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

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
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
                return matrixD.vectors[0].GetCoordinate(0) * matrixD.vectors[1].GetCoordinate(1) -
                       matrixD.vectors[1].GetCoordinate(0) * matrixD.vectors[0].GetCoordinate(1);
            }

            double result = 0;

            for (var j = 0; j < n; j++)
            {
                result += Math.Pow(-1, j + 1) * matrixD.vectors[1].GetCoordinate(j) *
                    GetDeterminant(matrixD.ExtractColumnFromMatrix(j).ExtractVectorFromMatrix(1));
            }

            return result;
        }
    }
}
