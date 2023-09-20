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

            var delimiters = _delimiters;

            if (expression.StartsWith("//"))
            {
                delimiters = new[] { expression[2] };
                expression = expression[4..];
            }

            var numbers = expression
                .Split(delimiters)
                .Select(int.Parse);

            var negatives = numbers.Where(n => n < 0);

            if (negatives.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(',', negatives)}");
            }

            return numbers
                .Sum();
        }
    }
}
