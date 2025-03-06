using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2932
{
    /*
     2932. Максимальная сильная пара XOR I
    Вам дан нумерованный с 0 целочисленный массив nums. Пара целых чисел x и y называется сильной парой, если она удовлетворяет условию:
        |x - y| <= min(x, y)
    Вам нужно выбрать два целых числа из nums так, чтобы они образовывали сильную пару, а их побитовое XOR было максимальным среди всех сильных пар в массиве.
    Возвращает максимальное XOR значение из всех возможных сильных пар в массиве nums.
    Обратите внимание, что вы можете выбрать одно и то же целое число дважды, чтобы сформировать пару.
    Ограничения:
        1 <= nums.length <= 50
        1 <= nums[i] <= 100
    https://leetcode.com/problems/maximum-strong-pair-xor-i/description/
     */
    public class Task2932 : InfoBasicTask
    {
        public Task2932(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5 };
            printArray(nums);
            if (isValid(nums))
            {
                int valXorMax = maximumStrongPairXor(nums);
                Console.WriteLine($"Максимальное XOR значение из всех возможных сильных пар в массиве = {valXorMax}");
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
            foreach (int num in nums) {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int maximumStrongPairXor(int[] nums)
        {
            List<int> xorValues = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) <= Math.Min(nums[i], nums[j]))
                    {
                        int xorValue = nums[i] ^ nums[j];
                        if (xorValues.Count == 0)
                        {
                            xorValues.Add(xorValue);
                        }
                        else if(xorValue > xorValues[0])
                        {
                            xorValues[0] = xorValue;
                        }
                    }
                }
            }
            return xorValues[0];
        }
    }
}
