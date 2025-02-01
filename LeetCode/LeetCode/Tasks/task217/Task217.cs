using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task217
{
    /*
    217. Содержит дубликаты

    Учитывая целочисленный массив nums, верните true если какое-либо значение встречается в массиве хотя бы дважды, и верните false если все элементы уникальны.
     */
    public class Task217 : InfoBasicTask
    {
        public Task217(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1,2,3,4,5,6,6 };
            Console.WriteLine(containsDuplicate(nums) ? "Исходный массив содержит дубликаты" : "Исходный массив не содержит дубликаты");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public bool containsDuplicate(int[] nums)
        {
            return !(nums.Length == new HashSet<int>(nums).Count);
        }
    }
}
