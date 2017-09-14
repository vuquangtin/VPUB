using System.Text.RegularExpressions;

namespace CommonHelper.Utils
{
    public static class PasswordUtils
    {
        public static PasswordScore CheckPasswordStrength(string password)
        {
            if (password.Length == 0)
            {
                return PasswordScore.Blank;
            }
            if (password.Length < 6)
            {
                return PasswordScore.VeryWeak;
            }

            int score = (int)PasswordScore.VeryWeak;
            if (password.Length >= 8)
            {
                score++;
            }
            if (password.Length >= 12)
            {
                score++;
            }
            //Có chứa chữ số
            if (Regex.IsMatch(password, @"(?=.*[0-9])", RegexOptions.ECMAScript))
            {
                score++;
            }
            //Có chứa ký tự upper case lẫn lower case
            if (Regex.IsMatch(password, @"(?=.*[a-z])", RegexOptions.ECMAScript)
                && Regex.IsMatch(password, @"(?=.*[A-Z])", RegexOptions.ECMAScript))
            {
                score++;
            }
            //Có chứa ký tự đặc biệt
            if (Regex.IsMatch(password, @"(?=.*[!,@,#,$,%,^,&,*,?,_,~,-,;,:,<,>,//,+,|,\,=])", RegexOptions.ECMAScript))
            {
                score++;
            }
            if (score > (int)PasswordScore.VeryStrong)
            {
                score = (int)PasswordScore.VeryStrong;
            }

            return (PasswordScore)score;
        }

        public static string GetName(this PasswordScore score)
        {
            switch(score)
            {
                case PasswordScore.Blank:
                    return "";
                case PasswordScore.VeryWeak:
                    return "Rất yếu";
                case PasswordScore.Weak:
                    return "Yếu";
                case PasswordScore.Medium:
                    return "Trung bình";
                case PasswordScore.Strong:
                    return "Mạnh";
                case PasswordScore.VeryStrong:
                    return "Rất mạnh";
                default:
                    return "N/A";
            }
        }
    }

    public enum PasswordScore : int
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }
}
