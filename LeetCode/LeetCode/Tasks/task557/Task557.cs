using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task557
{
    /*
     557. Поменять местами слова в строке III
     Дана строка s. Поменяйте местами символы в каждом слове в предложении, сохранив пробелы и исходный порядок слов.
     */
    public class Task557 : InfoBasicTask
    {
        public Task557(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "Let's take LeetCode contest";
            Console.WriteLine($"Оригинальная строка = \"{str}\"");
            string reverseWordsStr = reverseWords(str); 
            Console.WriteLine($"Cтрока с перевернутыми словами = \"{reverseWordsStr}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string reverseWords(string s)
        {
            string[] words = s.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                for (int j = currentWord.Length-1; j >= 0; j--)
                {
                    sb.Append(currentWord[j]);
                    
                }
                if (i < words.Length - 1)
                {
                    sb.Append(' ');
                }
            }
            return sb.ToString();
        }
    }
}
