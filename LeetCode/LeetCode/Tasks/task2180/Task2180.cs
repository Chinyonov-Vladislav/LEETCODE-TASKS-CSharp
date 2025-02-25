using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2180
{
    /*
     2180. Подсчитывайте целые числа с четной суммой цифр
    Для заданного положительного целого числа num верните количество положительных целых чисел,меньших или равных num сумма цифр которыхчётная.
    Сумма цифр положительного целого числа — это сумма всех его цифр.
    https://leetcode.com/problems/count-integers-with-even-digit-sum/description/
     */
    public class Task2180 : InfoBasicTask
    {
        public Task2180(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 30;
            Console.WriteLine($"Число = {number}");
            int count = countEven(number);
            Console.WriteLine($"Количество чисел с четной суммой цифр в диапазоне от 2 до {number} = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countEven(int num)
        {
            int count = 0;
            for (int i = 2; i <= num; i++)
            {
                int sum = 0;
                int currentIndex = i;
                while (currentIndex != 0)
                {
                    sum+= currentIndex % 10;
                    currentIndex /= 10;
                }
                if (sum % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
