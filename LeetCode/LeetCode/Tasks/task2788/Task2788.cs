using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2788
{
    /*
     2788. Разделение строк с помощью разделителя
     Учитывая массив строк words и символ separator, разделите каждую строку в words на separator.
    Верните массив строк, содержащий новые строки, образованные после разделения,за исключением пустых строк.
    Примечания
        separator используется для определения места, где должно произойти разделение, но не включается в результирующие строки.
        Разделение может привести к получению более чем двух строк.
        Результирующие строки должны сохраняться в том же порядке, в каком они были заданы изначально.
    https://leetcode.com/problems/split-strings-by-separator/
     */
    public class Task2788 : InfoBasicTask
    {
        public Task2788(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<string> words = new List<string>() { "один.два.три", "четыре.пять", "шесть" };
            printIListString(words, "Массив строк с разделителями: ");
            char separator = '.';
            Console.WriteLine($"Разделитель = {separator}");
            IList<string> result = splitWordsBySeparator(words, separator);
            printIListString(result, "Результирующий массив слов: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<string> splitWordsBySeparator(IList<string> words, char separator)
        {
            IList<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == separator)
                    {
                        if (sb.ToString() != String.Empty)
                        {
                            result.Add(sb.ToString());
                            sb.Clear();
                        }
                    }
                    else
                    {
                        sb.Append(word[i]);
                    }
                }
                if (sb.ToString() != String.Empty)
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                }
            }
            return result;
        }
        // скопировано с leetcode
        private IList<string> bestSolution(IList<string> words, char separator)
        {
            return String.Join(separator.ToString(), words)
                         .Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
