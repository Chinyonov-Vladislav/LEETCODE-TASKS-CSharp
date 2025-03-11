using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3264
{
    /*
     3264. Конечное состояние массива после K операций умножения I
    Вам будет предоставлен целочисленный массив nums, целое число k и целое число multiplier.
    Вам необходимо выполнить k операции над nums. В каждой операции:
        Найдите минимальное значение x в nums. Если минимальное значение встречается несколько раз, выберите первое из них.
        Замените выбранное минимальное значение x на x * multiplier.
    Верните целочисленный массив, обозначающий конечное состояниеnums после выполнения всех k операций.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 100
        1 <= k <= 10
        1 <= multiplier <= 5
    https://leetcode.com/problems/final-array-state-after-k-multiplication-operations-i/description/
     */
    public class Task3264 : InfoBasicTask
    {
        public Task3264(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 1, 3, 5, 6 };
            int k = 5;
            int multiplier = 2;
            printArray(nums);
            Console.WriteLine($"Значение переменной количества итераций (k) = {k}\nЗначение множителя = {multiplier}");
            if (isValid(nums, k, multiplier))
            {
                int[] res = getFinalState(nums, k, multiplier);
                printArray(res, "Финальное состояние массива: ");
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
        private bool isValid(int[] nums, int k, int multiplier)
        {
            if (k < 1 || k > 10 || multiplier < 1 || multiplier > 5 || nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num> 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] getFinalState(int[] nums, int k, int multiplier)
        {
            int[] resultArr = new int[nums.Length];
            int[] copyArr = new int[nums.Length];
            for (int i=0;i<nums.Length;i++)
            {
                copyArr[i] = nums[i];
                resultArr[i] = nums[i];
            }
            Array.Sort(copyArr);
            int count = 0;
            while (count < k)
            {
                int min = copyArr[0];
                for (int i = 0; i < resultArr.Length; i++)
                {
                    if (resultArr[i] == min)
                    {
                        resultArr[i] = min*multiplier;
                        break;
                    }
                }
                copyArr[0] = copyArr[0] * multiplier;
                for (int i = 1; i < copyArr.Length; i++)
                {
                    if (copyArr[i - 1] > copyArr[i])
                    {
                        (copyArr[i - 1], copyArr[i]) = (copyArr[i], copyArr[i - 1]);
                    }
                    else
                    {
                        break;
                    }
                }
                count++;
            }
            return resultArr;
        }
    }
}
