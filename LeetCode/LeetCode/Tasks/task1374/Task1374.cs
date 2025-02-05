using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1374
{
    /*
     1374. Сгенерируйте строку из символов с нечётным количеством повторений
    Учитывая целое число n, возвращаем строку с n такими символами, что каждый символ в такой строке встречается нечётное количество раз.
    Возвращаемая строка должна содержать только строчные буквы английского алфавита. Если существует несколько допустимых строк, верните любую из них.
    https://leetcode.com/problems/generate-a-string-with-characters-that-have-odd-counts
     */
    public class Task1374 : InfoBasicTask
    {
        public Task1374(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int totalCountSymbols = 4;
            Console.WriteLine($"Общее количество символов в результирующей строке = {totalCountSymbols}");
            string result = generateTheString(totalCountSymbols);
            Console.WriteLine($"Результирующая строка, в которой каждый символ встречается нечетное количество раз = \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string generateTheString(int n)
        {
            StringBuilder sb = new StringBuilder();
            if (n % 2 == 1)
            {
                sb.Append('a', n);
            }
            else
            {
                sb.Append('a', n-1);
                sb.Append('b');
            }
            return sb.ToString();
        }
    }
}
