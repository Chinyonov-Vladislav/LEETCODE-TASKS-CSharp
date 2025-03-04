using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2798
{
    /*
     2798. Количество сотрудников, достигших целевого показателя
    В компании n сотрудников, пронумерованных от 0 до n - 1. Каждый сотрудник i проработал в компании hours[i] часов.
    Компания требует, чтобы каждый сотрудник работал не менее target часов.
    Вам дан нумерованный с 0 массив неотрицательных целых чисел hours длиной n и неотрицательное целое число target.
    Верните целое число, обозначающее количество сотрудников, которые проработали не менее target часов.
    Ограничения:
        1 <= n == hours.length <= 50
        0 <= hours[i], target <= 10^5
    https://leetcode.com/problems/number-of-employees-who-met-the-target/description/
     */
    public class Task2798 : InfoBasicTask
    {
        public Task2798(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] hours = new int[] { 0, 1, 2, 3, 4 };
            int target = 2;
            printArray(hours, "Массив времени работ сотрудников: ");
            Console.WriteLine($"Целевое количество часов работы = {target}");
            if (isValid(hours, target))
            {
                int count = numberOfEmployeesWhoMetTarget(hours, target);
                Console.WriteLine($"Количество работников, которые отработали {target} и более часов = {count}");
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
        private bool isValid(int[] hours, int target)
        {
            if (hours.Length < 1 || hours.Length > 50)
            {
                return false;
            }
            int highLimit = (int)Math.Pow(10, 5);
            if (target < 0 || target > highLimit)
            {
                return false;
            }
            foreach (int hour in hours) {
                if (hour < 0 || hour > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int numberOfEmployeesWhoMetTarget(int[] hours, int target)
        {
            int count = 0;
            foreach (var item in hours)
            {
                if (item >= target)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
