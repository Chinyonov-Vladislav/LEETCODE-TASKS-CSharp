using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task647
{
    /*
     647. Палиндромные подстроки
    Дана строка s, верните количествопалиндромных подстрок в ней.
    Строка является палиндромом, если она читается одинаково как в прямом, так и в обратном направлении.
    Подстрока - это непрерывная последовательность символов внутри строки.
    Ограничения:
        1 <= s.length <= 1000
        s состоит из строчных английских букв.
    https://leetcode.com/problems/palindromic-substrings/description/
     */
    public class Task647 : InfoBasicTask
    {
        public Task647(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "aaa";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                int res = countSubstrings(s);
                Console.WriteLine($"Количество подстрок, которые являются палиндромами = {res}");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string s)
        {
            int lowLimitLengthString = 1;
            int highLimitLengthString = 1000;
            if (s.Length < lowLimitLengthString || s.Length > highLimitLengthString)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }
        private int countSubstrings(string s)
        {
            int count = 0;
            int currentLength = 1;
            int maxLength = s.Length;
            while (currentLength <= maxLength)
            {
                for (int i = 0; i < maxLength - currentLength + 1; i++)
                {
                    string substring = s.Substring(i, currentLength);
                    if (isPalindrome(substring))
                    {
                        count++;
                    }
                }
                currentLength++;
            }
            return count;
        }
        private bool isPalindrome(string s)
        {
            int left = 0;
            int right = s.Length-1;
            while (left < right)
            {
                if (s[left] != s[right])
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
