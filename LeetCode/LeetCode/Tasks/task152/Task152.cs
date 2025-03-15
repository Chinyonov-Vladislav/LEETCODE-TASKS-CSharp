using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task152
{
    /*
     152. Максимальное значение произведения подмассива
    Дан целочисленный массив nums. Найдите подмассив, произведение элементов которого максимально, и верните это произведение.
    Тестовые примеры генерируются таким образом, чтобы ответ помещался в 32-битное целое число.
    Ограничения:
        1 <= nums.length <= 2 * 10^4
        -10 <= nums[i] <= 10
        Произведение любого подмассива numsгарантированно поместится в 32-битное целое число.
    https://leetcode.com/problems/maximum-product-subarray/description/
     */
    public class Task152 : InfoBasicTask
    {
        public Task152(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 2, 3, -2, 4 };
            printArray(arr);
            if (isValid(arr))
            {
                int max = maxProduct(arr);
                int max2 = longDecisionMaxProduct(arr);
                Console.WriteLine($"Максимальное значение произведения подмассива (быстрый алгоритм) = {max}");
                Console.WriteLine($"Максимальное значение произведения подмассива (медленный алгоритм) = {max2}");
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
            int highLimit = 2 * (int)Math.Pow(10, 4);
            if (nums.Length < 1 || nums.Length > highLimit)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < -10 || num > 10)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxProduct(int[] nums) // при помощи DeepSeek
        {
            int maxProd = nums[0];
            int minProd = nums[0];
            int result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    (minProd, maxProd) = (maxProd, minProd);
                }
                maxProd = Math.Max(nums[i], maxProd * nums[i]);
                minProd = Math.Min(nums[i], minProd * nums[i]);
                result = Math.Max(result, maxProd);
            }
            return result;
        }
        private int longDecisionMaxProduct(int[] nums)
        {
            int max = 1;
            foreach (int num in nums)
            {
                max *= num;
            }
            int length = nums.Length;
            while (length >= 1)
            {
                for (int i = 0; i <= nums.Length - length; i++)
                {
                    int localMax = 1;
                    for (int j = i; j < i + length; j++)
                    {
                        localMax *= nums[j];
                        if (localMax > max)
                        {
                            max = localMax;
                        }
                    }
                }
                length--;
            }
            return max;
        }
    }
}
