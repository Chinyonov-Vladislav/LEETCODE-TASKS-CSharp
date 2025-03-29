using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task583
{
    /*
     583. Операция удаления для двух строк
    Учитывая две строки word1 и word2, верните минимальное количество шагов, необходимых для того, чтобы сделать word1 и word2 одинаковыми.
    За один шаг вы можете удалить ровно один символ в любой из строк.
    Ограничения:
        1 <= word1.length, word2.length <= 500
        word1 и word2 состоят только из строчных английских букв.
    https://leetcode.com/problems/delete-operation-for-two-strings/description/
     */
    public class Task583 : InfoBasicTask
    {
        public Task583(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string word1 = "sea";
            string word2 = "eat";
            Console.WriteLine($"Первое слово: \"{word1}\"\nВторое слово: \"{word2}\"");
            if (isValid(word1, word2))
            {
                int res = minDistance(word1, word2);
                Console.WriteLine($"Минимальное количество удаления одного символа в любой из строк для того, чтобы сделать строки \"{word1}\" и \"{word2}\" одинаковыми = {res}");
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
        private bool isValid(string word1, string word2)
        {
            int lowLimit = 1;
            int highLimit = 500;
            if (word1.Length < lowLimit || word1.Length > highLimit || word2.Length < lowLimit || word2.Length > highLimit)
            {
                return false;
            }
            List<string> words = new List<string>() { word1, word2 };
            foreach (string word in words)
            {
                foreach (char c in word)
                {
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int minDistance(string word1, string word2)
        {
            int countRows = word1.Length+1;
            int countColumns = word2.Length+1;
            int[][] arr = new int[countRows][];
            for (int i = 0; i < countRows; i++)
            {
                arr[i] = new int[countColumns];
            }
            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        arr[i][j] = 0;
                    }
                    else if (word1[i - 1] == word2[j - 1])
                    {
                        arr[i][j] = arr[i - 1][j - 1] + 1;
                    }
                    else
                    {
                        arr[i][j] = Math.Max(arr[i - 1][j], arr[i][j - 1]);
                    }
                }
            }
            return word1.Length + word2.Length - 2*arr[countRows - 1][countColumns - 1];
        }
    }
}
