using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task28
{
    public class Task28 : InfoBasicTask
    {
        public Task28(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string haystack = "abc";
            string needle = "c";
            int index = strStr(haystack, needle);
            Console.WriteLine(index == -1 ? $"Строка \"{needle}\" не содержится в строке \"{haystack}\"" : $"Первое вхождение строки \"{needle}\" в строке \"{haystack}\" находится по индексу {index}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int strStr(string haystack, string needle)
        {
            if (haystack == needle)
            {
                return 0;
            }
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                string substring = haystack.Substring(i, needle.Length);
                if (substring == needle)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
