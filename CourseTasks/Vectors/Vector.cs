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
                throw new ArgumentException("Number of coordinates is less than 1", nameof(n));
            }

            coordinates = new double[n];
        }

        public Vector(double[] initialCoordinates)
        {
            if (initialCoordinates.Length == 0)
            {
                throw new ArgumentException("Dimension of coordinates array is less than 1", nameof(initialCoordinates));
            }

            coordinates = new double[initialCoordinates.Length];
            initialCoordinates.CopyTo(coordinates, 0);
        }

        public Vector(Vector vector)
        {
            coordinates = new double[vector.GetSize()];
            vector.coordinates.CopyTo(coordinates, 0);
        }

        public Vector(int n, double[] initialCoordinates)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Number of coordinates is less than 1", nameof(n));
            }

            coordinates = new double[n];

            for (int i = 0; i < n; i++)
            {
                coordinates[i] = 0;
            }

            if (initialCoordinates.Length != 0)
            {
                Array.Copy(initialCoordinates, 0, coordinates, 0, Math.Min(n, initialCoordinates.Length));
            }
        }

        public double[] ConvertToArray() => (double[])coordinates.Clone();
        
        public int GetSize() => coordinates.Length;

        public override string ToString() => string.Concat("{", string.Join("; ", coordinates), " } ");

        public Vector Add(Vector vector)
        {
            int n = Math.Min(GetSize(), vector.GetSize());            
            Array.Resize(ref coordinates, Math.Max(GetSize(), vector.GetSize()));

            for (int i = 0; i < n; i++)
            {
                coordinates[i] += vector.coordinates[i];
            }

            for (int i=n; i < vector.GetSize(); i++)
            {
                coordinates[i] += vector.coordinates[i];
            }

            return this;
        }

        public Vector Subtract(Vector vector)
        {
            int n = Math.Min(GetSize(), vector.GetSize());
            Array.Resize(ref coordinates, Math.Max(GetSize(), vector.GetSize()));

            for (int i = 0; i < n; i++)
            {
                coordinates[i] -= vector.coordinates[i];
            }

            for (int i = n; i < vector.GetSize(); i++)
            {
                coordinates[i] -= vector.coordinates[i];
            }

            return this;
        }

        public Vector MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                coordinates[i] *= scalar;
            }

            return this;
        }

        public Vector Revert() => MultiplyByScalar(-1);

        public double GetLength()
        {
            double length = 0;

            foreach (double coordinate in coordinates)
            {
                length += coordinate * coordinate;
            }

            return Math.Sqrt(length);
        }

        public double GetCoordinate(int index) => coordinates[index];

        public void SetCoordinate(int index, double value) 
        {
            coordinates[index] = value;
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

        private static int GetHashCode(double[] array)
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
            return vectorsTemp.Add(vector2);
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector vectorsTemp = new Vector(vector1);
            return vectorsTemp.Subtract(vector2);
        }

        public static double Multiply(Vector vector1, Vector vector2)
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