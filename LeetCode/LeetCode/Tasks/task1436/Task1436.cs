using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1436
{
    /*
     1436. Город назначения
    Вам дан массив paths, где paths[i] = [cityAi, cityBi] означает, что существует прямой путь из cityAi в cityBi. Верните город назначения, то есть город, из которого нет пути в другой город.
    Гарантируется, что граф маршрутов образует линию без петель, следовательно, будет ровно один конечный город.
    https://leetcode.com/problems/destination-city/description/
     */
    public class Task1436 : InfoBasicTask
    {
        public Task1436(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<IList<string>> paths = new List<IList<string>>() { 
                new List<string>() {"B", "C" },
                new List<string>() {"D", "B" },
                new List<string>() {"C", "A" },
            };
            for (int i = 0; i < paths.Count; i++)
            {
                Console.WriteLine($"Текущий маршрут: {paths[i][0]} -> {paths[i][1]}");
            }
            string endCity = destCity(paths);
            Console.WriteLine($"Конечный город = \"{endCity}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string destCity(IList<IList<string>> paths)
        {
            return recursiveTravel(paths[0][0], paths);
        }
        private string recursiveTravel(string currentCity, IList<IList<string>> paths)
        {
            string nextCity = String.Empty;
            for (int i = 0; i < paths.Count; i++)
            {
                if (paths[i][0] == currentCity)
                {
                    nextCity = paths[i][1];
                    break;
                }
            }
            if (nextCity != String.Empty)
            {
                return recursiveTravel(nextCity, paths);
            }
            return currentCity;
        }
        // Скопировано с leetcode
        private string bestSolution(IList<IList<string>> paths)
        {

            HashSet<string> hs = new HashSet<string>();

            foreach (var lp in paths)
            {
                var src = lp[0];
                hs.Add(src);
            }

            foreach (var lp in paths)
            {
                var des = lp[1];
                if (!hs.Contains(des))
                    return des;
            }

            return "";
        }
    }
}
