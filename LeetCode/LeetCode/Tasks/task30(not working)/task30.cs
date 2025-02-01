using System;
using System.Collections.Generic;
using LeetCode.Basic;
namespace LeetCode.Tasks.task30
{
    public class task30 : InfoBasicTask
    {
        public task30(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "barfoothefoobarman";
            string[] words = new string[] { "bar", "foo" };
            IList<int> indexs = findSubstring(s, words);
            printResult(indexs);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> findSubstring(string s, string[] words)
        {
            List<int> indexs = new List<int>();
            string totalStringFromWords = "";
            foreach (var word in words)
            {
                totalStringFromWords += word;
            }
            List<string> combinations = GetAllConcatenations(words, totalStringFromWords);
            for (int i = 0; i < combinations.Count; i++)
            {
                if (s.Contains(combinations[i]))
                {
                    for (int j = 0; j <= s.Length - combinations[i].Length; j++)
                    {
                        string substring = s.Substring(j, combinations[i].Length);
                        if (substring == combinations[i])
                        {
                            if (!indexs.Contains(j))
                            {
                                indexs.Add(j);
                            }
                        }
                    }
                }
            }
            return indexs;
        }

        private List<string> GetAllConcatenations(string[] array, string totalWord)
        {
            var results = new List<string>();
            GenerateCombinations(array, "", results, new bool[array.Length], totalWord);
            return results;
        }

        private void GenerateCombinations(string[] array, string current, List<string> results, bool[] used, string totalWord)
        {
            if (current.Length == totalWord.Length)
            {
                results.Add(current);
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    GenerateCombinations(array, current + array[i], results, used, totalWord);
                    used[i] = false;
                }
            }
        }

        private void printResult(IList<int> result)
        {
            if (result.Count > 0)
            {
                Console.Write("Результат: ");
                if (result.Count >= 2)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (i == 0)
                        {
                            Console.Write($"[{result[i]},");
                        }
                        else if (i == result.Count - 1)
                        {
                            Console.Write($"{result[i]}]\n");
                        }
                        else
                        {
                            Console.Write($"{result[i]},");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"[{result[0]}]");
                }
            }
            else
            {
                Console.WriteLine("Результаты отсутствуют");
            }
        }
    }
}
