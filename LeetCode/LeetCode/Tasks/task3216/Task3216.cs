using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3216
{
    /*
     3216. Лексикографически наименьшая строка после замены
    Дана строка s, содержащая только цифры. 
    Верните лексикографически наименьшую строку, которую можно получить, поменяв местами соседние цифры в s с одинаковой чётностью не более одного раза.
    Цифры имеют одинаковую чётность, если они обе нечётные или обе чётные. Например, 5 и 9, а также 2 и 4 имеют одинаковую чётность, а 6 и 9 — нет.
    Ограничения:
        2 <= s.length <= 100
        s состоит только из цифр.
    https://leetcode.com/problems/lexicographically-smallest-string-after-a-swap/description/
     */
    public class Task3216 : InfoBasicTask
    {
        public Task3216(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "45320";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                string res = getSmallestString(s);
                Console.WriteLine($"Лексикографически наименьшая возможная строка после замены соседних символов одинаковой четности: \"{res}\"");
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
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private string getSmallestString(string s)
        {
            char[] arr = s.ToCharArray();
            for (int i = 0; i < s.Length - 1; i++)
            {
                int valueFirstChar = arr[i] - '0';
                int valueSecondChar = arr[i+1] - '0';
                if ((valueFirstChar % 2 == 0 && valueSecondChar % 2 == 0) || (valueFirstChar % 2 != 0 && valueSecondChar % 2 != 0))
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (arr[j] != s[j])
                        {
                            if (arr[j] < s[j])
                            {
                                return new string(arr);
                            }
                            break;
                        }
                    }
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                }
            }
            return s;
        }
    }
}
