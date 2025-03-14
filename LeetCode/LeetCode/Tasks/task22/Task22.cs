using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task22
{
    /*
     22. Сгенерируйте круглые скобки
    Учитывая n парные скобки, напишите функцию для генерации всех комбинаций правильно оформленных скобок.
    Ограничения:
        1 <= n <= 8
    https://leetcode.com/problems/generate-parentheses/description/
     */
    public class Task22 : InfoBasicTask
    {
        public Task22(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int count = 3;
            Console.WriteLine($"Количество пар открывающих и закрывающих скобок = {count}");
            if (isValid(count))
            {
                IList<string> res = generateParenthesis(count);
                printIListString(res, "Результат: ");
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
        private bool isValid(int n)
        {
            if (n < 1 || n > 8)
            {
                return false;
            }
            return true;
        }
        private IList<string> generateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            string initialString = String.Empty;
            int countOpen = 0;
            int countClosed = 0;
            recursive(result, initialString, countOpen, countClosed, n);
            return result;
        }
        private void recursive(IList<string> list, string str, int countOpen, int countClosed, int count)
        {
            if (str.Length == count * 2)
            {
                list.Add(str);
                return;
            }
            if (countOpen < count)
            {
                recursive(list, $"{str}(", countOpen+1, countClosed, count);
            }
            if (countClosed < countOpen)
            {
                recursive(list, $"{str})", countOpen, countClosed+1, count);
            }
        }
    }
}
