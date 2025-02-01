using System;
using LeetCode.Basic;

namespace LeetCode.Tasks.Task88
{
    public class Task88 : InfoBasicTask
    {
        public Task88(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] { -1, 3, 0, 0, 0, 0, 0 };
            int m =2;
            int[] nums2 = new int[] { 0, 0, 1, 2, 3 };
            int n = 5;
            merge(nums1, m, nums2, n);
            printFinalArray(nums1);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private void printFinalArray(int[] nums)
        {
            Console.Write("Финальный массив: ");
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write($"[{nums[i]}, ");
                }
                else if (i == nums.Length - 1)
                {
                    Console.Write($"{nums[i]}]\n");
                }
                else
                {
                    Console.Write($"{nums[i]}, ");
                }
            }
        }
        private void merge(int[] nums1, int m, int[] nums2, int n) // my solution
        {
            if (m + n != nums1.Length || n==0)
            {
                return;
            }
            if (m == 0)
            {
                for (int i = 0; i < nums2.Length; i++)
                {
                    nums1[i] = nums2[i];
                }
                return;
            }
            for (int indexNums2 = 0; indexNums2 < nums2.Length; indexNums2++)
            {
                int positionForNumber = 0;
                for (int indexNums1 = 0; indexNums1 < nums1.Length; indexNums1++)
                {
                    if ((nums1[indexNums1] == 0 && indexNums1 >= m+indexNums2) || 
                        (indexNums1 == 0 && nums2[indexNums2] <= nums1[indexNums1]) ||
                        (indexNums1 == nums1.Length - 1 && nums2[indexNums2] >= nums1[indexNums1]) ||
                        (indexNums1 > 0 && nums2[indexNums2] >= nums1[indexNums1 - 1] && nums2[indexNums2] <= nums1[indexNums1]))
                    {
                        positionForNumber = indexNums1;
                        break;
                    }
                }
                for (int indexNums1 = nums1.Length - 1; indexNums1 > positionForNumber; indexNums1--)
                {
                    nums1[indexNums1] = nums1[indexNums1 - 1];
                }
                nums1[positionForNumber] = nums2[indexNums2];
            }
        }
    }
}
