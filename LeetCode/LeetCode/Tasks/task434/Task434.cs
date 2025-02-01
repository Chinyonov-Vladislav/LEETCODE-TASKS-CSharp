using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task434
{
    public class Task434 : InfoBasicTask
    {
        /*
         434. Количество сегментов в строке
        Для заданной строки s верните количество сегментов в строке.
        Сегмент определяется как непрерывная последовательность непробельных символов.
         */
        public Task434(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "Hello, my name is John";
            Console.WriteLine($"Количество сегментов в строке \"{str}\" равно {countSegments(str)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countSegments(string s)
        {
            s = s.Trim();
            List<string> segments = new List<string>();
            string currentSegment = String.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    currentSegment += s[i];
                }
                if (s[i] == ' ' && currentSegment != String.Empty)
                {
                    segments.Add(currentSegment);
                    currentSegment = String.Empty;
                }
            }
            if (currentSegment != String.Empty)
            {
                segments.Add(currentSegment);
            }
            return segments.Count;
        }
    }
}
