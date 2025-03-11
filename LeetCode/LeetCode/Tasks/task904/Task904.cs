using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task904
{
    /*
     904. Фрукты в корзинах
    Вы посещаете ферму, на которой фруктовые деревья растут в один ряд слева направо. Деревья представлены целочисленным массивом fruits где fruits[i] — тип плодов, которые даёт ith дерево.
    Вы хотите собрать как можно больше фруктов. Однако у владельца есть несколько строгих правил, которым вы должны следовать:
        У вас есть только две корзины, и в каждую корзину можно положить только один вид фруктов. Количество фруктов в каждой корзине не ограничено.
        Начиная с любого дерева по вашему выбору, вы должны собрать ровно по одному плоду с каждого дерева (включая начальное дерево), двигаясь вправо. Собранные плоды должны поместиться в одну из ваших корзин.
        Как только вы доберётесь до дерева с плодами, которые не помещаются в ваши корзины, вы должны остановиться.
    Учитывая целочисленный массив fruits, верните максимальноеколичествофруктов, которые вы можете собрать.
    Ограничения:
        1 <= fruits.length <= 10^5
        0 <= fruits[i] < fruits.length
    https://leetcode.com/problems/fruit-into-baskets/description/
     */
    public class Task904 : InfoBasicTask
    {
        public Task904(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] fruits = new int[] { 1, 2, 3, 2, 2 };
            printArray(fruits, "Массив фруктов по типу: ");
            if (isValid(fruits))
            {
                int max = totalFruit(fruits);
                Console.WriteLine($"Максимальное количество возможных собранных фруктов = {max}");
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
        private bool isValid(int[] fruits)
        {
            int highLimit = (int)Math.Pow(10,5);
            if (fruits.Length < 1 || fruits.Length > highLimit)
            {
                return false;
            }
            foreach (int fruit in fruits)
            {
                if (fruit < 0 || fruit >= fruits.Length)
                {
                    return false;
                }
            }
            return true;
        }
        private int totalFruit(int[] fruits)
        {
            int count = 0;
            for (int i = 0; i < fruits.Length; i++)
            {
                int totalLocal = 0;
                HashSet<int> set = new HashSet<int>();
                for (int j = i; j < fruits.Length; j++)
                {
                    if (set.Contains(fruits[j]))
                    {
                        totalLocal++;
                    }
                    else
                    {
                        if (set.Count == 2)
                        {
                            break;
                        }
                        else
                        {
                            set.Add(fruits[j]);
                            totalLocal++;
                        }
                    }
                }
                if (totalLocal > count)
                {
                    count = totalLocal;
                }
            }
            return count;
        }
    }
}
