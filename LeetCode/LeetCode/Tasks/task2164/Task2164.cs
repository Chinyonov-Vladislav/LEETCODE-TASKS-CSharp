using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2164
{
    /*
     2164. Независимая сортировка четных и нечетных индексов
    Вам дан нумерованный с 0 целочисленный массив nums. Переставьте значения nums в соответствии со следующими правилами:
    Отсортируйте значения по нечётным индексам nums в неубывающем порядке.
        Например, если nums = [4,1,2,3] до этого шага, то после него станет [4,3,2,1] . Значения с нечётными индексами 1 и 3 сортируются в порядке неубывания.
    Отсортируйте значения по чётным индексам nums в неубывающем порядке.
        Например, если nums = [4,1,2,3] до этого шага, то после него станет [2,1,4,3] . Значения с чётными индексами 0 и 2 сортируются в порядке неубывания.
    Возвращает массив, сформированный после перестановки значений nums.
    https://leetcode.com/problems/sort-even-and-odd-indices-independently/description/
     */
    public class Task2164 : InfoBasicTask
    {
        public Task2164(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 4, 1, 2, 3 };
            printArray(nums, "Исходный массив: ");
            int[] sortedArray = sortEvenOdd(nums);
            printArray(sortedArray, "Отсортированный массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] sortEvenOdd(int[] nums)
        {
            int[] result = new int[nums.Length];
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    evenNumbers.Add(nums[i]);
                }
                else
                {
                    oddNumbers.Add(nums[i]);
                }
            }
            evenNumbers.Sort();
            oddNumbers.Sort();
            oddNumbers.Reverse();
            int indexEven = 0;
            int indexOdd = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result[i] = evenNumbers[indexEven];
                    indexEven++;
                }
                else
                {
                    result[i] = oddNumbers[indexOdd];
                    indexOdd++;
                }
            }
            return result;
        }
    }
}
