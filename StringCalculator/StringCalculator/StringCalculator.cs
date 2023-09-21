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
        private static readonly char[] _delimiters = new[] { ',', '\n' };

        /// <summary>
        /// Add numbers in a string
        /// </summary>
        /// <param name="expression">The expression to parse numbers from and add together.</param>
        /// <returns></returns>
        public static int Add(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return 0;
            }

            return expression
                .Split(_delimiters)
                .Select(int.Parse)
                .Sum();
        }
    }
}
