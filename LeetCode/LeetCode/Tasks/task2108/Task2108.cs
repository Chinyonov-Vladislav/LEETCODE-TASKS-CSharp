using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2108
{
    /*
     2108. Найдите первую палиндромную строку в массиве
    Учитывая массив строк words, верните первую палиндромную строку в массиве. Если такой строки нет, верните пустую строку "".
    Строка является палиндромом, если она читается одинаково в прямом и обратном направлении.
    https://leetcode.com/problems/find-first-palindromic-string-in-the-array/description/
     */
    public class Task2108 : InfoBasicTask
    {
        public Task2108(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "abc", "car", "ada", "racecar", "cool" };
            printArray(words, "Исходный массив слов: ");
            string firstPalindromeFromWords = firstPalindrome(words);
            Console.WriteLine(firstPalindromeFromWords == String.Empty ? "Палиндром в массиве не найден" : $"Первый палиндром в массиве: \"{firstPalindromeFromWords}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string firstPalindrome(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                int left = 0;
                int right = currentWord.Length - 1;
                bool isPalindrome = true;
                while (left < right)
                {
                    if (currentWord[left] != currentWord[right])
                    {
                        isPalindrome = false;
                        break;
                    }
                    left++;
                    right--;
                }
                if(isPalindrome)
                {
                    return currentWord;
                }
            }
            return String.Empty;
        }
    }
}
