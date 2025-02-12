using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1941
{
    /*
     1941. Проверьте, встречаются ли все символы одинаковое количество раз
    Учитывая строку s, верните true если s это хорошая строка, или false иначе.
    Строка s является хорошей, если все символы, встречающиеся в s, имеют одинаковое количество вхождений (то есть одинаковую частоту).
    https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences/description/
     */
    public class Task1941 : InfoBasicTask
    {
        public Task1941(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "abacbc";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            if (isValidInitialString(initialString))
            {
                Console.WriteLine(areOccurrencesEqual(initialString) ? "Все символы в исходной строке встречаются одинаковое количество раз" : "Символы в исходной строке встречаются различное количество раз");
            }
            else
            {
                Console.WriteLine("Неверная исходная строка");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValidInitialString(string initialString)
        {
            if (initialString.Length < 1 || initialString.Length > 1000)
            {
                return false;
            }
            return true;
        }
        private bool areOccurrencesEqual(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }
            HashSet<int> set = new HashSet<int>();
            foreach (var pair in dict)
            {
                set.Add(pair.Value);
            }
            return set.Count == 1;
        }
    }
}
