using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task796
{
    /*
     796. Повернуть строку
    Даны две строки s и goal. Вернуть true если и только если s может стать goal после некоторого количества сдвиговна s.
    Сдвиг на s заключается в перемещении крайнего левого символа s в крайнюю правую позицию.
     */
    public class Task796 : InfoBasicTask
    {
        public Task796(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "abcde";
            string goal = "cdeab";
            Console.WriteLine(rotateString(s, goal) ? $"Строка \"{goal}\" может быть получена из строки \"{s}\" после сдвигов влево" : $"Строка \"{goal}\" не может быть получена из строки \"{s}\" после сдвигов влево");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool rotateString(string s, string goal)
        {
            if (s.Length == 1)
            {
                return s == goal;
            }
            for (int i = 0; i < s.Length; i++)
            {
                s = s.Substring(1) + s[0];
                if (s == goal)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
