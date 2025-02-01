using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task34
{
    public class Task34 : InfoBasicTask
    {
        public Task34(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 5, 7, 7, 8, 8, 10 };
            int target = 8;
            printArray("Исходный массив", nums);
            if (isSorted(nums))
            {
                int[] result = searchRange(nums, target);
                printArray("Результат",result);
            }
            else
            {
                Console.WriteLine("Исходный массив не отсортирован по возрастанию");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isSorted(int[] nums)
        {
            if (nums.Length >= 2)
            {
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] < nums[i - 1])
                    {
                        return false;
                    }
                }
            }
            return true;   
        }
        private int[] searchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return new int[] { -1, -1 };
            }
            if (nums.Length == 1)
            {
                if (nums[0] == target)
                {
                    return new[] { 0,0 };
                }
                return new int[] { -1, -1 };
            }
            int left = 0;
            int right = nums.Length - 1;
            int[] result = new int[] { -1,-1 };
            while (left <= right) {
                if (nums[left] == target)
                {
                    result[0] = left;
                }
                if (nums[right] == target)
                {
                    result[1] = right;
                }
                if (result[0] == -1)
                {
                    left++;
                }
                if (result[1] == -1)
                {
                    right--;
                }
                if (result[0] != -1 && result[1] != -1)
                {
                    break;
                }
            }
            if (result[0] == -1 && result[1] != -1)
            {
                result[0] = result[1];
            }
            else if (result[0] != -1 && result[1] == -1)
            {
                result[1] = result[0];
            }
            return result;
        }
        private void printArray(string prefix, int[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write($"{prefix}: [{result[i]},");
                }
                else if (i == result.Length - 1)
                {
                    Console.Write($"{result[i]}]\n");
                }
                else 
                {
                    Console.Write($"{result[i]}, ");
                }
            }
        }
        private int[] bestSolution(int[] nums, int target) // copy from leetcode
        {
            int[] res = new int[] { -1, -1 };
            // We use binary search to look for the first occurance of target, and binary search to look for last occurance of target

            int l = 0;
            int r = nums.Length - 1;

            // First occurance
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] == target)
                {
                    res[0] = mid;
                    r = mid - 1;
                }
                else if (nums[mid] > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            l = 0;
            r = nums.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] == target)
                {
                    res[1] = mid;
                    l = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return res;
        }
    }
}
