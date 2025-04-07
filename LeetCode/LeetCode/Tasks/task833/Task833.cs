using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task833
{
    /*
     833. Найдите и замените в строке
     Вам дана строк s для выполнения k операций замен. Для операций замен приводятся три 0-индексированные параллельные массивы, indices, sources и targets все длины k.
    Завершить ith замена операции:
        Проверьте, встречается ли подстрока sources[i] по индексу indices[i] в исходной строке s.
        Если этого не происходит, ничего не предпринимайте.
        В противном случае, если это произойдёт, замените эту подстроку на targets[i].
    Например, если s = "abcd", indices[i] = 0, sources[i] = "ab", и targets[i] = "eee", то результатом этой замены будет "eeecd".
    Все операции замены должны выполняться одновременно, то есть операции замены не должны влиять на индексацию друг друга. Тестовые сценарии будут генерироваться таким образом, чтобы замены не перекрывались.
        Например, тестовый пример с s = "abc", indices = [0, 1] и sources = ["ab","bc"] не будет сгенерирован, потому что замены "ab" и "bc" перекрываются.
    Верните полученную строку после выполнения всех операций замены в s.
    Подстрока - это непрерывная последовательность символов в строке.
    Ограничения:
        1 <= s.length <= 1000
        k == indices.length == sources.length == targets.length
        1 <= k <= 100
        0 <= indexes[i] < s.length
        1 <= sources[i].length, targets[i].length <= 50
        s состоит только из строчных английских букв.
        sources[i] и targets[i] состоят только из строчных английских букв.
    https://leetcode.com/problems/find-and-replace-in-string/description/
     */
    public class Task833 : InfoBasicTask
    {
        public Task833(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "abcd";
            int[] indices = new int[] { 0, 2 };
            string[] sources = new string[] { "ab", "ec" };
            string[] targets = new string[] { "eee", "ffff" };
            Console.WriteLine($"Исходная строка для замены: \"{s}\"");
            printArray(indices, "Массив индексов: ");
            printArray(sources, "Массив заменяемых строк: ");
            printArray(targets, "Массив строк для замены: ");
            if (isValid(s, indices, sources, targets))
            {
                string res = findReplaceString(s, indices, sources, targets);
                Console.WriteLine($"Строка после выполнения замен: \"{res}\"");
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
        private bool isValid(string s, int[] indices, string[] sources, string[] targets)
        {
            int lowLimitLengthInitialString = 1;
            int highLimitLengthInitialString = 1000;
            if (s.Length < lowLimitLengthInitialString || s.Length > highLimitLengthInitialString)
            {
                return false;
            }
            int lowLimitValueK = 1;
            int highLimitValueK = 100;
            int k = indices.Length;
            if (k < lowLimitValueK || k > highLimitValueK)
            {
                return false;
            }
            if (!(sources.Length == k && targets.Length == k))
            {
                return false;
            }
            foreach (int index in indices)
            {
                if (index < 0 || index >= s.Length)
                {
                    return false;
                }
            }
            int lowLimitSourceAndTargetLength = 1;
            int highLimitSourceAndTargetLength = 50;
            List<string[]> sourcesAndTargets = new List<string[]>() { sources, targets };
            foreach (string[] arr in sourcesAndTargets)
            {
                foreach (string str in arr)
                {
                    if (str.Length < lowLimitSourceAndTargetLength || str.Length > highLimitSourceAndTargetLength)
                    {
                        return false;
                    }
                    foreach (char c in str)
                    {
                        if (!(c >= 'a' && c <= 'z'))
                        {
                            return false;
                        }
                    }
                }
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }
        private string findReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            StringBuilder sb = new StringBuilder();
            int k = 0;
            List<Tuple<int, Tuple<string, string>>> data = new List<Tuple<int, Tuple<string, string>>>();
            for (int i = 0; i < indices.Length; i++)
            {
                data.Add(new Tuple<int, Tuple<string, string>>(indices[i], new Tuple<string, string>(sources[i], targets[i])));
            }
            List<Tuple<int, Tuple<string, string>>> sortedData = data.OrderBy(item => item.Item1).ToList();
            for (int i = 0; i < s.Length;)
            {
                if (k < sortedData.Count)
                {
                    if (sortedData[k].Item1 == i)
                    {
                        int remainCountSymbols = s.Length - i;
                        if (remainCountSymbols >= sortedData[k].Item2.Item1.Length)
                        {
                            string checkString = s.Substring(i, sortedData[k].Item2.Item1.Length);
                            if (checkString == sortedData[k].Item2.Item1)
                            {
                                sb.Append(sortedData[k].Item2.Item2);
                                i += sortedData[k].Item2.Item1.Length;
                            }
                        }
                        else
                        {
                            sb.Append(s[i]);
                            i++;
                        }
                        k++;
                    }
                    else
                    {
                        sb.Append(s[i]);
                        i++;
                    }
                }
                else
                {
                    sb.Append(s[i]);
                    i++;
                }
            }
            return sb.ToString();
        }
    }
}
