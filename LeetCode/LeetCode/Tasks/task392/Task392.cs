using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task392
{
    /*
     392. Является ли Подпоследовательность

    Учитывая две строки s и t, верните true если s является подпоследовательностью из t, или false иначе.
    Подпоследовательность строки — это новая строка, которая образуется из исходной строки путём удаления некоторых (или всех) символов без изменения относительного расположения оставшихся символов. (То есть "ace" является подпоследовательностью "abcde", а "aec" — нет).
     */
    public class Task392 : InfoBasicTask
    {
        public Task392(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string first = "bc";
            string second = "abbc";
            Console.WriteLine(isSubsequence(first, second) ? $"Строка \"{first}\" является подпоследовательностью строки \"{second}\"" : $"Строка \"{first}\" не является подпоследовательностью строки \"{second}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public bool isSubsequence(string s, string t)
        {
            if ((s.Length == 0 && t.Length == 0) || t.Length == 0)
            {
                return true;
            }
            else if (s.Length == 0)
            {
                return true;
            }
            int indexOnS = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == s[indexOnS])
                {
                    indexOnS++;
                }
                if (indexOnS == s.Length)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
