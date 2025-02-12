using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1880
{
    /*
     1880. Проверьте, равно ли слово сумме двух слов
    Ценность буквы — это её позиция в алфавите, начиная с 0 (то есть 'a' -> 0, 'b' -> 1, 'c' -> 2 и т. д.).
    Числовое значение некоторой строки из строчных букв английского алфавита s — это сумма числовых значений каждой буквы в s, которая затем преобразуется в целое число.
        Например, если s = "acb" мы объединяем значения букв, в результате чего получаем "021". После преобразования мы получаем 21
    Вам даны три строки firstWord, secondWord, и targetWord, каждая из которых состоит из строчных букв английского алфавита 'a' по 'j' включительно.
    Возврат true если суммирования из числовых значений в firstWord и secondWord равно численное значение Из targetWord, или false иначе.
    https://leetcode.com/problems/check-if-word-equals-summation-of-two-words/description/
     */
    public class Task1880 : InfoBasicTask
    {
        public Task1880(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string firstWord = "acb";
            string secondWord = "cba";
            string targetWord = "cdb";
            Console.WriteLine($"Первое слово = \"{firstWord}\"\nВторое слово = \"{secondWord}\"\nЦелевое слово = \"{targetWord}\"");
            Console.WriteLine(isSumEqual(firstWord, secondWord, targetWord) ? "Целевое слово равно сумме двух слов" : "Целевое слово не равно сумме двух слов");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isSumEqual(string firstWord, string secondWord, string targetWord)
        {
            int sumOfFirstWord = calculateSumOfWord(firstWord);
            int sumOfSecondWord = calculateSumOfWord(secondWord);
            int sumOfThirdWord = calculateSumOfWord(targetWord);
            return sumOfFirstWord + sumOfSecondWord == sumOfThirdWord;
        }
        private int calculateSumOfWord(string word)
        {
            int sum = 0;
            for (int i = 0; i < word.Length; i++)
            {
                int indexLetter = word[i] - 'a';
                sum += indexLetter * (int)Math.Pow(10, word.Length - i - 1);
            }
            return sum;
        }
        // скопировано с leetcode
        private bool bestSolution(string firstWord, string secondWord, string targetWord)
        {
            int n1 = 0, n2 = 0, n3 = 0;
            for (int i = 0; i < firstWord.Length; i++)
            {
                n1 = (firstWord[i] - 'a') + n1 * 10;
            }
            for (int i = 0; i < secondWord.Length; i++)
            {
                n2 = (secondWord[i] - 'a') + n2 * 10;
            }
            for (int i = 0; i < targetWord.Length; i++)
            {
                n3 = (targetWord[i] - 'a') + n3 * 10;
            }
            return n1 + n2 == n3;
        }
    }
}
