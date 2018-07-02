using NUnit.Framework;

namespace GCDTest
{
    using System;
    using NUnit;
    using GCDLogic;



    [TestFixture]
    public class  GCDTest
    {
        [TestCase(12,4, ExpectedResult = 4)]
        [TestCase(56,2, ExpectedResult = 2)]
        [TestCase(-5,10, ExpectedResult = 5)]
        public int GCDTestNotBinary(int a, int b)
        {
            return GcdClass.FindGcd(a, b);
        }

        [TestCase(12, 4,3, ExpectedResult = 1)]
        [TestCase(56, 2,-2, ExpectedResult = 2)]
        [TestCase(-5, 10,-15, ExpectedResult = 5)]
        public int GCDTestNotBinary(int a, int b,int c)
        {
            return GcdClass.FindGcd(a, b,c);
        }

        [TestCase(1024,512,2048,4096,ExpectedResult = 512)]
        [TestCase(1025, 5 , 5001, 40, ExpectedResult = 1)]
        [TestCase(-20, -40, -240, 240, ExpectedResult = 20)]
        public int GCDTestNotBinary(params int[] array)
        {
            return GcdClass.FindGcd(array);
        }

        [TestCase(12, 4, ExpectedResult = 4)]
        [TestCase(56, 2, ExpectedResult = 2)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        public int GCDTestBinary(int a, int b)
        {
            return GcdClass.BinaryFindGcd(a, b);
        }

        [TestCase(12, 4, 3, ExpectedResult = 1)]
        [TestCase(56, 2, -2, ExpectedResult = 2)]
        [TestCase(-5, 10, -15, ExpectedResult = 5)]
        public int GCDTestBinary(int a, int b, int c)
        {
            return GcdClass.BinaryFindGcd(a, b, c);
        }

        [TestCase(1024, 512, 2048, 4096, ExpectedResult = 512)]
        [TestCase(1025, 5, 5001, 40, ExpectedResult = 1)]
        [TestCase(-20, -40, -240, 240, ExpectedResult = 20)]
        public int GCDTestBinary(params int[] array)
        {
            return GcdClass.BinaryFindGcd(array);
        }

    }
}
