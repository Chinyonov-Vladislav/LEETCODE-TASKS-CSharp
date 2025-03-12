using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3456
{
    /*
     3456. Найти специальную подстроку длиной K
    Вам даны строка s и целое число k.
    Определите, существует ли подстрока длиной точно k в s, которая удовлетворяет следующим условиям:
        Подстрока состоит только из одного отдельного символа (например, "aaa" или "bbb").
        Если перед подстрокой непосредственно стоит символ, он должен отличаться от символа в подстроке.
        Если сразу после подстроки есть символ, он также должен отличаться от символа в подстроке.
    Верните true, если такая подстрока существует. В противном случае верните false.
    Ограничения:
        1 <= k <= s.length <= 100
        s состоит только из строчных английских букв.
    https://leetcode.com/problems/find-special-substring-of-length-k/description/
     */
    public class Task3456 : InfoBasicTask
    {
        public Task3456(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "ccc";
            int k = 2;
            Console.WriteLine($"Исходная строка: \"{s}\"\nДлина подстроки = {k}");
            if (isValid(s, k))
            {
                Console.WriteLine(hasSpecialSubstring(s, k) ? $"Существует специальная подстрока, удовлетворяющая правилам: подстрока длиной {k} состоит из одного отдельного символа, предыдущий и следующий символы в исходной строке отличаются" :
                    $"Не существует специальная подстрока, удовлетворяющая правилам: подстрока длиной {k} состоит из одного отдельного символа, предыдущий и следующий символы в исходной строке отличаются");
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
        private bool isValid(string s, int k)
        {
            if (!(1 <= k && k <= s.Length && s.Length <= 100))
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
        private bool hasSpecialSubstring(string s, int k)
        {
            for (int i = 0; i <= s.Length - k; i++)
            {
                string subStr = s.Substring(i, k);
                Console.WriteLine(subStr);
                HashSet<char> set = new HashSet<char>(subStr);
                if (set.Count == 1)
                {
                    int indexBefore = i - 1;
                    int indexNext = i + k;
                    if (indexBefore >= 0 && indexBefore < s.Length)
                    {
                        if (s[i] == s[indexBefore])
                        {
                            continue;
                        }
                    }
                    if (indexNext >= 0 && indexNext < s.Length)
                    {
                        if (s[i] == s[indexNext])
                        {
                            continue;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
