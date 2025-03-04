using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2697
{
    /*
     2697. Лексикографически наименьший палиндром
    Вам дана строка, s состоящая из строчных букв английского алфавита, и вы можете выполнять с ней операции. 
    За одну операцию вы можете заменить символ в s на другую строчную букву английского алфавита.
    Ваша задача — составить s палиндром с помощью минимального количества операций, возможных. 
    Если существует несколько палиндромов, которые можно составить с помощью минимального количества операций, составьте лексикографически наименьший из них.
    Строка a лексикографически меньше, чем строка b (той же длины), если в первой позиции, где a и b отличаются, в строке a буква стоит раньше в алфавите, чем соответствующая буква в b.
    Возврат результирующая строка палиндрома.
    Ограничения:
        1 <= s.length <= 1000
        s состоит только из строчных английских букв.
    https://leetcode.com/problems/lexicographically-smallest-palindrome/description/
     */
    public class Task2697 : InfoBasicTask
    {
        public Task2697(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "egcfe";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            if (isValid(initialString))
            {
                string str = makeSmallestPalindrome(initialString);
                Console.WriteLine($"Наименьший возможный лексикографический палиндром: \"{str}\"");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string s)
        {
            if (s.Length < 1 || s.Length > 1000)
            {
                return false;
            }
            foreach (char c in s) {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            return true;
        }
        private string makeSmallestPalindrome(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0;
            int right = chars.Length - 1;
            while (left < right) {
                if (chars[left] != chars[right])
                {
                    char minChar = chars[left] > chars[right] ? chars[right] : chars[left];
                    if (chars[left] != minChar)
                    {
                        chars[left] = minChar;
                    }
                    else
                    {
                        chars[right] = minChar;
                    }
                }
                left++;
                right--;
            }
            return new string(chars);
        }
    }
}
