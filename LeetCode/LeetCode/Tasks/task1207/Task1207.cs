using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1207
{
    /*
     1207. Уникальное количество вхождений
     Учитывая массив целых чисел arr, верните true если количество вхождений каждого значения в массиве является уникальным или false иначе.
    https://leetcode.com/problems/unique-number-of-occurrences/description/
     */
    public class Task1207 : InfoBasicTask
    {
        public Task1207(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 1, 2, 2, 1, 1, 3 };
            Console.WriteLine(uniqueOccurrences(arr) ? "Количество вхождений каждого значения в массиве является уникальным" : "Количество вхождений каждого значения в массиве не является уникальным");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool uniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }
            List<int> occurences = dict.Values.ToList();
            HashSet<int> set = new HashSet<int>(occurences);
            return occurences.Count == set.Count;
        }
    }
}
