﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    interface IShape
    {
        double getWidth();
        double getHeight();
        double getArea();
        double getPerimeter();
        void printShapeInf();
    }

    public class Square : IShape
    {
        double Side;

        public Square(double side)
        {
            Side = side;
        }
        public double getWidth()
        {
            return Side;
        }
        public double getHeight()
        {
            return Side;
        }
        public double getArea()
        {
            return Side * Side;
        }
        public double getPerimeter()
        {
            return 4 * Side;
        }
        public void printShapeInf()
        {
            Console.WriteLine($"Square, side = {Side}");
        }
        public override bool Equals(object obj)
        {
            IShape shape2 = obj as IShape;
            
            if (!(shape2 is Square))
            {
                return false;
            }
            
            return (this.getArea()==shape2.getArea());
        }
        public override int GetHashCode()
        {
            return 1;
        }
        public override string ToString()
        {
            return ("Square");
        }
    }

    public class Rectangle : IShape
    {
        double Width;
        double Height;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double getWidth()
        {
            return Width;
        }
        public double getHeight()
        {
            return Height;
        }
        public double getArea()
        {
            return Height * Width;
        }
        public double getPerimeter()
        {
            return 2 * (Height + Width);
        }
        public void printShapeInf()
        {
            Console.WriteLine($"Rectangle, height = {Height}, width = {Width}");
        }
        public override bool Equals(object obj)
        {
            IShape shape2 = obj as IShape;

            if (!(shape2 is Rectangle))
            {
                return false;
            }

            return (this.getArea() == shape2.getArea());
        }
        public override int GetHashCode()
        {
            return 2;
        }
        public override string ToString()
        {
            return ("Rectangle");
        }
    }

    public class Circle : IShape
    {
        double Radius;

        public Circle(double radius)
        {
            Radius = radius;
        }
        public double getWidth()
        {
            return 2 * Radius;
        }
        public double getHeight()
        {
            return 2 * Radius;
        }
        public double getArea()
        {
            return Math.PI * Radius * Radius;
        }
        public double getPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
        public void printShapeInf()
        {
            Console.WriteLine($"Circle, radius = {Radius}");
        }
        public override bool Equals(object obj)
        {
            IShape shape2 = obj as IShape;

            if (!(shape2 is Circle))
            {
                return false;
            }

            return (this.getArea() == shape2.getArea());
        }
        public override int GetHashCode()
        {
            return 2;
        }
        public override string ToString()
        {
            return ("Circle");
        }
    }

    public class Triangle : IShape
    {
        double X1;
        double Y1;
        double X2;
        double Y2;
        double X3;
        double Y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }
        public double getWidth() //max(x1, x2, x3) – min(x1, x2, x3)
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }
        public double getHeight() //max(y1, y2, y3) – min(y1, y2, y3)
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }
        public double getArea()
        {
            return 0.5 * Math.Abs((X2 - X1) * (Y3 - Y1) - (X3 - X1) * (Y2 - Y1));
        }
        public double getPerimeter()
        {
            double a = Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));
            double b = Math.Sqrt((X3 - X1) * (X3 - X1) + (Y3 - Y1) * (Y3 - Y1));
            double c = Math.Sqrt((X2 - X3) * (X2 - X3) + (Y2 - Y3) * (Y2 - Y3));
            return a + b + c;
        }
        public void printShapeInf()
        {
            Console.WriteLine($"Triangle, x1 = {X1}, y1 = {Y1}, x2 = {X2}, y2 = {Y2}, x3 = {X3}, y3 = {Y3}");
        }
        public override bool Equals(object obj)
        {
            IShape shape2 = obj as IShape;

            if (!(shape2 is Triangle))
            {
                return false;
            }

            return (this.getArea() == shape2.getArea());
        }
        public override int GetHashCode()
        {
            return 6;
        }
        public override string ToString()
        {
            return ("Triangle");
        }
    }
}