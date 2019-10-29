using System;
using System.Collections.Generic;

namespace ArrayListHome
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            List<int> integerNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Initial list " + string.Join(", ", integerNumbers.ToArray()));

            if (ListOperations.RemoveEven(ref integerNumbers))
            {
                Console.WriteLine("Even elements were removed. New list " + string.Join(", ", integerNumbers.ToArray()));
            }

            Console.WriteLine();
            List<int> listAlliteration = new List<int> { 1, 2, 1, 3, 4, 5, 2, 2, 6, 7, 8, 5, 1, 9, 10 };
            Console.WriteLine("Initial list " + string.Join(", ", listAlliteration.ToArray()));
            Console.WriteLine("New list " + string.Join(", ", ListOperations.GetListWithoutRepeat(listAlliteration)));

            Console.WriteLine();
            string path = "\\articles.txt";
            List<string> fileStrings = FileReader.ReadStringsFromFile(path);

            if (fileStrings.Count != 0)
            {
                Console.WriteLine("Strings from the file", path);
                Console.WriteLine(string.Join(Environment.NewLine, fileStrings.ToArray()));
            }

            Console.ReadKey();
        }
    }
}
