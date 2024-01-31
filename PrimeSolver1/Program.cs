using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSolver1
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Test.Test_Sqrt();
            //Test.Test_Range_a();
            //Test.Test_Range_b();

            //Test.Test_Eratosthenes1a();
            //Test.Test_Eratosthenes1b();
            //Test.Test_Eratosthenes2a();
            //Test.Test_Eratosthenes2b();
            //Test.Test_Eratosthenes2c();
            //Test.Test_ParallelPrimeCounter_a();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
