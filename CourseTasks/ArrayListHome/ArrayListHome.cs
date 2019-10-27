using System;
using System.Collections.Generic;

namespace ArrayListHome
{
    class ArrayListHome
    {        
        static void Main(string[] args)
        {
            List<int> homes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Initial list " + string.Join(", ", homes.ToArray()));

            if (ListOperations.RemoveEven(ref homes))
            {
                Console.WriteLine("Even elements were removed. New list " + string.Join(", ", homes.ToArray()));
            }

            Console.WriteLine();
            List<int> listAlliteration = new List<int> { 1, 2, 1, 3, 4, 5, 2, 2, 6, 7, 8, 5, 1, 9, 10 };
            Console.WriteLine("Initial list " + string.Join(", ", listAlliteration.ToArray()));            
            Console.WriteLine("New list " + string.Join(", ", ListOperations.RemoveAlliteration(listAlliteration)));

            Console.WriteLine();
            string path = Environment.CurrentDirectory + "\\articles.txt";
            List<string> fileReader = FileReader.FileStringReder(path);
            Console.WriteLine("Strings from the file" , path);
            Console.WriteLine(string.Join("\n", fileReader.ToArray()));

            Console.ReadKey();
        }
    }
}
