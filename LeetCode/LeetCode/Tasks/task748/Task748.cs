using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task748
{
    /*
     748. Самое короткое завершающее слово
    Даны строка licensePlate и массив строк words. Найдите кратчайшее дополняющее слово в words.
    Завершающее слово — это слово, которое содержит все буквы в licensePlate. Игнорируйте цифры и пробелы в licensePlate и считайте, что регистр букв не имеет значения. Если буква встречается в licensePlate более одного раза, то она должна встречаться в слове столько же или больше раз.
    Например, если licensePlate = "aBc 12c", то оно содержит буквы 'a', 'b' (без учёта регистра) и 'c' дважды. Возможные дополнения к словам: "abccdef", "caaacab", и "cbca".
    Верните самое короткое дополняющее слово в words. Гарантируется, что ответ существует. Если есть несколько самых коротких дополняющих слов, верните первое из них, которое встречается в words.

 
     */
    public class Task748 : InfoBasicTask
    {
        public Task748(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string licensePlate = "1s3 456";
            string[] words = new string[] { "looks", "pest", "stew", "show" };
            string word = shortestCompletingWord(licensePlate, words);
            Console.WriteLine($"Результат = {word}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string shortestCompletingWord(string licensePlate, string[] words)
        {
            if (words.Length == 1)
            {
                return words[0];
            }
            licensePlate = licensePlate.ToLower();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in licensePlate)
            {
                if (char.IsLetter(c))
                {
                    if (dict.ContainsKey(c))
                    {
                        dict[c]++;
                    }
                    else
                    {
                        dict.Add(c, 1);
                    }
                }
            }
            string result = "";
            int lengthOfResult = Int32.MaxValue;
            foreach (string word in words)
            {
                string currentWord = word.ToLower();
                Dictionary<char, int> dictForWord = new Dictionary<char, int>();
                foreach (char c in currentWord)
                {
                    if (dictForWord.ContainsKey(c))
                    {
                        dictForWord[c]++;
                    }
                    else
                    {
                        dictForWord.Add(c, 1);
                    }
                }
                bool isGoodWord = true;
                foreach (var pair in dict)
                {
                    if (!dictForWord.ContainsKey(pair.Key) || dictForWord[pair.Key] < pair.Value)
                    {
                        isGoodWord = false;
                        break;
                    }
                }
                if (isGoodWord && word.Length < lengthOfResult)
                {
                    lengthOfResult = word.Length;
                    result = word;
                }
            }
            return result;
        }
    }
}
