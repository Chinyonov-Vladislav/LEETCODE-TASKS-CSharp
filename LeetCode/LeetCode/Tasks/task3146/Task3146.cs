using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3146
{
    /*
     3146. Разница в перестановках между двумя строками
    Вам даны две строки s и t такие, что каждый символ встречается в s не более одного раза, а t является перестановкой s.
    Разница в перестановках между s и t определяется как сумма абсолютных разностей между индексом появления каждого символа в s и индексом появления того же символа в t.
    Возвращает разницу перестановок между s и t.
    Ограничения:
        1 <= s.length <= 26
        Каждый символ встречается не более одного раза в s.
        t является перестановкой s.
        s состоит только из строчных английских букв.
    https://leetcode.com/problems/permutation-difference-between-two-strings/description/
     */
    public class Task3146 : InfoBasicTask
    {
        public Task3146(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "abc";
            string t = "bac";
            Console.WriteLine($"Исходная строка: \"{s}\"\nСтрока после перестановок: \"{t}\"");
            if (isValid(s, t))
            {
                int res = findPermutationDifference(s, t);
                Console.WriteLine($"Разница в перестановках между двумя строками = {res}");
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
        private bool isValid(string s, string t)
        {
            if (s.Length < 1 || s.Length > 26)
            {
                return false;
            }
            HashSet<char> symbols = new HashSet<char>(s);
            if (symbols.Count != s.Length)
            {
                return false;
            }
            foreach (char c in s) {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            if (s == t)
            {
                return false;
            }
            bool isPermutation = s.OrderBy(c => c).SequenceEqual(t.OrderBy(c => c));
            if (!isPermutation)
            {
                return false;
            }
            return true;
        }
        private int findPermutationDifference(string s, string t)
        {
            int[] freq = new int[26];
            int answer = 0;
            for (int i=0;i<s.Length;i++)
            {
                freq[s[i] - 'a'] = i;
            }
            for (int i = 0; i < s.Length; i++)
            {
                int indexFromS = freq[t[i] - 'a'];
                answer += Math.Abs(indexFromS - i);
            }
            return answer;
        }
    }
}
