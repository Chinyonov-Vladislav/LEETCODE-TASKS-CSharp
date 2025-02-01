using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1005
{
    /*
     1005. Максимизируйте сумму массива после K отрицаний
    Дан целочисленный массив nums и целое число k. Измените массив следующим образом:
        выберите индекс i и замените nums[i] на -nums[i].
    Вам следует применить этот процесс ровно k раз. Вы можете выбрать один и тот же индекс i несколько раз.
    Верните наибольшую возможную сумму элементов массива после его изменения таким образом.
    https://leetcode.com/problems/maximize-sum-of-array-after-k-negations/description/
     */
    public class Task1005 : InfoBasicTask
    {
        public Task1005(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, -1, 0, 2 };
            int k = 3;
            printArray(nums, "Исходный массив: ");
            Console.WriteLine($"Количество применения процесса негативизации = {k}");
            int maxSum = largestSumAfterKNegations(nums, k);
            Console.WriteLine($"Максимальная сумма элементов массива после применения негативизации ({k} раз) = {maxSum}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int largestSumAfterKNegations(int[] nums, int k)
        {
            for (int i = 0; i < k; i++)
            {
                int minIndex = Array.IndexOf(nums, nums.Min());
                nums[minIndex] *= -1;
            }
            return nums.Sum();
        }
        
    }
}
