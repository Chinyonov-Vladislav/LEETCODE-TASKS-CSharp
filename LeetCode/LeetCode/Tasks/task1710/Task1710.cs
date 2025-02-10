using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1710
{
    /*
     1710. Максимальное количество единиц на грузовике
    Вам нужно погрузить некоторое количество коробок на один грузовик. Вам дан двумерный массив boxTypes, где boxTypes[i] = [numberOfBoxesi, numberOfUnitsPerBoxi]:
        numberOfBoxes i - количество ячеек типа i.
        numberOfUnitsPerBox i - количество единиц измерения в каждой ячейке данного типа i.
    Вам также дано целое число truckSize, которое является максимальным количеством ящиков, которые можно погрузить в грузовик. Вы можете выбрать любые ящики для погрузки в грузовик, если количество ящиков не превышает truckSize.
    Укажите максимальное общее количество единиц, которые можно погрузить на грузовик.
    https://leetcode.com/problems/maximum-units-on-a-truck/description/
     */
    public class Task1710 : InfoBasicTask
    {
        public Task1710(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] array = new int[][] {
                new int[] { 5,10},
                new int[] { 2,5},
                new int[] { 4,7},
                new int[] { 3,9},
            };
            printTwoDimensionalArray(array, "Исходный двумерный массив");
            int countBoxes = 10;
            int max = maximumUnits(array, countBoxes);
            Console.WriteLine($"Максимальное количество единиц товара для погрузки в грузовик с местом для {countBoxes} ящиков = {max}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maximumUnits(int[][] boxTypes, int truckSize)
        {
            int max = 0;
            int countBoxs = 0;
            Array.Sort(boxTypes, (first, second) => second[1] - first[1]);
            for (int i = 0; i < boxTypes.Length; i++)
            {
                if (countBoxs + boxTypes[i][0] <= truckSize)
                {
                    max += boxTypes[i][0] * boxTypes[i][1];
                    countBoxs += boxTypes[i][0];
                }
                else
                {
                    int remainPlaceForBoxes = truckSize - countBoxs;
                    max += remainPlaceForBoxes * boxTypes[i][1];
                    countBoxs += remainPlaceForBoxes;
                }
                if (truckSize - countBoxs == 0)
                {
                    break;
                }
            }
            return max;
        }
    }
}
