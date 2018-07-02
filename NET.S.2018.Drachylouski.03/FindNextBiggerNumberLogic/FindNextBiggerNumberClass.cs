using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodsOfSort;

namespace FindNextBiggerNumberLogic
{
    public static class FindNextBiggerNumberClass
    {
        #region Public methods

        /// <summary>
        /// Finds the execution time of the method for a given number
        /// </summary>
        /// <param name="number">Source positive number</param>
        /// <returns>Execution time as a string</returns>
        public static string ExecutionTimeForFindNextBiggerNumber(int number)
        {
            var sw = new Stopwatch();

            sw.Start();

            FindNextBiggerNumber(number);

            sw.Stop();

            return sw.ElapsedMilliseconds.ToString();
        }

        /// <summary>
        /// The FindNextBiggerNumber method takes a positive integer
        /// and returns the nearest largest integer
        /// consisting of the digits of the original number, and null (or -1) if such a number does not exist.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <param name="number">Source positive number</param>
        /// <returns>The required number or null, if none is found</returns>
        public static int? FindNextBiggerNumber(int number)
        {

            Validate(number);

            int n = LengthOfNumber(number);

            if (n < 2)
            {
                return null;
            }

            int[] array = NumberToArray(number);

            array = array.Reverse().ToArray();

            return (FindNextBiggerNumber(array) > 0) ? FindNextBiggerNumber(array) : (int?) null;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Finds the length of a given number
        /// </summary>
        /// <param name="number">Souce number</param>
        /// <returns>Length</returns>
        private static int LengthOfNumber(int number)
        {
            int k = 0;

            while (number != 0)
            {
                k++;

                number /= 10;
            }

            return k;
        }

        /// <summary>
        /// Finds the index of the maximum element in the array from a given position
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="from">Position</param>
        /// <returns>Index of max element</returns>
        private static int FindIndexOfMax(int[] array, int from = 0)
        {
            Validate(array);

            int max = array[from];

            int index = from;

            for (int i = from; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    index = i;
                    max = array[i];
                }
            }

            return index;
        }

        /// <summary>
        /// An overloaded version of the public method
        /// </summary>
        /// <param name="array">Source array</param>
        /// <returns>The required number or zero, if none is found</returns>
        private static int FindNextBiggerNumber(int[] array)
        {
            Validate(array);

            int sourceNumber = array.ArrayToNumber();

            int indexTemp = FindIndexOfMax(array, 1);

            Swap(ref array[indexTemp], ref array[indexTemp - 1]);

            int min = array.ArrayToNumber();

            Swap(ref array[indexTemp], ref array[indexTemp - 1]);

            int minIndex = 0;

            int[] minArray = new int[array.Length];

            for (int i = 0, k = 1; i < array.Length - 1; i++, k++)
            {
                int index = FindIndexOfMax(array, k);

                Swap(ref array[index], ref array[index - 1]);

                int temp = array.ArrayToNumber();

                if (temp <= min && temp > sourceNumber)
                {
                    minIndex = index;
                    min = temp;
                    Array.Copy(array, minArray, array.Length);
                }

                Swap(ref array[index], ref array[index - 1]);
            }

            if (minIndex == minArray.Length - 1)
            {
                return minArray.ArrayToNumber();
            }
            else
            {
                MethodsOfSorting.QuickSort(minArray, minIndex, minArray.Length - 1);

                return minArray.ArrayToNumber();
            }


        }

        /// <summary>
        /// Splits a number into an array of digits
        /// </summary>
        /// <param name="number">Souce positive number</param>
        /// <returns>Array of digits</returns>
        private static int[] NumberToArray(int number)
        {
            Validate(number);

            int[] array = new int[LengthOfNumber(number)];

            int k = 0;

            while (number != 0)
            {
                array[k++] = number % 10;

                number /= 10;
            }

            return array;
        }

        /// <summary>
        /// Сhanges the values of two numbers among themselves
        /// </summary>
        /// <param name="a">a->b</param>
        /// <param name="b">b->a</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Finds a number consisting of array elements
        /// </summary>
        /// <param name="array">Source array</param>
        /// <returns>Number</returns>
        private static int ArrayToNumber(this int[] array)
        {
            Validate(array);

            int p = 1;
            int sum = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                sum += array[i] * p;

                p *= 10;
            }

            return sum;
        }

        /// <summary>
        /// Data validation
        ///Throw ArgumentOutOfRangeException,if the number is less than or equal to zero
        /// </summary>
        /// <param name="number">Source number</param>
        private static void Validate(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(number)} need to be positive");
            }
        }


        /// <summary>
        /// Data validation
        /// Throw ArgumentNullException,if array is equal to null.
        /// Throw ArgumentNullException , if array.Length is equal to zero;
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

        }

        #endregion
    }
}