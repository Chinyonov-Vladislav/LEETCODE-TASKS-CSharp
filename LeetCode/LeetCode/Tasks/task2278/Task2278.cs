using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2278
{
    /*
     2278. Процентное соотношение букв в строке
    Учитывая строку s и символ letter, верните процент количества символов в s строке, которые равны letter округленному в меньшую сторону до ближайшего целого процента.
    https://leetcode.com/problems/percentage-of-letter-in-string/description/
     */
    public class Task2278 : InfoBasicTask
    {
        public Task2278(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "foobar";
            char letter = 'o';
            Console.WriteLine($"Исходная строка: \"{str}\"");
            Console.WriteLine($"Символ для расчёта процента: \'{letter}\'");
            int percent = percentageLetter(str, letter);
            Console.WriteLine($"Процент символа \'{letter}\' в строке \"{str}\" = {percent}%");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int percentageLetter(string s, char letter)
        {
            int countLetter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == letter)
                {
                    countLetter++;
                }
            }
            double percentage = ((double)countLetter / s.Length) * 100;
            return (int)percentage;
        }
    }
}
