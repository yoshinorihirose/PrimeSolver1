using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSolver1
{
    internal class Helper
    {
        static internal Int64 Sqrt(Int64 n)
        {
            Int64 s1, s0;

            if (n >= (1L << 62) || n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            {
                Int64 tmp_n = n >> 2;
                Int64 min = 1L;
                for (; tmp_n != 0L; tmp_n >>= 2) min <<= 1;
                s1 = (min << 1) - 1;
            }

            do
            {
                s0 = s1;
                s1 = (s0 + n / s0) >> 1;
            } while (s1 < s0);

            return s0;
        }
    }
}
