using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cuppyzh.Exercise.TDD.Kata1
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input)
        {
            var numbers = input;

            string defaultDelimiter = ",";
            String[] delimiter = new String[] { defaultDelimiter };

            if (numbers.StartsWith("//"))
            {
                // Outter Field
                Regex regex = new Regex("(?<=//)(.*?)(?=\\n)");
                var matchResult = regex.Match(numbers);
                defaultDelimiter = matchResult.Value;

                if (defaultDelimiter.StartsWith("["))
                {
                    // Inner Field
                    Regex innerRegex = new Regex("(?<=\\[)(.*?)(?=\\])");
                    var innerMatchResult = innerRegex.Matches(defaultDelimiter);
                    delimiter = innerMatchResult.Select(result => result.Value).ToArray();

                    int numberStartIndex = numbers.IndexOf("\n") + 1;

                    numbers = numbers.Substring(numberStartIndex);

                } else
                {
                    delimiter = new String[] { defaultDelimiter };
                    numbers = numbers.Replace("//" + defaultDelimiter + "\n", "");
                }
            }

            numbers = numbers.Replace("\n", defaultDelimiter);

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<int> listOfNumber = numbers.Split(delimiter, int.MaxValue, StringSplitOptions.None).Select(element => int.Parse(element)).Where(element => element <= 1000).ToList();
            List<int> listOfNegativeNumber = listOfNumber.Where(element => element < 0).ToList();

            if (listOfNegativeNumber.Count > 0)
            {
                throw new Exception($"negatives not allowed: {string.Join(",", listOfNegativeNumber)}");
            }

            return listOfNumber.Sum(element => element);
        }
    }
}
