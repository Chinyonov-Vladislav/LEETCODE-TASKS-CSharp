using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2980
{
    /*
     2980. Проверьте, есть ли в побитовом ИЛИ конечные нули
    Вам предоставляется массив положительных целых чисел nums.
    Вам нужно проверить, можно ли выбрать два или более элементов в массиве таким образом, чтобы побитовое OR выбранных элементов имело хотя бы один конечный ноль в двоичном представлении.
        Например, двоичное представление 5, которое равно "101", не содержит конечных нулей, в то время как двоичное представление 4, которое равно "100", содержит два конечных нуля.
    Верните true если можно выбрать два или более элементов, которые побитово OR имеют конечные нули, верните false в противном случае.
    Ограничения:
        2 <= nums.length <= 100
        1 <= nums[i] <= 100
    https://leetcode.com/problems/check-if-bitwise-or-has-trailing-zeros/description/
     */
    public class Task2980 : InfoBasicTask
    {
        public Task2980(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5 };
            printArray(nums);
            if (isValid(nums))
            {
                Console.WriteLine(hasTrailingZeros(nums) ? "Исходные массив содержит два или более элементов, для которых результат побитового OR имеее конечные нули" : "Исходные массив не содержит два или более элементов, для которых результат побитового OR имеее конечные нули");
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
        private bool isValid(int[] nums)
        {
            if (nums.Length < 2 || nums.Length > 100)
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
        private bool hasTrailingZeros(int[] nums)
        {
            int countEvenElements = 0;
            foreach (int num in nums)
            {
                if (num % 2 == 0)
                {
                    countEvenElements++;
                    if (countEvenElements == 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
