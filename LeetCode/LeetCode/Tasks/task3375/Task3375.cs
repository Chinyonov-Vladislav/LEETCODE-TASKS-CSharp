using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3375
{
    /*
     3375. Минимальное количество операций для приведения значений массива к K
    Вам будет предоставлен целочисленный массив nums и целое число k.
    Целое число h называется действительным, если все значения в массиве, строго превышающие h, идентичны.
        Например, если nums = [10, 8, 10, 8], то допустимым является целое число, h = 9 потому что всеnums[i] > 9 равно 10, но 5 не является допустимым целым числом.
    Вам разрешено выполнить следующую операцию над nums:
        Выберите целое число h, которое подходит для текущих значений в nums.
        Для каждого индекса, i где nums[i] > h, установите nums[i] значение h.
    Верните минимальное количество операций, необходимых для того, чтобы сделать каждый элемент nums равным k. Если невозможно сделать все элементы равными k, верните -1.
    https://leetcode.com/problems/minimum-operations-to-make-array-values-equal-to-k/description/
     */
    public class Task3375 : InfoBasicTask
    {
        public Task3375(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 9, 7, 5, 3 };
            int k = 1;
            printArray(nums);
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(nums, k))
            {
                int answer = minOperations(nums, k);
                Console.WriteLine(answer == -1 ? $"Невозможно сделать все элементы равными {k}" : $"Минимальное количество операций, необходимых для того, чтобы сделать каждый элемент nums равным {k} = {answer}");
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
        private bool isValid(int[] nums, int k)
        {
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            if (k < 1 || k > 100)
            {
                return false;
            }
            return true;
        }
        private int minOperations(int[] nums, int k)
        {
            HashSet<int> res = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < k)
                {
                    return -1;
                }
                if (nums[i] > k)
                {
                    res.Add(nums[i]);
                }
            }
            return res.Count;
        }
    }
}
