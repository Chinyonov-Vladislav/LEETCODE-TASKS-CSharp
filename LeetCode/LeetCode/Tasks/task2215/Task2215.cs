using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2215
{
    /*
     2215. Найдите разницу между двумя массивами
    Учитывая два нумерованных с 0 целочисленных массива nums1 и nums2, верните список answer размером 2 где:
        answer[0] это список всех различных целых чисел в nums1 которые не присутствуют в nums2.
        answer[1] которые не присутствуют в nums2 это список всех различных целых чисел в nums1.
    Обратите внимание, что целые числа в списках могут возвращаться в любом порядке.
    https://leetcode.com/problems/find-the-difference-of-two-arrays/description/
     */
    public class Task2215 : InfoBasicTask
    {
        public Task2215(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array1 = new int[] { 1, 2, 3 };
            int[] array2 = new int[] { 2, 4, 6 };
            printArray(array1, "Массив №1");
            printArray(array2, "Массив №2");
            IList<IList<int>> result = findDifference(array1, array2);
            printIListIListInt(result);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<IList<int>> findDifference(int[] nums1, int[] nums2)
        {
            IList<IList<int>> result = new List<IList<int>>() {
                new List<int>(),
                new List<int>()
            };
            HashSet<int> set1 = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>(nums2);
            foreach (var item in set1)
            {
                if (!set2.Contains(item))
                {
                    result[0].Add(item);
                }
            }
            foreach (var item in set2)
            {
                if (!set1.Contains(item))
                {
                    result[1].Add(item);
                }
            }
            return result;
        }
    }
}
