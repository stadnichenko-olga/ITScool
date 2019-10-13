using System;

namespace Vectors
{
    public class Vector
    {
        private double[] vector;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException($"{nameof(n)} is less than 1");
            }

            vector = new double[n];
        }

        public Vector(double[] coordinates)
        {
            if (coordinates.Length == 0)
            {
                throw new ArgumentException($"Dimension of {nameof(coordinates)} is less than 1");
            }

            vector = new double[coordinates.Length];
            coordinates.CopyTo(vector, 0);
        }

        public Vector(Vector vectorToCopy)
        {
            if (vectorToCopy.GetSize() == 0)
            {
                throw new ArgumentException($"Dimension of {nameof(vectorToCopy)} is less than 1");
            }

            vector = new double[vectorToCopy.GetSize()];
            vectorToCopy.vector.CopyTo(vector, 0);
        }

        public Vector(int n, double[] coordinates)
        {
            if (n <= 0 || coordinates.Length == 0)
            {
                throw new ArgumentException($"Dimension of {nameof(coordinates)} or {nameof(n)} is less than 1");
            }

            vector = new double[n];
            Array.Copy(coordinates, coordinates.GetLowerBound(0), vector, vector.GetLowerBound(0), Math.Min(n,coordinates.Length));            
        }

        public int GetSize()
        {
            return vector.Length;
        }

        public override string ToString()
        {
            return string.Join(", ", vector);
        }

        public Vector GetVectorsSum(Vector vector2)
        {
            int n = Math.Min(GetSize(), vector2.GetSize());

            for (int i = 0; i < n; i++)
            {
                vector[i] += vector2.vector[i];
            }

            if (GetSize() < vector2.GetSize())
            {
                Array.Resize(ref vector, vector2.GetSize());
                for (int i = GetSize() - 1; i < vector2.GetSize(); i++)
                {
                    vector[i] = vector2.vector[i];
                }
            }

            return this;
        }

        public Vector GetVectorsDifference(Vector vector2)
        {
            int n = Math.Min(GetSize(), vector2.GetSize());

            for (int i = 0; i < n; i++)
            {
                vector[i] -= vector2.vector[i];
            }

            if (GetSize() < vector2.GetSize())
            {
                Array.Resize(ref vector, vector2.GetSize());
                for (int i = GetSize() - 1; i < vector2.GetSize(); i++)
                {
                    vector[i] = -vector2.vector[i];
                }
            }

            return this;
        }

        public Vector GetVectorMultiplicationByScalar(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                vector[i] *= scalar;
            }

            return this;
        }

        public Vector GetReverseVector()
        {
            GetVectorMultiplicationByScalar(-1);
            return this;
        }

        public double GetLength()
        {
            double length = 0;

            foreach (double coordinate in vector)
            {
                length += coordinate * coordinate;
            }

            return Math.Sqrt(length);
        }

        public double GetVectorCoordinate(int i)
        {
            return vector[i];
        }

        public void SetVectorCoordinate(int i, double value)
        {
            vector[i] = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }            

            return obj is Vector vector2 && this.GetVectorsDifference(vector2).GetLength() == 0;
        }

        public override int GetHashCode()
        {
            return GetLength().GetHashCode() ^ vector.GetHashCode();
        }

        public static Vector GetVectorsSum(Vector vector1, Vector vector2)
        {
            Vector vectorsTemp = new Vector(vector1);
            vectorsTemp.GetVectorsSum(vector2);
            return vectorsTemp;
        }

        public static Vector GetVectorsDifference(Vector vector1, Vector vector2)
        {
            Vector vectorsTemp = new Vector(vector1);
            vectorsTemp.GetVectorsDifference(vector2);
            return vectorsTemp;
        }

        public static double GetVectorsMultiplication(Vector vector1, Vector vector2)
        {            
            double vectorsMultiplication = 0;
            int n = Math.Min(vector1.GetSize(), vector2.GetSize());

            for (int i = 0; i < n; i++)
            {
                vectorsMultiplication += vector1.vector[i] * vector2.vector[i];
            }

            return vectorsMultiplication;
        }
    }
}
