using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1281
{
    /*
     1281. Вычитание произведения и суммы цифр целого числа
    Учитывая целое число n, верните разницу между произведением его цифр и суммой его цифр.
    https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/description/
     */
    public class Task1281 : InfoBasicTask
    {
        public Task1281(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 4421;
            Console.WriteLine($"Исходное число = {number}");
            int result = subtractProductAndSum(number);
            Console.WriteLine($"Разница между произведение и суммой цифр числа {number} = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int subtractProductAndSum(int n)
        {
            int sum = 0;
            int product = 1;
            while (n != 0)
            {
                int digit = n % 10;
                sum += digit;
                product*=digit;
                n /= 10;
            }
            return product - sum;
        }
    }
}
