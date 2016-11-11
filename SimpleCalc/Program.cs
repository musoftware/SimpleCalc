using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = Math.BigMul(1, 2) + 2;
            Console.WriteLine(r);
            Console.WriteLine(EquationV2.Compute("BigMul(1,2)+2"));
            Console.ReadKey();
        }
    }
}
