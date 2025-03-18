using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task6
{
    /*
     6. Зигзагообразное преобразование
    Строка "PAYPALISHIRING" записывается зигзагообразным узором в заданном количестве строк следующим образом: (вы можете отобразить этот узор фиксированным шрифтом для лучшей читаемости)
        P   A   H   N
        A P L S I I G
        Y   I   R
    А затем читайте построчно: "PAHNAPLSIIGYIR"
    Ограничения:
        1 <= s.length <= 1000
        s состоит из английских букв (строчных и прописных), ',' и '.'.
        1 <= numRows <= 1000
    https://leetcode.com/problems/zigzag-conversion/description/
     */
    public class Task6 : InfoBasicTask
    {
        public Task6(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "PAYPALISHIRING";
            int countRows = 3;
            Console.WriteLine($"Исходная строка: \"{initialString}\"\nКоличество строк = {countRows}");
            if (isValid(initialString, countRows))
            {
                string res = convert(initialString, countRows);
                Console.WriteLine($"Конечная строка после зигзагообразной конвертации: \"{res}\"");
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
        private bool isValid(string s, int countRows)
        {
            int lowLimit = 1;
            int highLimit = 1000;
            if (s.Length < lowLimit || s.Length > highLimit || countRows < lowLimit || countRows > highLimit)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == ',' || c == '.'))
                {
                    return false;
                }
            }
            return true;
        }
        private string convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }
            StringBuilder[] arr = new StringBuilder[numRows];
            for(int i=0;i<numRows; i++)
            {
                arr[i] = new StringBuilder();
            }
            int currentNumberRow = 0;
            bool isDirectionDown = true;
            foreach (char c in s)
            {
                arr[currentNumberRow].Append(c);
                if (isDirectionDown)
                {
                    currentNumberRow++;
                    if (currentNumberRow == numRows)
                    {
                        currentNumberRow-=2;
                        isDirectionDown = !isDirectionDown;
                    }
                }
                else
                {
                    currentNumberRow--;
                    if (currentNumberRow == -1)
                    {
                        currentNumberRow+=2;
                        isDirectionDown = !isDirectionDown;
                    }
                }
            }
            StringBuilder result = new StringBuilder();
            foreach (StringBuilder sb in arr)
            {
                result.Append(sb.ToString());
            }
            return result.ToString();
        }
    }
}
