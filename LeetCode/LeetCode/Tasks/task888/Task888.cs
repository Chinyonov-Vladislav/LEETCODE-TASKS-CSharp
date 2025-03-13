using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task888
{
    /*
     888. Честный обмен конфетами
    У Алисы и Боба разное количество конфет. Вам даны два массива целых чисел aliceSizes и bobSizes, где aliceSizes[i] — количество конфет в коробке ith у Алисы, а bobSizes[j] — количество конфет в коробке jth у Боба.
    Поскольку они друзья, они хотели бы обменяться по одной коробке конфет, чтобы после обмена у них обоих было одинаковое количество конфет. 
    Общее количество конфет у человека — это сумма количества конфет в каждой имеющейся у него коробке.
    Верните целый массив,answerгде answer[0] — количество конфет в коробке, которые Алиса должна обменять, а answer[1] — количество конфет в коробке, которые Боб должен обменять. Если ответов несколько, вы можете вернуть любой из них. Гарантируется, что хотя бы один ответ существует.
    Ограничения:
        1 <= aliceSizes.length, bobSizes.length <= 104
        1 <= aliceSizes[i], bobSizes[j] <= 105
        У Алисы и Боба разное общее количество конфет.
        Для данного ввода будет по крайней мере один допустимый ответ.
    https://leetcode.com/problems/fair-candy-swap/description/
     */
    public class Task888 : InfoBasicTask
    {
        public Task888(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] aliceSizes = new int[] { 2 };
            int[] bobSizes = new int[] { 1, 3 };
            printArray(aliceSizes, "Количество конфет Алисы в каждой из коробок: ");
            printArray(bobSizes, "Количество конфет Боба в каждой из коробок: ");
            if (isValid(aliceSizes, bobSizes))
            {
                int[] res = fairCandySwap(aliceSizes, bobSizes);
                Console.WriteLine($"Количество конфет, которые должна обменять Алиса = {res[0]}\nКоличество конфет, которые должен обменять Боб = {res[1]}");
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
        private bool isValid(int[] aliceSizes, int[] bobSizes)
        {
            int highLimit = (int)Math.Pow(10, 4);
            if (aliceSizes.Length < 1 || aliceSizes.Length > highLimit || bobSizes.Length < 1 || bobSizes.Length > highLimit)
            {
                return false;
            }
            highLimit = (int)Math.Pow(10, 5);
            long countCandiesAlice = 0;
            long countCandiesBob = 0;
            foreach (int item in aliceSizes)
            {
                if (item < 1 || item > highLimit)
                {
                    return false;
                }
                countCandiesAlice += item;
            }
            foreach (int item in bobSizes)
            {
                if (item < 1 || item > highLimit)
                {
                    return false;
                }
                countCandiesBob += item;
            }
            if (countCandiesAlice == countCandiesBob)
            {
                return false;
            }
            bool isExistResult = false;
            int[] result = new int[2];
            int totalCandiesAlice = aliceSizes.Sum();
            int totalCandiesBob = bobSizes.Sum();
            int diff = (totalCandiesAlice - totalCandiesBob) / 2;
            HashSet<int> setCandiesBob = new HashSet<int>(bobSizes);
            foreach (int candy in aliceSizes)
            {
                if (setCandiesBob.Contains(candy - diff))
                {
                    isExistResult = true;
                    break;
                }
            }
            if (!isExistResult)
            {
                return false;
            }
            return true;
        }
        private int[] fairCandySwap(int[] aliceSizes, int[] bobSizes)
        {
            int[] result = new int[2];
            int totalCandiesAlice = aliceSizes.Sum();
            int totalCandiesBob = bobSizes.Sum();
            int diff = (totalCandiesAlice - totalCandiesBob) / 2;
            HashSet<int> setCandiesBob = new HashSet<int>(bobSizes);
            foreach (int candy in aliceSizes)
            {
                if (setCandiesBob.Contains(candy - diff))
                {
                    result[0] = candy;
                    result[1] = candy - diff;
                }
            }
            return result;
        }
    }
}
