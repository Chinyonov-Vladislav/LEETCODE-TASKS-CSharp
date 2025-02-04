using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1342
{
    /*
     1342. Количество шагов для уменьшения числа до нуля
    Учитывая целое число num, верните количество шагов, необходимых для уменьшения его до нуля.
    Если текущее число чётное, то нужно разделить его на 2, в противном случае нужно вычесть из него 1.
    https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/description/
     */
    public class Task1342 : InfoBasicTask
    {
        public Task1342(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 14;
            Console.WriteLine($"Исходное число = {number}");
            Console.WriteLine($"Количество шагов для превращения {number} в 0 = {numberOfSteps(number)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int numberOfSteps(int num)
        {
            int numberSteps = 0;
            while (num != 0)
            {
                if (num % 2 != 0)
                {
                    num--;
                }
                else
                {
                    num /= 2;
                }
                numberSteps++;
            }
            return numberSteps;
        }
    }
}
