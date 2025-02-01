using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task461
{
    /*
     461. Расстояние Хэмминга
    Расстояние Хэмминга между двумя целыми числами — это количество позиций, в которых соответствующие биты отличаются.
    Даны два целых числа x и y, верните расстояниеХэмминга между ними.
     */
    public class Task461 : InfoBasicTask
    {
        public Task461(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int x = 1, y = 4;
            Console.WriteLine($"Расстояние Хамминга = {hammingDistance(x,y)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int hammingDistance(int x, int y)
        {
            int countDifferentBits = 0;
            while (x > 0 || y > 0)
            {
                int bitOfX = x > 0 ? x & 1 : 0;
                int bitOfY =  y > 0 ? y & 1 : 0;
                if (bitOfX != bitOfY)
                {
                    countDifferentBits++;
                }
                x = x > 0 ? x >>= 1 : x;
                y = y > 0 ? y >>= 1 : y;
            }
            return countDifferentBits;
        }
    }
}
