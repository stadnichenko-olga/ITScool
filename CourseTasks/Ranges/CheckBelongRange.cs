using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges
{
    class CheckBelongRange
    {        
        static void Main()
        {
            bool doMore = true;
            Range range = new Range();

            while (doMore)
            {
                Console.WriteLine("Add new left boundary");
                if (!double.TryParse(Console.ReadLine(), out double leftBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }
                range.From = leftBoundary;

                Console.WriteLine("Add new right boundary");
                if (!double.TryParse(Console.ReadLine(), out double rightBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }
                range.To = rightBoundary;

                range.Arrange();
                Console.Write($"The boundaries were arranged. ");
                range.Print();
                Console.WriteLine($"The length is equal to {range.Length()}");

                Console.WriteLine("What number do you want to check?");
                if (!double.TryParse(Console.ReadLine(), out double number))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }

                if (range.IsInside(number))
                {
                    Console.WriteLine("The numbet is inside.");
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
