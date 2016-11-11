using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SimpleCalc
{
    public class Equation
    {
        private double value = 0;
        private string function = "";
        private Equation linedTo { get; set; }
        private Equation _parent { get; set; }

    
        public Equation(double value)
        {
            this.value = value;
        }

        public Equation(double value, string function) : this(value)
        {
            this.function = function;
        }

        public Equation Multiply(double x)
        {
            linedTo = new SimpleCalc.Equation(x);
            linedTo._parent = this;
            function = "*";
            return linedTo;
        }

        public Equation Div(double x)
        {
            linedTo = new SimpleCalc.Equation(x);
            linedTo._parent = this;
            function = "/";
            return linedTo;
        }

        public Equation Add(double x)
        {
            linedTo = new SimpleCalc.Equation(x);
            linedTo._parent = this;
            function = "+";
            return linedTo;
        }
        public Equation Subtact(double x)
        {
            linedTo = new SimpleCalc.Equation(x);
            linedTo._parent = this;
            function = "-";
            return linedTo;
        }

        public void DoMath(Equation tmp, string chars = "+-*/")
        {
            Equation tmp2 = null;
            while (tmp != null)
            {
                tmp2 = tmp.linedTo;
                if (tmp2 != null && ((from char chr in chars.ToCharArray() select chr.ToString()).Contains(tmp.function)))
                {
                    tmp.value = ProcessByFunction(tmp.function, tmp.value, tmp2.value);
                    tmp.linedTo = tmp2.linedTo;
                    tmp.function = tmp2.function;
                }
                else if (tmp2 == null)
                {
                    break;
                }
                else
                {
                    tmp = tmp2;
                }
            }
        }



        public double Solve()
        {
            DoMath(this, "*/");
            DoMath(this, "+-");

            return this.value;
        }

        private double ProcessByFunction(string function, double x, double y)
        {
            switch (function)
            {
                case "+":
                    return x + y;
                case "-":
                    return x - y;
                case "*":
                    return x * y;
                case "/":
                    return x / y;
            }
            return 0;
        }
    }
}
