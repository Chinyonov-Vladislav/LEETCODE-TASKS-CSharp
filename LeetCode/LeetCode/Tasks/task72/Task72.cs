using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task72
{
    /*
     72. Редакционное расстояние
    Даны две строки word1 и word2, верните минимальное количество операций, необходимых для преобразования word1 в word2.
    Над словом разрешены следующие три операции:
        Вставить символ
        Удаление символа
        Заменить символ
    Ограничения:
        0 <= word1.length, word2.length <= 500
        word1 и word2 состоят из строчных английских букв.
    https://leetcode.com/problems/edit-distance/description/
     */
    public class Task72 : InfoBasicTask
    {
        public Task72(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string word1 = "horse";
            string word2 = "ros";
            Console.WriteLine($"Первое слово: \"{word1}\"\nВторое слово: \"{word2}\"");
            if (isValid(word1, word2))
            {
                int res = minDistance(word1, word2);
                Console.WriteLine($"Минимальное количество операций для преобразования строки \"{word1}\" в строку \"{word2}\" = {res}");
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
            int lowLimit = 0;
            int highLimit = 500;
            if(word1.Length<lowLimit || word1.Length> highLimit || word2.Length < lowLimit || word2.Length > highLimit)
            {
                return false;
            }
            foreach (char c in word1)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            foreach (char c in word2)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }
        private int minDistance(string word1, string word2)
        {
            int n = word1.Length + 1;
            int m = word2.Length + 1;
            int[,] matrixD = new int[n, m];
            const int deletionCost = 1;
            const int insertionCost = 1;
            for (var i = 0; i < n; i++)
            {
                matrixD[i, 0] = i;
            }
            for (var j = 0; j < m; j++)
            {
                matrixD[0, j] = j;
            }
            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    var substitutionCost = word1[i - 1] == word2[j - 1] ? 0 : 1;
                    matrixD[i, j] = Math.Min(matrixD[i - 1, j] + deletionCost,          // удаление
                                            Math.Min(matrixD[i, j - 1] + insertionCost, // вставка
                                            matrixD[i - 1, j - 1] + substitutionCost)); // замена
                }
            }
            return matrixD[n - 1, m - 1];
        }
    }
}
