using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks.task349
{
    /*
     349. Пересечение двух массивов
    Учитывая два целочисленных массива nums1 и nums2, верните массив их пересечение
    Каждый элемент в результате должен быть уникальным, и вы можете возвращать результат в любом порядке.
     */
    public class Task349 : InfoBasicTask
    {
        public Task349(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] {4,9,5 };
            int[] nums2 = new int[] {9,4, 9,8,4};
            int[] result = intersection(nums1, nums2);
            printArray(result, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int[] intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> result = new HashSet<int>();
            int[] arr;
            HashSet<int> uniqueNum1 = new HashSet<int>(nums1);
            HashSet<int> uniqueNum2 = new HashSet<int>(nums2);
            HashSet<int> finalUnique = new HashSet<int>();
            if (uniqueNum1.Count >= uniqueNum2.Count)
            {
                foreach (var item in uniqueNum1)
                {
                    if (!uniqueNum2.Contains(item))
                    {
                        finalUnique.Add(item);
                    }
                }
                arr = nums1;
            }
            else
            {
                foreach (var item in uniqueNum2)
                {
                    if (!uniqueNum1.Contains(item))
                    {
                        finalUnique.Add(item);
                    }
                }
                arr = nums2;           
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (!finalUnique.Contains(arr[i]))
                {
                    result.Add(arr[i]);
                }
            }
            return result.ToArray();
        }
        private int[] bestSolution(int[] nums1, int[] nums2)
        {
            var freq = new int[1001];

            foreach (var n in nums1)
            {
                freq[n] = 1;
            }

            var ans = new List<int>();

            foreach (var n in nums2)
            {
                if (freq[n] != 0)
                {
                    freq[n] = 0;
                    ans.Add(n);
                }
            }

            return ans.ToArray();
        }
    }
}
