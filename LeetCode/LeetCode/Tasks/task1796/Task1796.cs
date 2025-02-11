using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1796
{
    /*
     1796. Вторая по величине цифра в строке
    Учитывая буквенно-цифровую строку s, верните вторую по величине цифру, которая появляется в s, или -1, если она не существует.
    Буквенно-цифровая строка — это строка, состоящая из строчных букв английского алфавита и цифр.
    https://leetcode.com/problems/second-largest-digit-in-a-string/description/
     */
    public class Task1796 : InfoBasicTask
    {
        public Task1796(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "dfa12321afd";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            int secondHighValue = secondHighest(initialString);
            Console.WriteLine(secondHighValue == -1 ? "Строка не содержит второй по величине цифры" : $"Вторая по величине цифра в строке = {secondHighValue}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int secondHighest(string s)
        {
            HashSet<int> set = new HashSet<int>();
            for(int i=0;i<s.Length;i++)
            {
                if (char.IsDigit(s[i]))
                {
                    set.Add(s[i] - '0');
                }
            }
            if (set.Count <= 1)
            {
                return -1;
            }
            List<int> numbers = set.ToList();
            numbers.Sort();
            return numbers[numbers.Count-2];
        }
    }
}
