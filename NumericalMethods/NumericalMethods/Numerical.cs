using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NumericalMethods
{
    public static class Numerical
    {
        #region Newton's method
        /// <summary>
        /// Newton's method is a method for finding successively better approximations to the roots of a real-valued function
        /// </summary>
        /// <param name="number">Radicand</param>
        /// <param name="power">Degree of the root</param>
        /// <param name="accuracy">Digit accuracy</param>
        /// <param name="firstAproach">The initial value</param>
        /// <returns>N-th root of a number</returns>
        static double NewtonMethod(double number, int power, double accuracy, double firstAproach)
        {
            if (number != 0)
            {
                if (accuracy < 0.0 || accuracy >= 1.0)
                    throw new ArgumentException("Accuracy must be greater than 0 and less than 1.");

                double x = firstAproach;

                while (true)
                {
                    double f = Math.Pow(x, power) - number;

                    if (Math.Abs(f) < accuracy)
                        break;

                    x += -f / (power * Math.Pow(x, power - 1));
                }

                return x;
            }
            else
                return 0;
        }
        #endregion

        #region GCD methods
        /// <summary>
        /// GCD is an efficient method for computing the greatest common divisor of two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Return greatest common divisor of 'a' and 'b'</returns>
        public static int GCD(int a, int b)
        {
            if (a != 0 && b != 0)
            {
                if (a < 0)
                    a = -a;

                if (b < 0)
                    b = -b;

                if (a == 0)
                    return b;

                if (b == 0)
                    return a;

                int helper;

                while (b != 0)
                {
                    helper = b;
                    b = a % b;
                    a = helper;
                }
                return a;
            }
            else
                throw new ArgumentException("Both numbers can't be equal to zero.");
        }

        /// <summary>
        /// GCD is an efficient method for computing the greatest common divisor of three numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <returns>Return greatest common divisor of 'a', 'b' and 'c'</returns>
        public static int GCD(int a, int b, int c)
        {
            return GCD(GCD(a, b), c);
        }

        /// <summary>
        /// GCD is an efficient method for computing the greatest common divisor of array of numbers
        /// </summary>
        /// <param name="arr">Array of numbers</param>
        /// <returns>Return greatest common divisor of all numbers in array</returns>
        public static int GCD(params int[] arr)
        {
            if (arr.Length >= 2)
            {
                int res = GCD(arr[0], arr[1]);

                if (arr.Length == 2)
                    return res;

                for (int i = 2; i < arr.Length; i++)
                    res = GCD(res, arr[i]);

                return res;
            }
            else
                throw new ArgumentException("The number of parameters must be greater than one.");
        }
        #endregion

        #region GCD with timers
        /// <summary>
        /// GCD is an efficient method for computing the greatest common divisor of two numbers. This method can also compute time of evaluation using out parameter named 'elapsedMilliseconds'  
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="elapsedMilliseconds">Time of computing</param>
        /// <returns>Return greatest common divisor of two numbers</returns>
        public static int GCD(int a, int b, out long elapsedMilliseconds)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (a != 0 && b != 0)
            {
                if (a < 0)
                    a = -a;

                if (b < 0)
                    b = -b;

                if (a == 0)
                {
                    stopWatch.Stop();
                    elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

                    return b;
                }

                if (b == 0)
                {
                    stopWatch.Stop();
                    elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

                    return a;
                }
                    
                int helper;

                while (b != 0)
                {
                    helper = b;
                    b = a % b;
                    a = helper;
                }

                stopWatch.Stop();
                elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

                return a;
            }
            else
                throw new ArgumentException("Both numbers can't be equal to zero.");
        }

        /// <summary>
        /// GCD is an efficient method for computing the greatest common divisor of three numbers. This method can also compute time of evaluation using out parameter named 'elapsedMilliseconds'  
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <param name="elapsedMilliseconds">Time of computing</param>
        /// <returns>Return greatest common divisor of three numbers</returns>
        public static int GCD(int a, int b, int c, out long elapsedMilliseconds)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int d = GCD(a, b);
            int res = GCD(d, c);

            stopWatch.Stop();
            elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

            return res;
        }

        /// <summary>
        /// GCD is an efficient method for computing the greatest common divisor of array of numbers. This method can also compute time of evaluation using out parameter named 'elapsedMilliseconds'  
        /// </summary>
        /// <param name="arr">Array of numbers</param>
        /// <param name="elapsedMilliseconds">Time of computing</param>
        /// <returns>Return greatest common divisor of all numbers in array</returns>
        public static int GCD(out long elapsedMilliseconds, params int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (arr.Length >= 2)
            {
                int res = GCD(arr[0], arr[1]);

                if (arr.Length == 2)
                {
                    stopWatch.Stop();
                    elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

                    return res;
                }

                for (int i = 2; i < arr.Length; i++)
                    res = GCD(res, arr[i]);

                stopWatch.Stop();
                elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

                return res;
            }
            else
                throw new ArgumentException("The number of parameters must be greater than one.");
        }
        #endregion

        #region Binary GCD methods
        /// <summary>
        /// Binary GCD is the method for computing the greatest common divisor of two numbers. Binary GCD uses simpler arithmetic operations than the conventional Euclidean algorithm.  
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second Number</param>
        /// <returns>Return greatest common divisor of two numbers</returns>
        public static int BinaryGCD(int a, int b)
        {
            if (a != 0 && b != 0)
            {
                if (a < 0)
                    a = -a;

                if (b < 0)
                    b = -b;

                int k = 1;

                while (a != 0 && b != 0)
                {
                    while (a % 2 == 0 && b % 2 == 0)
                    {
                        a /= 2;
                        b /= 2;
                        k *= 2;
                    }

                    if (a % 2 == 0 && b % 2 != 0)
                        while (a % 2 == 0)
                            a /= 2;

                    if (b % 2 == 0 && a % 2 != 0)
                        while (b % 2 == 0)
                            b /= 2;

                    if (a >= b)
                        a -= b;
                    else
                        b -= a;
                }

                return b * k;
            }
            else
                throw new ArgumentException("Both numbers can't be equal to zero.");
        }

        /// <summary>
        /// Binary GCD is the method for computing the greatest common divisor of three numbers. Binary GCD uses simpler arithmetic operations than the conventional Euclidean algorithm.  
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second Number</param>
        /// <param name="c">Third Number</param>
        /// <returns>Return greatest common divisor of three numbers</returns>
        public static int BinaryGCD(int a, int b, int c)
        {
            return BinaryGCD(BinaryGCD(a, b), c);
        }

        /// <summary>
        /// Binary GCD is the method for computing the greatest common divisor of array of numbers. Binary GCD uses simpler arithmetic operations than the conventional Euclidean algorithm.  
        /// </summary>
        /// <param name="arr">Array of numbers</param>
        /// <returns>Return greatest common divisor of all numbers in array</returns>
        public static int BinaryGCD(params int[] arr)
        {
            if (arr.Length >= 2)
            {
                int res = BinaryGCD(arr[0], arr[1]);

                if (arr.Length == 2)
                    return res;

                for (int i = 2; i < arr.Length; i++)
                    res = BinaryGCD(res, arr[i]);

                return res;
            }
            else
                throw new ArgumentException("The number of parameters must be greater than one.");
        }
        #endregion

        #region Binary GCD with timers
        /// <summary>
        /// Binary GCD is the method for computing the greatest common divisor of two numbers. 
        /// Binary GCD uses simpler arithmetic operations than the conventional Euclidean algorithm. 
        /// This method can also compute time of evaluation using out parameter named 'elapsedMilliseconds'
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second Number</param>
        /// <param name="elapsedMilliseconds">Time of computing</param>
        /// <returns>Return greatest common divisor of two numbers</returns>
        public static int BinaryGCD(int a, int b, out long elapsedMilliseconds)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (a != 0 && b != 0)
            {
                if (a < 0)
                    a = -a;

                if (b < 0)
                    b = -b;

                int k = 1;

                while (a != 0 && b != 0)
                {
                    while (a % 2 == 0 && b % 2 == 0)
                    {
                        a /= 2;
                        b /= 2;
                        k *= 2;
                    }

                    if (a % 2 == 0 && b % 2 != 0)
                        while (a % 2 == 0)
                            a /= 2;

                    if (b % 2 == 0 && a % 2 != 0)
                        while (b % 2 == 0)
                            b /= 2;

                    if (a >= b)
                        a -= b;
                    else
                        b -= a;
                }

                stopWatch.Stop();
                elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

                return b * k;
            }
            else
                throw new ArgumentException("Both numbers can't be equal to zero.");
        }

        /// <summary>
        /// Binary GCD is the method for computing the greatest common divisor of three numbers. 
        /// Binary GCD uses simpler arithmetic operations than the conventional Euclidean algorithm. 
        /// This method can also compute time of evaluation using out parameter named 'elapsedMilliseconds'
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second Number</param>
        /// <param name="c">Third Number</param>
        /// <param name="elapsedMilliseconds">Time of computing</param>
        /// <returns>Return greatest common divisor of two numbers</returns>
        public static int BinaryGCD(int a, int b, int c, out long elapsedMilliseconds)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int d = BinaryGCD(a, b);
            int res = BinaryGCD(d, c);

            stopWatch.Stop();
            elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

            return res;
        }

        /// <summary>
        /// Binary GCD is the method for computing the greatest common divisor of all numbers in array. 
        /// Binary GCD uses simpler arithmetic operations than the conventional Euclidean algorithm. 
        /// This method can also compute time of evaluation using out parameter named 'elapsedMilliseconds'
        /// </summary>
        /// <param name="arr">Array of numbers</param>
        /// <param name="elapsedMilliseconds">Time of computing</param>
        /// <returns>Return greatest common divisor of all numbers in array</returns>
        public static int BinaryGCD(out long elapsedMilliseconds, params int[] arr)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            if (arr.Length >= 2)
            {
                int res = BinaryGCD(arr[0], arr[1]);

                if (arr.Length == 2)
                {
                    stopWatch.Stop();
                    elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

                    return res;
                }
                    

                for (int i = 2; i < arr.Length; i++)
                    res = BinaryGCD(res, arr[i]);

                stopWatch.Stop();
                elapsedMilliseconds = stopWatch.ElapsedMilliseconds;

                return res;
            }
            else
                throw new ArgumentException("The number of parameters must be greater than one.");
        } 
        #endregion
    }
}
