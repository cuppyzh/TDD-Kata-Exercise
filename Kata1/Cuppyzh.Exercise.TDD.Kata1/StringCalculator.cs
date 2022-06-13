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

            string delimiter = ",";

            if (numbers.StartsWith("//"))
            {
                Regex regex = new Regex("(?<=//)(.*?)(?=\\n)");
                var matchResult = regex.Match(numbers);
                delimiter = matchResult.Value;

                numbers = numbers.Replace("//" + delimiter + "\n", "");
            }

            numbers = numbers.Replace("\n", delimiter);

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<int> listOfNumber = numbers.Split(delimiter).Select(element => int.Parse(element)).Where(element => element <= 1000).ToList();
            List<int> listOfNegativeNumber = listOfNumber.Where(element => element < 0).ToList();

            if(listOfNegativeNumber.Count > 0)
            {
                throw new Exception($"negatives not allowed: {string.Join(",", listOfNegativeNumber)}");
            }

            return listOfNumber.Sum(element => element);
        }
    }
}
