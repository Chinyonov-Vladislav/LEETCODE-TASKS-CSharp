using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task809
{
    /*
     809. Выразительные слова
    Иногда люди повторяют буквы, чтобы выразить дополнительные чувства. Например:
        "hello" -> "heeellooo"
        "hi" -> "hiiii"
    В таких строках, как "heeellooo", есть группы соседних одинаковых букв: "h", "eee", "ll", "ooo".
    Вам дана строка s и массив строк запросов words. Слово запроса является растягиваемым, если его можно сделать равным s с помощью любого количества применений следующей операции расширения: выберите группу, состоящую из символов c, и добавьте в группу некоторое количество символов c так, чтобы размер группы был три или более символов.
        Например, начиная с "hello", мы можем расширить группу "o" до "hellooo", но мы не можем получить "helloo", так как размер группы "oo" меньше трёх. Также мы можем расширить группу "ll" -> "lllll" до "helllllooo". Если s = "helllllooo", то слово запроса "hello" будет растягиваться из-за этих двух операций расширения: query = "hello" -> "hellooo" -> "helllllooo" = s.
    Возвращает количество растягивающихся строк запроса.
    Ограничения:
        1 <= s.length, words.length <= 100
        1 <= words[i].length <= 100
        s и words[i] состоят из строчных букв.
    https://leetcode.com/problems/expressive-words/description/
     */
    public class Task809 : InfoBasicTask
    {
        public Task809(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "heeellooo";
            string[] words = new string[] { "hello", "hi", "helo" };
            Console.WriteLine($"Исходная строка: \"{s}\"");
            printArray(words, "Начальный массив слов: ");
            if (isValid(s, words))
            {
                int count = expressiveWords(s, words);
                Console.WriteLine($"Количество растягивающихся строк запроса = {count}");
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
        private bool isValid(string s, string[] words)
        {
            int lowLimitLength = 1;
            int highLimitLength = 100;
            if (s.Length < lowLimitLength || s.Length > highLimitLength || words.Length < lowLimitLength || words.Length>highLimitLength)
            {
                return false;
            }
            foreach (string word in words)
            {
                if (word.Length < lowLimitLength || word.Length > highLimitLength)
                {
                    return false;
                }
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            foreach (string word in words)
            {
                foreach (char c in word)
                {
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int expressiveWords(string s, string[] words)
        {
            int count = 0;
            List<Tuple<char, int[]>> segmentsOfTargetWord = getSegmentsOfWord(s);
            foreach (string word in words)
            {
                List<Tuple<char, int[]>> segmentsOfCurrentWord = getSegmentsOfWord(word);
                if (segmentsOfCurrentWord.Count != segmentsOfTargetWord.Count)
                {
                    continue;
                }
                bool isCorrect = true;
                for (int i = 0; i < segmentsOfCurrentWord.Count; i++)
                {
                    if (segmentsOfCurrentWord[i].Item1 != segmentsOfTargetWord[i].Item1)
                    {
                        isCorrect = false;
                        break;
                    }
                    int countLetterOfCurrentWord = segmentsOfCurrentWord[i].Item2[1] - segmentsOfCurrentWord[i].Item2[0] + 1;
                    int countLetterOfTargetWord = segmentsOfTargetWord[i].Item2[1] - segmentsOfTargetWord[i].Item2[0] + 1;
                    if (countLetterOfTargetWord == countLetterOfCurrentWord)
                    {
                        continue;
                    }
                    else if (countLetterOfCurrentWord > countLetterOfTargetWord)
                    {
                        isCorrect = false;
                        break;
                    }
                    else
                    {
                        if (countLetterOfTargetWord < 3)
                        {
                            isCorrect = false;
                            break;
                        }
                    }
                }
                if (isCorrect)
                {
                    count++;
                }
            }
            return count;
        }
        private List<Tuple<char, int[]>> getSegmentsOfWord(string str)
        {
            List<Tuple<char, int[]>> segmentsOfTargetWord = new List<Tuple<char, int[]>>();
            int left = 0;
            int right = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    right++;
                }
                else
                {
                    segmentsOfTargetWord.Add(new Tuple<char, int[]>(str[left], new int[] { left, right }));
                    left = i;
                    right = i;
                }
            }
            segmentsOfTargetWord.Add(new Tuple<char, int[]>(str[left], new int[] { left, right }));
            return segmentsOfTargetWord;
        }
    }
}
