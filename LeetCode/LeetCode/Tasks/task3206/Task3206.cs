using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3206
{
    /*
     3206. Чередующиеся группы I
    Есть круг из красных и синих плиток. Вам дан массив целых чисел colors. Цвет плитки i представлен colors[i]:
        colors[i] == 0 означает, что плитка i красная.
        colors[i] == 1 означает, что плитка i синего цвета.
    Каждые 3 последовательные плитки в круге с чередующимися цветами (средняя плитка отличается по цвету от левой и правой плиток) называются чередующейся группой.
    Возвращает количество чередующихся групп.
    Обратите внимание, что, поскольку colors представляет собой круг, первая и последняя плитки считаются расположенными рядом друг с другом.
    Ограничения:
        3 <= colors.length <= 100
        0 <= colors[i] <= 1
    https://leetcode.com/problems/alternating-groups-i/description/
     */
    public class Task3206 : InfoBasicTask
    {
        public Task3206(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 0, 1, 0, 0, 1 };
            printArray(nums, "Массив цветов: ");
            if (isValid(nums))
            {
                int res = numberOfAlternatingGroups(nums);
                Console.WriteLine($"Количество чередующихся групп = {res}");
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
        private bool isValid(int[] colors)
        {
            if (colors.Length < 3 || colors.Length > 100)
            {
                return false;
            }
            foreach (int color in colors)
            {
                if (color != 0 && color != 1)
                {
                    return false;
                }
            }
            return true;
        }
        private int numberOfAlternatingGroups(int[] colors)
        {
            int count = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                if (i == 0)
                {
                    if (colors[i] != colors[colors.Length - 1] && colors[i] != colors[i + 1])
                    {
                        count++;
                    }
                }
                else if (i == colors.Length - 1)
                {
                    if (colors[i] != colors[i-1] && colors[i] != colors[0])
                    {
                        count++;
                    }
                }
                else
                {
                    if (colors[i] != colors[i - 1] && colors[i] != colors[i+1])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
