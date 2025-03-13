using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task171
{
    /*
     171. Номер столбца на листе Excel
    Учитывая строку columnTitle, которая представляет собой заголовок столбца в виде, который отображается на листе Excel, верните соответствующий номер столбца.
    Ограничения:
        1 <= columnTitle.length <= 7
        columnTitle состоит только из заглавных английских букв.
        columnTitle находится в пределах досягаемости ["A", "FXSHRXW"].
    https://leetcode.com/problems/excel-sheet-column-number/description/
     */
    public class Task171 : InfoBasicTask
    {
        public Task171(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string columnTitle = "ZY";
            Console.WriteLine($"Номер столбца в excel = \"{columnTitle}\"");
            if (isValid(columnTitle))
            {
                int val = titleToNumber(columnTitle);
                Console.WriteLine($"Числовое значение столбца = {val}");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string columnTitle)
        {
            if (columnTitle.Length < 1 || columnTitle.Length > 7)
            {
                return false;
            }
            foreach (char c in columnTitle)
            {
                if (!(c >= 'A' && c <= 'Z'))
                {
                    return false;
                }
            }
            return true;
        }
        private int titleToNumber(string columnTitle)
        {
            int result = 0;
            int baseSystem = 26;
            for (int i = 0; i < columnTitle.Length; i++)
            {
                int digit = columnTitle[i] - 'A' + 1;
                result += digit * (int)Math.Pow(baseSystem, columnTitle.Length - i - 1);
            }
            return result;
        }
    }
}
