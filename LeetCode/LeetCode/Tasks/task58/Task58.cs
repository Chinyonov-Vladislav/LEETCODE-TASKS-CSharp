using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.Task58
{
    public class Task58 : InfoBasicTask
    {
        public Task58(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string word = "«Привет, мир!»";
            Console.WriteLine($"Последнее слово имеет длину {lengthOfLastWord(word)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int lengthOfLastWord(string s)
        {
            s = s.Trim();
            int indexOfLastSpace = -1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    indexOfLastSpace = i;
                    break;
                }
            }
            if (indexOfLastSpace == -1)
            {
                return s.Length;
            }
            return s.Length - indexOfLastSpace - 1;
        }
    }
}
