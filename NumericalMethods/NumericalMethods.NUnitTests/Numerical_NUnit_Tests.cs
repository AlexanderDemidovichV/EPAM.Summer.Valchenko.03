using System;
using NUnit.Framework;
using static NumericalMethods.Numerical;

namespace NumericalMethods.NUnitTests
{
    [TestFixture]
    public class Numerical_NUnit_Tests
    {
        [TestCase(4, 2, TestName = "GCDOfTwoPositiveNumbers", ExpectedResult = 2, Description = "GCD of two numbers.")]
        [TestCase(5, 7, TestName = "GCDOfTwoRelativelyPrimeNumbers", ExpectedResult = 1, Description = "GCD of two numbers.")]
        [TestCase(-5, 10, TestName = "GCDOfOnePositiveAndOneNegative", ExpectedResult = 5, Description = "GCD of two numbers which one of them is negative.")]
        [TestCase(0, 10, TestName = "GCDOfZeroAndPositiveNumber", ExpectedResult = 10, Description = "GCD of two numbers which one of them is zero.")]
        [TestCase(0, 0, TestName = "GCDOfTwoZeros", ExpectedException = typeof(ArgumentException), Description = "GCD of two zeros.")]
        public int GCDOfTwoNumbers(int arg1, int arg2)
        {
            return GCD(arg1, arg2);
        }

        public int GCDOfThreeNumbers(int arg1, int arg2, int arg3)
        {
            return GCD(arg1, arg2);
        }
    }
}
