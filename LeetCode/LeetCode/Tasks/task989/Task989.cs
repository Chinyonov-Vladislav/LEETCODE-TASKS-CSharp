using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task989
{
    /*
     989. Сложение числа в форме массива и числа (int)
    Массивная форма целого числа num — это массив, представляющий его цифры в порядке слева направо.
        Например, для num = 1321 форма массива равна [1,3,2,1].
    Учитывая num, массивную форму целого числа и целое число k, возвращают массивную форму целого числа num + k.
    https://leetcode.com/problems/add-to-array-form-of-integer/description/
     */
    public class Task989 : InfoBasicTask
    {
        public Task989(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 1, 5 };
            int k = 806;
            printArray(nums, "Исходный массив: ");
            Console.WriteLine($"k = {k}");
            IList<int> result = addToArrayForm(nums, k);
            printIListInt(result, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> addToArrayForm(int[] num, int k)
        {
            IList<int> result = new List<int>();
            int index = num.Length - 1;
            bool hasOverflow = false;
            while (k != 0 || index >= 0)
            {
                int remain = k % 10;
                int digit = index >= 0 ? remain + num[index]: remain;
                if (hasOverflow)
                {
                    digit++;
                }
                if (digit > 10)
                {
                    hasOverflow = true;
                    result.Add(digit % 10);
                }
                else if (digit == 10)
                {
                  hasOverflow = true;
                  result.Add(0);
                }
                else
                {
                    hasOverflow = false;
                    result.Add(digit);
                }
                index--;
                k /= 10;
                Console.WriteLine(k.ToString());
            }
            if (hasOverflow)
            {
                result.Add(1);
            }
            int left = 0;
            int right = result.Count-1;
            while (left < right)
            {
                (result[left], result[right] ) = (result[right], result[left]);
                left++;
                right--;
            }
            return result;
        }
        private IList<int> bestSolution(int[] num, int k)
        {
            List<int> res = new List<int>();
            int carry = k, i = num.Length - 1;
            while (i >= 0 || carry > 0)
            {
                if (i >= 0)
                {
                    carry += num[i];
                    i--;
                }
                res.Add(carry % 10);
                carry /= 10;
            }
            res.Reverse();
            return res;
        }
    }
}
