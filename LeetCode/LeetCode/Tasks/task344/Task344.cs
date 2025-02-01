using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task344
{
    public class Task344 : InfoBasicTask
    {
        public Task344(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            char[] chars = new char[] { '1', '2', '3', '4' };
            printArray(chars, "Исходный массив символов: ");
            reverseString(chars);
            printArray(chars, "Конечный массив символов: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private void reverseString(char[] s)
        {
            if (s.Length < 2)
            {
                return;
            }
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                (s[left], s[right]) = (s[right], s[left]);
                left++;
                right--;
            }
        }
    }
}
