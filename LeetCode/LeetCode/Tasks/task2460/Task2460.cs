using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2460
{
    /*
     2460. Применение операций к массиву
    Вам дан массив с индексацией 0 nums размером n состоящий из неотрицательных целых чисел.
    Вам нужно применить n - 1 операций к этому массиву, где в ith операции (с индексом 0) вы примените следующее к ith элементу nums:
        Если nums[i] == nums[i + 1], то умножьте nums[i] на 2 и присвойте nums[i + 1] значение 0. В противном случае пропустите эту операцию.
    После выполнения всех операций переместите все 0 в конец массива.
        Например, массив [1,0,2,0,0,1] после сдвига всех его 0 в конец выглядит так: [1,2,1,0,0,0].
    Возвращает результирующий массив.
    Обратите внимание, что операции применяются последовательно, а не все сразу.
    Ограничения:
        2 <= nums.length <= 2000
        0 <= nums[i] <= 1000
    https://leetcode.com/problems/apply-operations-to-an-array/description/
     */
    public class Task2460 : InfoBasicTask
    {
        public Task2460(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 2, 1, 1, 0 };
            printArray(nums);
            if (isValid(nums))
            {
                int[] result = applyOperations(nums);
                printArray(result, "Результирующий массив: ");
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
            if (nums.Length < 2 || nums.Length > 2000)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 0 || num > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] applyOperations(int[] nums)
        {
            int[] res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                res[i] = nums[i];
            }
            for(int i=0;i< res.Length-1;i++)
            {
                if (res[i] == res[i + 1])
                {
                    res[i] *= 2;
                    res[i + 1] = 0;
                }
            }
            int index = 0;
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] != 0)
                {
                    res[index] = res[i];
                    index++;
                }
            }
            while (index < res.Length)
            {
                res[index] = 0;
                index++;
            }
            return res;
        }
    }
}
