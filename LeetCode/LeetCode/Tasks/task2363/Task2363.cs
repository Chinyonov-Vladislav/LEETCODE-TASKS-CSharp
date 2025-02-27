using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2363
{
    /*
     2363. Объединять похожие элементы
    Вам даны два двумерных массива целых чисел items1 и items2, представляющие два набора элементов. Каждый массив items обладает следующими свойствами:
        items[i] = [valuei, weighti] где valuei обозначает стоимость, а weighti обозначает весith предмета.
        Значение каждого элемента в items является уникальным.
    Возвращает двумерный целочисленный массив ret где ret[i] = [valuei, weighti], где weighti - сумма весов всех элементов со значением valuei.
    Примечание: ret должно быть возвращено в возрастающем порядке по значению.
    Ограничения:
        1 <= items1.length, items2.length <= 1000
        items1[i].length == items2[i].length == 2
        1 <= valuei, weighti <= 1000
        Каждый valuei элементitems1 уникален.
        Каждый valuei элементitems2 уникален.
    https://leetcode.com/problems/merge-similar-items/description/
     */
    public class Task2363 : InfoBasicTask
    {
        public Task2363(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] items1 = new int[][] {
                new int[] {1,1 },
                new int[] {4,5 },
                new int[] {3,8 },
            };
            int[][] items2 = new int[][] {
                new int[] {3,1 },
                new int[] {1,5 },
            };
            printTwoDimensionalArray(items1, "Двумерный массив №1");
            printTwoDimensionalArray(items2, "Двумерный массив №2");
            IList<IList<int>> result = mergeSimilarItems(items1, items2);
            printIListIListInt(result);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<IList<int>> mergeSimilarItems(int[][] items1, int[][] items2)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < items1.Length; i++)
            {
                if (dict.ContainsKey(items1[i][0]))
                {
                    dict[items1[i][0]]+= items1[i][1];
                }
                else
                {
                    dict.Add(items1[i][0], items1[i][1]);
                }
            }
            for (int i = 0; i < items2.Length; i++)
            {
                if (dict.ContainsKey(items2[i][0]))
                {
                    dict[items2[i][0]] += items2[i][1];
                }
                else
                {
                    dict.Add(items2[i][0], items2[i][1]);
                }
            }
            var list = dict.OrderBy(x => x.Key).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(new List<int>() { list[i].Key, list[i].Value });
            }
            return result;
        }
    }
}
