using System;


namespace Ranges
{
    public class Range
    {
        private double from;
        private double to;

        public Range(double from, double to)
        {
            this.from = Math.Min(from, to);
            this.to = Math.Max(from, to);
        }

        public bool IsInside(double numberToCheck)
        {
            return (numberToCheck >= Math.Min(from, to)) && (numberToCheck <= Math.Max(from, to));
        }

        public double GetLength()
        {
            return Math.Abs(to - from);
        }

        public override string ToString()
        {
            if (this == null)
            {
                return ("None");
            }
            return ($"The left boundary is {this.from}, right one is {this.to}");
        }

        public Range GetIntersection(Range range)
        {
            if ((this.to <= range.from) || (range.to <= this.from))
            {
                return null;
            }
            Range intersection = new Range(Math.Max(this.from, range.from), Math.Min(this.to, range.to));
            return intersection;
        }

        public Range[] GetUnion(Range range)
        {
            if ((this.to <= range.from) || (range.to <= this.from))
            {
                Range[] unionRanges = { this, range };
                return unionRanges;
            }
            else
            {
                Range[] unionRanges = new Range[1];
                unionRanges[0] = new Range(Math.Min(this.from, range.from), Math.Max(this.to, range.to));
                return unionRanges;
            }
        }

        public Range[] GetDifference(Range range)
        {
            if ((this.to <= range.from) || (range.to <= this.from))
            {
                Range[] unionRanges = { this };
                return unionRanges;
            }
            else if (this.from >= range.from && this.to <= range.to)
            {
                return null;
            }
            else if (this.from < range.from && this.to > range.to)
            {
                Range[] UnionRanges = { new Range(this.from, range.from), new Range(range.to, this.to) };
                return UnionRanges;
            }
            else if (range.to == this.to)
            {
                Range[] UnionRanges = { new Range(this.from, range.from) };
                return UnionRanges;
            }
            else
            {
                Range[] UnionRanges = { new Range(range.to, this.to) };
                return UnionRanges;
            }
        }
    }
}
