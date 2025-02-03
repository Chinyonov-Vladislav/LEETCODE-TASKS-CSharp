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
            int num = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                num = (num * 2 + nums[i]) % 5;
                prefixes.Add(num == 0);
            }
            return prefixes;
        }
    }
}
