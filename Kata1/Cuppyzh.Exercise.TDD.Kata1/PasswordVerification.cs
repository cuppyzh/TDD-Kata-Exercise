using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Cuppyzh.Exercise.TDD.Kata1
{

    public class PasswordVerification
    {
        private const int MIN_LENGTH = 8;

        public bool Verification(string password)
        {
            List<string> errorValidation = new List<string>();

            if (password == null || string.IsNullOrEmpty(password))
            {
                errorValidation.Add(PasswordVerificationUtils.PASSWORD_NULL_ERROR);
            }

            if (string.IsNullOrEmpty(password) || password.Length < MIN_LENGTH)
            {
                errorValidation.Add(PasswordVerificationUtils.PASSWORD_LENGTH_ERROR);
            }

            if (string.IsNullOrEmpty(password) || !Regex.Match(password, ".*[A-Z].*").Success)
            {
                errorValidation.Add(PasswordVerificationUtils.PASSWORD_UPPERCASE_ERROR);
            }

            if (string.IsNullOrEmpty(password) || !Regex.Match(password, ".*[a-z].*").Success)
            {
                errorValidation.Add(PasswordVerificationUtils.PASSWORD_LOWERCASE_ERROR);
            }

            if (string.IsNullOrEmpty(password) || !Regex.Match(password, ".*[0-9].*").Success)
            {
                errorValidation.Add(PasswordVerificationUtils.PASSWORD_NUMBER_ERROR);
            }

            if (errorValidation.Count > 2
                || (errorValidation.Contains(PasswordVerificationUtils.PASSWORD_LENGTH_ERROR) || errorValidation.Contains(PasswordVerificationUtils.PASSWORD_LOWERCASE_ERROR)))
            {
                throw new Exception(string.Join(',', errorValidation));
            }

            return true;
        }
    }
}
