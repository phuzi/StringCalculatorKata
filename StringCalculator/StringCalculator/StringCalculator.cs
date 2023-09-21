using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    /// <summary>
    /// String Calculator
    /// </summary>
    public class StringCalculator
    {
        private const string SingleCaptureGroupName = "single";
        private const string MultiCaptureGroupName = "multi";

        private static readonly string[] _delimiters = new[] { ",", "\n" };
        private static readonly Regex _customDelimiterRegex = new($@"^//((?<delimiters>.)|(\[(?<delimiters>.)\])+|\[(?<delimiters>.+)\])\n");

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

            var numbers = GetNumbers(expression);

            AssertNoNegatives(numbers);

            return numbers
                .Where(n => n <= 1_000)
                .Sum();
        }

        private static IEnumerable<int> GetNumbers(string expression)
        {
            var delimiters = _delimiters;

            var match = _customDelimiterRegex.Match(expression);

            if (match.Success)
            {
                var matchedDelimiters = match.Groups["delimiters"].Captures.Select(x=> x.Value).ToArray();
                if (matchedDelimiters.Any()) 
                {
                    delimiters = matchedDelimiters;
                    expression = expression[match.Length..];
                }
            }

            return ParseNumbers(expression, delimiters);
        }

        private static IEnumerable<int> ParseNumbers(string expression, string[] delimiters)
        {
            return expression
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse);
        }

        private static void AssertNoNegatives(IEnumerable<int> numbers)
        {
            var negatives = numbers.Where(n => n < 0);

            if (negatives.Any())
            {
                throw new Exception($"Negatives not allowed: {string.Join(',', negatives)}");
            }
        }
    }
}
