using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1791
{
    /*
     1791. Найти центр звездного графа
    Существует неориентированный звёздчатый граф, состоящий из n узлов, пронумерованных от 1 до n. Звёздочный граф — это граф, в котором есть один центральный узел и ровно n - 1 рёбра, соединяющие центральный узел с каждым другим узлом.
    Вам дан двумерный целочисленный массив edges , где каждый edges[i] = [ui, vi] указывает на наличие ребра между узлами ui и vi. Верните центр заданного звёздчатого графа.
     https://leetcode.com/problems/find-center-of-star-graph/description/
     */
    public class Task1791 : InfoBasicTask
    {
        public Task1791(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] starGraph = new int[][] {
                new int[] { 1,2 },
                new int[] { 2,3 },
                new int[] { 4,2 },
            };
            printTwoDimensionalArray(starGraph, "Звездный граф");
            int center = findCenter(starGraph);
            Console.WriteLine($"Центральный узел имеет значение = {center}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findCenter(int[][] edges)
        {
            int[] allValues = new int[edges.Length * 2];
            int index = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                for (int j = 0; j < edges[i].Length; j++)
                {
                    allValues[index] = edges[i][j];
                    index++;
                }
            }
            return allValues.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
        }
        // скопировано с leetcode
        public int bestSolution(int[][] edges)
        {
            // The center node will be one of the two nodes in the first edge
            int node1 = edges[0][0];
            int node2 = edges[0][1];

            // Check the second edge to determine which node is the center
            if (edges[1][0] == node1 || edges[1][1] == node1)
            {
                return node1;
            }
            return node2;
        }
    }
}
