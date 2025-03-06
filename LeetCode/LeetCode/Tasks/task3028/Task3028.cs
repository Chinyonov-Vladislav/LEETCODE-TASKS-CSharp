using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3028
{
    /*
     3028. Муравей на границе
    Муравей находится на границе. Иногда он идёт влево, а иногда вправо.
    Вам дан массив ненулевых целых чисел nums. 
    Муравей начинает считывать nums с первого элемента до конца. На каждом шаге он перемещается в соответствии со значением текущего элемента:
        Если nums[i] < 0, то он перемещается влево на -nums[i] единицы.
        Если nums[i] > 0, то он перемещается вправо на nums[i] единицы.
    Верните количество раз, которое муравейвозвращаетсяк границе.
    Примечания:
        По обе стороны границы существует бесконечное пространство.
        Мы проверяем, находится ли муравей на границе, только после того, как он переместился на |nums[i]| единиц. Другими словами, если муравей пересекает границу во время движения, это не считается.
    Ограничения:
        1 <= nums.length <= 100
        -10 <= nums[i] <= 10
        nums[i] != 0
    https://leetcode.com/problems/ant-on-the-boundary/description/
     */
    public class Task3028 : InfoBasicTask
    {
        public Task3028(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 3, -5 };
            printArray(nums, "Массив движения муравья: ");
            if (isValid(nums))
            {
                int count = returnToBoundaryCount(nums);
                Console.WriteLine($"Количество раз возврата муравья к границе = {count}");
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
        private bool isValid(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num == 0 || num < -10 || num > 10)
                {
                    return false;
                }
            }
            return true;
        }
        private int returnToBoundaryCount(int[] nums)
        {
            int count = 0;
            int currentPos = 0;
            foreach (int num in nums)
            {
                currentPos += num;
                if (currentPos == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
