using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2748
{
    /*
     2748. Количество красивых пар
    Вам дан целочисленный массив nums с индексацией от 0. Пара индексов i, j где 0 <= i < j < nums.length называется красивой, если первая цифра nums[i] и последняя цифра nums[j] взаимно просты.
    Возвращает общее количество красивых пар в nums.
    Два целых числа x и y являются взаимно простыми, если не существует целого числа больше 1, которое делит их оба. 
    Другими словами, x и y являются взаимно простыми, если gcd(x, y) == 1, где gcd(x, y) — наибольший общий делительx и y.
    Ограничения:
        2 <= nums.length <= 100
        1 <= nums[i] <= 9999
        nums[i] % 10 != 0
    https://leetcode.com/problems/number-of-beautiful-pairs/description/
     */
    public class Task2748 : InfoBasicTask
    {
        public Task2748(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 11, 21, 12 };
            printArray(nums);
            if (isValid(nums))
            {
                int count = countBeautifulPairs(nums);
                Console.WriteLine($"Количество красивых пар = {count}");
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
            if (nums.Length < 2 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 9999)
                {
                    return false;
                }
                if (num % 10 == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private int countBeautifulPairs(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int digitFirstNum = nums[i];
                while (digitFirstNum >= 10)
                {
                    digitFirstNum /= 10;
                }
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int digitSecondNum = nums[j] %10;
                    if (gcd(digitFirstNum, digitSecondNum) == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private int gcd(int m, int n)
        {
            while (m != 0 && n != 0)
            {
                if (m > n)
                {
                    m = m % n;
                }
                else
                {
                    n = n % m;
                }
            }
            return m+n;
        }
    }
}
