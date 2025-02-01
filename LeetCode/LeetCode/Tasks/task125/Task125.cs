using System;
using System.Text.RegularExpressions;
using LeetCode.Basic;
namespace LeetCode.Tasks.task125
{
    public class Task125 : InfoBasicTask
    {
        public Task125(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "A man, a plan, a canal: Panama";
            Console.WriteLine($"{(isPalindromeSecondMethod(s) ? $"Строка \"{s}\" является валидным палиндромом" : $"Строка \"{s}\" не является валидным палиндромом")}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isPalindrome(string s)
        {
            string pattern = @"[^\w\d]+";
            Regex regex = new Regex(pattern);
            string target = "";
            string result = regex.Replace(s, target).ToLower();
            int left = 0;
            int right = result.Length - 1;
            while (left < right)
            {
                if (result[left] != result[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        private bool isPalindromeSecondMethod(string s)
        {
            int codeFirstDigit = 48;
            int codeLastDigit = 57;
            int codeFirstEnglishLetter = 97;
            int codeLastEnglishLetter = 122;
            s = s.ToLower();
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if ((codeFirstEnglishLetter <= (int)s[i] && (int)s[i] <= codeLastEnglishLetter) || (codeFirstDigit <= (int)s[i] && (int)s[i] <= codeLastDigit))
                {
                    result += s[i];
                }
            }
            int left = 0;
            int right = result.Length - 1;
            while (left < right)
            {
                if (result[left] != result[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
}
