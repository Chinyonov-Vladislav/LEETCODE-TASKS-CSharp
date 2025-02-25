using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2124
{
    /*
     2124. Проверьте, появляется ли буква «А» перед буквой «Б»
    Учитывая строку s, состоящую только из символов 'a' и 'b', верните true если каждый 'a' символ встречается раньше, чем каждый 'b'символ в строке. 
    В противном случае верните false.
    https://leetcode.com/problems/check-if-all-as-appears-before-all-bs/description/
     */
    public class Task2124 : InfoBasicTask
    {
        public Task2124(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "aaabbb";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            Console.WriteLine(checkString(str) ? "Все символы \'a\' встречаются перед символов \'b\'" : "Существует символ \'a\', который встречается после символа \'b\'");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool checkString(string s)
        {
            int indexOfFirstB = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'b')
                {
                    indexOfFirstB = i;
                    break;
                }
            }
            if (indexOfFirstB == -1)
            {
                return true;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a' && i > indexOfFirstB)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
