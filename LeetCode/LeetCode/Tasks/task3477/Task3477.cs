using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3477
{
    /*
     3477. Фрукты в корзинах II
    Вам даны два массива целых чисел fruits и baskets длиной n, где fruits[i] обозначает количество фруктов ith вида, а baskets[j] обозначает вместимость корзины jth вида.
    Слева направо разложите фрукты в соответствии с этими правилами:
        Каждый вид фруктов должен быть помещён в самую левую доступную корзину вместимостью больше или равной количеству фруктов этого вида.
        В каждой корзине может храниться только один вид фруктов.
        Если фрукт нельзя поместить ни в одну из корзин, он остаётся неразмещённым.
    Верните количество видов фруктов, которые остались нераспределёнными после выполнения всех возможных распределений.
    Ограничения:
        n == fruits.length == baskets.length
        1 <= n <= 100
        1 <= fruits[i], baskets[i] <= 1000
    https://leetcode.com/problems/fruits-into-baskets-ii/description/
     */
    public class Task3477 : InfoBasicTask
    {
        public Task3477(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] fruits = new int[] { 4, 2, 5 };
            printArray(fruits, "Массив количества фруктов по типу: ");
            int[] baskets = new int[] { 3, 5, 4 };
            printArray(baskets, "Массив вместимости корзин: ");
            if (isValid(fruits, baskets))
            {
                int count = numOfUnplacedFruits(fruits, baskets);
                Console.WriteLine($"Количество типов фруктов, которые не могут быть размещены в корзину = {count}");
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
        private bool isValid(int[] fruits, int[] baskets)
        {
            if (fruits.Length != baskets.Length)
            {
                return false;
            }
            if (fruits.Length < 1 || fruits.Length > 100)
            {
                return false;
            }
            for (int i = 0; i < fruits.Length; i++)
            {
                if (fruits[i] < 1 || fruits[i] > 1000 || baskets[i] < 1 || baskets[i] > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private int numOfUnplacedFruits(int[] fruits, int[] baskets)
        {
            int count = 0;
            bool[] bools = new bool[baskets.Length];
            for (int i = 0; i < fruits.Length; i++)
            {
                bool isPlaced = false;
                for (int j = 0; j < baskets.Length; j++)
                {
                    if (baskets[j] >= fruits[i] && !bools[j])
                    {
                        bools[j] = true;
                        isPlaced = true;
                        break;
                    }
                }
                if (!isPlaced)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
