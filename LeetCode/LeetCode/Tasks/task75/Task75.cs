using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task75
{
    /*
     75. Сортировка цветов
    Дан массив nums с n объектами, окрашенными в красный, белый или синий цвет. Отсортируйте их на месте так, чтобы объекты одного цвета располагались рядом, а цвета шли в следующем порядке: красный, белый, синий.
    Мы будем использовать целые числа 0, 1 и 2 для обозначения красного, белого и синего цветов соответственно.
    Вы должны решить эту задачу, не используя функцию сортировки библиотеки.
    Ограничения:
        n == nums.length
        1 <= n <= 300
        nums[i] является либо 0, 1, либо 2.
    https://leetcode.com/problems/sort-colors/description/
     */
    public class Task75 : InfoBasicTask
    {
        public Task75(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 0, 2, 1, 1, 0 };
            printArray(nums);
            if (isValid(nums))
            {
                sortColors(nums);
                printArray(nums, "Результат: ");
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
        private bool isValid(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 300)
            {
                return false;
            }
            List<int> accepetedNums = new List<int>() { 0,1,2};
            foreach (int num in nums) {
                if (!accepetedNums.Contains(num))
                {
                    return false;
                }
            }
            return true;
        }
        private void sortColors(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums) {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            Dictionary<int, int> orderedDict = dict.OrderBy(x => x.Key).ToDictionary(item => item.Key, item=>item.Value);
            int index = 0;
            foreach (var pair in orderedDict)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    nums[index] = pair.Key;
                    index++;
                }
            }
        }
    }
}
