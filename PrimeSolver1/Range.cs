using System;

namespace PrimeSolver1
{
    internal class Range
    {
        private Int64 start;
        private Int64 end;

        public Range(Int64 start, Int64 end)
        {
            this.start = start;
            this.end = end;
        }

        public Int64 Start { get { return start; } }
        public Int64 End { get { return end; } }

        public static DividedRange Divide(Range range, Int64 divisor)
        {
            return new Range.DividedRange(range.start, range.end, divisor);
        }

        public interface IEnumerator
        {
            Range Current { get; }
            bool MoveNext();
        }

        internal class DividedRange : Range, Range.IEnumerator
        {
            private Int64 divisor;
            private Int64 index;
            private Int64 delta;
            private Int64 modulo;
            private Int64 sigma;

            public DividedRange(Int64 start, Int64 end, Int64 divisor) : base(start, end)
            {
                this.divisor = divisor;
                this.index = 0;
                this.delta = (this.end - this.start + 1) / divisor;
                this.modulo = (this.end - this.start + 1) % divisor;
                this.sigma = start;
            }

            public Int64 Divisor { get { return this.divisor; } }

            public Range Current
            {
                get
                {
                    Int64 shiftEnd = this.index < this.modulo ? 1 : 0;
                    return new Range(this.sigma, this.sigma + this.delta + shiftEnd - 1);
                }
            }

            public bool MoveNext()
            {
                if (this.index != this.divisor - 1)
                {
                    if (this.index < this.modulo) { ++this.sigma; }
                    ++this.index;
                    this.sigma += this.delta;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
