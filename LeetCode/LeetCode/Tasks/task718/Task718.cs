using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task718
{
    /*
     718. Максимальная длина повторяющегося подмассива
    Учитывая два массива целых чисел nums1 и nums2, верните максимальную длину подмассива, которая отображается в обоих массивах.
    Ограничения:
        1 <= nums1.length, nums2.length <= 1000
        0 <= nums1[i], nums2[i] <= 100
    https://leetcode.com/problems/maximum-length-of-repeated-subarray/description/
     */
    public class Task718 : InfoBasicTask
    {
        public Task718(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums1 = new int[] { 1, 2, 3, 2, 1 };
            int[] nums2 = new int[] { 3, 2, 1, 4, 7 };
            printArray(nums1, "Массив №1: ");
            printArray(nums2, "Массив №2: ");
            if (isValid(nums1, nums2))
            {
                int res = findLength(nums1, nums2);
                Console.WriteLine($"Наибольшая длина подмассива, который существует в обоих исходных массивах = {res}");
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
        private bool isValid(int[] nums1, int[] nums2)
        {
            int lowLimit = 1;
            int highLimit = 1000;
            int lowLimitValueInArr = 0;
            int highLimitValueInArr = 100;
            if (nums1.Length < lowLimit || nums1.Length > highLimit || nums2.Length < lowLimit || nums2.Length > highLimit)
            {
                return false;
            }
            List<int[]> data = new List<int[]>() { nums1, nums2 };
            foreach (int[] arr in data)
            {
                foreach (int val in arr)
                {
                    if (val < lowLimitValueInArr || val > highLimitValueInArr)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int findLength(int[] nums1, int[] nums2)
        {
            int max = 0;
            int countRows = nums1.Length;
            int countColumns = nums2.Length;
            int[][] dp = new int[countRows][];
            for (int i = 0; i < countRows; i++)
            {
                dp[i] = new int[countColumns];
            }
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    if (indexRow == 0 || indexColumn == 0)
                    {
                        dp[indexRow][indexColumn] = nums1[indexRow] == nums2[indexColumn] ? 1 : 0;
                    }
                    else
                    {
                        if (nums1[indexRow] == nums2[indexColumn])
                        {
                            dp[indexRow][indexColumn] = dp[indexRow - 1][indexColumn - 1] + 1;
                        }
                        else
                        {
                            dp[indexRow][indexColumn] = 0;
                        }
                    }
                    if (dp[indexRow][indexColumn] > max)
                    {
                        max = dp[indexRow][indexColumn];
                    }
                }
            }
            return max;
        }
    }
}
