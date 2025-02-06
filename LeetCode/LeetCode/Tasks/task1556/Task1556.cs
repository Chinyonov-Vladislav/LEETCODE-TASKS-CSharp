using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1556
{
    /*
     1556. Разделитель тысяч
    К целому числу n добавьте точку (".") в качестве разделителя тысяч и верните результат в строковом формате.
    https://leetcode.com/problems/thousand-separator/description/
     */
    public class Task1556 : InfoBasicTask
    {
        public Task1556(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 1234;
            Console.WriteLine($"Число = {number}");
            string numberWithDot = thousandSeparator(number);
            Console.WriteLine($"Число с точкой в качестве разделителя тысячи = \"{numberWithDot}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string thousandSeparator(int n)
        {
            if (n == 0) {
                return "0";
            }
            int countAdded = 0;
            StringBuilder sb = new StringBuilder();
            while (n != 0) {
                int digit = n % 10;
                sb.Insert(0,digit);
                countAdded++;
                n = n / 10;
                if (countAdded == 3 && n!=0)
                {
                    countAdded=0;
                    sb.Insert(0,'.');
                }
            }
            return sb.ToString();
        }
    }
}
