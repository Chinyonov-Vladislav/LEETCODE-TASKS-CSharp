using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3330
{
    /*
     3330. Найдите исходную введенную строку I
    Алиса пытается ввести определённую строку на своём компьютере. Однако она довольно неуклюжа и может нажимать на клавишу слишком долго, в результате чего символ вводится несколько раз.
    Хотя Алиса старалась сосредоточиться на наборе текста, она понимает, что, возможно, сделала это максимум один раз.
    Вам дана строка word, которая представляет собой окончательный результат, отображаемый на экране Алисы.
    Верните общее количество возможных исходных строк, которые Алиса могла намереваться ввести.
    Ограничения:
        1 <= word.length <= 100
        word состоит только из строчных английских букв.
    https://leetcode.com/problems/find-the-original-typed-string-i/description/
     */
    public class Task3330 : InfoBasicTask
    {
        public Task3330(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string word = "abbcccc";
            Console.WriteLine($"Исходная строка: \"{word}\"");
            if (isValid(word))
            {
                int count = possibleStringCount(word);
                Console.WriteLine($"Возможное количество строк = {count}");
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
        private bool isValid(string word)
        {
            if (word.Length < 1 || word.Length > 100)
            {
                return false;
            }
            foreach (char c in word)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }
        private int possibleStringCount(string word)
        {
            int count = 1;
            int left = 0;
            int right = 0;
            while(right<word.Length)
            {
                if (word[left] != word[right])
                {
                    count += right - left - 1;
                    left = right;
                }
                else
                {
                    right++;
                }
            }
            return count + right - left - 1;
        }
    }
}
