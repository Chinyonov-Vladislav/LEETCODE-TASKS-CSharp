using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1046
{
    /*
    1046. Вес Последнего Камня
    Вам дан массив целых чисел stones где stones[i] — это вес камня i
    Мы играем в игру с камнями. На каждом ходу мы выбираем самые тяжёлые два камня и разбиваем их. Предположим, что самые тяжёлые два камня имеют вес x и y с x <= y. Результат этого разбивания:
        Если x == y, то оба камня разрушаются, и
        Если x != y, то камень с весом x разрушается, а камень с весом y приобретает новый вес y - x.
        В конце игры остаётся не более одного камня.
    Верните вес последнего оставшегося камня. Если камней не осталось, верните 0.
    https://leetcode.com/problems/last-stone-weight/description/
     */
    public class Task1046 : InfoBasicTask
    {
        public Task1046(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] stones = new int[] { 2, 7, 4, 1, 8, 1 };
            printArray(stones,"Исходный массив веса камней: ");
            int weightLastStone = lastStoneWeight(stones);
            Console.WriteLine(weightLastStone == 0 ? "Последнего камня не осталось" : $"Вес последнего камня = {weightLastStone}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int lastStoneWeight(int[] stones)
        {
            List<int> stonesList = stones.ToList();
            stonesList.Sort();
            while (stonesList.Count > 1)
            {
                int yStone = stonesList[stonesList.Count-1];
                int xStone = stonesList[stonesList.Count - 2];
                stonesList.RemoveAt(stonesList.Count - 1);
                stonesList.RemoveAt(stonesList.Count - 1);
                if (yStone != xStone)
                {
                    int newWeight = yStone - xStone;
                    int positionOfInsert = binarySearchInsertPosition(stonesList, newWeight);
                    if (positionOfInsert != -1)
                    {
                        stonesList.Insert(positionOfInsert, newWeight);
                    }
                }
            }
            return stonesList.Count == 1 ? stonesList[stonesList.Count-1] : 0;
        }
        private int binarySearchInsertPosition(List<int> array, int target)
        {
            int left = 0;
            int right = array.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                {
                    // Если элемент найден, возвращаем его позицию
                    return mid;
                }
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            // Если элемент не найден, возвращаем позицию для вставки
            return left;
        }
    }
}
