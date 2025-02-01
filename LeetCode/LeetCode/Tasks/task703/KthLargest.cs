using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task703
{
    public class KthLargest
    {
        private int k;
        private int[] nums;
        public KthLargest(int k, int[] nums)
        {
            this.k = k;
            Array.Sort(nums);
            this.nums = nums;
        }

        public int Add(int val)
        {
            int[] copyNums = new int[nums.Length+1];
            int left = 0, right = nums.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] < val)
                    left = mid + 1;
                else
                    right = mid;
            }
            for (int i = 0; i < copyNums.Length; i++)
            {
                if (i == left)
                {
                    copyNums[i] = val;
                }
                else if (i < left)
                {
                    copyNums[i] = nums[i];
                }
                else
                {
                    copyNums[i] = nums[i-1];
                }
            }
            nums = copyNums;
            return copyNums[copyNums.Length-k];
        }
    }
}
