using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task5
{
    public class Task5 : InfoBasicTask
    {
        public Task5(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "cbbd";
            Console.WriteLine($"Самая длинная палиндромная подстрока = {longestPalindrome(str)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string longestPalindrome(string s)
        {
            if (s.Length == 1)
            {
                return s;
            }
            string longestPalindrome = String.Empty;
            int countSymbolsInSubstring = 1;
            for (int indexFirst = 0; indexFirst < s.Length; indexFirst++)
            {
                while (countSymbolsInSubstring <= s.Length)
                {
                    try
                    {
                        string substring = s.Substring(indexFirst, countSymbolsInSubstring);
                        if (isPalindrome(substring))
                        {
                            if (substring.Length > longestPalindrome.Length)
                            {
                                longestPalindrome = substring;
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        countSymbolsInSubstring++;
                        break;
                    }
                    countSymbolsInSubstring++;
                }
                countSymbolsInSubstring = 1;
            }
            return longestPalindrome;
        }
        private bool isPalindrome(string str)
        {
            var left = 0;
            var right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        // TODO: найти лучшее решение
        /* best solution
        private void ExpandFromLeft(string s,int palindromeLength, int palindromeStart, int left)
        {
            if (left < 0 || left + 1 >= s.Length)
                return;

            if (s[left] == s[left + 1])
                Expand(s, palindromeLength, palindromeStart, left, 2);

            if (left + 2 < s.Length && s[left] == s[left + 2])
                Expand(s, palindromeLength, palindromeStart, left, 3);
        }
        private void Expand(string s, int palindromeLength,int palindromeStart, int start, int length)
        {
            int maxOneSidedGrowth = Math.Min(start, s.Length - start - length);

            if ((maxOneSidedGrowth * 2) + length <= palindromeLength)
                return;

            int left = start - 1;
            int right = start + length;

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                start--;
                length += 2;

                left--;
                right++;
            }

            if (length > palindromeLength)
            {
                palindromeStart = start;
                palindromeLength = length;
            }
        }
        private string bestSolution(string s)
        {
            if (s.Length == 1)
                return s;

            int palindromeStart = 0;
            int palindromeLength = 1;

            for (int i = s.Length / 2; i < s.Length; i++)
            {
                ExpandFromLeft(s, palindromeLength, palindromeStart, i);
                ExpandFromLeft(s, palindromeLength, palindromeStart, s.Length - 1 - i);
            }
            return s.Substring(palindromeStart, palindromeLength);
        }*/
    }
}
