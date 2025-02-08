using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1608
{
    /*
     1608. Специальный массив с X элементами, превышающими или равными X
    Вам предоставляется массив nums неотрицательных целых чисел. nums считается особенным, если существует число x такое, что в нем есть ровно x числа, nums которые больше или равны x.
    Обратите внимание, что x не обязательно должно быть элементом в nums.
    Верните x если массив является специальным, в противном случае верните -1. Можно доказать, что если nums является специальным, то значение x уникально.
    https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/description/
     */
    public class Task1608 : InfoBasicTask
    {
        public Task1608(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 3, 5 };
            printArray(array, "Исходный массив: ");
            int result = specialArray(array);
            Console.WriteLine(result == -1 ? "Исходный массив не является специальным" : $"Исходный массив является специальным. X = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int specialArray(int[] nums)
        {
            for (int num = 0; num <= nums.Length; num++)
            {
                int countGreater = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] >= num)
                    {
                        countGreater++;
                    }
                }
                if (num == countGreater)
                {
                    return num;
                }
            }
            return -1;
        }
    }
}
