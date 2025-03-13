using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3442
{
    /*
     3442. Максимальная разница между четной и нечетной частотой появления символа I
     Вам дана строка s, состоящая из строчных букв английского алфавита. Ваша задача — найти максимальную разницу между частотой двух символов в строке, чтобы:
        Один из символов имеет четную частоту в строке.
        Другой символ имеет нечетную частоту в строке.
    Верните максимальную разницу, рассчитанную как частота символа с нечётной частотой минус частота символа с чётной частотой.
    Ограничения:
        3 <= s.length <= 100
        s состоит только из строчных английских букв.
        s содержит по крайней мере один символ с нечётной частотой появления и один символ с чётной частотой появления.
    https://leetcode.com/problems/maximum-difference-between-even-and-odd-frequency-i/description/
     */
    public class Task3442 : InfoBasicTask
    {
        public Task3442(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "aaaaabbc";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                int res = maxDifference(s);
                Console.WriteLine($"Максимальная разница между нечетной частотой появления символа и четной частотой появления символа = {res}");
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
            if (s.Length < 3 || s.Length > 100)
            {
                return false;
            }
            int[] freq = new int[26];
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
                freq[c - 'a']++;
            }
            bool isExistEvenFreq = false;
            bool isExistOddFreq = false;
            foreach (int count in freq) {
                if (count > 0)
                {
                    if (count % 2 == 0)
                    {
                        isExistEvenFreq = true;
                    }
                    else
                    {
                        isExistOddFreq = true;
                    }
                }
            }
            if (!(isExistEvenFreq && isExistOddFreq))
            {
                return false;
            }
            return true;
        }
        private int maxDifference(string s)
        {
            int[] freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }
            int maxOddFreq = int.MinValue;
            int minEvenFreq = int.MaxValue;
            foreach (int f in freq)
            {
                if (f > 0)
                {
                    if (f % 2 == 0)
                    {
                        if (f < minEvenFreq)
                        {
                            minEvenFreq = f;
                        }
                    }
                    else
                    {
                        if (f > maxOddFreq)
                        {
                            maxOddFreq = f;
                        }
                    }
                }
            }
            return maxOddFreq - minEvenFreq;
        }
    }
}
