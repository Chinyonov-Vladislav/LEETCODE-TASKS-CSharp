using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2169
{
    /*
     2169. Подсчитайте операции для получения нуля
    Вам даны два неотрицательных целых числа num1 и num2.
    В одной операции, если num1 >= num2, вы должны вычесть num2 из num1, в противном случае вычесть num1 из num2.
        Например, если num1 = 5 и num2 = 4, вычтем num2 из num1, получив num1 = 1 и num2 = 4. Однако если num1 = 4 и num2 = 5, после одной операции num1 = 4 и num2 = 1.
    Верните количество операций, необходимых для выполнения либо num1 = 0 или num2 = 0.
     */
    public class Task2169 : InfoBasicTask
    {
        public Task2169(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int num1 = 2;
            int num2 = 3;
            Console.WriteLine($"Первое число = {num1}\nВторое число = {num2}");
            int countOper = countOperations(num1, num2);
            Console.WriteLine($"Количество операций, чтобы одно из чисел было равно 0 = {countOper}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countOperations(int num1, int num2)
        {
            int countOperations = 0;
            while (num1 != 0 && num2 !=0)
            {
                if (num1 > num2)
                {
                    num1 -= num2;
                }
                else
                {
                    num2-= num1;
                }
                countOperations++;
            }
            return countOperations;
        }
    }
}
