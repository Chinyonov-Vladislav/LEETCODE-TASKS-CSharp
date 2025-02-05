using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1385
{
    /*
     1385. Найдите значение расстояния между двумя массивами
    Даны два целочисленных массива arr1 и arr2 и целое число d. Верните значение расстояния между двумя массивами.
    Значение расстояния определяется как количество элементов arr1[i] таких, что не существует элемента arr2[j] где |arr1[i]-arr2[j]| <= d.
    https://leetcode.com/problems/find-the-distance-value-between-two-arrays/description/
     */
    public class Task1385 : InfoBasicTask
    {
        public Task1385(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr1 = new int[] { 4, 5, 8 };
            printArray(arr1, "Массив №1: ");
            int[] arr2 = new int[] { 10, 9, 1, 8 };
            printArray(arr2, "Массив №2: ");
            int d = 2;
            Console.WriteLine($"Значение целого числа d = {d}");
            int distance = findTheDistanceValueFirstMethod(arr1, arr2, d);
            Console.WriteLine($"Расстояние между двумя массива = {distance}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findTheDistanceValueFirstMethod(int[] arr1, int[] arr2, int d)
        {
            int count = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                bool canAdd = true;
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (Math.Abs(arr1[i] - arr2[j]) <= d)
                    {
                        canAdd = false;
                        break;
                    }
                }
                if (canAdd)
                {
                    count++;
                }
            }
            return count;
        }
        private int findTheDistanceValueSecondMethod(int[] arr1, int[] arr2, int d)
        {
            int count = 0;
            Array.Sort(arr2);
            for (int i = 0; i < arr1.Length; i++)
            {
                int closestValue = findClosestValueWithBinarySearch(arr2, arr1[i]);
                if (Math.Abs(arr1[i] - closestValue) > d)
                {
                    count++;
                }
            }
            return count;
        }
        private int findClosestValueWithBinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] == target)
                {
                    return array[mid];
                }
                if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            if (right < 0)
            {
                return array[left];
            }
            if (left >= array.Length)
            {
                return array[right];
            }
            if (Math.Abs(array[left] - target) < Math.Abs(array[right] - target))
            {
                return array[left];
            }
            else
            {
                return array[right];
            }
        }
    }
}
