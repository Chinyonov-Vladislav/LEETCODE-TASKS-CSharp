using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1502
{
    /*
     1502. Может Сделать Арифметическую Прогрессию Из Последовательности
    Последовательность чисел называется арифметической прогрессией, если разница между любыми двумя последовательными элементами одинакова.
    Учитывая массив чисел arr, верните true если массив можно переставить так, чтобы он образовал арифметическую прогрессию. В противном случае верните false.
    https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence/description/
     */
    public class Task1502 : InfoBasicTask
    {
        public Task1502(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 3, 5, 1 };
            printArray(array, "Исходный массив: ");
            Console.WriteLine(canMakeArithmeticProgression(array) ? "Возможно сделать арифметическую прогрессию из массива путём перестановок элементов" : "Невозможно сделать арифметическую прогрессию из массива путём перестановок элементов");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool canMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);
            if (arr.Length >= 2)
            {
                int diffence = arr[1] - arr[0];
                for (int i = 2; i < arr.Length; i++)
                {
                    if (arr[i] - arr[i - 1] != diffence)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
