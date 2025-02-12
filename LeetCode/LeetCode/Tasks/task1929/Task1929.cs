using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1929
{
    /*
     1929. Объединение массива
    Учитывая целочисленный массив nums длиной n, вы хотите создать массив ans длиной 2n, где ans[i] == nums[i] и ans[i + n] == nums[i] для 0 <= i < n (нумерация с 0).
    В частности, ans это объединение двух nums массивов.
    Возвращает массив ans.
    https://leetcode.com/problems/concatenation-of-array/description/
     */
    public class Task1929 : InfoBasicTask
    {
        public Task1929(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 1, 3, 2, 1 };
            printArray(arr, "Исходный массив: ");
            int[] result = getConcatenation(arr);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] getConcatenation(int[] nums)
        {
            int[] result = new int[nums.Length * 2];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i];
                result[i + nums.Length] = nums[i];
            }
            return result;
        }
    }
}
