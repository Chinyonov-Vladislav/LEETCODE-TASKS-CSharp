using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3158
{
    /*
     3158. Найдите побитовое исключающее ИЛИ чисел, которые встречаются дважды
    Вам дан массив nums, в котором каждое число встречается либо один или два раза.
    Верните побитовое XOR объединение всех чисел, которые встречаются в массиве дважды, или 0, если ни одно число не встречается дважды.
    Ограничения:
        1 <= nums.length <= 50
        1 <= nums[i] <= 50
        Каждое число в nums появляется либо один, либо два раза.
    https://leetcode.com/problems/find-the-xor-of-numbers-which-appear-twice/description/
     */
    public class Task3158 : InfoBasicTask
    {
        public Task3158(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 2, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = duplicateNumbersXOR(nums);
                Console.WriteLine(res == 0 ? "В массиве нет значений, которые встречаются дважды" : $"Побитовое XOR объединение всех чисел, которые встречаются в массиве дважды, равно {res}");
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
            if (nums.Length < 1 || nums.Length > 50)
            {
                return false;
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums) {
                if (num < 1 || num > 50)
                {
                    return false;
                }
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                    if (dict[num] > 2)
                    {
                        return false;
                    }
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            return true;
        }
        private int duplicateNumbersXOR(int[] nums)
        {
            int number = 0;
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                if (set.Contains(num))
                {
                    number ^= num;
                }
                else
                {
                    set.Add(num);
                }
            }
            return number;
        }
    }
}
