using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cuppyzh.Exercise.TDD.Kata1.Tests
{
    public class PasswordVerificationTests
    {
        private readonly PasswordVerification _passwordVerification = new PasswordVerification();

        public PasswordVerificationTests()
        {

        }

        [Theory]
        [InlineData("asdf1asdA")]
        [InlineData("12345678aZ")]
        [InlineData("12345678aa")]
        [InlineData("ABCABCzz")]
        public void PasswordVerification_ValidResult(string password)
        {
            var result = _passwordVerification.Verification(password);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(null, PasswordVerificationUtils.PASSWORD_NULL_ERROR)]
        [InlineData("", PasswordVerificationUtils.PASSWORD_LENGTH_ERROR)]
        [InlineData("ASDFASDFASDF", PasswordVerificationUtils.PASSWORD_LOWERCASE_ERROR)]
        [InlineData("ASDFASDFASDF", PasswordVerificationUtils.PASSWORD_NUMBER_ERROR)]
        [InlineData("123456789", PasswordVerificationUtils.PASSWORD_LOWERCASE_ERROR)]
        [InlineData("123456789", PasswordVerificationUtils.PASSWORD_UPPERCASE_ERROR)]
        [InlineData("a1D", PasswordVerificationUtils.PASSWORD_LENGTH_ERROR)]
        public void PasswordVerification_InvalidResult(string password, string expectedError)
        {
            Action result = () => _passwordVerification.Verification(password);

            result.Should().Throw<Exception>().Where(message => message.Message.Contains(expectedError));
        }
    }
}
