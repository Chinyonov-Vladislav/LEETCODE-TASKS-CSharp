using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task70
{
    /*
     70. Подъем по лестнице
    Вы поднимаетесь по лестнице. Чтобы добраться до верха, нужно n шагов.
    Каждый раз вы можете либо подняться по 1 ступеням, либо по 2 ступенькам. Сколькими разными способами вы можете подняться на вершину?
    Ограничения:
        1 <= n <= 45
    https://leetcode.com/problems/climbing-stairs/description/
     */
    public class Task70 : InfoBasicTask
    {
        public Task70(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int countStairs = 3;
            Console.WriteLine($"Количество ступенек = {countStairs}");
            if (isValid(countStairs))
            {
                int count = climbStairs(countStairs);
                Console.WriteLine($"Количество способов подняться по лестнице, поднимаясь по 1 или 2 ступеням = {count}");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int n)
        {
            if (n<1||n>45)
            {
                return false;
            }
            return true;
        }
        private int climbStairs(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
    }
}
