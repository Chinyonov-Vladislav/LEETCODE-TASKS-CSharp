using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task944
{
    /*
     944. Удалите столбцы, чтобы сделать их отсортированными
    Вам предоставляется массив n строк strs, все одинаковой длины.
    Строки можно расположить так, чтобы в каждой строке была одна строка, образуя сетку.
    Вы хотите удалить столбцы, которые не отсортированы лексикографически.
    Возвращает количество столбцов, которые вы будете удалять.
    https://leetcode.com/problems/delete-columns-to-make-sorted/description/
     */
    public class Task944 : InfoBasicTask
    {
        public Task944(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] strs = new string[] { "zyx", "wvu", "tsr"  };
            printArray(strs, "Массив строк: ");
            int countColumnsForDelete = minDeletionSize(strs);
            Console.WriteLine($"Количество столбцов для удаления, которые не отсортированы лексикографически = {countColumnsForDelete}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int minDeletionSize(string[] strs)
        {
            if (strs.Length <= 1)
            {
                return 0;
            }
            int countDeletedColumns = 0;
            int countColumns = strs[0].Length;
            for (int numberColumn = 0; numberColumn < countColumns; numberColumn++)
            {
                for (int indexRow = 1; indexRow < strs.Length; indexRow++)
                {
                    if ((int)strs[indexRow][numberColumn] < (int)strs[indexRow - 1][numberColumn])
                    {
                        countDeletedColumns++;
                        break;
                    }
                }
            }
            return countDeletedColumns;
        }
    }
}
