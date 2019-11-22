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

            Console.WriteLine(linkedList);
            Console.WriteLine($"List length = {linkedList.Count}.");

            linkedList.Revert();
            Console.WriteLine("Reverse List:");
            Console.WriteLine(linkedList);

            linkedList.AddByIndex(3, "M");
            Console.WriteLine("Add new element M index 3");
            Console.WriteLine(linkedList);

            linkedList.Remove("M");
            Console.WriteLine("Remove element M");
            Console.WriteLine(linkedList);

            Console.WriteLine($"Element index 4 = {linkedList.GetValue(4).ToString()}");
            linkedList.RemoveAt(4);
            Console.WriteLine("Remove element index 4");
            Console.WriteLine(linkedList);

            linkedList.RemoveFirst();
            Console.WriteLine("Remove first element");
            Console.WriteLine(linkedList);

            Console.WriteLine("Make a copy of the List");
            LinkedList<string> linkedListCopy = linkedList.Copy();
            Console.WriteLine(linkedListCopy);

            Console.ReadKey();
        }
    }
}
