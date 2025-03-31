using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task686
{
    /*
     686. Повторное совпадение строк
    Даны две строки a и b. Верните минимальное количество повторений строки a, чтобы строка b стала её подстрокой. Если b​​​​​​ не может стать подстрокой a после повторения, верните -1.
    Обратите внимание: строка "abc" при повторении 0 раз выглядит как "", при повторении 1 раз — как "abc" и при повторении 2 раз — как "abcabc".
    Ограничения:
        1 <= a.length, b.length <= 10^4
        a и b состоят из строчных английских букв.
    https://leetcode.com/problems/repeated-string-match/description/
     */
    public class Task686 : InfoBasicTask
    {
        public Task686(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string firstStr = "abcd";
            string secondStr = "cdabcdab";
            Console.WriteLine($"Первая строка: \"{firstStr}\"\nВторая строка: \"{secondStr}\"");
            if (isValid(firstStr, secondStr))
            {
                int res = repeatedStringMatch(firstStr, secondStr);
                Console.WriteLine(res == -1 ? 
                    $"Строка \"{secondStr}\" не может стать подстрокой строки \"{firstStr}\" после повторения строки \"{firstStr}\"" :
                     $"Строка \"{secondStr}\" может стать подстрокой строки \"{firstStr}\" после повторения строки \"{firstStr}\"");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string a, string b)
        {
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10,4);
            if (a.Length < lowLimit || a.Length > highLimit || b.Length < lowLimit || b.Length > highLimit)
            {
                return false;
            }
            List<string> strings = new List<string>() { a,b};
            foreach (string s in strings)
            {
                foreach (char c in s)
                {
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int repeatedStringMatch(string a, string b)
        {
            if (a.Contains(b))
            {
                return 1;
            }
            int currentCountRepeated = 0;
            StringBuilder stringBuilder = new StringBuilder();
            while (true) {
                stringBuilder.Append(a);
                currentCountRepeated++;
                if (stringBuilder.Length >= b.Length)
                {
                    if (stringBuilder.ToString().Contains(b))
                    {
                        return currentCountRepeated;
                    }
                    currentCountRepeated++;
                    stringBuilder.Append(a);
                    if (stringBuilder.ToString().Contains(b))
                    {
                        return currentCountRepeated;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return -1;
        }
    }
}
