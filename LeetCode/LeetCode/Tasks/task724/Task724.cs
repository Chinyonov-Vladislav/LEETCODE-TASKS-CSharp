using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task724
{
    /*
     724. Найдите cводный индекс
    Дан массив целых чисел nums. Вычислите опорный индекс этого массива.
    Опорный индекс — это индекс, при котором сумма всех чисел, строго расположенных слева от индекса, равна сумме всех чисел, строго расположенных справа от индекса.
    Если индекс находится на левом краю массива, то левая сумма равна 0, потому что слева нет элементов. Это также относится к правому краю массива.
    Верните крайний левыйиндекс поворота. Если такого индекса не существует, верните -1.
    https://leetcode.com/problems/find-pivot-index/description/
     */
    public class Task724 : InfoBasicTask
    {
        public Task724(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 7, 3, 6, 5, 6 };
            printArray(array, "Исходный массив: ");
            int searchedPivotIndex = pivotIndex(array);
            Console.WriteLine(searchedPivotIndex == -1 ? "Pivot index не найден" : $"Найденный pivot index = {searchedPivotIndex}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int pivotIndex(int[] nums)
        {
            int leftSum = 0;
            int rightSum = 0;
            int pivotIndex = 0;
            bool firstIteration = true;
            while(pivotIndex < nums.Length)
            {
                if (firstIteration)
                {
                    for (int i = nums.Length - 1; i > pivotIndex; i--)
                    {
                        rightSum += nums[i];
                    }
                    firstIteration = false;
                }
                else
                {
                    leftSum += nums[pivotIndex - 1];
                    rightSum -= nums[pivotIndex];
                }
                if (leftSum == rightSum)
                {
                    return pivotIndex;
                }
                pivotIndex++;
            }
            return -1;
        }
    }
}
