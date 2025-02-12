using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1909
{
    /*
     1909. Удалите один элемент, чтобы массив стал строго возрастающим
    Учитывая нумерованный с 0 целочисленный массив nums, верните true если его можно сделать строго возрастающим после удаления ровно одного элемента, или false в противном случае. Если массив уже является строго возрастающим, верните true.
    Массив nums строго увеличивается, если nums[i - 1] < nums[i] для каждого индекса (1 <= i < nums.length).
    https://leetcode.com/problems/remove-one-element-to-make-the-array-strictly-increasing/description/
     */
    public class Task1909 : InfoBasicTask
    {
        public Task1909(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 2, 10, 5, 7 };
            printArray(array, "Исходный массив: ");
            Console.WriteLine(canBeIncreasing(array) ? "Исходный массив может быть отсортирован по возрастанию после удаления одного элемента" : "Исходный массив не может быть отсортирован по возрастанию после удаления одного элемента");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool canBeIncreasing(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int[] newArray = new int[nums.Length-1];
                int indexInsert = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {
                        newArray[indexInsert] = nums[j];
                        indexInsert++;
                    }
                }
                bool newArrayIsSorted = true;
                for (int j = 1; j < newArray.Length; j++)
                {
                    if (newArray[j - 1] >= newArray[j])
                    {
                        newArrayIsSorted = false;
                        break;
                    }
                }
                if (newArrayIsSorted)
                {
                    return true;
                }
            }
            return false;
        }
        // скопировано с leetcode
        private bool bestSolution(int[] nums)
        {
            var prevHighest = -1;
            var highestEncountered = -1;
            var flag = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                if (n > highestEncountered)
                {
                    prevHighest = highestEncountered;
                    highestEncountered = n;
                    continue;
                }
                else if (flag == 1)
                {
                    return false;
                }
                {
                    flag = 1;
                    if (i + 1 >= nums.Length)
                    {
                        return true;
                    }
                    if (nums[i + 1] > highestEncountered)
                    {
                        continue;
                    }
                    highestEncountered = n;
                    if (highestEncountered <= prevHighest)
                    {
                        return false;
                    }
                    if (nums[i] > prevHighest)
                    {
                        continue;
                    }
                }
            }
            return true;
        }
    }
}
