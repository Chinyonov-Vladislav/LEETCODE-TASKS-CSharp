using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task605
{
    /*
     605. Расстановка цветов на клумбе
    У вас есть длинная клумба, на которой некоторые участки засажены, а некоторые нет. Однако цветы нельзя сажать на соседних участках.
    Учитывая целочисленный массив flowerbed, содержащий 0 и 1, где 0 означает пусто, а 1 означает не пусто, а также целочисленное значение n, верните true если n новые цветы можно посадить в flowerbed не нарушая правило отсутствия соседних цветов и false в противном случае.
     */
    public class Task605 : InfoBasicTask
    {
        public Task605(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] flowerbed = new int[] { 0,1,0 };
            int countFlowers = 1;
            Console.WriteLine(canPlaceFlowers(flowerbed, countFlowers) ? $"Можно посадить {countFlowers} цветков на клумбе" : $"Нельзя посадить {countFlowers} цветков на клумбе");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool canPlaceFlowers(int[] flowerbed, int n)
        {
            int canFlowerCount = 0;
            if (flowerbed.Length == 0)
            {
                return false;
            }
            if (flowerbed.Length == 1)
            {
                if (flowerbed[0] == 0)
                {
                    canFlowerCount++;
                }
                return canFlowerCount >= n;
            }
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0)
                {
                    if ((i == 0 && flowerbed[i + 1] == 0) 
                        || (i == flowerbed.Length - 1 && flowerbed[i - 1] == 0) 
                        || (i !=0 && i != flowerbed.Length - 1 && flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0))
                    {
                        flowerbed[i] = 1;
                        canFlowerCount++;
                        i++;
                    }
                }
            }
            return canFlowerCount >= n;
        }
    }
}
