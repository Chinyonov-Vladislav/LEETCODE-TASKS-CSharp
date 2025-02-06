using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.Task1446
{
    /*
     1446. Последовательные символы
    Мощность строки — это максимальная длина непустой подстроки, содержащей только один уникальный символ.
    Учитывая строку s, верните мощность из s.
    https://leetcode.com/problems/consecutive-characters/description/
     */
    public class Task1446 : InfoBasicTask
    {
        public Task1446(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "abbcccddddeeeeedcba";
            Console.WriteLine($"Исходная строка = \"{s}\"");
            int max = maxPower(s);
            Console.WriteLine($"Мощность строки = {max}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maxPower(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }
            int max = 1;
            int startIndex = 0;
            int finishIndex = 0;
            char currentChar = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != currentChar)
                {
                    int length = finishIndex - startIndex + 1;
                    if (length > max)
                    {
                        max = length;
                    }
                    startIndex = i;
                    finishIndex = i;
                    currentChar = s[i];
                }
                else
                {
                    finishIndex++;
                }
            }
            if (finishIndex - startIndex + 1 > max)
            {
                max = finishIndex - startIndex + 1;
            }
            return max;
        }
    }
}
