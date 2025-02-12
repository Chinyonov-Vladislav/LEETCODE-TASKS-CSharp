using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1957
{
    public class Task1957 : InfoBasicTask
    {
        public Task1957(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "leeetcode";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            string result = makeFancyString(str);
            Console.WriteLine($"Результирующая строка: \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string makeFancyString(string s)
        {
            if (s.Length < 3)
            {
                return s;
            }

            StringBuilder result = new StringBuilder();
            result.Append(s[0]);
            result.Append(s[1]);

            for (int i = 2; i < s.Length; i++)
            {
                if (s[i] != s[i - 1] || s[i] != s[i - 2])
                {
                    result.Append(s[i]);
                }
            }
            return result.ToString();
        }
    }
}
