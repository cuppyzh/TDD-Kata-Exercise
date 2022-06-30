using System;
using System.Collections.Generic;
using System.Text;

namespace Cuppyzh.Exercise.TDD.Kata1
{
    public static class PasswordVerificationUtils
    {
        public const string PASSWORD_LENGTH_ERROR = "password should be larger than 8 chars";
        public const string PASSWORD_NULL_ERROR = "password should not be null";
        public const string PASSWORD_UPPERCASE_ERROR = "password should have one uppercase letter at least";
        public const string PASSWORD_LOWERCASE_ERROR = "password should have one lowercase letter at least";
        public const string PASSWORD_NUMBER_ERROR = "password should have one number at least";
    }
}
