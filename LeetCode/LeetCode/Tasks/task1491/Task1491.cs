using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1491
{
    /*
     1491. Средняя зарплата без учёта минимальной и максимальной зарплат
    Вам дан массив уникальных целых чисел salary где salary[i] — это зарплата ith сотрудника.
    Верните среднюю зарплату сотрудников, исключив минимальную и максимальную зарплату. Будут приняты ответы в пределах 10-5 от фактического ответа.
     https://leetcode.com/problems/average-salary-excluding-the-minimum-and-maximum-salary/description/
     */
    public class Task1491 : InfoBasicTask
    {
        public Task1491(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] salaryArray = new int[] { 4000, 3000, 1000, 2000 };
            printArray(salaryArray, "Массив зарплат: ");
            double averageSalaryWithoutMinMax = average(salaryArray);
            Console.WriteLine($"Средняя зарплата без максимального и минимального значения = {averageSalaryWithoutMinMax}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private double average(int[] salary)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int totalSalary = 0;
            for (int i = 0; i < salary.Length; i++)
            {
                totalSalary += salary[i];
                if (salary[i] > max)
                {
                    max = salary[i];
                }
                if (salary[i] < min)
                {
                    min = salary[i];
                }
            }
            return (totalSalary -min - max) / (double)(salary.Length-2);
        }
    }
}
