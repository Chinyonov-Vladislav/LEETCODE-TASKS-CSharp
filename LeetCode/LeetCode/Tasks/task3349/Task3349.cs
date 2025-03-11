using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3349
{
    /*
     3349. Обнаружение соседних увеличивающихся подмассивов I
    Дан массив nums из n целых чисел и целое число k. Определите, существуют ли два смежных подмассива длиной k такие, что оба подмассива строго возрастают. В частности, проверьте, есть ли два подмассива, начинающихся с индексов a и b (a < b), где:
        Оба подмассива nums[a..a + k - 1] и nums[b..b + k - 1] строго увеличиваются.
        Подмассивы должны быть смежными, что означает b = a + k
    Верните true, если возможно найти два таких подмассива, и false в противном случае.
    Ограничения:
        2 <= nums.length <= 100
        1 < 2 * k <= nums.length
        -1000 <= nums[i] <= 1000
    https://leetcode.com/problems/adjacent-increasing-subarrays-detection-i/description/
     */
    public class Task3349 : InfoBasicTask
    {
        public Task3349(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<int> nums = new List<int>() { 2, 5, 7, 8, 9, 2, 3, 4, 3, 1 };
            int k = 3;
            printIListInt(nums);
            Console.WriteLine($"Длина подмассива = {k}");
            if (isValid(nums, k))
            {
                Console.WriteLine(hasIncreasingSubarrays(nums, k) ? $"Существует два строго возрастающих смежных подмассива длиной {k}" : $"Не существует два строго возрастающих смежных подмассива длиной {k}");
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
        private bool isValid(IList<int> nums, int k)
        {
            if (nums.Count < 2 || nums.Count > 100 || !(2 * k > 1 && 2 * k <= nums.Count))
            {
                return false;
            }
            foreach (int item in nums)
            {
                if (item < -1000 || item > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private bool hasIncreasingSubarrays(IList<int> nums, int k)
        {
            for (int i = 0; i <= nums.Count - k*2; i++)
            {
                bool isFirstIncreasing = true;
                bool isSecondIncreasing = true;
                for (int j = i + 1; j < i + k; j++)
                {
                    if (nums[j] <= nums[j - 1])
                    {
                        isFirstIncreasing = false;
                        break;
                    }
                }
                for (int j = i + k+1; j < i + 2*k; j++)
                {
                    if (nums[j] <= nums[j - 1])
                    {
                        isSecondIncreasing = false;
                        break;
                    }
                }
                if (isFirstIncreasing && isSecondIncreasing)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
