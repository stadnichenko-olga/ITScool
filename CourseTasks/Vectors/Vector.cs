using System;

namespace Vectors
{
    public class Vector
    {
        private double[] coordinates;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException($"Value of {nameof(n)} is less than 1");
            }

            coordinates = new double[n];
        }

        public Vector(double[] coordinatesInit)
        {
            if (coordinatesInit.Length == 0)
            {
                throw new ArgumentException($"Dimension of {nameof(coordinatesInit)} is less than 1");
            }

            coordinates = new double[coordinatesInit.Length];
            coordinatesInit.CopyTo(coordinates, 0);
        }

        public Vector(Vector vector)
        {
            coordinates = new double[vector.GetSize()];
            vector.coordinates.CopyTo(coordinates, 0);
        }

        public Vector(int n, double[] coordinatesInit)
        {
            if (n <= 0)
            {
                throw new ArgumentException($"Value of {nameof(n)} is less than 1");
            }
            else if (coordinatesInit.Length == 0)
            {
                throw new ArgumentException($"Dimension of {nameof(coordinatesInit)} is less than 1");
            }

            coordinates = new double[n];
            Array.Copy(coordinatesInit, 0, coordinates, 0, Math.Min(n, coordinatesInit.Length));
        }

        public int GetSize() => coordinates.Length;

        public override string ToString() => string.Concat("{", string.Join("; ", coordinates), " }, ");

        public Vector GetSum(Vector vector2)
        {
            int n = Math.Min(GetSize(), vector2.GetSize());

            for (int i = 0; i < n; i++)
            {
                coordinates[i] += vector2.coordinates[i];
            }

            if (GetSize() < vector2.GetSize())
            {
                Array.Resize(ref coordinates, vector2.GetSize());
                for (int i = GetSize() - 1; i < vector2.GetSize(); i++)
                {
                    coordinates[i] = vector2.coordinates[i];
                }
            }

            return this;
        }

        public Vector GetDifference(Vector vector2)
        {
            int n = Math.Min(GetSize(), vector2.GetSize());

            for (int i = 0; i < n; i++)
            {
                coordinates[i] -= vector2.coordinates[i];
            }

            if (GetSize() < vector2.GetSize())
            {
                Array.Resize(ref coordinates, vector2.GetSize());
                for (int i = GetSize() - 1; i < vector2.GetSize(); i++)
                {
                    coordinates[i] = -vector2.coordinates[i];
                }
            }

            return this;
        }

        public Vector GetMultiplicationByScalar(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                coordinates[i] *= scalar;
            }

            return this;
        }

        public Vector GetReverse() => GetMultiplicationByScalar(-1);

        public double GetLength()
        {
            double length = 0;

            foreach (double coordinate in coordinates)
            {
                length += coordinate * coordinate;
            }

            return Math.Sqrt(length);
        }

        public double GetCoordinate(int i) => coordinates[i];

        public void SetVectorCoordinate(int i, double value)
        {
            coordinates[i] = value;
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

            Vector vector2 = (Vector)obj;

            return EqualCoordinates(this, vector2);
        }

        private static bool EqualCoordinates(Vector vector1, Vector vector2)
        {
            if (vector1.GetSize() != vector2.GetSize())
            {
                return false;
            }

            int n = vector1.GetSize();

            for (int i = 0; i < n; i++)
            {
                if (vector1.coordinates[i] != vector2.coordinates[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() => GetLength().GetHashCode() ^ GetHashCode(coordinates);

        public static int GetHashCode(double[] array)
        {
            unchecked
            {
                int hash = 37;
                foreach (double item in array)
                {
                    hash = 17 * hash + item.GetHashCode();
                }
                return hash;
            }
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector vectorsTemp = new Vector(vector1);
            return vectorsTemp.GetSum(vector2);
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector vectorsTemp = new Vector(vector1);
            return vectorsTemp.GetDifference(vector2);
        }

        public static double GetMultiplication(Vector vector1, Vector vector2)
        {
            double vectorsMultiplication = 0;
            int n = Math.Min(vector1.GetSize(), vector2.GetSize());

            for (int i = 0; i < n; i++)
            {
                vectorsMultiplication += vector1.coordinates[i] * vector2.coordinates[i];
            }

            return vectorsMultiplication;
        }
    }
}