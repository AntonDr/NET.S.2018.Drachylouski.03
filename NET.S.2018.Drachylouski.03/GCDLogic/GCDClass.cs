using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDLogic
{
    public static class GcdClass
    {
        /// <summary>
        /// Finds a GCD by the euclidean algorithm for two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>GCD</returns>
        public static (int,long) FindGcd(int a, int b,Func<int,int,int> gcdAlgorithm)
        {
            Validate(a, b);

            var sw = new Stopwatch();

            sw.Start();

            int gcd = gcdAlgorithm(a,b);

            sw.Stop();

            return  (gcd,sw.ElapsedMilliseconds);

        }

        /// <summary>
        /// Finds a GCD by the euclidean algorithm for three numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>GCD</returns>
        public static (int,long) FindGcd(int a, int b, int c, Func<int, int, int> gcdAlgorithm)
        {
            Validate(a, b, c);

            var sw = new Stopwatch();

            sw.Start();

            int gcd = gcdAlgorithm(gcdAlgorithm(a, b), c);

            sw.Stop();

            return (gcd, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Finds a GCD by the euclidean algorithm for more than three numbers
        /// </summary>
        /// <param name="array">Source array</param>
        /// <returns>GCD</returns>
        public static (int,long) FindGcd(Func<int, int, int> gcdAlgorithm, params int[] array)
        {
            Validate(array);

            var sw = new Stopwatch();

            sw.Start();

            List<int> list = new List<int>();

            while (list.Count != 1)
            {
                list.Clear();

                for (int i = 0; i < array.Length - 1; i++)
                {
                    list.Add(gcdAlgorithm(array[i], array[i + 1]));
                }

                array = list.ToArray();
            }

            sw.Stop();

            return (list[0],sw.ElapsedMilliseconds);
        }

        #region Private methods
        /// <summary>
        /// Euclidean algorithm for searching GCD
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>GDC</returns>
        private static int EuclideanAlgorithm(int a, int b)
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
        private static int BinaryEuclideanAlgorithm(int a, int b)
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

        /// <summary>
        /// Data validation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Validate(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                throw new ArgumentException("To find gcd, no parameter can be equal to zero");
            }
        }

        /// <summary>
        /// Data validation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        private static void Validate(int a, int b, int c)
        {
            if (a == 0 || b == 0 || c == 0)
            {
                throw new ArgumentException("To find gcd, no parameter can be equal to zero");
            }
        }

        /// <summary>
        /// Data validation
        /// </summary>
        /// <param name="array"></param>
        private static void Validate(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    throw new ArgumentException("To find gcd, no parameter can be equal to zero");
                }
            }
        } 
        #endregion
    }
}
