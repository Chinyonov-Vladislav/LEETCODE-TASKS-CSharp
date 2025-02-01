using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task643
{
    /*
     643. Максимальное среднее значение подмассива I
    Вам дан целочисленный массив nums, состоящий из n элементов, и целое число k.
    Найдите непрерывный подмассив, длина которого равна k, имеющий максимальное среднее значение, и верните это значение. Будет принят любой ответ с погрешностью вычисления менее 10-5.
     */
    public class Task643 : InfoBasicTask
    {
        public Task643(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 12, -5, -6, 50, 3 };
            int k = 4;
            double result = findMaxAverage(nums, k);
            Console.WriteLine($"Наибольший максимум подмассива длины {k} = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private double findMaxAverage(int[] nums, int k)
        {
            double maxAverage = double.MinValue;
            int startIndex = 0;
            int finishIndex = k-1;
            bool firstIteration = true;
            double sum = 0;
            while (finishIndex < nums.Length)
            {
                if (firstIteration)
                {
                    for (int i = startIndex; i <= finishIndex; i++)
                    {
                        sum += nums[i];
                    }
                    firstIteration = false;
                }
                else
                {
                    sum = sum - nums[startIndex - 1] + nums[finishIndex];
                }
                double average = sum / k;
                if (average > maxAverage)
                {
                    maxAverage = average;
                }
                startIndex++;
                finishIndex++;
            }
            return maxAverage;
        }
    }
}
