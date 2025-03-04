using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2778
{
    /*
     2778. Сумма квадратов специальных элементов 
    Вам дан индексированный с 1-го элемента целочисленный массив nums длиной n.
    Элемент nums[i] из nums называется специальным, если i делит n, то есть n % i == 0.
    Возвращает сумму квадратов всех специальных элементов nums.
    Ограничения:
        1 <= nums.length == n <= 50
        1 <= nums[i] <= 50
    https://leetcode.com/problems/sum-of-squares-of-special-elements/description/
     */
    public class Task2778 : InfoBasicTask
    {
        public Task2778(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 7, 1, 19, 18, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = sumOfSquares(nums);
                Console.WriteLine($"Результат = {res}");
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
            if (nums.Length < 1 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            return true;
        }
        private int sumOfSquares(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums.Length % (i + 1) == 0)
                {
                    sum+= nums[i]*nums[i];
                }
            }
            return sum;
        }
    }
}
