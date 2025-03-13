using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1422
{
    /*
     1422. Максимальный балл после разделения строки
    Дана строка s из нулей и единиц, верните максимальное количество баллов после разделения строки на две непустые подстроки (то есть левую подстроку и правую подстроку).
    Результат после разделения строки — это количество нулей в левой подстроке плюс количество единиц в правой подстроке.
    Ограничения:
        2 <= s.length <= 500
        Строка s состоит из символов '0' и '1' только.
    https://leetcode.com/problems/maximum-score-after-splitting-a-string/description/
     */
    public class Task1422 : InfoBasicTask
    {
        public Task1422(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "011101";
            Console.WriteLine($"Исходная строка = {s}");
            if (isValid(s))
            {
                int res = maxScore(s);
                Console.WriteLine($"Максимальный счет (сумма количества нулей в левой части и единиц в правой части) исходной строки = {res}");
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
            if (s.Length < 2 || s.Length > 500)
            {
                return false;
            }
            List<char> acceptedChars = new List<char>() { '0', '1' };
            foreach (char c in s) {
                if (!acceptedChars.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        private int maxScore(string s)
        {
            int totalCountZeros = 0;
            int totalCountOnes = 0;
            foreach (char c in s)
            {
                if (c == '0')
                {
                    totalCountZeros++;
                }
                else
                {
                    totalCountOnes++;
                }
            }
            int countZerosInLeft = 0;
            int countOnesInLeft = 0;
            if (s[0] == '0')
            {
                countZerosInLeft++;
            }
            else
            {
                countOnesInLeft++;
            }
            int countZerosInRight = totalCountZeros - countZerosInLeft;
            int countOnesInRight = totalCountOnes - countOnesInLeft;
            int maxScore = countZerosInLeft + countOnesInRight;
            for (int i = 2; i < s.Length; i++)
            {
                string leftStr = s.Substring(0, i);
                countZerosInLeft = 0;
                countOnesInLeft = 0;
                foreach (char c in leftStr)
                {
                    if (c == '0')
                    {
                        countZerosInLeft++;
                    }
                    else
                    {
                        countOnesInLeft++;
                    }
                }
                countZerosInRight = totalCountZeros - countZerosInLeft;
                countOnesInRight = totalCountOnes - countOnesInLeft;
                int score = countZerosInLeft + countOnesInRight;
                if (score > maxScore)
                {
                    maxScore = score;
                }
            }
            return maxScore;
        }
    }
}
