using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task503
{
    /*
     503. Следующий важный элемент II
    Учитывая круговой массив целых чисел nums (т.е. Следующим элементом nums[nums.length - 1] является nums[0]), верните следующее большее число для каждого элемента в nums.
    Следующее большее число за числом x — это первое большее число, следующее за ним в порядке обхода массива, то есть вы можете выполнить круговой поиск, чтобы найти следующее большее число. Если его не существует, верните -1 для этого числа.
     Ограничения:
        1 <= nums.length <= 10^4
        -10^9 <= nums[i] <= 10^9
    https://leetcode.com/problems/next-greater-element-ii/description/
     */
    public class Task503 : InfoBasicTask
    {
        public Task503(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int[] res = nextGreaterElements(nums);
                printArray(res, "Результирующий массив: ");
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
            int highLimit = (int)Math.Pow(10, 4);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1*(int)Math.Pow(10, 9);
            highLimit = (int)Math.Pow(10, 9);
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] nextGreaterElements(int[] nums)
        {
            int[] res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int index = i + 1; ; index++)
                { 
                    int valueIndex = index % nums.Length;
                    if (valueIndex == i)
                    {
                        res[i] = -1;
                        break;
                    }
                    if (nums[valueIndex] > nums[i])
                    {
                        res[i] = nums[valueIndex];
                        break;
                    }
                }
            }
            return res;
        }

        // скопировано с leetcode
        public int[] bestSolution(int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            int n = nums.Length;
            int[] ans = new int[n];
            for (int i = 0; i < 2 * n; i++)
            {
                if (i < n)
                {
                    if (stack.Count == 0 || nums[stack.Peek()] > nums[i])
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
                        {
                            ans[stack.Pop()] = nums[i];
                        }
                        stack.Push(i);
                    }
                }
                else
                {
                    while (stack.Count > 0 && nums[stack.Peek()] < nums[i % n])
                    {
                        ans[stack.Pop()] = nums[i % n];
                    }
                }

            }
            while (stack.Count > 0)
            {
                ans[stack.Pop()] = -1;
            }
            return ans;
        }
    }
}
