using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1051
{
    /*
     1051. Регулятор высоты
    В школе хотят сделать ежегодную фотографию всех учеников. Учеников просят выстроиться в одну линию в порядке возрастания по росту. Пусть этот порядок будет представлен целочисленным массивом expected где expected[i] — ожидаемый рост ith-го ученика в очереди.
    Вам дан целочисленный массив heights, представляющий текущий порядок, в котором стоят ученики. Каждый heights[i] элемент — это рост ith ученика в очереди (нумерация с 0).
    Возвращает количество индексов где heights[i] != expected[i].
    https://leetcode.com/problems/height-checker/description/
     */
    public class Task1051 : InfoBasicTask
    {
        public Task1051(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] height = new int[] { 1, 1, 4, 2, 1, 3 };
            Console.WriteLine($"Количество учеников, стоящих не по возрастанию роста = {heightChecker(height)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int heightChecker(int[] heights)
        {
            int count = 0;
            int[] expected = new int[heights.Length];
            for (int i = 0; i < heights.Length; i++)
            {
                expected[i] = heights[i];
            }
            Array.Sort(expected);
            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i] != heights[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
