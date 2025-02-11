using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1784
{
    /*
     1784. Проверьте, содержит ли двоичная строка не более одного сегмента из единиц
    Учитывая двоичную строку s без ведущих нулей, верните true​​​ если s содержит не более одного непрерывного сегмента из единиц. В противном случае верните false.
    https://leetcode.com/problems/check-if-binary-string-has-at-most-one-segment-of-ones/description/
     */
    public class Task1784 : InfoBasicTask
    {
        public Task1784(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "111";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            Console.WriteLine(checkOnesSegment(str) ? "Исходная бинарная строка содержит один непрерывный сегмент из единиц" : "Исходная бинарная строка либо не содержит ни одного непрерывного сегмента из единиц, либо содержит более одного непрерывного сегмента из единиц");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool checkOnesSegment(string s)
        {
            int indexOfLastOne = -1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != '1')
                {
                    indexOfLastOne = i-1;
                }
                if (indexOfLastOne != -1 && s[i] == '1')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
