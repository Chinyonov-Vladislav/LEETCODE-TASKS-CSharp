using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task560
{
    /*
     560. Сумма подмассива равна K
    Учитывая массив целых чисел nums и целое число k, верните общее количество подмассивов, сумма которых равна k.
    Подмассив — это непрерывная непустая последовательность элементов внутри массива.
    Ограничения:
        1 <= nums.length <= 2 * 10^4
        -1000 <= nums[i] <= 1000
        -10^7 <= k <= 10^7
    https://leetcode.com/problems/subarray-sum-equals-k/description/
     */
    public class Task560 : InfoBasicTask
    {
        private enum TypeSolution
        {
            None = 0,
            Slow = 1,
            Optimized = 2,
            Both = 3
        }
        public Task560(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1,1,1 };
            int k = 2;
            printArray(nums);
            Console.WriteLine($"Сумма искомых подмассивов = {k}");
            if (isValid(nums, k))
            {
                TypeSolution typeSolution = askUserTypeSolution();
                int res = 0;
                switch (typeSolution)
                {
                    case TypeSolution.Slow:
                        res = subarraySum(nums, k);
                        Console.WriteLine($"Решение с помощью медленного метода: количество подмассивов с суммой равной {k} = {res}");
                        break;
                    case TypeSolution.Optimized:
                        res = subarraySumOptimized(nums, k);
                        Console.WriteLine($"Решение с помощью оптимизированного метода: количество подмассивов с суммой равной {k} = {res}");
                        break;
                    case TypeSolution.Both:
                        res = subarraySum(nums, k);
                        Console.WriteLine($"Решение с помощью медленного метода: количество подмассивов с суммой равной {k} = {res}");
                        res = subarraySumOptimized(nums, k);
                        Console.WriteLine($"Решение с помощью оптимизированного метода: количество подмассивов с суммой равной {k} = {res}");
                        break;
                }
                
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
        private bool isValid(int[] nums, int k)
        {
            int lowLimitLengthNums = 1;
            int highLimitLengthNum = 2 * (int)Math.Pow(10, 4);
            int lowLimitValueNum = -1000;
            int highLimitValueNum = 1000;
            int lowLimitValueK = -1 * (int)Math.Pow(10, 7);
            int highLimitValueK = (int)Math.Pow(10, 7);
            if (nums.Length < lowLimitLengthNums || nums.Length > highLimitLengthNum || k < lowLimitValueK || k > highLimitValueK)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < lowLimitValueNum || num > highLimitValueNum)
                {
                    return false;
                }
            }
            return true;
        }
        private int subarraySum(int[] nums, int k)
        {
            int total = 0;
            int currentPrefixSum = 0;
            int[] prefix = new int[nums.Length + 1];
            prefix[0] = 0;
            for (int i = 0; i< nums.Length; i++)
            {
                currentPrefixSum+= nums[i];
                prefix[i+1] = currentPrefixSum;
                int remain = currentPrefixSum - k;
                for (int j = 0; j < i + 1; j++)
                {
                    if (prefix[j] == remain)
                    {
                        total++;
                    }
                }
            }
            return total;
        }
        private int subarraySumOptimized(int[] nums, int k)
        {
            int total = 0;
            int currentPrefixSum = 0;
            Dictionary<int,int> freqPrefixSum = new Dictionary<int,int>();
            freqPrefixSum.Add(0, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                currentPrefixSum += nums[i];
                int remain = currentPrefixSum - k;
                if (freqPrefixSum.ContainsKey(remain))
                {
                    total+= freqPrefixSum[remain];
                }
                if (freqPrefixSum.ContainsKey(currentPrefixSum))
                {
                    freqPrefixSum[currentPrefixSum]++;
                }
                else
                {
                    freqPrefixSum.Add(currentPrefixSum, 1);
                }
            }
            return total;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Медленный\n" +
                    "2 - Оптимизированный\n" +
                    "3 - Протестировать оба варианта\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 3)
                    {
                        throw new FormatException();
                    }
                    switch (choiceUser)
                    {
                        case 0:
                            return TypeSolution.None;
                        case 1:
                            return TypeSolution.Slow;
                        case 2:
                            return TypeSolution.Optimized;
                        case 3:
                            return TypeSolution.Both;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }
    }
}
