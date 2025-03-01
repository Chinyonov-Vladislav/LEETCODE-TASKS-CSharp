using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2558
{
    /*
     2558. Берите подарки из самой богатой кучи
    Вам дан целочисленный массив gifts с количеством подарков в каждой стопке. Каждую секунду вы делаете следующее:
        Выберите стопку с максимальным количеством подарков.
        Если есть несколько стопок с максимальным количеством подарков, выберите любую.
        Уменьшите количество подарков в стопке до квадратного корня из исходного количества подарков в стопке.
    Верните количество подарков, оставшихся через k секунды.
    Ограничения:
        1 <= gifts.length <= 10^3
        1 <= gifts[i] <= 10^9
        1 <= k <= 10^3
    https://leetcode.com/problems/take-gifts-from-the-richest-pile/description/
     */
    public class Task2558 : InfoBasicTask
    {
        public Task2558(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 25, 64, 9, 4, 100 };
            int k = 4;
            printArray(arr);
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(arr, k))
            {
                long result = pickGifts(arr, k);
                Console.WriteLine($"Результат = {result}");
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
        private bool isValid(int[] gifts, int k)
        {
            int upperLimit = (int)Math.Pow(10, 3);
            if (gifts.Length < 1 || gifts.Length > upperLimit)
            {
                return false;
            }
            if (k < 1 || k > upperLimit)
            {
                return false;
            }
            upperLimit = (int)Math.Pow(10, 9);
            foreach (int gift in gifts)
            {
                if (gift < 1 || gift > upperLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private long pickGifts(int[] gifts, int k)
        {
            Array.Sort(gifts);
            for (int count = 0; count < k; count++)
            {
                int square = (int)Math.Sqrt(gifts[gifts.Length - 1]);
                int left = 0;
                int right = gifts.Length;
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (gifts[mid] < square)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                for (int i = gifts.Length - 1; i > left; i--)
                {
                    (gifts[i], gifts[i - 1]) = (gifts[i - 1], gifts[i]);
                }
                gifts[left] = square;
            }
            long result = 0;
            foreach (int gift in gifts)
            {
                result += gift;
            }
            return result;
        }
    }
}
