using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2129
{
    /*
     2129. Написать слова заглавными буквами
    Вам дана строка title, состоящая из одного или нескольких слов, разделённых одним пробелом, где каждое слово состоит из английских букв. 
    Сделайте строку заглавной, изменив регистр каждого слова таким образом, чтобы:
        Если длина слова составляет 1 или 2 букв, измените все буквы на строчные.
        В противном случае измените первую букву на заглавную, а остальные - на строчные.
    Верните заглавную title букву.
    https://leetcode.com/problems/capitalize-the-title/description/
     */
    public class Task2129 : InfoBasicTask
    {
        public Task2129(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "First leTTeR of EACH Word";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            string result = capitalizeTitle(str);
            Console.WriteLine($"Результирующая строка: {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string capitalizeTitle(string title)
        {
            string[] words = title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();
                if (currentWord.Length > 2)
                {
                    currentWord = currentWord.Substring(0,1).ToUpper()+currentWord.Substring(1);
                }
                sb.Append(currentWord);
                if (i < words.Length - 1)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
    }
}
