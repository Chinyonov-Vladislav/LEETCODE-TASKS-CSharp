using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2160
{
    /*
     2160. Минимальная сумма четырёхзначного числа после разделения цифр
    Вам дано положительное целое число num, состоящее ровно из четырёх цифр. Разделите num на два новых целых числа new1 и new2 с помощью цифр, содержащихся в num. Ведущие нули допустимы в new1 и new2, и все цифры, содержащиеся в num, должны быть использованы.
        Например, если у вас есть num = 2932, то у вас есть следующие цифры: две 2, одна 9 и одна 3. Некоторые из возможных пар [new1, new2] — это [22, 93], [23, 92], [223, 9] и [2, 329].
    Верните минимально возможную сумму new1 и new2.
    https://leetcode.com/problems/minimum-sum-of-four-digit-number-after-splitting-digits/description/
     */
    public class Task2160 : InfoBasicTask
    {
        public Task2160(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 2002;
            Console.WriteLine($"Исходное число = {number}");
            if (isCorrect(number))
            {
                
            }
            else
            {
                Console.WriteLine($"Некорректное исходое значение. Значение должно быть в диапазоне от 1000 до 9999");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isCorrect(int num)
        {
            if (num < 1000 || num > 9999)
            {
                return false;
            }
            return true;
        }
        private int minimumSum(int num)
        {
            int[] digits = new int[4];
            int index = 0;
            while (num != 0)
            {
                digits[index] = num % 10;
                num /= 10;
                index++;
            }
            Array.Sort(digits);
            int firstNumber = digits[0]*10+digits[2];
            int secondNumber = digits[1] * 10 + digits[3];
            return firstNumber + secondNumber;
        }
    }
}
