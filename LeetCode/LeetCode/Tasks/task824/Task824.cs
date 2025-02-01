using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task824
{
    /*
     824. Козлиная латынь
    Вам дана строка sentence, состоящая из слов, разделённых пробелами. Каждое слово состоит только из строчных и прописных букв.
    Мы хотели бы перевести это предложение на «козлиный латынь» (вымышленный язык, похожий на «свинскую латынь»). Правила «козлиной латыни» следующие:
        Если слово начинается с гласной ('a', 'e', 'i', 'o', или 'u'), добавьте "ma" в конец слова.
            Например, слово "apple" становится "applema".
        Если слово начинается с согласной (то есть не с гласной), удалите первую букву и добавьте её в конец, затем добавьте "ma".
            Например, слово "goat" становится "oatgma".
        Добавьте одну букву 'a' в конец каждого слова в соответствии с его порядковым номером в предложении, начиная с 1.
            Например, к первому слову добавляется "a" в конце, ко второму слову добавляется "aa" в конце и так далее.
    Верните последнее предложение, представляющее собой преобразование из предложения в козлиную латынь.
    https://leetcode.com/problems/goat-latin/description/
     */
    public class Task824 : InfoBasicTask
    {
        public Task824(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "I speak Goat Latin";
            Console.WriteLine($"Оригинальная строка: {str}");
            string strOnGoatLatin = toGoatLatin(str);
            Console.WriteLine($"Строка на козлиной латыни: {strOnGoatLatin}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string toGoatLatin(string sentence)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] words = sentence.Split(' ');
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A','E','I','O','U' };
            for (int i=0; i<words.Length;i++)
            {
                if (!vowels.Contains(words[i][0]))
                {
                    stringBuilder.Append(words[i].Substring(1));
                    stringBuilder.Append(words[i][0]);
                }
                else
                {
                    stringBuilder.Append(words[i]);
                }
                stringBuilder.Append("ma");
                stringBuilder.Append('a', i + 1);
                if (i != words.Length - 1)
                {
                    stringBuilder.Append(" ");
                }
            }
            return stringBuilder.ToString();
        }
    }
}
