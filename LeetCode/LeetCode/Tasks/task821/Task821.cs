using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task821
{
    /*
     821. Кратчайшее расстояние до символа
    Учитывая строку s и символ c, встречающийся в s, верните массив целых чисел answer где answer.length == s.length и answer[i] - расстояние от индекса i до ближайшего вхождения символа c в s.
    Расстояние между двумя индексами i и j равно abs(i - j), где abs — функция абсолютного значения.
    https://leetcode.com/problems/shortest-distance-to-a-character/description/
     */
    public class Task821 : InfoBasicTask
    {
        public Task821(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "loveleetcode";
            char c = 'e';
            int[] result = shortestToChar(s, c);
            printArray(result, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] shortestToChar(string s, char c)
        {
            int[] result = new int[s.Length];
            List<int> indexsOfChar = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    indexsOfChar.Add(i);
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    result[i] = 0;
                }
                else
                {
                    int minValue = Int32.MaxValue;
                    foreach (var item in indexsOfChar)
                    {
                        int dist = Math.Abs(i - item);
                        if (minValue > dist)
                        {
                            minValue = dist;
                        }
                    }
                    result[i] = minValue;
                }
            }
            return result;
        }
    }
}
