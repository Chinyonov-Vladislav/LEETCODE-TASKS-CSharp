using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task804
{
    /*
     804. Уникальные слова азбуки Морзе
    Международный код Морзе определяет стандартную кодировку, в которой каждой букве соответствует последовательность точек и тире следующим образом:
        'a' карты для ".-",
        'b' карты для "-...",
        'c' сопоставляет с "-.-." и так далее.
    Для удобства ниже приведена полная таблица для букв 26 английского алфавита:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
    Дан массив строк words , где каждое слово может быть записано как последовательность кода Морзе для каждой буквы.
    Например, "cab" может быть записан как "-.-..--...", что является объединением "-.-.", ".-" и "-...". Мы будем называть такое объединение преобразованием слова.
    Верните количество различных преобразований среди всех имеющихся у нас слов.
    https://leetcode.com/problems/unique-morse-code-words/description/
     */
    public class Task804 : InfoBasicTask
    {
        public Task804(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "gin", "zen", "gig", "msg" };
            int countUniqueWordsOnMorse = uniqueMorseRepresentations(words);
            Console.WriteLine($"Количество уникальных презентаций слова на азбуке Морзе = {countUniqueWordsOnMorse}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int uniqueMorseRepresentations(string[] words)
        {
            string[] array = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();
                StringBuilder morseWord = new StringBuilder(); ;
                foreach (var symbol in currentWord)
                {
                    int index = (int)symbol - (int)'a';
                    morseWord.Append(array[index]);
                }
                set.Add(morseWord.ToString());
            }
            return set.Count;
        }
    }
}
