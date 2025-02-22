using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1995
{
    /*
     1995. Подсчитайте специальные четверки
    Учитывая нумерованный с 0 целочисленный массив nums, верните количестворазличныхчетверок (a, b, c, d) таких что:
        nums[a] + nums[b] + nums[c] == nums[d], и
        a < b < c < d
    https://leetcode.com/problems/count-special-quadruplets/description/
     */
    public class Task1995 : InfoBasicTask
    {
        public Task1995(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 1, 1, 3, 5 };
            printArray(array, "Исходный массив: ");
            int count = countQuadruplets(array);
            Console.WriteLine($"Количество специальных четверок = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countQuadruplets(int[] nums)
        {
            int count = 0;
            for (int index1 = 0; index1 < nums.Length - 3; index1++)
            {
                for (int index2 = index1 + 1; index2 < nums.Length - 2; index2++)
                {
                    for (int index3 = index2 + 1; index3 < nums.Length - 1; index3++)
                    {
                        for (int index4 = index3 + 1; index4 < nums.Length; index4++)
                        {
                            if (nums[index1] + nums[index2] + nums[index3] == nums[index4])
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }
    }
}
