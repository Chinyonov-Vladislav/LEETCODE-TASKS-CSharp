using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task303
{
    /*
     303. Запрос суммы диапазона - неизменяемый
    Учитывая целочисленный массив nums, обработайте несколько запросов следующего типа:
        Вычислите сумму элементов nums между индексами left и right включительно, где left <= right.
    Реализовать класс NumArray:
        NumArray(int[] nums) Инициализирует объект целочисленным массивом nums.
        int sumRange(int left, int right) Возвращает сумму элементов nums между индексами left и right включительно (т. е. nums[left] + nums[left + 1] + ... + nums[right]).
     */
    public class Task303 : InfoBasicTask
    {
        public Task303(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { -2, 0, 3, -5, 2, -1 };
            NumArray objectNumArray = new NumArray(array);
            int left =0 ;
            int right = 2;
            Console.WriteLine($"Сумма элементов с индекса {left} по индекс {right} включительно равна {objectNumArray.SumRange(left, right)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
    }
}
