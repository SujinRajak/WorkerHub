using System.Text;

namespace Mvc.Helper
{
    public class RandomPassGenerator
    {
        private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";
        private const string SpecialCharacters = "!@#$%^&";

        public static string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeDigits, bool includeSpecialCharacters)
        {
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            string characterSet = "";
            if (includeUppercase)
                characterSet += UppercaseLetters;
            if (includeLowercase)
                characterSet += LowercaseLetters;
            if (includeDigits)
                characterSet += Digits;
            if (includeSpecialCharacters)
                characterSet += SpecialCharacters;

            if (characterSet == "")
                throw new ArgumentException("At least one character set must be included.");

            // Add at least one character from each character set
            if (includeUppercase)
                password.Append(UppercaseLetters[random.Next(UppercaseLetters.Length)]);
            if (includeLowercase)
                password.Append(LowercaseLetters[random.Next(LowercaseLetters.Length)]);
            if (includeDigits)
                password.Append(Digits[random.Next(Digits.Length)]);
            if (includeSpecialCharacters)
                password.Append(SpecialCharacters[random.Next(SpecialCharacters.Length)]);

            // Generate remaining characters randomly
            for (int i = 0; i < length - 4; i++) // Subtract 4 for the characters already added
            {
                int randomIndex = random.Next(0, characterSet.Length);
                password.Append(characterSet[randomIndex]);
            }

            // Shuffle the password characters
            for (int i = 0; i < password.Length; i++)
            {
                int randomIndex = random.Next(i, password.Length);
                char temp = password[i];
                password[i] = password[randomIndex];
                password[randomIndex] = temp;
            }

            return password.ToString();
        }
    }
}
