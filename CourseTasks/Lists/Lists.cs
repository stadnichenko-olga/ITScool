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

            linkedList.Reverse();
            Console.WriteLine("Reverse List:");
            linkedList.Print();

            linkedList.AddIndex(3, "M");
            Console.WriteLine("Add new element M index 3");
            linkedList.Print();

            linkedList.Remove("M");
            Console.WriteLine("Remove element M");
            linkedList.Print();

            Console.WriteLine($"Element index 2 = {linkedList.GetNode(2).ToString()}");
            linkedList.Remove(2);
            Console.WriteLine("Remove element index 2");
            linkedList.Print();

            linkedList.RemoveFirst();
            Console.WriteLine("Remove first element");
            linkedList.Print();

            Console.WriteLine("Make a copy of the List");
            LinkedList<string> linkedListCopy = linkedList.CopyOf();
            linkedListCopy.Print();

            Console.ReadKey();
        }        
    }
}
