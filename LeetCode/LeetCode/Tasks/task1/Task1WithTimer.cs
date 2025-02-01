using System;
using LeetCode.Basic;

namespace LeetCode.Tasks.task1
{
    public class Task1WithTimer : TaskWithTimer
    {
        public Task1WithTimer(int number, string name, string description, Difficult difficult, InfoBasicTask task) : base(number, name, description, difficult, task)
        {
        }

        public override void execute()
        {
            DateTime nowStart = DateTime.Now;
            task.execute();
            DateTime nowFinish = DateTime.Now;
            Console.WriteLine($"Время выполнения: {(nowFinish - nowStart).TotalMilliseconds} ms");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
    }
}
