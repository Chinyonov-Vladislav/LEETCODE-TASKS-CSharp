using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1013
{
    /*
     1013. Разделите массив на три части с равной суммой
    Дан массив целых чисел arr. Верните true, если мы можем разделить массив на три непустые части с равными суммами.
    Формально мы можем разбить массив на разделы, если сможем найти индексы i + 1 < j с помощью (arr[0] + arr[1] + ... + arr[i] == arr[i + 1] + arr[i + 2] + ... + arr[j - 1] == arr[j] + arr[j + 1] + ... + arr[arr.length - 1])
    https://leetcode.com/problems/partition-array-into-three-parts-with-equal-sum/description/
     */
    public class Task1013 : InfoBasicTask
    {
        public Task1013(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, -1, 1, -1 };
            printArray(array, "Исходный массив: ");
            Console.WriteLine(canThreePartsEqualSum(array) ? "Исходный массив может быть разбит на три непустых массива с одинаковой суммой" : "Исходный массив не может быть разбит на три непустых массива с одинаковой суммой");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool canThreePartsEqualSum(int[] arr)
        {
            int totalSum = arr.Sum();
            if (totalSum % 3 != 0)
            {
                return false;
            }
            int sumOfPart = totalSum / 3;
            int leftIndex = 0;
            int rightIndex = arr.Length - 1;
            int firstSum = 0;
            int secondSum = 0;
            bool firstIteration = true;
            while (leftIndex < rightIndex) {
                if (firstIteration)
                {
                    firstSum += arr[leftIndex];
                    secondSum += arr[rightIndex];
                    firstIteration = false;
                }
                else
                {
                    if (firstSum != sumOfPart)
                    {
                        firstSum += arr[leftIndex];
                    }
                    if (secondSum != sumOfPart)
                    {
                        secondSum += arr[rightIndex];
                    }
                }
                if (firstSum == sumOfPart && secondSum == sumOfPart)
                {
                    break;
                }
                if (firstSum != sumOfPart)
                {
                    leftIndex++;
                }
                if (secondSum != sumOfPart)
                {
                    rightIndex--;
                }
            }
            return firstSum == sumOfPart && secondSum == sumOfPart && rightIndex - leftIndex >1;
        }
        // скопировано с leetcode
        private bool bestSolution(int[] arr)
        {
            long total = 0;
            foreach (var num in arr)
            {
                total += num;
            }

            if (total % 3 != 0)
            { 
                return false; 
            }

            var target = total / 3;

            int count = 0;
            int currSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currSum += arr[i];

                if (currSum == target)
                {
                    count++;
                    currSum = 0;
                }
            }

            return count >= 3;
        }
    }
}
