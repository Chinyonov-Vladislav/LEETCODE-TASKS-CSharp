using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1534
{
    /*
     1534.Количество хороших триплетов
    Дан массив целых чисел arr и три целых числа a, b и c. Необходимо найти количество хороших триплетов.
    Триплет (arr[i], arr[j], arr[k]) является хорошим , если выполняются следующие условия:
        0 <= i < j < k < arr.length
        |arr[i] - arr[j]| <= a
        |arr[j] - arr[k]| <= b
        |arr[i] - arr[k]| <= c
       Где |x| обозначает абсолютное значение x.
    Возвращает количество хороших триплетов.
     */
    public class Task1534 : InfoBasicTask
    {
        public Task1534(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 3, 0, 1, 1, 9, 7 };
            int a = 7;
            int b = 2;
            int c = 3;
            printArray(arr, "Исходный массив: ");
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
            int count = countGoodTriplets(arr, a, b, c);
            Console.WriteLine($"Количество хороших триплетов = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countGoodTriplets(int[] arr, int a, int b, int c)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (Math.Abs(arr[i] - arr[j]) <= a && Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
