using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2210
{
    /*
     2210. Считайте холмы и долины во множестве
    Вам будет предоставлен целочисленный массив с 0-индексом nums. Индекс i является частью холма в nums, если ближайшие неравные соседи i меньше, чем nums[i]. Аналогично, индекс i является частью долины в nums, если ближайшие неравные соседи i больше, чем nums[i]. Соседние индексы i и j являются частью одного и того же холма или долины, если nums[i] == nums[j].
    Обратите внимание, что для того, чтобы индекс был частью холма или долины, у него должен быть неравный сосед как слева, так и справа от индекса.
    Верните количество холмов и долин в nums.
     Ограничения:
        3 <= nums.length <= 100
        1 <= nums[i] <= 100
    https://leetcode.com/problems/count-hills-and-valleys-in-an-array/
     */
    public class Task2210 : InfoBasicTask
    {
        public Task2210(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 2, 4, 1, 1, 6, 5 };
            printArray(array, "Исходный массив: ");
            int count = countHillValley(array);
            Console.WriteLine($"Количество холмов и долин = {count}");

        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countHillValley(int[] nums)
        {
            int count = 0;
            for (int i = 1; i < nums.Length - 1; i++)
            {
                int left = 0;
                int right = 0;
                for (int indexLeft = i - 1; indexLeft >= 0; indexLeft--)
                {
                    if (nums[indexLeft] != nums[i])
                    {
                        left = nums[indexLeft];
                        break;
                    }
                }
                for (int indexRight = i + 1; indexRight < nums.Length; indexRight++)
                {
                    if (nums[indexRight] != nums[i])
                    {
                        right = nums[indexRight];
                        break;
                    }
                }
                if (left == 0 || right == 0 || nums[i] == nums[i-1])
                {
                    continue;
                }
                if ((left < nums[i] && right < nums[i]) || (left > nums[i] && right > nums[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
