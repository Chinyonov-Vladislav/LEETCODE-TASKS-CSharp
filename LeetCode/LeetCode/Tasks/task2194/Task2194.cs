using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2194
{
    /*
     2194. Ячейки в диапазоне на листе Excel
    Ячейка (r, c) листа Excel представлена в виде строки "<col><row>" , где:
        <col> обозначает номер столбца c в ячейке. Он обозначается буквами алфавита.
            Например, столбец 1st обозначается 'A', столбец 2nd — 'B', столбец 3rd — 'C' и так далее.
        <row> Это номер строки r ячейки. Строка rth представлена целым числом r.
    Вам дана строка s в формате "<col1><row1>:<col2><row2>", где <col1> обозначает столбец c1, <row1> обозначает строку r1, <col2> обозначает столбец c2, а <row2> обозначает строку r2, так что r1 <= r2 и c1 <= c2.
    Верните список ячеек (x, y) таких что r1 <= x <= r2 и c1 <= y <= c2. Ячейки должны быть представлены в виде строк в указанном выше формате и отсортированы в неубывающем порядке сначала по столбцам, а затем по строкам.
     https://leetcode.com/problems/cells-in-a-range-on-an-excel-sheet/description/
     */
    public class Task2194 : InfoBasicTask
    {
        public Task2194(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initial = "K1:L2";
            Console.WriteLine($"Исходный диапазон: \"{initial}\"");
            IList<string> result = cellsInRange(initial);
            printIListString(result, "Ячейки в указанном диапазоне: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<string> cellsInRange(string s)
        {
            IList<string> result = new List<string>();
            char startChar = s[0];
            char finishChar = s[3];
            int startValue = s[1]-'0';
            int finishValue = s[4] - '0';
            while (startChar <= finishChar)
            {
                for (int index = startValue; index <= finishValue; index++)
                {
                    result.Add($"{startChar}{index}");
                }
                startChar++;
            }
            return result;
        }
    }
}
