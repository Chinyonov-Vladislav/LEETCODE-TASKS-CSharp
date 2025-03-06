using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3005
{
    /*
     3005. Подсчитывать элементы с максимальной частотой
    Вам выдается массив, nums состоящий из положительных целых чисел.
    Верните общую сумму частот элементов, nums чтобы все эти элементы имели максимальную частоту.
    Частота элемента — это количество вхождений этого элемента в массив.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 100
    https://leetcode.com/problems/count-elements-with-maximum-frequency/description/
     */
    public class Task3005 : InfoBasicTask
    {
        public Task3005(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 2, 3, 1, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int countElements = maxFrequencyElements(nums);
                Console.WriteLine($"Общая сумма частот элементов, имеющух наибольшую частоту = {countElements}");
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
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxFrequencyElements(int[] nums)
        {
            int max = 0;
            Dictionary<int,int> dict= new Dictionary<int,int>();
            foreach (int num in nums) {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
                if (dict[num] > max)
                {
                    max = dict[num];
                }
            }
            return max* dict.Where(x => x.Value == max).Count();
        }
    }
}
