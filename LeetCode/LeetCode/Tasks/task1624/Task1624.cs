using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1624
{
    /*
     1624. Самая большая подстрока между двумя равными символами
    Учитывая строку s, верните длину самой длинной подстроки между двумя одинаковыми символами, исключая эти два символа. Если такой подстроки нет, верните -1.
    Подстрока - это непрерывная последовательность символов внутри строки.
     */
    public class Task1624 : InfoBasicTask
    {
        public Task1624(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "abca";
            Console.WriteLine($"Исходная строка = \"{s}\"");
            int result = maxLengthBetweenEqualCharacters(s);
            Console.WriteLine($"Максимальная длина подстроки между одинаковыми символами = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maxLengthBetweenEqualCharacters(string s)
        {
            int max = -1;
            Dictionary<char, List<int>> dict = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]].Add(i);
                }
                else
                {
                    dict.Add(s[i], new List<int>() { i });
                }
            }
            foreach (var pair in dict)
            {
                if (pair.Value.Count <= 1)
                {
                    continue;
                }
                for (int i = 1; i < pair.Value.Count; i++)
                {
                    int value = pair.Value[i] - pair.Value[i - 1] -1;
                    if (value > max)
                    {
                        max = value;
                    }
                }
            }
            return max;
        }
    }
}
