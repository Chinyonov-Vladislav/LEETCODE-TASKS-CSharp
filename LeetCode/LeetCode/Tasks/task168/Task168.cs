using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task168
{
    /*
     168. Заголовок столбца на листе Excel
    Для заданного целого числа columnNumber верните название соответствующего столбца в том виде, в котором оно отображается на листе Excel.
     */
    public class Task168 : InfoBasicTask
    {
        public Task168(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 211;
            Console.WriteLine($"Результат: {number} = {convertToTitle(number)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string convertToTitle(int columnNumber)
        {
            string result = "";
            while (columnNumber > 0)
            {
                columnNumber--;
                result = (char)(columnNumber % 26 + 'A') + result;
                columnNumber /= 26;
            }
            return result;
        }
    }
}
