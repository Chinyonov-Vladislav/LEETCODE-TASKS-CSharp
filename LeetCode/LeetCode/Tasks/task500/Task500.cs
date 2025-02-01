using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks.task500
{
    /*
     500. Строка клавиатуры
    Учитывая массив строк words, верните слова, которые можно напечатать, используя буквы алфавита только в одной строке американской клавиатуры, как показано на изображении ниже.
    Обратите внимание, что строки нечувствительны к регистру, то есть строчные и прописные буквы одной и той же строки считаются находящимися в одной строке.
    На американской клавиатуре:
        первая строка состоит из символов "qwertyuiop"
        вторая строка состоит из символов "asdfghjkl",
        третья строка состоит из символов "zxcvbnm".
    https://leetcode.com/problems/keyboard-row/description/
     */
    public class Task500 : InfoBasicTask
    {
        public Task500(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "Hello", "Alaska", "Dad", "Peace" };
            printArray(words, "Исходный массив: ");
            printArray(findWords(words), "Слова, которые можно напечатать с помощью одной строки клавиатуры: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string[] findWords(string[] words)
        {
            List<string> result = new List<string>();
            string firstRow = "qwertyuiop";
            string secondRow = "asdfghjkl";
            string thirdRow = "zxcvbnm";
            foreach (var word in words)
            {
                string currentWordInLower = word.ToLower();
                bool isFirstRow = true;
                bool isSecondRow = true;
                bool isThirdRow = true;
                for (int i = 0; i < currentWordInLower.Length; i++)
                {
                    char currentChar = currentWordInLower[i];
                    if (!firstRow.Contains(currentChar) && isFirstRow)
                    {
                        isFirstRow = false;
                    }
                    if (!secondRow.Contains(currentChar) && isSecondRow)
                    {
                        isSecondRow = false;
                    }
                    if (!thirdRow.Contains(currentChar) && isThirdRow)
                    {
                        isThirdRow = false;
                    }
                }
                if (isFirstRow || isSecondRow || isThirdRow)
                {
                    result.Add(word);
                }
            }
            return result.ToArray();
        }
    }
}
