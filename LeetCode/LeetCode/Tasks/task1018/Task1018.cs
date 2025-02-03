using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1018
{
    /*
     1018. Двоичный префикс, делимый на 5
    Вам будет предоставлен двоичный массив nums (с индексом 0).
    Мы определяем xi как число, двоичным представлением которого является подмассив nums[0..i] (от старшего бита к младшему).
        Например, если nums = [1,0,1], то x0 = 1, x1 = 2 и x2 = 5.
    Возвращает массив логических значений, answer где answer[i] это true если xi делится на 5.
    https://leetcode.com/problems/binary-prefix-divisible-by-5/description/
     */
    public class Task1018 : InfoBasicTask
    {
        public Task1018(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 0,1,1 };
            printArray(nums, "Исходный бинарный массив: ");
            IList<bool> prefixiesBool = prefixesDivBy5(nums);
            printIListBool(prefixiesBool, "Двоичный префикс делится на 5: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<bool> prefixesDivBy5(int[] nums)
        {
            IList<bool> prefixes = new List<bool>();
            int allValue = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                prefixes.Add(false);
            }
            for(int index = 0; index< nums.Length;index++)
            {
                if (nums[index] == 1)
                {
                    allValue += (int)Math.Pow(2, nums.Length - index - 1);
                }
                Console.WriteLine($"{allValue}");
            }
            for (int i = nums.Length -1; i >= 0; i--)
            {
                prefixes[i] = allValue % 5 == 0;
                if (nums[i] == 1)
                {
                    allValue -= (int)Math.Pow(2, nums.Length - i - 1);
                }
            }
            return prefixes;
        }
    }
}
