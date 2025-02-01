using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task645
{
    /*
     645. Установить несоответствие
    У вас есть набор целых чисел s, который изначально содержит все числа от 1 до n. К сожалению, из-за какой-то ошибки одно из чисел в s было продублировано другим числом из набора, что привело к повтору одного числа и потере другого числа.
    Вам дан целочисленный массив nums с данными о состоянии этого набора после ошибки.
    Найдите число, которое встречается дважды, и число, которого нет, и верните их в виде массива.
    https://leetcode.com/problems/set-mismatch/description/
     */
    public class Task645 : InfoBasicTask
    {
        public Task645(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 2 };
            int[] result = findErrorNums(nums);
            printArray(result, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] findErrorNums(int[] nums)
        {
            int[] freq = new int[nums.Length];
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                freq[nums[i] - 1]++;
            }
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] == 0)
                {
                    result[1] = i + 1;
                }
                if (freq[i] == 2)
                {
                    result[0] = i + 1;
                }
                if (result[0] != 0 && result[1] != 0)
                {
                    break;
                }
            }
            return result;
        }
    }
}
