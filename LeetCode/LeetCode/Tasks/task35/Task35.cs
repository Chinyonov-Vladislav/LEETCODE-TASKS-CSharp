using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task35
{
    public class Task35 : InfoBasicTask
    {
        public Task35(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] sortedArray = new int[] { 1, 3, 5, 6 };
            int target = 4;
            int index = searchInsert(sortedArray, target);
            Console.WriteLine($"Индекс вставки: {index}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int searchInsert(int[] nums, int target)
        {
            return binarySearch(nums, target);
        }
        private int binarySearch(int[] array, int target) // модифицированный алгоритм бинарного поиска. Если элемент найден, то возвращается индекс элемента. Если элемент не найден, то возвращается значение левого указателя
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // Избегаем переполнения

                if (array[mid] == target)
                {
                    return mid; // Элемент найден
                }
                else if (array[mid] < target)
                {
                    left = mid + 1; // Ищем в правой половине
                }
                else
                {
                    right = mid - 1; // Ищем в левой половине
                }
            }

            return left; // Элемент не найден
        }
    }
}
