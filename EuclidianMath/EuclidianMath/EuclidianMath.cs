using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EuclidianMath
{
    #region standard GCD methods
    public static class EuclidianMath
    {
        public static int GCD(int a, int b)
        {
            int helper;

            while (b != 0)
            {
                helper = b;
                b = a % b;
                a = helper;
            }
            return a;
        }

        public static int GCD(int a, int b, int c)
        {
            return GCD(GCD(a, b), c);
        }

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

        #region overload GCD methods with timers 
        public static int GCD(int a, int b, out long elapsedMilliseconds)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

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
        public static int BinaryGCD(int a, int b)
        {
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

        public static int BinaryGCD(int a, int b, int c)
        {
            return BinaryGCD(BinaryGCD(a, b) ,c);
        }

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

        #region overload Binary GCD methods with timers
        public static int BinaryGCD(int a, int b, out long elapsedMilliseconds)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

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
