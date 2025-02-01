using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task338
{
    /*
     338. Подсчет битов
    Учитывая целое число n, верните массив ans длины n + 1 такой, что для каждого i (0 <= i <= n), ans[i] это количество 1's в двоичном представлении i.
     */
    public class Task338 : InfoBasicTask
    {
        public Task338(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 5;
            int[] result = countBits(n);
            printArray(result, "Результат");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] countBits(int n)
        {
            int[] ans = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                int countZeros = 0;
                int currentNumber = i;
                while (currentNumber != 0)
                {
                    currentNumber &= currentNumber - 1;
                    countZeros++;
                }
                ans[i] = countZeros;
            }
            return ans;
        }
    }
}
