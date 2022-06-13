using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuppyzh.Exercise.TDD.Kata1
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            string delimiter = ",";

            if (numbers.StartsWith("//"))
            {
                delimiter = numbers[2].ToString();
                numbers = numbers.Substring(4);
            }

            numbers = numbers.Replace("\n", delimiter);

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<int> listOfNumber = numbers.Split(delimiter).Select(element => int.Parse(element)).ToList();
            List<int> listOfNegativeNumber = listOfNumber.Where(element => element < 0).ToList();

            if(listOfNegativeNumber.Count > 0)
            {
                throw new Exception($"negatives not allowed: {string.Join(",", listOfNegativeNumber)}");
            }

            return listOfNumber.Sum(element => element);
        }
    }
}
