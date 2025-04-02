using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task676
{
    /*
     676. Реализовать магический словарь
    Создайте структуру данных, которая инициализируется списком из разных слов. Учитывая строку, вы должны определить, можно ли изменить ровно один символ в этой строке так, чтобы она совпадала с любым словом в структуре данных.
    Реализация MagicDictionary класс:
        MagicDictionary() Инициализирует объект.
        void buildDict(String[] dictionary) Задает структуру данных с помощью массива различных строк dictionary.
        bool search(String searchWord)Возвращает trueесли вы можете изменить ровно один символв searchWordлюбой строке в структуре данных, в противном случае возвращает false.
   Ограничения:
        1 <= dictionary.length <= 100
        1 <= dictionary[i].length <= 100
        dictionary[i] состоит только из строчных английских букв.
        Все строки в dictionary есть различных.
        1 <= searchWord.length <= 100
        searchWord состоит только из строчных английских букв.
        buildDict будет вызван только один раз до этого search.
        Максимум 100 звонки будут сделаны на search.
     https://leetcode.com/problems/implement-magic-dictionary/description/
     */
    public class Task676 : InfoBasicTask
    {
        public Task676(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] operations = new string[] { "MagicDictionary", "buildDict", "search", "search", "search", "search" };
            string[][] data = new string[][]
            {
                new string[] { },
                new string[] { "hello","leetcode" },
                new string[] { "hello" },
                new string[] { "hhllo" },
                new string[] { "hell" },
                new string[] { "leetcoded" }
            };
            printArray(operations, "Массив операций: ");
            printTwoDimensionalArray(data, "Массив данных для операций");
            if (isValid(operations, data))
            {
                MagicDictionary magicDictionary = null;
                for(int i=0;i<operations.Length;i++)
                {
                    switch (operations[i])
                    {
                        case "MagicDictionary":
                            magicDictionary = new MagicDictionary();
                            Console.WriteLine("Объект \"MagicDictionary\" был инициализирован");
                            break;
                        case "buildDict":
                            if (magicDictionary != null)
                            {
                                magicDictionary.BuildDict(data[i]);
                                printArray(data[i], "Массив слов, добавленных в словарь: ");
                            }
                            else
                            {
                                Console.WriteLine("Объект \"MagicDictionary\" не был инициализирован");
                            }
                            break;
                        case "search":
                            if (magicDictionary != null)
                            {
                                bool res = magicDictionary.Search(data[i][0]);
                                Console.WriteLine(res ? $"Можно изменить ровно один символ в строк {data[i][0]} для того, чтобы она соответствовала одной из строке в словаре" : $"Нельзя изменить ровно один символ в строк {data[i][0]} для того, чтобы она соответствовала одной из строке в словаре");
                            }
                            else
                            {
                                Console.WriteLine("Объект \"MagicDictionary\" не был инициализирован");
                            }
                            break;
                    }
                }
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
        private bool isValid(string[] operations, string[][] data)
        {
            int lowLimitCountOperations = 1;
            int highLimitCountOperations = 102;
            if (operations.Length != data.Length) // проверка на то, что длина массива операций и данных должна быть одинаковой
            {
                return false;
            }
            List<string> acceptedOperations = new List<string>() { "MagicDictionary", "buildDict", "search" };
            if (operations.Length < lowLimitCountOperations || operations.Length > highLimitCountOperations) // проверка ограничений на количество операций
            {
                return false;
            }
            int countSearchOperation = 0;
            for (int i = 0; i < operations.Length; i++)
            {
                if (!acceptedOperations.Contains(operations[i]))
                {
                    return false;
                }
                if (i == 0)
                {
                    if (operations[i] != "MagicDictionary") // проверка, что первая операция MagicDictionart
                    {
                        return false;
                    }
                    if (data[i].Length != 0)
                    {
                        return false;
                    }
                }
                else if (i == 1)
                {
                    if (operations[i] != "buildDict") // проверка, что вторая операция (если существует) - buildDict
                    {
                        return false;
                    }
                    int lowLimitLengthDict = 1;
                    int highLimitLengthDict = 100;
                    int lowLimitLengthItemDict = 1;
                    int highLimitLengthItemDict = 100;
                    HashSet<string> set = new HashSet<string>();
                    string[] dictionary = data[i];
                    if (dictionary.Length < lowLimitLengthDict || dictionary.Length > highLimitLengthDict)
                    {
                        return false;
                    }
                    foreach (string word in dictionary)
                    {
                        if (word.Length < lowLimitLengthItemDict || word.Length > highLimitLengthItemDict)
                        {
                            return false;
                        }
                        set.Add(word);
                        foreach (char c in word)
                        {
                            if (!(c >= 'a' && c <= 'z'))
                            {
                                return false;
                            }
                        }
                    }
                    if (set.Count != dictionary.Length)
                    {
                        return false;
                    }
                }
                else
                {
                    if (operations[i] != acceptedOperations[2])
                    {
                        return false;
                    }
                    if (data[i].Length != 1)
                    {
                        return false;
                    }
                    int lowLimitLengthSearchWord = 1;
                    int highLimitLengthSearchWord = 100;
                    string searchWord = data[i][0];
                    if ( searchWord.Length < lowLimitLengthSearchWord || searchWord.Length > highLimitLengthSearchWord)
                    {
                        return false;
                    }
                    foreach (char c in searchWord)
                    {
                        if (!(c >= 'a' && c <= 'z'))
                        {
                            return false;
                        }
                    }
                    countSearchOperation++;
                }
            }
            if (countSearchOperation > 100)
            {
                return false;
            }
            return true;
        }
    }
}
