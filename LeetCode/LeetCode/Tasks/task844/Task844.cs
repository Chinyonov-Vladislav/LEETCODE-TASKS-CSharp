using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task844
{
    /*
     844. Сравнение строк обратного пробела
    Учитывая две строки s и t, верните true значение, равное 1, если они равны, когда обе введены в пустые текстовые редакторы. '#' означает символ возврата на одну позицию.
    Обратите внимание, что после обратного заполнения пустого текста текст останется пустым.
    https://leetcode.com/problems/backspace-string-compare/description/
     */
    public class Task844 : InfoBasicTask
    {
        public Task844(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str1 = "ab#c";
            string str2 = "ad#c";
            Console.WriteLine($"Первая строка в наборе текстового редактора = \"{str1}\".\nВторая строка в наборе текстового редактора = \"{str2}\".");
            Console.WriteLine(backspaceCompare(str1, str2) ? "Строки равны" : "Строки не равны");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool backspaceCompare(string s, string t)
        {
            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '#')
                {
                    if(sb1.Length>=1)
                    {
                        sb1.Remove(sb1.Length - 1, 1);
                    }
                }
                else
                {
                    sb1.Append(s[i]);
                }
            }
            StringBuilder sb2 = new StringBuilder();
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == '#')
                {
                    if(sb2.Length>=1)
                    {
                        sb2.Remove(sb2.Length - 1, 1);
                    }
                }
                else
                {
                    sb2.Append(t[i]);
                }
            }
            return sb1.ToString().Equals(sb2.ToString());
        }
    }
}
