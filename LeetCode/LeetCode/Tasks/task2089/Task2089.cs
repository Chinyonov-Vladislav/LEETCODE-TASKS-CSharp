using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2089
{
    /*
     2089. Найдите целевые индексы после сортировки массива
    Вам дан нумерованный от 0 целочисленный массив nums и целевой элемент target.
    Целевой индекс - это индекс, i такой, что nums[i] == target.
    Возвращает список целевых индексов nums после сортировки nums в неубывающем порядке. Если целевых индексов нет, верните пустой список. Возвращаемый список должен быть отсортирован в порядке возрастания.
    https://leetcode.com/problems/find-target-indices-after-sorting-array/description/
     */
    public class Task2089 : InfoBasicTask
    {
        public Task2089(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1 };
            printArray(nums, "Исходный массив: ");
            int target = 2;
            Console.WriteLine($"Целевое значение = {target}");
            IList<int> result = targetIndices(nums, target);
            printIListInt(result, $"Массив индексов, на которых расположено число {target} после сортировки массива: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> targetIndices(int[] nums, int target)
        {
            IList<int> result = new List<int>();
            Array.Sort(nums);
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                if (nums[left] == target && nums[right] == target)
                {
                    break;
                }
                if (nums[left] != target)
                {
                    left++;
                }
                if (nums[right] != target)
                {
                    right--;
                }
            }
            for (; left <= right; left++)
            {
                result.Add(left);
            }
            return result;
        }
    }
}
