using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidianMath
{
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
            int d = GCD(a, b);
            return GCD(d, c);
        }

        public static int GCD(params int[] arr)
        {
            int res = 0;

            if (arr.Length >= 2)
            {
                if (arr.Length == 2)
                    return GCD(arr[0], arr[1]);

                res = GCD(arr[0], arr[1]);

                for (int i = 2; i < arr.Length; i++)
                {
                    res = GCD(res, arr[i]);
                }
            }
            else
                throw new ArgumentException("The number of parameters must be greater than one.");

            return res;
        }
    }
}
