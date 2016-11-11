using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = Math.Sin(10) + 2;
            Console.WriteLine(r);
            Console.WriteLine(EquationV2.Compute("Sin(10)+2"));
            Console.ReadKey();
        }
    }
}
