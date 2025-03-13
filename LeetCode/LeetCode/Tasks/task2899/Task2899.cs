using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2899
{
    /*
     2899. Последние посещенные целые числа
    Дан целочисленный массив nums где nums[i] является либо положительным целым числом, либо -1. Нам нужно найти для каждого -1 соответствующее положительное целое число, которое мы называем последним посещённым целым числом.
    Чтобы достичь этой цели, давайте определим два пустых массива: seen и ans.
    Начните итерацию с начала массива nums.
        Если встретится положительное целое число, добавьте его в начало seen.
        Если -1 встречается, пусть k - количество последовательных -1 виденных на данный момент (включая текущий -1),
            Если k меньше или равно длине seen, добавьте k-й элемент seen в ans.
            Если k строго больше длины seen, добавьте -1 к ans.
    Возвращает массив ans.
    Ограничения:
        1 <= nums.length <= 100
        nums[i] == -1 или 1 <= nums[i] <= 100
    https://leetcode.com/problems/last-visited-integers/description/
     */
    public class Task2899 : InfoBasicTask
    {
        public Task2899(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, -1, 2, -1, -1 };
            printArray(nums);
            if (isValid(nums))
            {
                IList<int> res = lastVisitedIntegers(nums);
                printIListInt(res, "Результирующий список чисел: ");
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
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if ((num < 1 || num > 100) && num != -1)
                { 
                    return false;
                }
            }
            return true;
        }
        private IList<int> lastVisitedIntegers(int[] nums)
        {
            IList<int> seen = new List<int>();
            IList<int> ans = new List<int>();
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 1)
                {
                    seen.Insert(0, nums[i]);
                    
                    k = 0;
                }
                else
                {
                    k++;
                    int index = k - 1;
                    if (index >= 0 && index < seen.Count)
                    {
                        ans.Add(seen[index]);
                    }
                    else
                    {
                        ans.Add(-1);
                    }
                }
            }
            return ans;
        }
    }
}
