using System;
using System.Linq;

namespace ArrayList
{
    class ArrayLists
    {
        static void Main()
        {
            var items = new ArrayList<string>(8);

            Console.WriteLine("Before adding: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            items.Add("Ann"); 
            items.Insert(0, "Bill"); // insert the value at index 0


            Console.WriteLine("After adding two elements to items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            Console.Write("\nDisplay list contents with counter-controlled loop:");
            for (var i = 0; i < items.Count; i++)
            {
                Console.Write($" {items[i]}");
            }

            Console.Write("\nDisplay list contents with foreach statement:");
            foreach (var item in items)
            {
                Console.Write($" {item}");
            }

            items.Add("green"); // add "green" to the end of the List
            items.Add("yellow"); // add "yellow" to the end of the List

            // display List's Count and Capacity after adding two more elements
            Console.WriteLine("\n\nAfter adding two more elements to items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            Console.Write("List with two new elements:");
            foreach (var item in items)
            {
                Console.Write($" {item}");
            }

            items.Remove("yellow"); // remove the first "yellow"

            // display the List
            Console.Write("\n\nRemove first instance of yellow:");
            foreach (var item in items)
            {
                Console.Write($" {item}");
            }

            items.RemoveAt(1); // remove item at index 1

            // display the List
            Console.Write("\nRemove second list element (green):");
            foreach (var item in items)
            {
                Console.Write($" {item}");
            }

            // display List's Count and Capacity after removing two elements
            Console.WriteLine("\nAfter removing two elements from items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            // check if a value is in the List
            Console.WriteLine("\n\"red\" is " + $"{(items.Contains("red") ? string.Empty : "not ")}in the list");

            items.Add("orange"); // add "orange" to the end of the List
            items.Add("violet"); // add "violet" to the end of the List
            items.Add("blue"); // add "blue" to the end of the List

            // display List's Count and Capacity after adding three elements
            Console.WriteLine("\nAfter adding three more elements to items: " + $"Count = {items.Count}; Capacity = {items.Capacity}");

            // display the List
            Console.Write("List with three new elements:");

            foreach (var item in items)
            {
                Console.Write($" {item}");
            }
        }
    }
}
