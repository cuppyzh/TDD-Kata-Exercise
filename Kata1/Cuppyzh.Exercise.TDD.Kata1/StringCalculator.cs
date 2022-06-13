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
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<int> listOfNumber = numbers.Split(',').Select(element => int.Parse(element)).ToList();

            return listOfNumber.Sum(element => element);
        }
    }
}
