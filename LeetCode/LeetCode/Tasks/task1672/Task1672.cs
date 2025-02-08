using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1672
{
    /*
     1672. Сумма денег самого богатого клиента
    Вам предоставляется m x n целочисленная сетка, accounts где accounts[i][j] - это сумма денег, которую i​​​​​​​​​​​th​​​​ клиент имеет в j​​​​​​​​​​​th банке. Верните то богатство которое есть у самого богатого клиента.
    Состояние клиента — это сумма денег на всех его банковских счетах. Самый богатый клиент — это клиент с максимальным состоянием.
    https://leetcode.com/problems/richest-customer-wealth/description/
     */
    public class Task1672 : InfoBasicTask
    {
        public Task1672(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] array = new int[][] {
                new int[] { 2,8,7 },
                new int[] {7,1,3 },
                new int[] { 1, 9, 5 }
            };
            printTwoDimensionalArray(array, "Исходная двумерная матрица");
            int max = maximumWealth(array);
            Console.WriteLine($"Сумма денег самого богатого клиента = {max}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maximumWealth(int[][] accounts)
        {
            int max = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                int current = 0;
                for (int j = 0; j < accounts[i].Length; j++)
                {
                    current += accounts[i][j];
                }
                if (current > max)
                {
                    max = current;
                }
            }
            return max;
        }
    }
}
