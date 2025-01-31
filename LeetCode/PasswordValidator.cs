namespace LeetCode
{
    public class PasswordValidator
    {
        //A password is considered valid if it satisfies the following conditions
        //It has at least 8 characters.
        //It contains at least one lowercase letter.
        //It contains at least one uppercase letter.
        //It contains at least one digit.
        //It contains at least one special character. The special characters are the characters in the following string: "!@#$%^&*()-+".
        public bool StrongPasswordChecker(string password)
        {
            if(password.Length < 8)
            {
                return false;
            }

            var upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if(!IsValid(password, upperCase))
            {
                return false;
            }

            var lowerCase = "abcdefghijklmnopqrstuvwxyz";
            if (!IsValid(password, lowerCase))
            {
                return false;
            }

            var digits = "0123456789";
            if (!IsValid(password, digits))
            {
                return false;
            }
            var specialCharacters = "!@#$%^&*()-+";
            if (!IsValid(password, specialCharacters))
            {
                return false;
            }

            for (var i=0;i < password.Length - 1;i++)
            {
                if (password[i] == password[i+1])
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsValid(string password, string chars)
        {
            foreach (var c in chars)
            {
                if (password.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
