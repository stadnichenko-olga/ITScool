using System;

namespace Ranges
{
    class CheckBelongRange
    {        
        static void Main()
        {
            bool doMore = true;

            while (doMore)
            {
                Console.WriteLine("Add new left boundary");
                if (!double.TryParse(Console.ReadLine(), out double leftBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Add new right boundary");
                if (!double.TryParse(Console.ReadLine(), out double rightBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }
                Range range = new Range(leftBoundary,rightBoundary);
                Console.WriteLine(range.ToString());
                Console.WriteLine($"The length is equal to {range.GetLength()}");

                Console.WriteLine("What number do you want to check?");
                if (!double.TryParse(Console.ReadLine(), out double number))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }

                if (range.IsInside(number))
                {
                    Console.WriteLine("The number is inside.");
                }
                else
                {
                    Console.WriteLine("The number is outside.");
                }

                Console.WriteLine("Do you want repeat? Y/N");
                string needMore = Console.ReadLine();
                needMore = needMore.ToLower();
                if (!needMore.Equals("y"))
                {
                    doMore = false;
                }
            }
        }
    }
}
