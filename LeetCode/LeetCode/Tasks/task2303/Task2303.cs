using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2303
{
    /*
     2303. Рассчитать сумму, уплаченную в виде налогов
    Вам дан двумерный целочисленный массив с индексацией 0 brackets где brackets[i] = [upperi, percenti] означает, что ith налоговая категория имеет верхнюю границу upperi и облагается налогом по ставке percenti. Категории отсортированы по верхней границе (т. е. upperi-1 < upperi для 0 < i < brackets.length).
    Налог рассчитывается следующим образом:
        Первые upper0 заработанные доллары облагаются налогом по ставке percent0.
        Следующие upper1 - upper0 заработанные доллары облагаются налогом по ставке percent1.
        Следующие upper2 - upper1 заработанные доллары облагаются налогом по ставке percent2.
        И так далее.
    Вам дано целое число income, обозначающее сумму, которую вы заработали. Верните сумму, которую вы должны заплатить в качестве налогов. Будут приняты ответы в пределах 10-5 от фактического ответа.
    https://leetcode.com/problems/calculate-amount-paid-in-taxes/description/
     */
    public class Task2303 : InfoBasicTask
    {
        public Task2303(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] taxes = new int[][] {
                new int[] {3,50 },
                new int[] {7,10 },
                new int[] {12,25 }
            };
            printTwoDimensionalArray(taxes, "Наловые ставки");
            int income = 10;
            Console.WriteLine($"Доход = {income}");
            double result = calculateTax(taxes, income);
            Console.WriteLine($"Общее количество налогов = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private double calculateTax(int[][] brackets, int income)
        {
            double result = 0;
            int paid = 0;
            int index = 0;
            while (paid != income)
            {
                if (index == brackets.Length)
                {
                    break;
                }
                if (index == 0)
                {
                    if (income >= brackets[index][0])
                    {
                        result += (double)brackets[index][0] / 100 * (double)brackets[index][1];
                        paid = brackets[index][0];
                    }
                    else
                    {
                        result += (double)income / 100 * (double)brackets[index][1];
                        paid = income;
                    }
                    index++;
                }
                else
                {
                    int difference = brackets[index][0] - brackets[index-1][0];
                    if (paid + difference > income)
                    {
                        difference = income - paid;
                    }
                    result += (double)difference / 100 * (double)brackets[index][1];
                    paid+= difference;
                    index++;
                }
            }
            return result;
        }
    }
}
