using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranges;

namespace Ranges
{
    class TwoRangesActions
    {
        static void Main()
        {
            bool doMore = true;
            Range range1 = new Range();
            Range range2 = new Range();

            Console.WriteLine("Let's check intersection, conjunction and disjunction.");

            while (doMore)
            {
                Console.WriteLine("Add first left boundary");
                if (!double.TryParse(Console.ReadLine(), out double leftBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }
                range1.From = leftBoundary;

                Console.WriteLine("Add first right boundary");
                if (!double.TryParse(Console.ReadLine(), out double rightBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }
                range1.To = rightBoundary;

                Console.WriteLine("Add second left boundary");
                if (!double.TryParse(Console.ReadLine(), out leftBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }
                range2.From = leftBoundary;

                Console.WriteLine("Add second right boundary");
                if (!double.TryParse(Console.ReadLine(), out rightBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }
                range2.To = rightBoundary;

                Console.Write("Ranges intersection = ");
                if (range1.Intersection(range2) != null)
                {
                    range1.Intersection(range2).Print();
                }

                Console.Write("Ranges conjunction: ");
                Range[] rangesConjunction = range1.Conjunction(range2);
                foreach (Range result in rangesConjunction)
                {
                    result.Print();
                }

                Console.Write("Ranges difference Range1/Range2: ");
                Range[] rangesDifference = range1.Difference(range2);
                if (rangesDifference != null)
                {
                    foreach (Range result in rangesDifference)
                    {
                        result.Print();
                    }
                }

                Console.Write("Ranges difference Range2/Range1: ");
                rangesDifference = range2.Difference(range1);
                if (rangesDifference != null)
                {
                    foreach (Range result in rangesDifference)
                    {
                        result.Print();
                    }
                }

                Console.WriteLine();
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
