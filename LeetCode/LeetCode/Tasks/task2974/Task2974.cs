using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2974
{
    /*
     2974. Игра с минимальными числами
    Вам дан нумерованный с 0 целочисленный массив nums чётной длины, а также пустой массив arr. Алиса и Боб решили сыграть в игру, в которой в каждом раунде Алиса и Боб делают по одному ходу. Правила игры следующие:
        В каждом раунде сначала Алиса удаляет минимальный элемент из nums, а затем Боб делает то же самое.
        Теперь сначала Боб добавит удалённый элемент в массив arr, а затем Алиса сделает то же самое.
        Игра продолжается до тех пор, пока nums не опустеет.
    Возвращает результирующий массив arr.
    Ограничения:
        2 <= nums.length <= 100
        1 <= nums[i] <= 100
        nums.length % 2 == 0
    https://leetcode.com/problems/minimum-number-game/description/
     */
    public class Task2974 : InfoBasicTask
    {
        public Task2974(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 5, 4, 2, 3 };
            printArray(nums, "Исходный массив для игры: ");
            if (isValid(nums))
            {
                int[] res = numberGame(nums);
                printArray(res, "Результирующий массив после игры: ");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 2 || nums.Length > 100 || nums.Length % 2 != 0)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] numberGame(int[] nums)
        {
            int[] res = new int[nums.Length];
            int pointerAlice = 0;
            int pointerBob = 1;
            Array.Sort(nums);
            while (pointerBob < nums.Length)
            {
                res[pointerBob] = nums[pointerAlice];
                res[pointerAlice] = nums[pointerBob];
                pointerAlice += 2;
                pointerBob += 2;
            }
            return res;
        }
    }
}
