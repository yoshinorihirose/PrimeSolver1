using System;

namespace PrimeSolver1
{
    internal class Eratosthenes1
    {
        static public Byte[] Solve(Int64 size)
        {
            Byte[] a = new Byte[size];
            Int64 sqrt_size = Helper.Sqrt(size);

            for (Int64 i = 0; i < size; ++i)
            {
                a[i] = 1;
            }
            a[0] = 0;
            for (Int64 i = 2; i <= sqrt_size; ++i)
            {
                if (a[i - 1] == 0) continue;
                for (Int64 j = 2 * i - 1; j < size; j += i)
                {
                    a[j] = 0;
                }
            }
            return a;
        }
    }
}
