using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
             
            Equation ex = new SimpleCalc.Equation(10);
            ex.Add(10).Multiply(5).Div(2);

            Console.WriteLine(ex.Solve());

            20 * 5 = 100 = 50

            Console.WriteLine(10 + 10 * 5 / 2);

            Console.ReadKey();
        }
    }
}
