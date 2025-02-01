using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task599
{
    /*
     599. Минимальная сумма индексов двух списков
    Даны два массива строк list1 и list2, найдите общие строки с наименьшей суммой индексов.
    Общая строка — это строка, которая встречается и в list1 и в list2.
    Общая строка с наименьшей суммой индексов - это общая строка, такая, что если она появилась в list1[i] и list2[j], то i + j это должно быть минимальное значение среди всех других общих строк.
    Верните все общие строки с наименьшей суммой индексов. Верните ответ в любом порядке.
     */
    public class Task599 : InfoBasicTask
    {
        public Task599(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] list1 = new string[] { "happy", "sad", "good" };
            string[] list2 = new string[] { "sad", "happy", "good" };
            string[] result = findRestaurant(list1, list2);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public string[] findRestaurant(string[] list1, string[] list2)
        {
            int minValue = Int32.MaxValue;
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            for (int i = 0; i < list1.Length; i++)
            {
                for (int j = 0; j < list2.Length; j++)
                {
                    if (list1[i] == list2[j] && !pairs.ContainsKey(list1[i]))
                    {
                        pairs.Add(list1[i], i + j);
                        if (i + j < minValue)
                        {
                            minValue = i + j;
                        }
                    }
                }
            }
            List<string> result = new List<string>();
            foreach (var pair in pairs)
            {
                if (pair.Value == minValue)
                {
                    result.Add(pair.Key);
                }
            }
            return result.ToArray();
        }
    }
}
