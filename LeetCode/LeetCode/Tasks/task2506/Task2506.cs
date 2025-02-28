using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2506
{
    /*
     2506. Подсчитайте пары похожих строк
    Вам будет предоставлен строковый массив с 0-индексацией words.
    Две строки похожи, если они состоят из одних и тех же символов.
        Например, "abca" и "cba" похожи, поскольку оба состоят из символов 'a', 'b', и 'c'.
        Однако "abacba" и "bcfd" не похожи друг на друга, поскольку состоят из разных символов.
    Верните количество пар, (i, j) таких что 0 <= i < j <= word.length - 1 и две строки words[i] и words[j] похожи.
    Ограничения:
        1 <= words.length <= 100
        1 <= words[i].length <= 100
        words[i] состоит только из строчных английских букв.
    https://leetcode.com/problems/count-pairs-of-similar-strings/description/
     */
    public class Task2506 : InfoBasicTask
    {
        public Task2506(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "zgtzytjkre", "jjzdbxyutj", "umghhnlihq", "mdxjukhqsm", "mqdplhuvqr", "xpdhateywu", "ugedwkxapc", "vjpryhictr" };
            printArray(words);
            if (isValid(words))
            {
                int count = similarPairs(words);
                Console.WriteLine($"Количество пар схожих строк = {count}");
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
        private bool isValid(string[] words)
        {
            if (words.Length < 1 || words.Length > 100)
            {
                return false;
            }
            foreach (string word in words) {
                if (word.Length < 1 || word.Length > 100)
                {
                    return false;
                }
                foreach (char c in word)
                {
                    if (!char.IsLetter(c) || (char.IsLetter(c) && char.IsUpper(c)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int similarPairs(string[] words)
        {
            int count = 0;
            for (int i = 0; i < words.Length - 1; i++)
            {
                HashSet<char> set1 = new HashSet<char>(words[i]);
                for (int j = i + 1; j < words.Length; j++)
                {
                    HashSet<char> set2 = new HashSet<char>(words[j]);
                    if (set1.Count == set2.Count)
                    {
                        List<char> list1 = set1.ToList();
                        list1.Sort();
                        List<char> list2 = set2.ToList();
                        list2.Sort();
                        if (list1.SequenceEqual(list2))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        //Скопировано с leetcode
        private int bestSolution(string[] words)
        {
            Dictionary<int, int> maskCount = new Dictionary<int, int>();
            foreach (var word in words)
            {
                int mask = 0;
                foreach (char c in word)
                {
                    // Set the bit corresponding to the character
                    mask |= (1 << (c - 'a'));
                }
                if (maskCount.ContainsKey(mask))
                {
                    maskCount[mask]++;
                }
                else
                {
                    maskCount[mask] = 1;
                }
            }
            int result = 0;
            // For each bitmask frequency, count the number of pairs
            foreach (var count in maskCount.Values)
            {
                result += count * (count - 1) / 2;
            }
            return result;
        }
    }
}
