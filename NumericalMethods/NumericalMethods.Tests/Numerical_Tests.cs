using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NumericalMethods.Numerical;

namespace NumericalMethods.Tests
{
    [TestClass]
    public class Numerical_Tests
    {
        [TestMethod]
        public void NthRootOfZeroExpectedZero()
        {
            int num = 0;
            int pow = 15;
            double e = 0.001;
            int firstApproach = 2;

            double res = NewtonMethod(num, pow, e, firstApproach);

            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void EvenNthRootOfNegativeNumberExpectedArgumentException()
        {
            int num = -15;
            int pow = 8;
            double e = 0.001;
            int firstApproach = 2;

            try
            {
                double res = NewtonMethod(num, pow, e, firstApproach);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("N-th root with even power and negative base doesn't exist.", ae.Message);
            }
        }

        [TestMethod]
        public void EvenNthRootOfPositiveNumberWithGivenAccuracyExpectedCorrectValue()
        {
            int num = 15;
            int pow = 6;
            double e = 0.0001;
            int firstApproach = 2;

            double res = NewtonMethod(num, pow, e, firstApproach);
            double standardRes = Math.Pow(num, 1.0 / pow);

            Assert.AreEqual(standardRes.ToString().Remove(e.ToString().Length), res.ToString().Remove(e.ToString().Length));
        }
    }
}
