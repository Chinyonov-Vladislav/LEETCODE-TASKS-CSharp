using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task260
{
    /*
     260. Одиночный Номер III
    Дан целочисленный массив nums, в котором ровно два элемента встречаются только один раз, а все остальные элементы встречаются ровно два раза. 
    Найдите два элемента, которые встречаются только один раз. Вы можете вернуть ответ в любом порядке.
    Вы должны написать алгоритм, который работает с линейной временной сложностью и использует только постоянное дополнительное пространство.
    Ограничения:
        2 <= nums.length <= 3 * 10^4
        -2^31 <= nums[i] <= 2^31 - 1
        Каждое целое число в nums появится дважды, только два целых числа появятся один раз.
    https://leetcode.com/problems/single-number-iii/description/
     */
    public class Task260 : InfoBasicTask
    {
        public Task260(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 1, 3, 2, 5 };
            printArray(nums);
            if (isValid(nums))
            {
                int[] result = singleNumber(nums);
                Console.WriteLine($"Первый элемент, который встречается единожды = {result[0]}\nВторой элемент, который встречается единожды = {result[1]}");
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
            int lowLimit = 2;
            int highLimit = 3*(int)Math.Pow(10,4);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
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
            int countElementsOne = 0;
            foreach (var pair in dict)
            {
                if (pair.Value == 1)
                {
                    countElementsOne++;
                }
                else if (pair.Value != 2)
                {
                    return false;
                }
            }
            if (countElementsOne != 2)
            {
                return false;
            }
            return true;
        }
        private int[] singleNumber(int[] nums)
        {
            int index = 0;
            int[] result = new int[2];
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    if (nums[i] != nums[i + 1])
                    {
                        result[index] = nums[i];
                        index++;
                    }
                }
                else if (i == nums.Length - 1)
                {
                    if (nums[i] != nums[i - 1])
                    {
                        result[index] = nums[i];
                        index++;
                    }
                }
                else
                {
                    if (nums[i] != nums[i - 1] && nums[i] != nums[i + 1])
                    {
                        result[index] = nums[i];
                        index++;
                    }
                }
            }
            return result;
        }
    }
}
