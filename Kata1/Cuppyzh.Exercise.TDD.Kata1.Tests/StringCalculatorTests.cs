using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cuppyzh.Exercise.TDD.Kata1.Tests
{
    public class StringCalculatorTests
    {
        private readonly IStringCalculator stringCalculator = new StringCalculator();

        [Theory]
        [InlineData("", 0)]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("129", 129)]
        [InlineData("12", 12)]
        [InlineData("1,4", 5)]
        [InlineData("0,2", 2)]
        [InlineData("1\n2,3\n2", 8)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2", 3)]
        public void Add_Tests(string testCase, int expectedResult)
        {
            var result = stringCalculator.Add(testCase);

            Assert.Equal(expectedResult, result);
        }
    }
}
