using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2942
{
    /*
     2942. Найдите слова, содержащие символ
    Вам будет предоставлен 0-индексированный массив строк words и символ x.
    Верните массив индексов, представляющих слова, содержащие этот символ x.
    Обратите внимание, что возвращаемый массив может располагаться в любом порядке.
    Ограничения:
        1 <= words.length <= 50
        1 <= words[i].length <= 50
        x это строчная английская буква.
        words[i] состоит только из строчных английских букв.
    https://leetcode.com/problems/find-words-containing-character/description/
     */
    public class Task2942 : InfoBasicTask
    {
        public Task2942(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "leet", "code" };
            printArray(words);
            char x = 'e';
            Console.WriteLine($"Символ для поиска количества слов, содержащий данный символ: \'{x}\'");
            if (isValid(words, x))
            {
                IList<int> indexs = findWordsContaining(words, x);
                if (indexs.Count == 0)
                {
                    Console.WriteLine($"В массиве отсутствуют слова, содержащие символ \'{x}\'");
                }
                else
                {
                    printIListInt(indexs, $"Массив индексов слов, содержащих символ \'{x}\': ");
                }

            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string[] words, char x)
        {
            if (words.Length < 1 || words.Length > 50)
            {
                return false;
            }
            foreach (string word in words)
            {
                if (word.Length < 1 || word.Length > 50)
                {
                    return false;
                }
                foreach (char c in word)
                {
                    if (c < 'a' || c > 'z')
                    {
                        return false;
                    }
                }
            }
            if (x < 'a' || x > 'z')
            {
                return false;
            }
            return true;
        }
        private IList<int> findWordsContaining(string[] words, char x)
        {
            IList<int> res= new List<int>();
            for(int i=0;i<words.Length;i++)
            {
                foreach (char c in words[i])
                {
                    if (c == x)
                    {
                        res.Add(i);
                        break;
                    }
                }
            }
            return res;
        }
    }
}
