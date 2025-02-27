using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2395
{
    /*
     2395. Найдите подмассивы с равной суммой
    Учитывая нумерованный с 0 целочисленный массив nums, определите, существуют ли два подмассива длиной 2 с одинаковой суммой. Обратите внимание, что два подмассива должны начинаться с разных индексов.
    Возвращает, true если эти подмассивы существуют, и false в противном случае.
    Подмассив — это непрерывная непустая последовательность элементов внутри массива.
    Ограничения:
        2 <= nums.length <= 1000
        -10^9 <= nums[i] <= 10^9
     */
    public class Task2395 : InfoBasicTask
    {
        public Task2395(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 4, 2, 4 };
            if (isValid(array))
            {
                Console.WriteLine(findSubarrays(array) ? "Существуют подмассивы с равной суммой" : "Не существуют подмассивы с равной суммой");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 2 || nums.Length > 1000)
            {
                return false;
            }
            int lowLimit = (int)Math.Pow(-10, 9);
            int upperLimit = (int)Math.Pow(10, 9);
            foreach (var item in nums)
            {
                if (item < lowLimit || item > upperLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private bool findSubarrays(int[] nums)
        {
            HashSet<int> sumsOfSubArrays = new HashSet<int>();
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int sum = nums[i] + nums[i + 1];
                int previousSizeSet = sumsOfSubArrays.Count;
                sumsOfSubArrays.Add(sum);
                if (sumsOfSubArrays.Count == previousSizeSet)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
