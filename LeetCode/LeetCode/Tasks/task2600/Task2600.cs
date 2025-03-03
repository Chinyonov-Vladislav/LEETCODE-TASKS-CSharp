using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2600
{
    /*
     2600. K предметов с максимальной суммой
    В сумке лежат предметы, на каждом из которых написан номер 1, 0, или -1.
    Вам даны четыре неотрицательных целых числа numOnes, numZeros, numNegOnes, и k.
    Пакет изначально содержит:
        numOnes предметов с написанными на них 1.
        numZeroes предметов с написанными на них 0.
        numNegOnes предметов с написанными на них -1.
    Мы хотим выбрать ровно k предметов из доступных. Верните максимально возможную сумму чисел, написанных на предметах.
    Ограничения:
        0 <= numOnes, numZeros, numNegOnes <= 50
        0 <= k <= numOnes + numZeros + numNegOnes
    https://leetcode.com/problems/k-items-with-the-maximum-sum/description/
     */
    public class Task2600 : InfoBasicTask
    {
        public Task2600(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int numOnes = 3; 
            int numZeros = 2; 
            int numNegOnes = 0; 
            int k = 4;
            Console.WriteLine($"Количество предметов с 1 = {numOnes}\nКоличество предметов с 0 = {numZeros}\nКоличество предметов с -1 = {numNegOnes}\nКоличество предметов для взятия = {k}");
            if (isValid(numOnes, numZeros, numNegOnes, k))
            {
                int max = KItemsWithMaximumSum(numOnes, numZeros, numNegOnes, k);
                Console.WriteLine($"Максимальная сумма = {max}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int numOnes, int numZeros, int numNegOnes, int k)
        {
            int sum = numOnes + numZeros + numNegOnes;
            if (numOnes < 0 || numOnes > 50 || numZeros < 0 || numZeros > 50 || numNegOnes < 0 || numNegOnes > 50 || k < 0 || k > sum)
            {
                return false;
            }
            return true;
        }
        private int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
        {
            int result = 0;
            if (numOnes != 0)
            {
                if (numOnes < k)
                {
                    result += numOnes * 1;
                    k -= numOnes;
                }
                else
                {
                    result += k * 1;
                    return result;
                }
            }
            if (numZeros != 0)
            {
                if (numZeros < k)
                {
                    k -= numZeros;
                    numZeros = 0;
                }
                else
                {
                    return result;
                }
            }
            if (numNegOnes != 0)
            {
                if (numNegOnes < k)
                {
                    result += numOnes * -1;
                    k -= numNegOnes;
                    numZeros = 0;
                }
                else
                {
                    result += k * (-1);
                    return result;
                }
            }
            return result;
        }
    }
}
