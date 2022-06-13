using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [InlineData("1\n2,3,2000", 6)]
        [InlineData("1\n2,4000", 3)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//-\n1-2", 3)]
        [InlineData("//;\n1;2;4\n5", 12)]
        [InlineData("//;\n1;2;4\n5;1001", 12)]
        [InlineData("//;\n1;2;4\n5;1000", 1012)]
        [InlineData("//[;;]\n1;;2", 3)]
        [InlineData("//[--]\n1--4", 5)]
        [InlineData("//[*][%]\n1*2%3", 6)]
        [InlineData("//[**][%%]\n1**2%%3", 6)]
        public void Add_Tests_Success_ReturnExpectedResult(string testCase, int expectedResult)
        {
            var result = stringCalculator.Add(testCase);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("-1", "-1")]
        [InlineData("-129", "-129")]
        [InlineData("-12", "-12")]
        [InlineData("1,-4", "-4")]
        [InlineData("0,-2", "-2")]
        [InlineData("-1,-2", "-1,-2")]
        [InlineData("1\n2,3\n-22", "-22")]
        [InlineData("-1\n2,3", "-1")]
        [InlineData("//;\n1;2;-4\n5", "-4")]
        [InlineData("//;\n1;2;-4\n-5", "-4,-5")]
        public void Add_Test_Failed_ReturnException(string testCase, string expectedResult)
        {
            Action act = () => stringCalculator.Add(testCase);

            act.Should().Throw<Exception>()
                .Where(exception => exception.Message.Equals($"negatives not allowed: {expectedResult}"));
        }
    }
}
