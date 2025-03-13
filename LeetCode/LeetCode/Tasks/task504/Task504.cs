using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task504
{
    /*
     504. Основание 7
    Учитывая целое число num, верните строку егопредставления в системе счисления с основанием 7.
    Ограничения:
        -10^7 <= num <= 10^7
    https://leetcode.com/problems/base-7/description/
     */
    public class Task504 : InfoBasicTask
    {
        public Task504(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int num = 100;
            Console.WriteLine($"Исходное число = {num}");
            if (isValid(num))
            {
                string res = convertToBase7(num);
                Console.WriteLine($"Число {num} в 7-ричной системе счисления = {res}");
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
        private bool isValid(int num)
        {
            int lowLimit = (int)Math.Pow(-10, 7);
            int highLimit = (int)Math.Pow(10, 7);
            if (num < lowLimit || num > highLimit)
            {
                return false;
            }
            return true;
        }
        private string convertToBase7(int num)
        {
            if (num == 0)
            {
                return "0";
            }
            StringBuilder stringBuilder = new StringBuilder();
            bool isNegative = false;
            if (num < 0)
            {
                isNegative = true;
                num *= -1;
            }
            while (num != 0)
            {
                int remain = num % 7;
                num /= 7;
                stringBuilder.Append($"{remain}");
            }
            char[] chars = stringBuilder.ToString().ToCharArray();
            int left = 0;
            int right = chars.Length - 1;
            while (left < right)
            {
                (chars[right], chars[left]) = (chars[left], chars[right]);
                left++;
                right--;
            }
            string result = new string(chars);
            if (isNegative)
            {
                result = $"-{result}";
            }
            return result;
        }
    }
}
