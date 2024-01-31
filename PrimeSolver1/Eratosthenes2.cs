using System;
using System.Diagnostics;

namespace PrimeSolver1
{
    internal class Eratosthenes2
    {
        private Int64 start;
        private Int64 end;
        private Byte[] a;
        private Byte[] b;
        public Int64 Start { get { return this.start; } }
        public Int64 End { get { return this.end; } }
        public Eratosthenes2(Int64 start, Int64 end, Byte[] eratosthenes1)
        {
            this.start = start;
            this.end = end;
            Int64 size = end - start + 1;
            a = eratosthenes1;
            Byte[] b = this.b = new Byte[size];
            for (Int64 i = 0; i < size; ++i)
            {
                b[i] = 1;
            }

            Int64 sqrt = Helper.Sqrt(end);
            Debug.Assert(sqrt <= a.Length);
            for (Int64 i = 1; i <= sqrt; ++i)
            {
                if (a[i - 1] == 0) continue;
                for (Int64 j = size - 1 - (end % i); j >= 0; j -= i)
                {
                    b[j] = 0;
                }
            }
        }

        public bool IsPrime(Int64 n)
        {
            Debug.Assert(n >= this.start && n <= this.end);
            if (n <= this.a.Length)
            {
                return this.a[n - 1] == 1;
            }
            else
            {
                return this.b[n - start] == 1;
            }
        }
    }
}
