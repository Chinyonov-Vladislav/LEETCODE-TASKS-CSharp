using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task682
{
    /*
     682. Бейсбольный матч
    Вы ведёте счёт в бейсбольном матче со странными правилами. В начале игры вы начинаете с пустым счётом.
    Вам дан список строк operations, где operations[i] — это операция i, которую вы должны применить к записи, и она может быть одной из следующих:
        Целое число x.
            Запишите новый результат x.
        '+'.
            Запишите новый балл, который является суммой двух предыдущих баллов.
        'D'.
            Запишите новый результат, вдвое превышающий предыдущий.
        'C'.
            Аннулируйте предыдущую оценку, удалив ее из протокола.
    Верните сумму всех баллов в записи после применения всех операций.
    Тестовые примеры генерируются таким образом, чтобы ответ и все промежуточные вычисления помещались в 32-битное целое число и чтобы все операции были корректными.
    https://leetcode.com/problems/baseball-game/description/
     */
    public class Task682 : InfoBasicTask
    {
        public Task682(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] operations = new string[] { "5", "2", "C", "D", "+" }; 
            int resultPoints = calPoints(operations);
            Console.WriteLine($"Результат матча = {resultPoints}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int calPoints(string[] operations)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == "C")
                {
                    result.RemoveAt(result.Count-1);
                }
                else if (operations[i] == "D")
                {
                    result.Add(result[result.Count - 1]*2);
                }
                else if (operations[i] == "+")
                {
                    result.Add(result[result.Count - 1] + result[result.Count - 2]);
                }
                else
                {
                    result.Add(Convert.ToInt32(operations[i]));
                }
            }
            return result.Sum();
        }
    }
}
