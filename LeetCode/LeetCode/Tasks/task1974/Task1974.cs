using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1974
{
    /*
     1974. Минимальное время для набора слова на специальной пишущей машинке
    Существует специальная пишущая машинка со строчными английскими буквами 'a' для 'z' расположения по кругу с указателем. 
    Символ можно напечатать только в том случае, если указатель указывает на этот символ. 
    Изначально указатель указывает на символ 'a'.
    https://leetcode.com/problems/minimum-time-to-type-word-using-special-typewriter/description/
     */
    public class Task1974 : InfoBasicTask
    {
        public Task1974(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "zjpc";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            int minTime = minTimeToType(str);
            Console.WriteLine($"Минимальное время для набора строки \"{str}\" = {minTime}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int minTimeToType(string word)
        {
            int totalTimeToTap = 0;
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int currentPointer = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (chars[currentPointer] == word[i])
                {
                    totalTimeToTap++;
                }
                else
                {
                    int timeClockWise = 0;
                    int timeCounterClockWise = 0;
                    int tempPointer = currentPointer;
                    while (chars[tempPointer] != word[i])
                    {
                        timeClockWise++;
                        tempPointer++;
                        if (tempPointer == chars.Length)
                        {
                            tempPointer = 0;
                        }
                    }
                    tempPointer = currentPointer;
                    while (chars[tempPointer] != word[i])
                    {
                        timeCounterClockWise++;
                        tempPointer--;
                        if (tempPointer < 0)
                        {
                            tempPointer = chars.Length-1;
                        }
                    }
                    currentPointer = tempPointer;
                    int minTime = Math.Min(timeClockWise, timeCounterClockWise);
                    totalTimeToTap += minTime;
                    totalTimeToTap += 1;
                }
            }
            return totalTimeToTap;
        }
        // скопировано с leetcode
        private int bestSolution(string word)
        {
            int time = word.Length;
            char pointer = 'a';
            for (int i = 0; i < word.Length; i++)
            {
                time += Math.Min(Math.Abs(word[i] - pointer), 26 - Math.Abs(pointer - word[i]));
                pointer = word[i];
            }
            return time;
        }
    }
}
