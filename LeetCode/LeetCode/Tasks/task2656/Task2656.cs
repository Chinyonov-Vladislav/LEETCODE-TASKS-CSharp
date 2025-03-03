using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2656
{
    /*
     2656. Максимальная сумма ровно из K элементов 
    Вам дан нумерованный от 0 целочисленный массив nums и целое число k. Ваша задача — выполнить следующую операцию ровно k раз, чтобы набрать как можно больше очков:
        Выберите элемент m из nums.
        Удалите выбранный элемент m из массива.
        Добавьте в массив новый элемент со значением m + 1.
        Увеличьте свой счет на m.
    Верните максимальное количество баллов, которое вы можете получить после выполнения операции ровно k раз.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 100
        1 <= k <= 100
    https://leetcode.com/problems/maximum-sum-with-exactly-k-elements/description/
     */
    public class Task2656 : InfoBasicTask
    {
        public Task2656(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5 };
            printArray(nums);
            int k = 3;
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(nums, k))
            {
                int res = maximizeSum(nums, k);
                Console.WriteLine($"Максимальная сумма = {res}");
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
        private int maximizeSum(int[] nums, int k)
        {
            int sum = 0;
            int max = nums.Max();
            int count = 1;
            while (count <= k)
            {
                sum += max;
                max += 1;
                count++;
            }
            return sum;
        }
    }
}
