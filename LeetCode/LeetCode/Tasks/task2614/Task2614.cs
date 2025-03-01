using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2614
{
    /*
     2614. Простое число по диагонали
    Вам дан двумерный целочисленный массив nums.
    Возвращает наибольшее простое число, которое лежит хотя бы на одной из диагоналей из nums. 
    В случае, если ни на одной из диагоналей нет простого числа, верните 0.
    Обратите внимание, что:
        Целое число является простым, если оно больше 1 и не имеет положительных целых делителей, кроме 1 и самого себя.
        Целое число val находится на одной из диагоналейnums если существует целое число i для которого nums[i][i] = val или i для которого nums[i][nums.length - i - 1] = val.
    Ограничения:
        1 <= nums.length <= 300
        nums.length == nums[i].length
        1 <= nums[i][j] <= 4*10^6
    https://leetcode.com/problems/prime-in-diagonal/description/
     */
    public class Task2614 : InfoBasicTask
    {
        public Task2614(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] {
                new int[] { 1,2,3 },
                new int[] { 5, 6, 7 },
                new int[] { 9, 10, 11 }
            };
            printTwoDimensionalArray(grid, "Исходная матрицы");
            if (isValid(grid))
            {
                int result = diagonalPrime(grid);
                Console.WriteLine(result == 0 ? "Простое число отсутствует на главной и побочной диагонали" : $"Наибольшее простое число на главной и побочной диагонали = {result}");
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
        private bool isValid(int[][] nums)
        {
            int countRows = nums.Length;
            if (countRows < 1 || countRows > 300)
            {
                return false;
            }
            foreach (int[] row in nums)
            {
                if (row.Length != countRows)
                {
                    return false;
                }
            }
            int highLimit = 4 * (int)Math.Pow(10, 6);
            foreach (var row in nums)
            {
                foreach (var item in row)
                {
                    if (item < 1 || item > highLimit)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int diagonalPrime(int[][] nums)
        {
            int result = 0;
            int countRows = nums.Length;
            for (int i = 0; i < countRows; i++)
            {
                if (isPrime(nums[i][i]) && nums[i][i] > result)
                {
                    result = nums[i][i];
                }
                if (isPrime(nums[i][countRows - i - 1]) && nums[i][countRows - i - 1] > result)
                {
                    result = nums[i][countRows - i - 1];
                }
            }
            return result;
        }
        private bool isPrime(int num)
        {
            if (num < 2)
            {
                return false;
            }
            if (num == 2)
            {
                return true;
            }
            if (num % 2 == 0)
            {
                return false;
            }
            for (int i = 3; i < Math.Sqrt(num) + 1; i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
