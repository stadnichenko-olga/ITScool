using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges
{
    public class Range
    {
        private double From;
        private double To;

        public Range(double from, double to)
        {
            From = Math.Min(from, to);
            To = Math.Max(from, to);
        }

        public bool IsInside(double numberToCheck)
        {
            return (numberToCheck >= Math.Min(From, To)) && (numberToCheck <= Math.Max(From, To));
        }

        public double GetLength()
        {
            return Math.Abs(To - From);
        }

        public override string ToString()
        {
            if (this == null)
            {
                return ("None");
            }
            return ($"The left boundary is {this.From}, right one is {this.To}");
        }

        public Range GetIntersection(Range range)
        {
            if ((this.To <= range.From) || (range.To <= this.From))
            {
                return null;
            }
            Range intersection = new Range(Math.Max(this.From, range.From), Math.Min(this.To, range.To));
            return intersection;
        }

        public Range[] GetUnion(Range range)
        {
            if ((this.To <= range.From) || (range.To <= this.From))
            {
                Range[] unionRanges = { this, range };
                return unionRanges;
            }
            else
            {
                Range[] unionRanges = new Range[1];
                unionRanges[0] = new Range(Math.Min(this.From, range.From), Math.Max(this.To, range.To));
                return unionRanges;
            }
        }

        public Range[] GetDifference(Range range)
        {
            if ((this.To <= range.From) || (range.To <= this.From))
            {
                Range[] unionRanges = { this };
                return unionRanges;
            }
            else if (this.From >= range.From && this.To <= range.To)
            {
                return null;
            }
            else if (this.From < range.From && this.To > range.To)
            {
                Range[] UnionRanges = { new Range(this.From, range.From), new Range(range.To, this.To) };
                return UnionRanges;
            }
            else if (range.To == this.To)
            {
                Range[] UnionRanges = { new Range(this.From, range.From) };
                return UnionRanges;
            }
            else
            {
                Range[] UnionRanges = { new Range(range.To, this.To) };
                return UnionRanges;
            }
        }
    }
}
