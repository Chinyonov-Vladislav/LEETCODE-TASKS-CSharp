using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task738
{
    /*
     738. Монотонно увеличивающиеся цифры
    Целое число имеет монотонно возрастающие цифры тогда и только тогда, когда каждая пара соседних цифр x и y удовлетворяет x <= y.
    Учитывая целое число n, верните наибольшее число, которое меньше или равно n с монотонно возрастающими цифрами.
    Ограничения:
        0 <= n <= 10^9
    https://leetcode.com/problems/monotone-increasing-digits/description/
     */
    public class Task738 : InfoBasicTask
    {
        public Task738(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 332;
            Console.WriteLine($"Исходное число = {number}");
            if (isValid(number))
            {
                int res = monotoneIncreasingDigits(number);
                Console.WriteLine($"Наибольшее число, которое меньше или равно {number} с монотонно возрастающими цифрами = {res}");
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
        private bool isValid(int n)
        {
            int lowLimit = 0;
            int highLimit = (int)Math.Pow(10,9);
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int monotoneIncreasingDigits(int n)
        {
            List<int> digits = new List<int>();
            if (n == 0)
            {
                return 0;
            }
            else
            {
                int copyN = n;
                while (copyN != 0)
                {
                    digits.Add(copyN % 10);
                    copyN /= 10;
                }
                digits.Reverse();
                if (isMonotoneIncreasingDigits(digits))
                {
                    return n;
                }
            }
            int res = 0;
            for (int i = 0; i < digits.Count; i++)
            {
                res = n-n % (int)Math.Pow(10, i) - 1;
                List<int> digitsRes = new List<int>();
                int copyRes = res;
                while (copyRes != 0)
                {
                    digitsRes.Add(copyRes % 10);
                    copyRes /= 10;
                }
                digitsRes.Reverse();
                if (isMonotoneIncreasingDigits(digitsRes))
                {
                    break;
                }
            }
            return res;
        }
        private bool isMonotoneIncreasingDigits(List<int> digits)
        {
            if (digits.Count == 1)
            {
                return true;
            }
            for (int i = 0; i < digits.Count - 1; i++)
            {
                if (!(digits[i] <= digits[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
