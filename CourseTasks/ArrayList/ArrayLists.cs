using System;

namespace ArrayList
{
    class ArrayLists
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

            items.Add("Mary");
            items.Insert(2, "John");

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

            Console.WriteLine();
            Console.WriteLine("Remove item #3");
            items.RemoveAt(3);
            Console.WriteLine(string.Join("; ", items));
            Console.WriteLine("After removing two elements from items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            Console.WriteLine();
            Console.WriteLine("CopyTo an array startong from index 3");
            items.CopyTo(new string[] { "Jane", "Kitty", "Max" }, 3);
            Console.WriteLine(string.Join("; ", items));
            Console.WriteLine("After copying an array to items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            Console.WriteLine();

            if (items.Contains(null))
            {
                Console.WriteLine("Items contains NULL");
            }
            else
            {
                Console.WriteLine("Items doesn't contain NULL");
            }

            if (items.Contains("John"))
            {
                Console.WriteLine("Items contains John");
            }
            else
            {
                Console.WriteLine("Items doesn't contain John");
            }

            Console.WriteLine($"Index of item John {items.IndexOf("John")}");

            if (items.Contains("Mary"))
            {
                Console.WriteLine("Items contains Mary");
            }
            else
            {
                Console.WriteLine("Items doesn't contain Mary");
            }

            Console.WriteLine($"Index of item Mary {items.IndexOf("Mary")}");

            Console.ReadLine();
        }
    }
}
