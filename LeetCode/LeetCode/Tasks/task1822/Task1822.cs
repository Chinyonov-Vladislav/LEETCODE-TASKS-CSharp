using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1822
{
    /*
     1822. Знак произведения массива
    Реализуйте функцию signFunc(x) , которая возвращает:
        1 если x является положительным.
        -1 если x отрицательно.
        0 если x равно 0.
    Вам дан целочисленный массив nums. Пусть product будет произведением всех значений в массиве nums.
    Возврат signFunc(product).
    https://leetcode.com/problems/sign-of-the-product-of-an-array/description/
     */
    public class Task1822 : InfoBasicTask
    {
        public Task1822(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { -1, 1, -1, 1, -1 };
            printArray(arr, "Исходный массив: ");
            int result = arraySign(arr);
            Console.WriteLine(result == 0 ? "Произведение элементов массива равно 0" : result == -1 ? "Произведение элементов массива является отрицательным" : "Произведение элементов массива является положительным");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int arraySign(int[] nums)
        {
            int countNegative = 0;
            foreach (int item in nums)
            {
                if (item == 0)
                {
                    return 0;
                }
                if(item < 0)
                {
                    countNegative++;
                }
            }
            if (countNegative % 2 != 0)
            {
                return -1;
            }
            return 1;
        }
    }
}
