using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MathServer : IMathService
    {
        public double Add(double firstValue, double secondValue)
        {
            return firstValue + secondValue;
        }

        public double Div(double firstValue, double secondValue)
        {
            if (secondValue == 0)
            {
                Console.WriteLine("DivideByZeroException");
                return 0;
            }
            return firstValue / secondValue;
        }

        public double Mult(double firstValue, double secondValue)
        {
            return firstValue * secondValue;
        }

        public double Sub(double firstValue, double secondValue)
        {
            return firstValue - secondValue;
        }
    }
}
