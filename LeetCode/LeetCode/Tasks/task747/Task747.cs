using LeetCode.Basic;
using System;
using System.Linq;

namespace LeetCode.Tasks.task747
{
    /*
     747. Наибольшее Число, По Крайней Мере, в два раза больше других
    Вам предоставляется целочисленный массив, nums где наибольшее целое число является уникальным.
    Определите, является ли наибольший элемент массива как минимум в два раза больше любого другого числа в массиве. Если да, верните индекснаибольшего элементаили верните-1иначе.
     */
    public class Task747 : InfoBasicTask
    {
        public Task747(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            int dominantIndexMaxValue = dominantIndex(nums);
            Console.WriteLine(dominantIndexMaxValue == -1 ? "В массиве есть значения, которые больше удвоенного значения максимального числа" : $"Индекс максимального числа = {dominantIndexMaxValue}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int dominantIndex(int[] nums)
        {
            int index = -1;
            int max = nums.Max();
            bool isValid = true;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == max)
                {
                    index = i;
                    continue;
                }
                if (nums[i] * 2 > max)
                {
                    isValid = false;
                    break;
                }
            }
            return isValid ? index : -1;
        }
    }
}
