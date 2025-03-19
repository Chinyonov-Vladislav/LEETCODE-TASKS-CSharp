using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task137
{
    /*
     137. Одиночный Номер II
    Дан целочисленный массив nums, в котором каждый элемент встречается трижды, кроме одного, который встречается ровно один раз. Найдите единственный элемент и верните его.
    Вы должны реализовать решение с линейной сложностью выполнения и использовать только постоянное дополнительное пространство.
    Ограничения:
        1 <= nums.length <= 3 * 104
        -2^31 <= nums[i] <= 2^31 - 1
        Каждый элемент в nums встречается ровно три раза, кроме одного элемента, который встречается один раз.
    https://leetcode.com/problems/single-number-ii/description/
     */
    public class Task137 : InfoBasicTask
    {
        public Task137(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 0, 1, 0, 1, 0, 1, 99 };
            printArray(nums);
            if (isValid(nums))
            {
                int val = singleNumber(nums);
                Console.WriteLine($"Значение элемента, который встречается единожды = {val}");
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
            int lowLimit = 1;
            int highLimit = 3*(int)Math.Pow(10,4);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            int countElementsWithFreqOne = 0;
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
            foreach (var pair in dict) {
                if (pair.Value == 1)
                {
                    countElementsWithFreqOne++;
                    continue;
                }
                if(pair.Value != 3)
                {
                    return false;
                }
            }
            if (countElementsWithFreqOne != 1)
            {
                return false;
            }
            return true;
        }
        private int singleNumber(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i+=3)
            {
                int previousIndex = i - 1;
                int nextIndex = i + 1;
                if (nextIndex < nums.Length)
                {
                    if (nums[previousIndex] == nums[i] && nums[i] == nums[nextIndex])
                    {
                        continue;
                    }
                    else if (nums[previousIndex] != nums[i])
                    {
                        return nums[previousIndex];
                    }
                    else if (nums[i] != nums[nextIndex])
                    {
                        return nums[nextIndex];
                    }
                }
            }
            return nums[nums.Length - 1];
        }
    }
}
