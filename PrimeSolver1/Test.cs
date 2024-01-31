using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSolver1
{
    internal class Test
    {
        static internal void Test_Sqrt()
        {
            Debug.Assert(Helper.Sqrt(1L) == 1L);
            Debug.Assert(Helper.Sqrt(2L) == 1L);
            Debug.Assert(Helper.Sqrt(3L) == 1L);
            Debug.Assert(Helper.Sqrt(4) == 2);
            Debug.Assert(Helper.Sqrt(5) == 2);
            Debug.Assert(Helper.Sqrt(6) == 2);
            Debug.Assert(Helper.Sqrt(7) == 2);
            Debug.Assert(Helper.Sqrt(8) == 2);
            Debug.Assert(Helper.Sqrt(9) == 3);
            Debug.Assert(Helper.Sqrt(10) == 3);
            Debug.Assert(Helper.Sqrt(11) == 3);
            Debug.Assert(Helper.Sqrt(12) == 3);
            Debug.Assert(Helper.Sqrt(13) == 3);
            Debug.Assert(Helper.Sqrt(14) == 3);
            Debug.Assert(Helper.Sqrt(15) == 3);
            Debug.Assert(Helper.Sqrt(16) == 4);
            Debug.Assert(Helper.Sqrt(17) == 4);
            Debug.Assert(Helper.Sqrt(18) == 4);
            Debug.Assert(Helper.Sqrt(19) == 4);
            Debug.Assert(Helper.Sqrt(20) == 4);
            Debug.Assert(Helper.Sqrt(21) == 4);
            Debug.Assert(Helper.Sqrt(22) == 4);
            Debug.Assert(Helper.Sqrt(23) == 4);
            Debug.Assert(Helper.Sqrt(24) == 4);
            Debug.Assert(Helper.Sqrt(25) == 5);

            Debug.Assert(Helper.Sqrt(123456L * 123456L) == 123456L);
            Debug.Assert(Helper.Sqrt(123456L * 123456L - 1) == 123455L);
            Debug.Assert(Helper.Sqrt(123456L * 123456L + 1) == 123456L);

            Debug.Assert(Helper.Sqrt(12345678L * 12345678L) == 12345678L);
            Debug.Assert(Helper.Sqrt(12345678L * 12345678L - 1) == 12345677L);
            Debug.Assert(Helper.Sqrt(12345678L * 12345678L + 1) == 12345678L);
        }

        static internal void Test_Range_a()
        {
            var e = Range.Divide(new Range(5, 20), 4);
            Range c = e.Current;
            Debug.Assert(c.Start == 5 && c.End == 8);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 9 && c.End == 12);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 13 && c.End == 16);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 17 && c.End == 20);
            Debug.Assert(!e.MoveNext());
        }

        static internal void Test_Range_b()
        {
            var e = Range.Divide(new Range(1, 102), 10);
            Range c = e.Current;
            Debug.Assert(c.Start == 1 && c.End == 11);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 12 && c.End == 22);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 23 && c.End == 32);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 33 && c.End == 42);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 43 && c.End == 52);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 53 && c.End == 62);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 63 && c.End == 72);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 73 && c.End == 82);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 83 && c.End == 92);
            Debug.Assert(e.MoveNext());
            c = e.Current;
            Debug.Assert(c.Start == 93 && c.End == 102);
            Debug.Assert(!e.MoveNext());
        }

        static internal void Test_Eratosthenes1a()
        {
            Byte[] a = Eratosthenes1.Solve(10);
            Debug.Assert(a[1 - 1] == 0);
            Debug.Assert(a[2 - 1] == 1);
            Debug.Assert(a[3 - 1] == 1);
            Debug.Assert(a[4 - 1] == 0);
            Debug.Assert(a[5 - 1] == 1);
            Debug.Assert(a[6 - 1] == 0);
            Debug.Assert(a[7 - 1] == 1);
            Debug.Assert(a[8 - 1] == 0);
            Debug.Assert(a[9 - 1] == 0);
            Debug.Assert(a[10 - 1] == 0);
        }

        static internal void Test_Eratosthenes1b()
        {
            {
                Byte[] a = Eratosthenes1.Solve(100);
                Int32 c = 0;
                for (Int64 i = 0; i < a.Length; ++i) { if (a[i] != 0) ++c; }
                Debug.Assert(c == 25);
            }
            {
                Byte[] a = Eratosthenes1.Solve(1000);
                Int32 c = 0;
                for (Int64 i = 0; i < a.Length; ++i) { if (a[i] != 0) ++c; }
                Debug.Assert(c == 168);
            }
            {
                Byte[] a = Eratosthenes1.Solve(10000);
                Int32 c = 0;
                for (Int64 i = 0; i < a.Length; ++i) { if (a[i] != 0) ++c; }
                Debug.Assert(c == 1229);
            }
            {
                Byte[] a = Eratosthenes1.Solve(100000);
                Int32 c = 0;
                for (Int64 i = 0; i < a.Length; ++i) { if (a[i] != 0) ++c; }
                Debug.Assert(c == 9592);
            }
        }

        static internal void Test_Eratosthenes2a()
        {
            Eratosthenes2 e = new Eratosthenes2(1, 10, Eratosthenes1.Solve(Helper.Sqrt(10)));
            Debug.Assert(!e.IsPrime(1));
            Debug.Assert(e.IsPrime(2));
            Debug.Assert(e.IsPrime(3));
            Debug.Assert(!e.IsPrime(4));
            Debug.Assert(e.IsPrime(5));
            Debug.Assert(!e.IsPrime(6));
            Debug.Assert(e.IsPrime(7));
            Debug.Assert(!e.IsPrime(8));
            Debug.Assert(!e.IsPrime(9));
            Debug.Assert(!e.IsPrime(10));
        }

        static internal void Test_Eratosthenes2b()
        {
            {
                Eratosthenes2 e = new Eratosthenes2(1, 100, Eratosthenes1.Solve(Helper.Sqrt(100)));
                Int32 c = 0;
                for (Int64 i = e.Start; i <= e.End; ++i) { if (e.IsPrime(i)) ++c; }
                Debug.Assert(c == 25);
            }
            {
                Eratosthenes2 e = new Eratosthenes2(1, 1000, Eratosthenes1.Solve(Helper.Sqrt(1000)));
                Int32 c = 0;
                for (Int64 i = e.Start; i <= e.End; ++i) { if (e.IsPrime(i)) ++c; }
                Debug.Assert(c == 168);
            }
            {
                Eratosthenes2 e = new Eratosthenes2(1, 10000, Eratosthenes1.Solve(Helper.Sqrt(10000)));
                Int32 c = 0;
                for (Int64 i = e.Start; i <= e.End; ++i) { if (e.IsPrime(i)) ++c; }
                Debug.Assert(c == 1229);
            }
            {
                Eratosthenes2 e = new Eratosthenes2(1, 100000, Eratosthenes1.Solve(Helper.Sqrt(100000)));
                Int32 c = 0;
                for (Int64 i = e.Start; i <= e.End; ++i) { if (e.IsPrime(i)) ++c; }
                Debug.Assert(c == 9592);
            }
        }

        static internal void Test_Eratosthenes2c()
        {
            {
                Eratosthenes2[] e = new Eratosthenes2[10];
                const Int64 size = 1000;
                for (Int32 i = 0; i < 10; ++i)
                {
                    e[i] = new Eratosthenes2(1 + i * (size / 10), (i + 1) * (size / 10), Eratosthenes1.Solve(Helper.Sqrt(size)));
                }
                Int32 c = 0;
                for (Int32 i = 0; i < 10; ++i)
                {
                    for (Int64 j = e[i].Start; j <= e[i].End; ++j)
                    {
                        if (e[i].IsPrime(j)) ++c;
                    }
                }
                Debug.Assert(c == 168);
            }
            {
                Eratosthenes2[] e = new Eratosthenes2[10];
                const Int64 size = 10000;
                for (Int32 i = 0; i < 10; ++i)
                {
                    e[i] = new Eratosthenes2(1 + i * (size / 10), (i + 1) * (size / 10), Eratosthenes1.Solve(Helper.Sqrt(size)));
                }
                Int32 c = 0;
                for (Int32 i = 0; i < 10; ++i)
                {
                    for (Int64 j = e[i].Start; j <= e[i].End; ++j)
                    {
                        if (e[i].IsPrime(j)) ++c;
                    }
                }
                Debug.Assert(c == 1229);
            }
            {
                Eratosthenes2[] e = new Eratosthenes2[10];
                const Int64 size = 100000;
                for (Int32 i = 0; i < 10; ++i)
                {
                    e[i] = new Eratosthenes2(1 + i * (size / 10), (i + 1) * (size / 10), Eratosthenes1.Solve(Helper.Sqrt(size)));
                }
                Int32 c = 0;
                for (Int32 i = 0; i < 10; ++i)
                {
                    for (Int64 j = e[i].Start; j <= e[i].End; ++j)
                    {
                        if (e[i].IsPrime(j)) ++c;
                    }
                }
                Debug.Assert(c == 9592);
            }
        }

        static internal void Test_ParallelPrimeCounter_a()
        {
            var p = new ParallelPrimeCounter();
            p.Init(1000, 10, 1);
            while (p.MoveNext()) ;
            Debug.Assert(p.Count == 168);
            p = new ParallelPrimeCounter();
            p.Init(100000, 100, 1);
            while (p.MoveNext()) ;
            Debug.Assert(p.Count == 9592);
            p = new ParallelPrimeCounter();
            p.Init(100000, 100, 100);
            while (p.MoveNext()) ;
            Debug.Assert(p.Count == 9592);
        }
    }
}
