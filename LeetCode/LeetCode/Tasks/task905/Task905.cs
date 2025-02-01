using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task905
{
    /*
     905. Отсортировать массив по четности
    Дан целочисленный массив nums. Переместите все чётные числа в начало массива, а затем все нечётные числа.
    Возвращает любой массив удовлетворяющий этому условию.
    https://leetcode.com/problems/sort-array-by-parity/description/
     */
    public class Task905 : InfoBasicTask
    {
        public Task905(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 1, 2, 4 };
            printArray(nums, "Исходный массив: ");
            nums = sortArrayByParity(nums);
            printArray(nums, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int[] sortArrayByParity(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] % 2 != 0 && nums[right] % 2 == 0)
                {
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                    left++;
                    right--;
                    continue;
                }
                if (nums[left] % 2 == 0)
                {
                    left++;
                }
                if (nums[right] % 2 != 0)
                {
                    right--;
                }
            }
            return nums;
        }
    }
}
