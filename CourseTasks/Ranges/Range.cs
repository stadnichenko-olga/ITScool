using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges
{
    public class Range
    {
        public double From;
        public double To;

        public void Arrange()
        {
            double left = Math.Min(this.From, this.To);
            this.To = Math.Max(this.From, this.To);
            this.From = left;
        }

        public bool IsInside(double numberToCheck)
        {
            if ((numberToCheck >= Math.Min(this.From, this.To)) && (numberToCheck <= Math.Max(this.From, this.To)))
            {
                return true;
            }
            return false;
        }

        public double Length()
        {
            return Math.Abs(this.To - this.From);
        }

        public void Print()
        {
            Console.WriteLine($"The left boundary is {this.From}, right one is {this.To}");
        }

        public Range Intersection(Range range2)
        {
            this.Arrange();
            range2.Arrange();
            if ((this.To < range2.From) || (range2.To < this.From))
            {
                return null;
            }
            Range intersection = new Range();
            intersection.From = Math.Max(this.From, range2.From);
            intersection.To = Math.Min(this.To, range2.To);
            return intersection;
        }

        public Range[] Conjunction(Range range2)
        {
            this.Arrange();
            range2.Arrange();

            if (this.Intersection(range2) == null)
            {
                Range[] conjunctionRanges = new Range[2];
                conjunctionRanges[0] = this;
                conjunctionRanges[1] = range2;
                return conjunctionRanges;
            }
            else
            {
                Range[] conjunctionRanges = new Range[1];
                conjunctionRanges[0] = new Range();
                conjunctionRanges[0].From = Math.Min(this.From, range2.From);
                conjunctionRanges[0].To = Math.Max(this.To, range2.To);
                return conjunctionRanges;
            }
        }

        public Range[] Difference(Range range2)
        {
            this.Arrange();
            range2.Arrange();

            if (this.Intersection(range2) == null)
            {
                Range[] conjunctionRanges = new Range[1];
                conjunctionRanges[0] = new Range();
                conjunctionRanges[0] = this;
                return conjunctionRanges;
            }
            else if (this.Intersection(range2).From == this.From && this.Intersection(range2).To == this.To)
            {
                return null;
            }
            else if (this.Intersection(range2).From > this.From && this.Intersection(range2).To < this.To)
            {
                Range[] conjunctionRanges = new Range[2];
                conjunctionRanges[0] = new Range();
                conjunctionRanges[0].From = this.From;
                conjunctionRanges[0].To = this.Intersection(range2).From;
                conjunctionRanges[1] = new Range();
                conjunctionRanges[1].From = this.Intersection(range2).To;
                conjunctionRanges[1].To = this.To;
                return conjunctionRanges;
            }
            else if (this.Intersection(range2).To == this.To)
            {
                Range[] conjunctionRanges = new Range[1];
                conjunctionRanges[0] = new Range();
                conjunctionRanges[0].From = this.From;
                conjunctionRanges[0].To = this.Intersection(range2).From;
                return conjunctionRanges;
            }
            else
            {
                Range[] conjunctionRanges = new Range[1];
                conjunctionRanges[0] = new Range();
                conjunctionRanges[0].From = this.Intersection(range2).To;
                conjunctionRanges[0].To = this.To;
                return conjunctionRanges;
            }
        }
    }
}
