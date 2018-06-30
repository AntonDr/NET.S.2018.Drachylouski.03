namespace NUnitNthRootTest
{
    using System;

    using NUnit.Framework;

    using NthRootLogic;

    [TestFixture]
    public class FindNthRootTest
    {
        [TestCase(1, 5, 0.0001,  1)]
        [TestCase(8, 3, 0.0001,  2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001,0.45)]
        [TestCase(8, 3, 0.0001,  2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1,  0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRootTestCase(double a, int n, double eps, double expected)
        {
            double actual = FindNthRootClass.FindNthRoot(a, n, eps);
            Assert.AreEqual(actual,expected,eps);
        }

        [TestCase(-0.01,2,0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRoot_ThrowArgumentException(double a, int n, double eps)
        {
           Assert.Throws<ArgumentException>(()=>FindNthRootClass.FindNthRoot(a, n, eps));

        }

    }

}