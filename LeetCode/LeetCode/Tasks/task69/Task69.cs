using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task69
{
    public class Task69 : InfoBasicTask
    {
        public Task69(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int x = 10;
            int answer = mySqrt(x);
            Console.WriteLine($"Целый округленный квадратный корень из {x} = {answer}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int mySqrt(int x)
        {
            int start = 0;
            int end = x;
            while (start <= end)
            {
                int mid = start + (end - start) / 2; // Избегаем переполнения
                if ((long)mid * mid == (long)x)
                {
                    return mid;
                }
                else if ((long)mid * mid > (long)x)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }

            }
            return end;
        }
       
    }
}
