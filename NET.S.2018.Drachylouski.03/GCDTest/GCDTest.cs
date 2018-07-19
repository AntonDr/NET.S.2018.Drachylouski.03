using NUnit.Framework;

namespace GCDTest
{
    using System;
    using NUnit;
    using GCDLogic;
    using static System.ValueTuple;


    [TestFixture]
    public class  GCDTest
    {
        [TestCase(12,4, ExpectedResult = 4)]
        [TestCase(56,2, ExpectedResult = 2)]
        [TestCase(-5,10, ExpectedResult = 5)]
        public int GCDTestNotBinary(int a, int b)
        {
            var result = GcdClass.FindGcd(a, b,EuclideanAlgorithm);
            return result.Item1;

        }

        [TestCase(12, 4,3, ExpectedResult = 1)]
        [TestCase(56, 2,-2, ExpectedResult = 2)]
        [TestCase(-5, 10,-15, ExpectedResult = 5)]
        public int GCDTestNotBinary(int a, int b,int c)
        {
            var result = GcdClass.FindGcd(a, b, c,EuclideanAlgorithm);
            return result.Item1;
        }

        [TestCase(1024,512,2048,4096,ExpectedResult = 512)]
        [TestCase(1025, 5 , 5001, 40, ExpectedResult = 1)]
        [TestCase(-20, -40, -240, 240, ExpectedResult = 20)]
        public int GCDTestNotBinary(params int[] array)
        {
            var result = GcdClass.FindGcd(EuclideanAlgorithm,array);
            return result.Item1;
        }

        [TestCase(12, 4, ExpectedResult = 4)]
        [TestCase(56, 2, ExpectedResult = 2)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        public int GCDTestBinary(int a, int b)
        {
            return GcdClass.FindGcd(a, b,BinaryEuclideanAlgorithm).Item1;
        }

        [TestCase(12, 4, 3, ExpectedResult = 1)]
        [TestCase(56, 2, -2, ExpectedResult = 2)]
        [TestCase(-5, 10, -15, ExpectedResult = 5)]
        public int GCDTestBinary(int a, int b, int c)
        {
            return GcdClass.FindGcd(a, b,c, BinaryEuclideanAlgorithm).Item1;
        }

        [TestCase(1024, 512, 2048, 4096, ExpectedResult = 512)]
        [TestCase(1025, 5, 5001, 40, ExpectedResult = 1)]
        [TestCase(-20, -40, -240, 240, ExpectedResult = 20)]
        public int GCDTestBinary(params int[] array)
        {
            return GcdClass.FindGcd(BinaryEuclideanAlgorithm,array).Item1;
        }

        public static int EuclideanAlgorithm(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }

        /// <summary>
        /// Binary euclidean algorithm for searching GCD
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>GDC</returns>
        public static int BinaryEuclideanAlgorithm(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);


            int shift;

            if (a == 0)
            {
                return b;
            }

            if (b == 0)

            {
                return a;
            }

            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    int t = b;
                    b = a;
                    a = t;
                }

                b = b - a;
            } while (b != 0);

            return a << shift;
        }

    }
}
