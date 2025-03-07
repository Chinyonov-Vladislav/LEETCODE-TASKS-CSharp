using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3069
{
    /*
     3069. Распределите элементы по двум массивам I
    Вам дан массив с 1-индексированием различных целых чисел nums длиной n.
    Вам нужно распределить все элементы nums между двумя массивами arr1 и arr2 с помощью n операций. 
    В первой операции добавьте nums[1] к arr1. Во второй операции добавьте nums[2] к arr2. Затем в ith операции:
        Если последний элемент arr1 больше последнего элемента arr2, добавьте nums[i] к arr1. В противном случае добавьте nums[i] к arr2.
    Массив result формируется путём объединения массивов arr1 и arr2. Например, если arr1 == [1,2,3] и arr2 == [4,5,6], то result = [1,2,3,4,5,6].
    Возвращает массив result.
    Ограничения:
        3 <= n <= 50
        1 <= nums[i] <= 100
        Все элементы в nums различны.
    https://leetcode.com/problems/distribute-elements-into-two-arrays-i/description/
     */
    public class Task3069 : InfoBasicTask
    {
        public Task3069(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 5, 4, 3, 8 };
            printArray(nums);
            if (isValid(nums))
            {
                int[] res = resultArray(nums);
                printArray(nums, "Результирующий массив: ");
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
        private bool isValid(int[] nums)
        {
            if (nums.Length < 3 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            HashSet<int> set = new HashSet<int>(nums);
            if (nums.Length != set.Count)
            {
                return false;
            }
            return true;
        }
        private int[] resultArray(int[] nums)
        {
            List<int> num1 = new List<int>();
            List<int> num2 = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    num1.Add(nums[i]);
                }
                else if (i == 1)
                {
                    num2.Add(nums[i]);
                }
                else
                {
                    if (num1[num1.Count - 1] > num2[num2.Count - 1])
                    {
                        num1.Add(nums[i]);
                    }
                    else
                    {
                        num2.Add(nums[i]);
                    }
                }
            }
            int[] res = new int[num1.Count + num2.Count];
            int index = 0;
            foreach (int num in num1)
            {
                res[index] = num;
                index++;
            }
            foreach (int num in num2)
            {
                res[index] = num;
                index++;
            }
            return res;
        }
    }
}
