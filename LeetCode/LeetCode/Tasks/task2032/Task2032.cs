using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2032
{
    /*
     2032. Два из трех
    Учитывая три массива целых чисел nums1, nums2 и nums3, верните отдельный массив, содержащий все значения, которые присутствуют в по крайней мере в двух из трех массивов. 
    Вы можете возвращать значения в любом порядке.
    https://leetcode.com/problems/two-out-of-three/description/
     */
    public class Task2032 : InfoBasicTask
    {
        public Task2032(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] {1,1,3,2};
            int[] nums2 = new int[] {2,3 };
            int[] nums3 = new int[] {3 };
            printArray(nums1, "Массив №1: ");
            printArray(nums2, "Массив №2: ");
            printArray(nums3, "Массив №3: ");
            IList<int> result = twoOutOfThree(nums1, nums2, nums3);
            printIListInt(result, "Массив значений, содержащий числа, которые встречаются как минимум в 2 массивах одновременно: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> twoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {
            HashSet<int> result = new HashSet<int>();
            HashSet<int> set = new HashSet<int>(nums1);
            for (int i = 0; i < nums2.Length; i++)
            {
                if (set.Contains(nums2[i]))
                {
                    result.Add(nums2[i]);
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                set.Add(nums2[i]);
            }
            for (int i = 0; i < nums3.Length; i++)
            {
                if (set.Contains(nums3[i]))
                {
                    result.Add(nums3[i]);
                }
            }
            return result.ToList();
        }
    }
}
