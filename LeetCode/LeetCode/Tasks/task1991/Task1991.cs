using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1991
{
    /*
     1991. Найдите средний индекс в массиве
    Учитывая целочисленный массив с 0-индексомnums, найдите крайний левый middleIndex (т. е. Наименьший из всех возможных).
    A middleIndex - это индекс, где nums[0] + nums[1] + ... + nums[middleIndex-1] == nums[middleIndex+1] + nums[middleIndex+2] + ... + nums[nums.length-1].
    Если middleIndex == 0, то сумма с левой стороны считается равной 0. Аналогично, если middleIndex == nums.length - 1, то сумма с правой стороны считается равной 0.
    Верните самый левый middleIndexиндекс, удовлетворяющий условию, или -1 если такого индекса нет.
    https://leetcode.com/problems/find-the-middle-index-in-array/description/
     */
    public class Task1991 : InfoBasicTask
    {
        public Task1991(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 2, 3, -1, 8, 4 };
            printArray(array, "Исходный массив: ");
            int middleIndex = findMiddleIndex(array);
            Console.WriteLine(middleIndex == -1 ? "Нет допустимого среднего индекса" : $"Средний индекс = {middleIndex}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findMiddleIndex(int[] nums)
        {
            int leftSum = 0;
            int rightSum = nums.Sum();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    rightSum -= nums[i];
                }
                else
                {
                    leftSum += nums[i - 1];
                    rightSum -= nums[i - 1];
                    rightSum -= nums[i];
                }
                if (leftSum == rightSum)
                {
                    return i;
                }
                rightSum += nums[i];
            }
            return -1;
        }
    }
}
