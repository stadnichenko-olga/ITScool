using System;

namespace Ranges
{
    public class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = Math.Min(from, to);
            To = Math.Max(from, to);
        }

        public Range(Range range)
        {
            From = range.From;
            To = range.To;
        }

        public bool IsInside(double numberToCheck)
        {
            return ((numberToCheck > To) && (numberToCheck < From)) || (numberToCheck == To) || (numberToCheck == From);
        }

        public double GetLength()
        {
            return To - From;
        }

        public override string ToString()
        {
            return $"The left boundary is {From}, right one is {To}";
        }

        public Range GetIntersection(Range range)
        {
            if ((To <= range.From) || (range.To <= From))
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetUnion(Range range)
        {
            if ((To < range.From) || (range.To < From))
            {
                return new Range[2] { new Range(this), new Range(range) };
            }

            return new Range[1] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if (To <= range.From || From >= range.To)
            {
                return new Range[1] { new Range(this) };
            }
            else if (From >= range.From && To <= range.To)
            {
                return null;
            }
            else if (From < range.From && To <= range.To)
            {
                return new Range[1] { new Range(From, range.From) }; ;
            }
            else if (From >= range.From && To > range.To)
            {
                return new Range[1] { new Range(range.To, To) }; ;
            }

            return new Range[2] { new Range(From, range.From), new Range(range.To, To) }; 
        }
    }
}
