using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2913
{
    /*
     2913. Сумма квадратов элементов подмассивов
    Вам будет предоставлен целочисленный массив с 0-индексом nums.
    Отдельное количество подмассива nums определяется как:
        Пусть nums[i..j] — это подмассив nums из всех индексов от i до j включительно, таких что 0 <= i <= j < nums.length. Тогда количество различных значений в nums[i..j] называется количеством различных значений в nums[i..j].
    Верните сумму квадратов из отдельных значенийвсех подмассивовnums.
    Подмассив — это непрерывная непустая последовательность элементов внутри массива.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 100
    https://leetcode.com/problems/subarrays-distinct-element-sum-of-squares-i/description/
     */
    public class Task2913 : InfoBasicTask
    {
        public Task2913(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<int> nums = new List<int>() { 1, 2, 1 };
            printIListInt(nums, "Исходный массив чисел: ");
            if (isValid(nums))
            {
                int res = sumCounts(nums);
                Console.WriteLine($"Сумма квадратов количества уникальных значений каждого из возможных подмассивов = {res}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(IList<int> nums)
        {
            if (nums.Count < 1 || nums.Count > 100)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int sumCounts(IList<int> nums)
        {
            int res = 0;
            int count = 1;
            while (count <= nums.Count)
            {
                HashSet<int> set = new HashSet<int>();
                for (int start = 0; start < nums.Count -count +1; start++)
                {
                    int end = start + count;
                    Console.WriteLine($"Start = {start} END = {end}");
                    for (int i = start; i < end; i++)
                    {
                        set.Add(nums[i]);
                    }
                    res += set.Count * set.Count;
                    set.Clear();
                }
                count++;
            }
            return res;
        }
    }
}
