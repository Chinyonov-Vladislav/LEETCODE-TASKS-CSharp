using LeetCode.Basic;
using System;
using System.Linq;

namespace LeetCode.Tasks.task268
{
    public class Task268 : InfoBasicTask
    {
        /*
         268. Недостающий Номер
        Учитывая массив nums, содержащий n различных чисел в диапазоне [0, n], верните единственное число в диапазоне, которого нет в массиве.
         */
        public Task268(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] sum = new int[] { 3, 0, 1 };
            Console.WriteLine($"Пропущенное значение = {missingNumber(sum)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int missingNumber(int[] nums)
        {
            int sumFromArray = nums.Sum();
            int sum = 0;
            for (int i = 0; i <= nums.Length; i++)
            {
                sum += i;
            }
            return sum - sumFromArray;
        }
    }
}
