using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task496
{
    /*
     496. Следующий  больший элемент I
    Следующий больший элемент после некоторого элемента x в массиве — это первый больший элемент, который находится справа от x в том же массиве.
    Вам даны два отличных друг от друга целочисленных массива nums1 и nums2, где nums1 является подмножеством nums2.
    Для каждого 0 <= i < nums1.length найдите индекс j такой, что nums1[i] == nums2[j] и определите следующий больший элементnums2[j] в nums2. 
    Если следующего большего элемента нет, то ответом на этот запрос будет -1.
    Верните массив ans длины nums1.length такой, что ans[i] является следующим большим элементом, как описано выше.
    Ограничения:
        1 <= nums1.length <= nums2.length <= 1000
        0 <= nums1[i], nums2[i] <= 10^4
        Все целые числа в nums1 и nums2 уникальны.
        Все целые числа из nums1 также отображаются в nums2.
    https://leetcode.com/problems/next-greater-element-i/description/
     */
    public class Task496 : InfoBasicTask
    {
        public Task496(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] { 4, 1, 2 };
            int[] nums2 = new int[] { 1, 3, 4, 2 };
            printArray(nums1, "Массив №1: ");
            printArray(nums2, "Массив №2: ");
            if (isValid(nums1, nums2))
            {
                int[] answer = nextGreaterElement(nums1, nums2);
                printArray(answer, "Результирующий массив: ");
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
        private bool isValid(int[] nums1, int[] nums2)
        {
            if (nums1.Length < 1 || nums1.Length > 1000 || nums2.Length < 1 || nums2.Length > 1000 || nums1.Length > nums2.Length)
            {
                return false;
            }
            int highLimit = (int)Math.Pow(10, 4);
            int[][] arrays = new int[][] { nums1, nums2 };
            foreach (int[] nums in arrays)
            {
                foreach (int num in nums)
                {
                    if (num < 0 || num > highLimit)
                    {
                        return false;
                    }
                }
            }
            HashSet<int> set = new HashSet<int>(nums1);
            if (set.Count != nums1.Length)
            {
                return false;
            }
            set = new HashSet<int>(nums2);
            if (set.Count != nums2.Length)
            {
                return false;
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums1)
            {
                dict.Add(num, 1);
            }
            foreach (int num in nums2)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]--;
                    if (dict[num] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int[] nextGreaterElement(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                dict.Add(nums2[i], i);
            }
            int[] answer = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                bool isFind = false;
                int indexCurrentElementInNums2 = dict[nums1[i]];
                for (int j = indexCurrentElementInNums2 + 1; j < nums2.Length; j++)
                {
                    if (nums2[j] > nums1[i])
                    {
                        isFind = true;
                        answer[i] = nums2[j];
                        break;
                    }
                }
                if (!isFind)
                {
                    answer[i] = -1;
                }
            }
            return answer;
        }
    }
}
