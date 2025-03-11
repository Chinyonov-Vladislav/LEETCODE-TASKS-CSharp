using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3248
{
    /*
     3248. Змея в матрице
    В n x n матрице grid есть змея, которая может двигаться в четырех возможных направлениях. Каждая ячейка в grid идентифицируется по позиции: grid[i][j] = (i * n) + j.
    Змейка начинается с ячейки 0 и следует последовательности команд.
    Вам дано целое число n , обозначающее размер grid , и массив строк commands , где каждая command[i] является либо "UP", либо "RIGHT", либо "DOWN", либо "LEFT". Гарантируется, что змея будет оставаться в границах grid на протяжении всего своего движения.
    Верните позицию конечной ячейки, в которой окажется змея после выполнения commands.
    Ограничения:
        2 <= n <= 10
        1 <= commands.length <= 100
        commands состоит только из "UP", "RIGHT", "DOWN" и "LEFT".
        Входные данные генерируются таким образом, что змея не будет выходить за пределы границ.
    https://leetcode.com/problems/snake-in-matrix/description/
     */
    public class Task3248 : InfoBasicTask
    {
        public Task3248(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 3;
            Console.WriteLine($"Размер двумерной матрица = {n}");
            IList<string> commands = new List<string>() { "DOWN", "RIGHT", "UP" };
            printIListString(commands, "Команды движения: ");
            if (isValid(n, commands))
            {
                int res = finalPositionOfSnake(n, commands);
                Console.WriteLine($"Значение конечной ячейки = {res}");
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
        private bool isValid(int n, IList<string> commands)
        {
            if (n < 2 || n > 10)
            {
                return false;
            }
            if (commands.Count < 1 || commands.Count > 100)
            {
                return false;
            }
            List<string> acceptedCommands = new List<string>() { "UP", "RIGHT", "DOWN", "LEFT" };
            foreach (string command in commands)
            {
                if (!acceptedCommands.Contains(command))
                {
                    return false;
                }
            }
            int indexRow = 0;
            int indexColumn = 0;
            foreach (string command in commands)
            {
                switch (command)
                {
                    case "UP":
                        indexRow--;
                        break;
                    case "RIGHT":
                        indexColumn++;
                        break;
                    case "DOWN":
                        indexRow++;
                        break;
                    case "LEFT":
                        indexColumn--;
                        break;
                }
                if (indexRow == n || indexColumn == n || indexRow < 0 || indexColumn < 0)
                {
                    return false;
                }
            }
            return true;
        }
        private int finalPositionOfSnake(int n, IList<string> commands)
        {
            int indexRow = 0;
            int indexColumn = 0;
            foreach (string command in commands)
            {
                switch (command)
                {
                    case "UP":
                        indexRow--;
                        break;
                    case "RIGHT":
                        indexColumn++;
                        break;
                    case "DOWN":
                        indexRow++;
                        break;
                    case "LEFT":
                        indexColumn--;
                        break;
                }
            }
            return (indexRow * n) + indexColumn;
        }
    }
}
