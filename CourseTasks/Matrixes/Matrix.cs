using Ranges;
using System;
using System.Text;
using Vectors;

namespace Matrixes
{
    public class Matrix
    {
        private Vector[] strings;

        public Matrix(int stringsNumber, int columnsNumber)
        {
            if (columnsNumber <= 0)
            {
                throw new ArgumentException(nameof(columnsNumber), "dimension is less than 1");
            }

            if (stringsNumber <= 0)
            {
                throw new ArgumentException(nameof(stringsNumber), "dimension is less than 1");
            }

            strings = new Vector[stringsNumber];

            for (int i = 0; i < stringsNumber; i++)
            {
                strings[i] = new Vector(columnsNumber);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array), "dimension is less than 1");
            }

            int stringsNumber = array.GetLength(0);
            int columnsNumber = array.GetUpperBound(1) + 1;
            strings = new Vector[stringsNumber];

            for (int i = 0; i < stringsNumber; i++)
            {
                double[] stringArray = new double[columnsNumber];
                for (int j = 0; j < columnsNumber; j++)
                {
                    stringArray[j] = array[i, j];
                }
                strings[i] = new Vector(stringArray);
            }
        }

        public Matrix(Vector[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array), "dimension is less than 1");
            }

            strings = new Vector[array.Length];
            int i = 0;

            foreach (Vector vector in array)
            {
                strings[i] = new Vector(vector);
                i++;
            }
        }

        public Matrix(Matrix matrix)
        {
            strings = new Vector[matrix.GetStringsNumber()];
            int i = 0;

            foreach (Vector line in matrix.strings)
            {
                strings[i] = new Vector(line);
                i++;
            }
        }

        public int GetStringsNumber() => strings.Length;
        
        public int GetColumnsNumber() => strings[0].GetSize();

        private bool IsEmpty()=> strings.Length == 0;

        private double[][] ToArray()
        {
            double[][] result = new double[GetStringsNumber()][];

            int stringsNumber = GetStringsNumber();

            for (int i = 0; i < stringsNumber; i++)
            {
                result[i] = new double[GetColumnsNumber()];
                Array.Copy(strings[i].ConvertToArray(), result[i], GetColumnsNumber());
            }

            return result;
        }

        private void AddString(Vector newString)
        {
            Array.Resize(ref strings, GetStringsNumber() + 1);
            strings[GetStringsNumber() - 1] = new Vector(newString);
        }

        public Matrix MultiplyByScalar(double scalar)
        {
            Matrix result = new Matrix(GetStringsNumber(), GetColumnsNumber());

            for (int i = 0; i < GetStringsNumber(); i++)
            {
                strings[i].MultiplyByScalar(scalar);
            }

            return this;
        }

        public Vector MultiplyByVector(Vector vectorToMultiplicate)
        {
            double[] result = new double[GetStringsNumber()];

            for (int i = 0; i < GetStringsNumber(); i++)
            {
                result[i] = Vector.Multiply(strings[i], vectorToMultiplicate);
            }

            return new Vector(result);
        }

        public Matrix Append(Matrix matrix2)
        {
            int mMin = Math.Min(GetStringsNumber(), matrix2.GetStringsNumber());

            for (int i = 0; i < mMin; i++)
            {
                strings[i].GetSum(matrix2.strings[i]);
            }

            for (int i = mMin; i < matrix2.GetStringsNumber(); i++)
            {
                AddString(matrix2.strings[i]);
            }

            return this;
        }

        public Matrix Deduct(Matrix matrix2)
        {
            int mMin = Math.Min(GetStringsNumber(), matrix2.GetStringsNumber());

            for (int i = 0; i < mMin; i++)
            {
                strings[i].GetDifference(matrix2.strings[i]);
            }

            for (int i = mMin; i < matrix2.GetStringsNumber(); i++)
            {
                AddString(matrix2.strings[i].MultiplyByScalar(-1));
            }

            return this;
        }

        public Vector GetString(int i)
        {
            Range validIndexRange = new Range(0, GetStringsNumber());

            if (!validIndexRange.IsInside(i))
            {
                throw new ArgumentException(nameof(i) + "value is out of" + validIndexRange.ToString());
            }

            return new Vector(strings[i]);
        }

        public Vector GetColumn(int i)
        {
            Range validIndexRange = new Range(0, GetColumnsNumber());

            if (!validIndexRange.IsInside(i))
            {
                throw new ArgumentException(nameof(i) + "value is out of" + validIndexRange.ToString());
            }

            double[] column = new double[GetStringsNumber()];
            int j = 0;

            foreach (Vector line in strings)
            {
                column[j] = line.GetCoordinate(i);
                j++;
            }

            return new Vector(column);
        }

        public void SetString(int i, Vector row)
        {
            Range validIndexRange = new Range(0, GetStringsNumber());

            if (!validIndexRange.IsInside(i))
            {
                throw new ArgumentException(nameof(i) + "value is out of" + validIndexRange.ToString());
            }

            strings[i] = new Vector(new Vector(GetColumnsNumber(), row.ConvertToArray()));
        }

        public Matrix Transpose()
        {
            int stringsNumber = GetStringsNumber();
            int columnsNumber = GetColumnsNumber();
            double[][] matrixArray = ToArray();
            Vector temp = new Vector(stringsNumber);
            Array.Resize(ref strings, columnsNumber);

            for (int i = 0; i < columnsNumber; i++)
            {
                for (int j = 0; j < stringsNumber; j++)
                {
                    temp.SetVectorCoordinate(j, matrixArray[j][i]);
                }
                strings[i] = new Vector(temp);
            }

            return this;
        }

        private Matrix GetMatrixStringDeleted(int index)
        {
            Range validIndexRange = new Range(0, GetStringsNumber());

            if (!validIndexRange.IsInside(index))
            {
                throw new ArgumentException(nameof(index) + "value is out of" + validIndexRange.ToString());
            }

            Matrix result = new Matrix(GetStringsNumber() - 1, GetColumnsNumber());

            for (int i = 0; i < index; i++)
            {
                result.strings[i] = new Vector(strings[i]);
            }

            for (int i = index; i < GetStringsNumber() - 1; i++)
            {
                result.strings[i] = new Vector(strings[i + 1]);
            }

            return result;
        }

        private Matrix GetMatrixColumnDeleted(int index)
        {
            Range validIndexRange = new Range(0, GetColumnsNumber());

            if (!validIndexRange.IsInside(index))
            {
                throw new ArgumentException(nameof(index) + "value is out of" + validIndexRange.ToString());
            }

            Matrix result = new Matrix(Transpose().GetMatrixStringDeleted(index));
            return result.Transpose();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{ ");

            foreach (Vector row in strings)
            {
                result.Append(string.Join("; ", row));
            }

            result.Append(" }");
            return result.ToString();
        }

        public override int GetHashCode() => GetStringsNumber().GetHashCode() ^ GetColumnsNumber().GetHashCode()
                                             ^ GetHashCode(strings);

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

            return Equals(this, matrix2);
        }

        private static bool Equals(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetStringsNumber() != matrix2.GetStringsNumber())
            {
                return false;
            }

            if (matrix1.GetColumnsNumber() != matrix2.GetColumnsNumber())
            {
                return false;
            }

            int n = matrix1.GetStringsNumber();

            for (int i = 0; i < n; i++)
            {
                if (!matrix1.strings[i].Equals(matrix2.strings[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static Matrix Append(Matrix matrix1, Matrix matrix2)
        {
            Matrix tempMatrix = new Matrix(matrix1);
            return tempMatrix.Append(matrix2);
        }

        public static Matrix Deduct(Matrix matrix1, Matrix matrix2)
        {
            Matrix tempMatrix = new Matrix(matrix1);
            return tempMatrix.Deduct(matrix2);
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.IsEmpty())
            {
                throw new ArgumentException(nameof(matrix1), " is empty");
            }

            if (matrix2.IsEmpty())
            {
                throw new ArgumentException(nameof(matrix2), " is empty");
            }

            int stringsNumber = matrix1.GetStringsNumber();
            int columnsNumber = matrix2.GetColumnsNumber();

            double[,] result = new double[stringsNumber, columnsNumber];

            for (int i = 0; i < stringsNumber; i++)
            {
                for (int j = 0; j < columnsNumber; j++)
                {
                    result[i, j] = Vector.Multiply(matrix1.GetString(i), matrix2.GetColumn(j));
                }
            }

            return new Matrix(result);
        }

        public double GetDeterminant()
        {
            if (IsEmpty())
            {
                throw new ArgumentException("Matrix is empty");
            }

            if (GetStringsNumber() != GetColumnsNumber())
            {
                throw new ArgumentException(" Matrix is not squared");
            }

            Matrix matrixD = new Matrix(this);

            int n = matrixD.GetStringsNumber();

            if (n == 1)
            {
                return matrixD.strings[0].GetCoordinate(0);
            }

            if (n == 2)
            {
                return matrixD.strings[0].GetCoordinate(0) * matrixD.strings[1].GetCoordinate(1) -
                       matrixD.strings[1].GetCoordinate(0) * matrixD.strings[0].GetCoordinate(1);
            }

            double result = 0;

            for (var j = 0; j < n; j++)
            {
                result += Math.Pow(-1, j + 1) * matrixD.strings[1].GetCoordinate(j) *
                    matrixD.GetMatrixColumnDeleted(j).GetMatrixStringDeleted(1).GetDeterminant();
            }

            return result;
        }
    }
}
