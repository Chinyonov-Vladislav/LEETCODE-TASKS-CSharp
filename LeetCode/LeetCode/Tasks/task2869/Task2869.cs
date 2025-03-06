using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2869
{
    /*
     2869. Минимальное количество операций по сбору элементов
    Вам предоставляется массив nums натуральных чисел и целое число k.
    За одну операцию вы можете удалить последний элемент массива и добавить его в свою коллекцию.
    Возвращает минимальное количество операций, необходимых для сбора элементов 1, 2, ..., k.
    Ограничения:
        1 <= nums.length <= 50
        1 <= nums[i] <= nums.length
        1 <= k <= nums.length
        Входные данные генерируются таким образом, что вы можете собирать элементы 1, 2, ..., k.
    https://leetcode.com/problems/minimum-operations-to-collect-elements/description/
     */
    public class Task2869 : InfoBasicTask
    {
        public Task2869(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<int> nums = new List<int>() { 3, 1, 5, 4, 2 };
            printIListInt(nums, "Исходный список чисел");
            int k = 2;
            Console.WriteLine($"Диапазон: [1,{k}]");
            if (isValid(nums, k))
            {
                int min = minOperations(nums, k);
                Console.WriteLine($"Минимальное количество удалений элементов с конца для сбора чисел в диапазоне [1,{k}] = {min}");
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
        private bool isValid(IList<int> nums, int k)
        {
            if (nums.Count < 1 || nums.Count > 50)
            {
                return false;
            }
            foreach (var item in nums)
            {
                if (item < 1 || item > nums.Count)
                {
                    return false;
                }
            }
            if (k < 1 || k > nums.Count)
            {
                return false;
            }
            bool[] bools = new bool[k];
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                if (nums[i] <= k && nums[i] > 0)
                {
                    bools[nums[i] - 1] = true;
                }
            }
            foreach (bool item in bools)
            {
                if (!item)
                {
                    return false;
                }
            }
            return true;
        }
        private int minOperations(IList<int> nums, int k)
        {
            bool[] bools = new bool[k];
            int countOperation = 0;
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                if (nums[i] <= k && nums[i] > 0)
                {
                    bools[nums[i] - 1] = true;
                }
                countOperation++;
                bool areAllTrue = true;
                foreach (bool item in bools)
                {
                    if (!item)
                    {
                        areAllTrue = false;
                        break;
                    }
                }
                if (areAllTrue)
                {
                    break;
                }
            }
            return countOperation;
        }
    }
}
