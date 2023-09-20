using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    /// <summary>
    /// String Calculator
    /// </summary>
    public class StringCalculator
    {
        private static readonly char _delimiter = ',';

        /// <summary>
        /// Add numbers in a string
        /// </summary>
        /// <param name="expression">The expression to parse numbers from and add together.</param>
        /// <returns></returns>
        public static int Add(string expression)
        {
            var sum = 0;

            if (string.IsNullOrEmpty(expression))
            {
                return sum;
            }

            var numbers = expression.Split(_delimiter);
            foreach ( var number in numbers)
            {
                var value = int.Parse(number);
                sum += value;
            }

            return sum;
        }
    }
}
