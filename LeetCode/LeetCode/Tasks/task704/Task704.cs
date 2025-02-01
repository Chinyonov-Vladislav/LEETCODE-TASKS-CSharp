using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task704
{
    /*
     704. Бинарный поиск
    Учитывая массив целых чисел nums, отсортированный в порядке возрастания, и целое число target, напишите функцию для поиска target в nums. 
    Если target существует, то верните его индекс. В противном случае верните -1.
    Вы должны написать алгоритм со O(log n) сложностью во время выполнения.
    https://leetcode.com/problems/binary-search/description/
     */
    public class Task704 : InfoBasicTask
    {
        public Task704(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { -1, 0, 3, 5, 9, 12 };
            int target = 9;
            int indexOfTarget = search(nums, target);
            printArray(nums, "Массив: ");
            Console.WriteLine(indexOfTarget == -1 ? $"Значение {target} не было найдено в массиве" : $"Значение {target} было найдено в массиве на позиции {indexOfTarget}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }     
            }
            return -1;
        }
    }
}
