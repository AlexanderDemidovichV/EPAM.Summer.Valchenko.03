using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int num = 15;
            int power = 8;
            double e = 0.0000015;
            double firstAproach = num / power;

            Console.WriteLine("Number: {0}, Root power: {1}, Accuracy: {2}, First aproach: {3}", num, power, e, firstAproach);
            Console.WriteLine("Newton method: {0}", NewtonMethod(num, power, e, firstAproach));
            Console.WriteLine("Math.Pow: {0}", Math.Pow(num, 1/power));

            Console.WriteLine("\nTap to continue...");
            Console.ReadKey(true);
        }

        static double NewtonMethod(int number, int power, double accuracy, double firstAproach)
        {
            double x = firstAproach;

            while(true)
            {
                double f = Math.Pow(x, power) - number;

                if (Math.Abs(f) < accuracy) 
                    break;

                x += -f / (power * Math.Pow(x, power - 1));
            }

            return x;
        }
    }
}
