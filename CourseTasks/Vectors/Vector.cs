﻿using System;

namespace Vectors
{
    public class Vector
    {
        private double[] vector;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException(String.Format("{0} is less than 1", n), "n");
            }
            vector = new double[n];
            for (int i = 0; i < n; i++)
            {
                vector[i] = 0;
            }
        }

        public Vector(double[] coordinates)
        {
            vector = new double[coordinates.Length];
            coordinates.CopyTo(vector, 0);
        }

        public Vector(Vector vectorToCopy)
        {
            vector = new double[vectorToCopy.GetSize()];
            vectorToCopy.vector.CopyTo(this.vector, 0);
        }

        public Vector(int n, double[] coordinates)
        {
            if (n <= 0)
            {
                throw new ArgumentException(String.Format("Dimension {0} is less than 1", n));
            }

            vector = new double[n];
            for (int i = 0; i < Math.Min(coordinates.Length, n); i++)
            {
                vector[i] = coordinates[i];
            }
            for (int i = coordinates.Length; i < n; i++)
            {
                vector[i] = 0;
            }
        }

        public int GetSize()
        {
            return vector.Length;
        }

        public override string ToString()
        {
            return string.Join(", ", vector);
        }

        public void GetVectorsSumm(Vector vector2)
        {
            for (int i = 0; i < Math.Min(GetSize(), vector2.GetSize()); i++)
            {
                vector[i] += vector2.vector[i];
            }
            Array.Resize(ref vector, Math.Max(GetSize(), vector2.GetSize()));
            for (int i = GetSize() - 1; i < vector2.GetSize(); i++)
            {
                vector[i] = vector2.vector[i];
            }
        }

        public void GetVectorsDifference(Vector vector2)
        {
            for (int i = 0; i < Math.Min(GetSize(), vector2.GetSize()); i++)
            {
                vector[i] -= vector2.vector[i];
            }
        }

        public void GetVectorMultiplicationByScalar(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                vector[i] *= scalar;
            }
        }

        public void GetReverseVector()
        {
            GetVectorMultiplicationByScalar(-1);
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
            return vector[i - 1];
        }

        public void SetVectorCoordinate(int i, double value)
        {
            vector[i - 1] = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Vector vector2 = obj as Vector;
            if (this.GetSize() != vector2.GetSize())
            {
                return false;
            }
            int i = 0;
            foreach (double coordinate in vector2.vector)
            {
                if (coordinate != vector[i])
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static Vector GetVectorsSumm(Vector vector1, Vector vector2)
        {
            int n = Math.Max(vector1.GetSize(), vector2.GetSize());
            double[] vectorsSumm = new double[n];
            int i = 0;
            if (vector1.GetSize() <= vector2.GetSize())
            {
                foreach (double coordinate in vector1.vector)
                {
                    vectorsSumm[i] = coordinate + vector2.vector[i];
                    i++;
                }
                while (i < n)
                {
                    vectorsSumm[i] = vector2.vector[i];
                    i++;
                };
            }
            else
            {
                foreach (double coordinate in vector2.vector)
                {
                    vectorsSumm[i] = coordinate + vector1.vector[i];
                    i++;
                }
                while (i < n)
                {
                    vectorsSumm[i] = vector1.vector[i];
                    i++;
                };
            }

            return new Vector(vectorsSumm);
        }

        public static Vector GetVectorsDifference(Vector vector1, Vector vector2)
        {
            Vector vectorTemp = new Vector(vector2);
            vectorTemp.GetReverseVector();
            return GetVectorsSumm(vector1, vectorTemp);
        }

        public static double GetVectorsMultiplication(Vector vector1, Vector vector2)
        {
            if (vector1.GetSize() != vector2.GetSize())
            {
                throw new ArgumentException(String.Format("Dimensions are not equal"));
            }
            double vectorsMultiplication = 0;
            for (int i = 0; i < vector1.GetSize(); i++)
            {
                vectorsMultiplication += vector1.vector[i] * vector2.vector[i];
            }

            return vectorsMultiplication;
        }
    }
}
