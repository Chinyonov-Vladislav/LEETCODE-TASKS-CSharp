using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task398
{
    /*
     398. Индекс случайного выбора
    Учитывая целочисленный массив nums с возможными дубликатами, случайным образом выведите индекс заданного target числа. 
    Можно предположить, что заданное целевое число должно присутствовать в массиве.
    Реализовать класс Solution:
        Solution(int[] nums) Инициализирует объект с помощью массива nums.
        int pick(int target) Выбирает случайный индекс i из nums где nums[i] == target. Если существует несколько допустимых значений i, то каждый индекс должен иметь равную вероятность возврата.
     Ограничения:
        1 <= nums.length <= 2 * 10^4
        -2^31 <= nums[i] <= 2^31 - 1
        target является целым числом из nums.
        Не более 10^4 звонков будет сделано по адресу pick.
    https://leetcode.com/problems/random-pick-index/description/
     */
    public class Task398 : InfoBasicTask
    {
        public Task398(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1,2,3,3,3 };
            printArray(nums);
            int[] target = new int[] { 3, 1, 3 };
            printArray(target, "Массив значений для поиска: ");
            if (isValid(nums, target))
            {
                Solution s = new Solution(nums);
                foreach (int i in target)
                {
                    Console.WriteLine($"Значение {i} найдено по индексу {s.Pick(i)}");
                }
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
        private bool isValid(int[] nums, int[] target)
        {
            int lowLimit = 1;
            int highLimit = 2*(int)Math.Pow(10,4);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            highLimit = (int)Math.Pow(10, 4);
            if (target.Length < 1 || target.Length > highLimit)
            {
                return false;
            }
            foreach (int targ in target)
            {
                if (!nums.Contains(targ))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
