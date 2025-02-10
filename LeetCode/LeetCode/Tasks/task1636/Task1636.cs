using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1636
{
    /*
     1636. Сортировка массива по возрастающей частоте
    Дан массив целых чисел nums. Отсортируйте массив в возрастающем порядке по частоте встречаемости значений. Если несколько значений встречаются с одинаковой частотой, отсортируйте их в убывающем порядке.
    Возвращает отсортированный массив.
    https://leetcode.com/problems/sort-array-by-increasing-frequency/description/
     */
    public class Task1636 : InfoBasicTask
    {
        public Task1636(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] initialArray = new int[] { 2, 3, 1, 3, 2 };
            printArray(initialArray, "Исходный массив: ");
            int[] sortedArray = frequencySort(initialArray);
            printArray(sortedArray, "Отсортированный массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] frequencySort(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums) {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            var comparer = new FrequencyComparer(dict);
            Array.Sort(nums, comparer);
            return nums;
        }
    }
    class FrequencyComparer : IComparer<int>
    {
        private readonly Dictionary<int, int> frequencyDict;

        public FrequencyComparer(Dictionary<int, int> frequencyDict)
        {
            this.frequencyDict = frequencyDict;
        }

        public int Compare(int x, int y)
        {
            // Compare by frequency
            int freqCompare = frequencyDict[x].CompareTo(frequencyDict[y]);
            if (freqCompare != 0)
            {
                return freqCompare;
            }
            // If frequencies are equal, compare by value
            return x.CompareTo(y) * (-1);
        }
    }
}
