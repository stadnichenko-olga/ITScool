﻿using System;

namespace ArrayList
{
    static class ArrayLists
    {
        static void Main()
        {
            var items = new ArrayList<string>(8);

            Console.WriteLine("Before adding: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            items.Add("Ann");
            items.Insert(0, "Bill");

            Console.WriteLine();
            Console.WriteLine(string.Join("; ", items));
            Console.WriteLine("After adding two elements to items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            items.Insert(items.Count, "Mary");
            Console.WriteLine("After adding Mary to the end");
            Console.WriteLine();
            Console.WriteLine(string.Join("; ", items));

            items.Insert(2, "John");
            Console.WriteLine("After adding John into 2 position");
            Console.WriteLine();
            Console.WriteLine(string.Join("; ", items));
            Console.WriteLine("After adding two more elements to items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            items.Add("Jack");
            items.Add("Andrew");
            items.Add("Natali");
            items.Add("Brian");
            items.Add("Oscar");
            items.Add("Kate");

            Console.WriteLine();
            Console.WriteLine(string.Join("; ", items));
            Console.WriteLine("After adding six more elements to items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            Console.WriteLine();
            Console.WriteLine("Remove item: John");
            items.Remove("John");
            Console.WriteLine(string.Join("; ", items));
            Console.WriteLine("After removing John from items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            Console.WriteLine();
            Console.WriteLine("Remove item #3");
            items.RemoveAt(3);
            Console.WriteLine(string.Join("; ", items));
            Console.WriteLine("After removing two elements from items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            Console.WriteLine();
            Console.WriteLine("CopyTo an array starting from index 1");
            var arrayToCopyTo = new string[20];
            arrayToCopyTo[0] = "Jane";
            arrayToCopyTo[1] = "Greg";
            Console.WriteLine(string.Join("; ", arrayToCopyTo));
            items.CopyTo(arrayToCopyTo, 1);             
            Console.WriteLine(string.Join("; ", arrayToCopyTo));

            Console.WriteLine();

            Console.WriteLine(items.Contains(null) ? "Items contains NULL" : "Items doesn't contain NULL");

            Console.WriteLine(items.Contains("John") ? "Items contains John" : "Items doesn't contain John");

            Console.WriteLine($"Index of item John {items.IndexOf("John")}");

            Console.WriteLine(items.Contains("Mary") ? "Items contains Mary" : "Items doesn't contain Mary");

            Console.WriteLine($"Index of item Mary {items.IndexOf("Mary")}");

            Console.ReadLine();
        }
    }
}
