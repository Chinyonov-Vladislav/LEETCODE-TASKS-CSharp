using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task506
{
    public class Task506 : InfoBasicTask
    {
        /*
         506. Относительные ранги
        Вам дан целочисленный массив score размером n, где score[i] — результат спортсмена ith на соревнованиях. Все результаты гарантированно уникальны.
        Спортсмены размещаются на основе их результатов, где у 1st спортсмена, занявшего первое место, самый высокий балл, у 2nd спортсмена, занявшего 2nd первое место, самый высокий балл и так далее. Место каждого спортсмена определяет его ранг:
            Ранг спортсмена, занимающего 1st место, равен "Gold Medal".
            Ранг спортсмена, занимающего 2nd место, равен "Silver Medal".
            Ранг спортсмена, занимающего 3rd место, равен "Bronze Medal".
            Для 4th места спортсмену, занявшему nth место, его ранг равен номеру места (т. е. Ранг спортсмена, занявшего xth место, равен "x").
        Верните массив answer размером n, где answer[i] — ранг спортсмена ith.
        https://leetcode.com/problems/relative-ranks/description/
         */
        public Task506(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] score = new int[] { 10, 3, 8, 9, 4 };
            printArray(score, "Счёт игроков: ");
            string[] result = findRelativeRanks(score);
            printArray(result, "Медали и места игроков: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public string[] findRelativeRanks(int[] score)
        {
            Dictionary<int, int> scoreDict = new Dictionary<int, int>(); // счёт, номер позиции
            string[] result = new string[score.Length];
            for (int i = 0; i < score.Length; i++) {
                result[i] = score[i].ToString();
                scoreDict.Add(score[i], i);
            }
            Array.Sort(score);
            for (int i = 0; i <score.Length; i++)
            {
                int valueScore = score[score.Length-1 - i];
                int indexForReplace = scoreDict[valueScore];
                if (i == 0)
                {
                    result[indexForReplace] = "Gold Medal";
                }
                else if (i == 1)
                {
                    result[indexForReplace] = "Silver Medal";
                }
                else if(i==2)
                {
                    result[indexForReplace] = "Bronze Medal";
                }
                else
                {
                    result[indexForReplace] = (i+1).ToString();
                }
            }
            return result;
        }
    }
}
