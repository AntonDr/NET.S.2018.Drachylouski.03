using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthRootLogic
{
    public static class FindNthRootClass
    {
        #region Public methods
        /// <summary>
        /// The method of searching for a root of the nth power for a real number
        /// with an indication of the accuracy
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="root">Exponent</param>
        /// <param name="accuracy">Accuracy</param>
        /// <returns>nth root</returns>
        public static double FindNthRoot(double number, int root, double accuracy)
        {
            Validate(number, root, accuracy);

            double previous = number / root;
            double next = (1.0 / root) * ((root - 1) * previous + number / Math.Pow(previous, root - 1));

            while (Math.Abs(next - previous) > accuracy)
            {
                previous = next;
                next = (1.0 / root) * ((root - 1) * previous + number / Math.Pow(previous, root - 1));
            }

            return next;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Data validation
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="root">Exponent</param>
        /// <param name="accuracy">Accuracy</param>
        private static void Validate(double number, int root, double accuracy)
        {
            if (root < 1)
            {
                throw new ArgumentException($"The {nameof(root)} exponent must be greater than 1");
            }

            if (root % 2 == 0 && number < 0)
            {
                throw new ArgumentException($"It is impossible to extract a {nameof(root)} of even degree from a negative  {nameof(number)}");
            }

            if (accuracy < 0)
            {
                throw new ArgumentException($"{nameof(accuracy)} can not be less than 0");
            }
        } 
        #endregion
    }
}
