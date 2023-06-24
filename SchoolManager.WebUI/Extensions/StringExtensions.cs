using System.Text;

namespace SchoolManager.WebUI.Extensions
{
    public static class StringExtesions
    {
        public static bool ContainsUppercase(this string? password)
        {
            if (password is null) return false;

            return password.Any(char.IsUpper);
        }
        public static bool ContainsLowercase(this string? password)
        {
            if (password is null) return false;

            return password.Any(char.IsLower);
        }

        public static bool ContainsNumber(this string? password)
        {
            if (password is null) return false;

            return password.Any(char.IsDigit);
        }

        public static bool ContainsSpecialCharacter(this string? password)
        {
            if (password is null) return false;

            var specialCharacters = "!@#$%^&*()-_=+[{}];:'\",.<>/?";
            return password.Any(c => specialCharacters.Contains(c));
        }
    }
}
