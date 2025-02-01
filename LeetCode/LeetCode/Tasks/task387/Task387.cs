using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task387
{
    /*
     387. Первый уникальный символ в строке
    Дана строка s, найдите в ней первый неповторяющийся символ и верните его индекс. Если его нет, верните -1.
    https://leetcode.com/problems/first-unique-character-in-a-string/description/
     */
    public class Task387 : InfoBasicTask
    {
        public Task387(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "loveleetcode";
            int index = firstUniqChar(str);
            Console.WriteLine(index== -1 ? "В строке нет уникальных символов" : $"Индекс первого уникального символа в строке = {index}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int firstUniqChar(string s)
        {
            Dictionary<char, List<int>> countChars = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (countChars.ContainsKey(s[i]))
                {
                    countChars[s[i]].Add(i);
                }
                else
                {
                    countChars.Add(s[i], new List<int>() { i });
                }
            }
            List<int> uniqueCharsIndexs = new List<int>();
            foreach (var pair in countChars)
            {
                if (pair.Value.Count == 1)
                {
                    uniqueCharsIndexs.Add(pair.Value[0]);
                }
            }
            return uniqueCharsIndexs.Count == 0 ? -1 : uniqueCharsIndexs.Min();
        }
    }
}
