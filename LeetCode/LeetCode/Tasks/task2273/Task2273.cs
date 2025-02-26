using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2273
{
    /*
     2273. Найдите результирующий массив после удаления анаграмм
    Вам дан нумерованный с 0 массив строк words, где words[i] состоит из строчных букв английского алфавита.
    За одну операцию выберите любой индекс i такой, что 0 < i < words.length и words[i - 1] и words[i] являются анаграммами, и удалите words[i] из words. Продолжайте выполнять эту операцию до тех пор, пока не сможете выбрать индекс, удовлетворяющий условиям.
    Вернёмся words к выполнению всех операций. Можно показать, что выбор индексов для каждой операции в любом произвольном порядке приведёт к тому же результату.
    Анаграмма — это слово или фраза, образованные путём перестановки букв другого слова или фразы с использованием всех исходных букв ровно по одному разу. Например, "dacb" — это анаграмма "abdc".
    https://leetcode.com/problems/find-resultant-array-after-removing-anagrams/description/
     */
    public class Task2273 : InfoBasicTask
    {
        public Task2273(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "abba", "baba", "bbaa", "cd", "cd" };
            printArray(words);
            IList<string> result = removeAnagrams(words);
            printIListString(result, "Результирующий массив после удаления анаграмм: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<string> removeAnagrams(string[] words)
        {
            IList<string> result = new List<string>();
            if(words.Length ==0)
            {
                return result;
            }
            result.Add(words[0]);
            List<char> previous = new List<char>(words[0]);
            previous.Sort();
            for (int i=0;i<words.Length;i++)
            {
                List<char> current = new List<char>(words[i]);
                current.Sort();
                if (current.Count != previous.Count)
                {
                    result.Add(words[i]);
                    previous = current;
                }
                else
                {
                    bool isIdentic = true;
                    for (int index = 0; index < current.Count; index++)
                    {
                        if (current[index] != previous[index])
                        {
                            isIdentic = false;
                            break;
                        }
                    }
                    if (!isIdentic)
                    {
                        result.Add(words[i]);
                        previous = current;
                    }
                }
            }
            return result;
        }
    }
}
