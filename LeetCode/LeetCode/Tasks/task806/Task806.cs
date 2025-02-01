using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task806
{
    /*
     806. Количество строк для записи строки
    Вам дана строка s из строчных букв английского алфавита и массив widths с указанием ширины в пикселях каждой строчной буквы английского алфавита. В частности, widths[0] — это ширина 'a', widths[1] — это ширина 'b' и так далее.
    Вы пытаетесь написать s в несколько строк, где каждая строка не длиннее, чем 100 пикселей. 
    Начиная с начала s, напишите столько букв на первой строке, чтобы общая ширина не превышала 100 пикселей. 
    Затем, с того места, где вы остановились в s, продолжайте писать столько букв, сколько сможете, на второй строке.
    Продолжайте в том же духе, пока не напишете все s.
    Возвращает массив result длины 2, где:
        result[0] - общее количество строк.
        result[1] - ширина последней строки в пикселях.
     */
    public class Task806 : InfoBasicTask
    {
        public Task806(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] widths = new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string s = "bbbcccdddaaa";
            int[] result = numberOfLines(widths, s);
            Console.WriteLine($"Общее количество строк = {result[0]}\nШирина последней строки = {result[1]}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] numberOfLines(int[] widths, string s)
        {
            int maxWidth = 100;
            int currentWidth = 0;
            int[] result = new int[2] { 0,0 };
            for (int i = 0; i < s.Length; i++)
            {
                int widthOfCurrentLetter = widths[(int)s[i] - (int)'a'];
                if (currentWidth + widthOfCurrentLetter > maxWidth)
                {
                    result[0]++;
                    currentWidth = widthOfCurrentLetter;
                }
                else
                {
                    currentWidth+=widthOfCurrentLetter;
                }
            }
            result[1] = currentWidth;
            if (currentWidth > 0)
            {
                result[0]++;
            }
            return result;
        }
    }
}
