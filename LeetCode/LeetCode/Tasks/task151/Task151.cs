using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task151
{
    /*
     151. Поменять местами слова в строке
    Получив входную строку s, измените порядок слов в обратном порядке.
    Слово определяется как последовательность непробельных символов. Слова в s будут разделены как минимум одним пробелом.
    Верните строку из слов в обратном порядке, разделённых одним пробелом.
    Обратите внимание, что s может содержать пробелы в начале или в конце строки или несколько пробелов между двумя словами. В возвращаемой строке между словами должен быть только один пробел. Не добавляйте лишние пробелы.
    https://leetcode.com/problems/reverse-words-in-a-string/description/
     */
    public class Task151 : InfoBasicTask
    {
        public Task151(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "a good   example";
            Console.WriteLine($"Исходная строка = \"{str}\"");
            string result = reverseWords(str);
            Console.WriteLine($"Строка с перевернутым порядком слов: \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string reverseWords(string s)
        {
            s = s.Trim();
            string[] parts = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder res = new StringBuilder();
            for (int i = parts.Length - 1; i >= 0; i--)
            {
                res.Append(parts[i]);
                if (i != 0)
                {
                    res.Append(" ");
                }
            }
            return res.ToString();
        }
    }
}
