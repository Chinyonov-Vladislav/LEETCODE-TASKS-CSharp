namespace LeetCode.Basic
{
    public abstract class TaskWithTimer: InfoBasicTask
    {
        protected InfoBasicTask task;

        protected TaskWithTimer(int number, string name, string description, Difficult difficult, InfoBasicTask task) : base(number, name, description, difficult)
        {
            this.task = task;
        }
    }
}
