using System;
using NUnit.Framework;
using static BinaryInsertion.BitMath;

namespace BinaryInsertion.Tests
{
    [TestFixture]
    public class BitMath_Tests
    {
        [TestCase(5, 3, 0, 2, TestName = "BitInsertion3into5", ExpectedResult = 43, Description = "Insert 3 into 5 using binary presentation")]
        [TestCase(0, 5, 0, 2, TestName = "BitInsertionIntegerIntoZero", ExpectedException = typeof(ArgumentException), Description = "Insert 5 into 0")]
        [TestCase(5, 0, 0, 2, TestName = "BitInsertionZeroIntoInteger", ExpectedException = typeof(ArgumentException), Description = "Insert 0 into 5")]
        [TestCase(5, 1, 0, 2, TestName = "BitInsertion1Into5", ExpectedResult = 41, Description = "Insert 1 into 5")]
        public int BinaryInsertionForTwoIntegers(int targetNumber, int insertNumber, int iStart, int jEnd)
        {
            return BitInsertion(targetNumber, insertNumber, iStart, jEnd);
        }
    }
}
