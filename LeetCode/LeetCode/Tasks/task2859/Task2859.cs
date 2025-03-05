using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2859
{
    /*
     2859. Сумма значений в индексах с установленными битами K
    Вам дан нумерованный от 0 целочисленный массив nums и целое число k.
    Возвращает целое число, обозначающее сумму элементов, в nums которых соответствующие индексы имеют точно k установленные биты в их двоичном представлении.
    Установленные биты в целочисленном значении — это 1's, присутствующие в двоичной записи.
    Например, двоичное представление 21 — это 10101, в котором 3 установленных битов.
    Ограничения:
        1 <= nums.length <= 1000
        1 <= nums[i] <= 105
        0 <= k <= 10
    https://leetcode.com/problems/sum-of-values-at-indices-with-k-set-bits/description/
     */
    public class Task2859 : InfoBasicTask
    {
        public Task2859(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<int> nums = new List<int>() { 5, 10, 1, 5, 2 };
            int k = 1;
            printIListInt(nums, "Исходный массив: ");
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(nums, k))
            {
                int res = sumIndicesWithKSetBits(nums, k);
                Console.WriteLine($"Сумма чисел с установленным {k} битами = {res}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(IList<int> nums, int k)
        {
            if (nums.Count < 1 || nums.Count > 1000)
            {
                return false;
            }
            int highLimit = (int)Math.Pow(10, 5);
            foreach (int num in nums) {
                if (num < 1 || num > highLimit)
                {
                    return false;
                }
            }
            if (k < 0 || k > 10)
            {
                return false;
            }
            return true;
        }
        private int sumIndicesWithKSetBits(IList<int> nums, int k)
        {
            int sum = 0;
            for (int index = 0; index<nums.Count;index++) {
                int currentNumber = index;
                int countOfBitsOne = 0;
                while (currentNumber != 0)
                {
                    int bit = currentNumber & 1;
                    if (bit==1)
                    {
                        countOfBitsOne++;
                    }
                    currentNumber  >>= 1;
                }
                if (countOfBitsOne == k)
                {
                    sum += nums[index];
                }
            }
            return sum;
        }
    }
}
