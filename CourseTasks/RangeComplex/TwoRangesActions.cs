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

                Console.WriteLine("Add first right boundary");
                if (!double.TryParse(Console.ReadLine(), out double rightBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }
                Range range1 = new Range(leftBoundary, rightBoundary);
                Console.WriteLine(range1.ToString());

                Console.WriteLine("Add second left boundary");
                if (!double.TryParse(Console.ReadLine(), out leftBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Add second right boundary");
                if (!double.TryParse(Console.ReadLine(), out rightBoundary))
                {
                    Console.WriteLine("Error: not a number");
                    Console.ReadKey();
                    return;
                }
                Range range2 = new Range(leftBoundary, rightBoundary);
                Console.WriteLine(range2.ToString());

                Console.Write("Ranges intersection = ");
                if (range1.GetIntersection(range2) != null)
                {
                    Console.WriteLine(range1.GetIntersection(range2).ToString());
                }

                Console.Write("Ranges conjunction: ");
                Range[] rangesConjunction = range1.GetUnion(range2);
                foreach (Range result in rangesConjunction)
                {
                    Console.WriteLine(result.ToString());
                }

                Console.Write("Ranges difference Range1/Range2: ");
                Range[] rangesDifference = range1.GetDifference(range2);
                if (rangesDifference != null)
                {
                    foreach (Range result in rangesDifference)
                    {
                        Console.WriteLine(result.ToString());
                    }
                }

                Console.Write("Ranges difference Range2/Range1: ");
                rangesDifference = range2.GetDifference(range1);
                if (rangesDifference != null)
                {
                    foreach (Range result in rangesDifference)
                    {
                        Console.WriteLine(result.ToString());
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
