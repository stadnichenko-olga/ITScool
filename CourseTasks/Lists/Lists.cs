using System;

namespace Lists
{
    class Lists
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            linkedList.Add("A");
            linkedList.Add("B");
            linkedList.Add("C");
            linkedList.Add("D");
            linkedList.Add("E");
            linkedList.Add("F");
            linkedList.Add("G");
            linkedList.Add("H");
            linkedList.Add("I");

            linkedList.Print();
            Console.WriteLine($"List length = {linkedList.Length()}.");

            linkedList.Revert();
            Console.WriteLine("Reverse List:");
            linkedList.Print();

            linkedList.AddByIndex(3, "M");
            Console.WriteLine("Add new element M index 3");
            linkedList.Print();
            Console.WriteLine($"List length = {linkedList.Length()}.");

            linkedList.Remove("M");
            Console.WriteLine("Remove element M");
            linkedList.Print();
            Console.WriteLine($"List length = {linkedList.Length()}.");

            Console.WriteLine($"Element index 4 = {linkedList.GetValue(4).ToString()}");
            linkedList.Remove(4);
            Console.WriteLine("Remove element index 4");
            linkedList.Print();
            Console.WriteLine($"List length = {linkedList.Length()}.");

            linkedList.RemoveFirst();
            Console.WriteLine("Remove first element");
            linkedList.Print();
            Console.WriteLine($"List length = {linkedList.Length()}.");

            Console.WriteLine("Make a copy of the List");
            LinkedList<string> linkedListCopy = linkedList.Copy();
            linkedListCopy.Print();

            Console.ReadKey();
        }
    }
}
