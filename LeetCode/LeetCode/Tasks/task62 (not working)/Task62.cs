using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task62
{
    /*
     62. Уникальные пути
    На сетке m x n находится робот. Изначально робот находится в верхнем левом углу (то есть в grid[0][0]). Робот пытается переместиться в нижний правый угол (то есть в grid[m - 1][n - 1]). В любой момент времени робот может перемещаться только вниз или вправо.
    Учитывая два целых числа m и n, верните количество возможных уникальных путей, по которым робот может добраться до правого нижнего угла.
    Тестовые примеры генерируются таким образом, чтобы ответ был меньше или равен 2 * 109.
    https://leetcode.com/problems/unique-paths/description/
     */
    public class Task62 : InfoBasicTask
    {
        public Task62(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int m = 3;
            int n = 7;
            Console.WriteLine($"Стартовая позиция = (0,0). Конечная позиция = ({m-1},{n-1})");
            int countUniquePaths = uniquePaths(m, n);
            Console.WriteLine($"Количество уникальных путей = {countUniquePaths}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int uniquePaths(int m, int n)
        {
            int indexX = 0;
            int indexY = 0;
            return move(indexX, indexY, m, n);

        }
        private int move(int currentX, int currentY, int m, int n, int totalUniquePaths = 0)
        {
            if (m - 1 == currentX && n - 1 == currentY)
            {
                return totalUniquePaths += 1;
            }
            if (currentX >= m || currentY >= n)
            {
                return totalUniquePaths;
            }
            totalUniquePaths = move(currentX+1, currentY, m, n, totalUniquePaths) + move(currentX, currentY+1, m, n, totalUniquePaths);
            return totalUniquePaths;
        }
    }
}
