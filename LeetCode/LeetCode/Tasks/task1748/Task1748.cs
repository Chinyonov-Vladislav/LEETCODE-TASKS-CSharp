using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1748
{
    /*
     1748. Сумма уникальных элементов
    Вам дан целочисленный массив nums. Уникальные элементы массива — это элементы, которые встречаются в массиве ровно один раз.
    Возвращает сумму всех уникальных элементов nums.
    https://leetcode.com/problems/sum-of-unique-elements/description/
     */
    public class Task1748 : InfoBasicTask
    {
        public Task1748(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 1,1,1};
            printArray(nums, "Исходный массив: ");
            int sumUniqueItems = sumOfUnique(nums);
            Console.WriteLine($"Сумма уникальных элементов = {sumUniqueItems}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int sumOfUnique(int[] nums)
        {
            Dictionary<int,int> dict = new Dictionary<int,int>();
            for (int i = 0; i < nums.Length; i++) {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            return dict.Where(x => x.Value == 1).Sum(x => x.Key);
        }
    }
}
