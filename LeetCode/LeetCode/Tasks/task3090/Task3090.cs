using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3090
{
    /*
     3090. Подстрока максимальной длины с двумя вхождениями
    Для заданной строки s верните максимальную длину подстроки, которая содержит не более двух вхождений каждого символа.
    Ограничения:
        2 <= s.length <= 100
        s состоит только из строчных английских букв.
    https://leetcode.com/problems/maximum-length-substring-with-two-occurrences/description/
     */
    public class Task3090 : InfoBasicTask
    {
        public Task3090(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "bcbbbcba";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                int maxLength = maximumLengthSubstring(s);
                Console.WriteLine($"Максимальная длина подстроки без вхождения одного и того же символа более 2 раз = {maxLength}");
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
            if (s.Length < 2 || s.Length > 100)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            return true;
        }
        private int maximumLengthSubstring(string s)
        {
            int length = s.Length-1;
            while (length >= 0)
            {
                for (int i = 0; i < s.Length - length; i++)
                {
                    int[] freq = new int[26];
                    string subStr = s.Substring(i, length+1);
                    bool isValid = true;
                    foreach (char c in subStr) {
                        freq[c - 'a']++;
                        if (freq[c - 'a'] > 2)
                        {
                            isValid = false;
                        }
                    }
                    if (isValid)
                    {
                        return subStr.Length;
                    }
                }
                length--;
            }
            return 2;
        }
    }
}
