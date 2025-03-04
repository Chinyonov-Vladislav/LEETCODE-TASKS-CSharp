using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2855
{
    /*
     2855. Минимальные сдвиги вправо для сортировки массива
    Вам предоставляется 0-индексированный массив nums длины, n содержащий различные положительные целые числа. 
    Верните минимальное количество сдвигов вправо, необходимое для сортировки, nums и -1 если это невозможно.
    Сдвиг вправо определяется как перемещение элемента с индекса i на индекс (i + 1) % n для всех индексов.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 100
        nums содержит различные целые числа.
    https://leetcode.com/problems/minimum-right-shifts-to-sort-the-array/description/
     */
    public class Task2855 : InfoBasicTask
    {
        public Task2855(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<int> nums = new List<int>() { 3, 4, 5, 1, 2 };
            printIListInt(nums, "Массив чисел: ");
            if (isValid(nums))
            {
                int count = minimumRightShifts(nums);
                Console.WriteLine(count == -1 ? "Невозможно отсортировать массив путём сдвигов вправо" : $"Количество сдвигов вправо для сортировки массива = {count}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(IList<int> nums)
        {
            if (nums.Count < 1 || nums.Count > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            HashSet<int> set = new HashSet<int>(nums);
            if (set.Count != nums.Count)
            {
                return false;
            }
            return true;
        }
        private int minimumRightShifts(IList<int> nums)
        {
            List<int> indexsOfSortingViolations = new List<int>();
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    indexsOfSortingViolations.Add(i);
                }
            }
            if (indexsOfSortingViolations.Count == 0)
            {
                return 0;
            }
            else if (indexsOfSortingViolations.Count == 1)
            {
                for (int i = indexsOfSortingViolations[0]; i < nums.Count; i++)
                {
                    for (int j = 0; j < indexsOfSortingViolations[0]; j++)
                    {
                        if (nums[j] < nums[i])
                        {
                            return -1;
                        }
                    }
                }
                return nums.Count - indexsOfSortingViolations[0];
            }
            return -1;
        }
    }
}
