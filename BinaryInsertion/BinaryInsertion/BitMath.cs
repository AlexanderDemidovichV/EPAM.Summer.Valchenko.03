using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryInsertion
{
    /// <summary>
    /// BitMath class provides basical bit operations.
    /// </summary>
    public static class BitMath
    {
        /// <summary>
        /// BitInsertion is the method which translate both integer numbers into binary form and then
        /// insert the first one into another one. You should specify insertion parameters 'i' ang 'j'.
        /// </summary>
        /// <param name="targetNumber">Number which service such as platform for insertion</param>
        /// <param name="insertNumber">Number which you want to insert into 'targetNumber'</param>
        /// <param name="i">Start index of insertion</param>
        /// <param name="j">End index of insertion</param>
        /// <returns>New integer which is obtained by inserting.</returns>
        public static int BitInsertion(int targetNumber, int insertNumber, int i, int j)
        {
            if ((i < 0 || j < 0) || (i > 31 || j > 31))
                throw new ArgumentException("Indexes can't be negative or more then 31.");

            if (targetNumber == 0 || insertNumber == 0)
                throw new ArgumentException("You can't insert zero number or insert into zero.");

            if (i >= j)
                throw new ArgumentException("Index i must be less then j.");

            if (Convert.ToString(targetNumber, 2).Length + Convert.ToString(insertNumber, 2).Length > 31)
                throw new ArgumentException("InsertNumber is so big. Bits from the targetNumber go out of bounds.");

            if ((j - i + Convert.ToString(targetNumber, 2).Length) > 31)
                throw new ArgumentException("Insertion range is so big. Bits from the targetNumber go out of bounds.");

            if ((j - i + 1) < Convert.ToString(insertNumber, 2).Length)
                throw new ArgumentException("Insertion range is too small for the insertNumber.");

            int[] bitTargerArray = Convert.ToString(targetNumber, 2).PadLeft(31, '0').Select(c => int.Parse(c.ToString())).ToArray();
            int[] bitInsertArray = Convert.ToString(insertNumber, 2).Select(c => int.Parse(c.ToString())).ToArray();

            for (int _i = i, _j = j, shift = j - i + 1; _i <= j; _j++, _i++)
                bitTargerArray[(bitTargerArray.Length + 1 - _j) - shift] = bitTargerArray[bitTargerArray.Length + 1 - _j];

            for (int _i = i, _j = j, shift = j - i + 1; _i <= j; _j++, _i++)
                bitTargerArray[bitTargerArray.Length + 1 - _j] = 0;

            for (int iter = bitInsertArray.Length - 1, _j = j; iter >= 0; _j++, iter--)
                bitTargerArray[bitTargerArray.Length + 1 - _j] = bitInsertArray[iter];

            return Convert.ToInt32(string.Join("", bitTargerArray), 2);
        }
    }
}
