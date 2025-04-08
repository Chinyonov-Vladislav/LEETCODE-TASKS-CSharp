using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task852
{
    /*
     852. Индекс пика в горном массиве
    Вам дан целочисленный массив горных вершинarr длиной n, в котором значения увеличиваются до пикового элемента, а затем уменьшаются.
    Возвращает индекс элемента peak.
    Ваша задача - решить ее за O(log(n)) время сложности.
    Ограничения:
        3 <= arr.length <= 10^5
        0 <= arr[i] <= 10^6
        arr это гарантированно будет горный массив.
    https://leetcode.com/problems/peak-index-in-a-mountain-array/description/
     */
    public class Task852 : InfoBasicTask
    {
        public Task852(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 24, 69, 100, 99, 79, 78, 67, 35, 26, 19 };
            printArray(arr, "Горный массив: ");
            if (isValid(arr))
            {
                int indexPeak = peakIndexInMountainArray(arr);
                Console.WriteLine($"Индекс пика в горном массиве = {indexPeak}");
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
        private bool isValid(int[] arr)
        {
            int lowLimitLengthArr = 3;
            int highLimitLengthArr = (int)Math.Pow(10, 5);
            int lowLimitValueItemArr = 0;
            int highLimitValueItemArr = (int)Math.Pow(10,6);
            if (arr.Length < lowLimitLengthArr || arr.Length > highLimitLengthArr)
            {
                return false;
            }
            foreach (int item in arr)
            {
                if (item < lowLimitValueItemArr || item > highLimitValueItemArr)
                {
                    return false;
                }
            }
            bool isFind = false;
            List<int> before = new List<int>();
            List<int> after = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    before.Add(arr[j]);
                }
                for (int j = i; j < arr.Length; j++)
                {
                    after.Add(arr[j]);
                }
                bool isIncreasingBefore = isStrictlyIncreasing(before);
                bool isDecreaingAfter = isStrictlyDecreasing(after);
                isFind = isIncreasingBefore && isDecreaingAfter;
                if (isFind)
                {
                    break;
                }
                before.Clear();
                after.Clear();
            }
            if (!isFind)
            {
                Console.WriteLine("СУКАА");
                return false;
            }
            return true;
        }


        private bool isStrictlyIncreasing(List<int> sequence)
        {
            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] <= sequence[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        private bool isStrictlyDecreasing(List<int> sequence)
        {
            for (int i = 0; i < sequence.Count-1; i++)
            {
                if (sequence[i] <= sequence[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
        private int peakIndexInMountainArray(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            int index = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (mid == 0)
                {
                    if (arr[mid] > arr[mid + 1])
                    {
                        index = mid;
                        break;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else if (mid == arr.Length - 1)
                {
                    if (arr[mid] > arr[mid - 1])
                    {
                        index = mid;
                        break;
                    }
                    else
                    { 
                        right = mid - 1;
                    }
                }
                else
                {
                    if (arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1])
                    {
                        index = mid;
                        break;
                    }
                    else if (arr[mid] < arr[mid - 1] && arr[mid] > arr[mid + 1])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }
            return index;
        }
    }
}
