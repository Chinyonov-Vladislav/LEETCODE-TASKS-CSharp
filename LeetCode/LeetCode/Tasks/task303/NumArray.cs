namespace LeetCode.Tasks.task303
{
    public class NumArray
    {
        private int[] array;
        public NumArray(int[] nums)
        {
            array = new int[nums.Length];
            nums.CopyTo(array, 0);
        }

        public int SumRange(int left, int right)
        {
            int sum = 0;
            for (; left <= right; left++)
            {
                sum += array[left];
            }
            return sum;
        }
    }
}
