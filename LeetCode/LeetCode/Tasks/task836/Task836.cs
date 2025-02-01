using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task836
{
    /*
     836. Перекрытие прямоугольника
    Прямоугольник, выровненный по осям, представлен в виде списка [x1, y1, x2, y2], где (x1, y1) — координата его левого нижнего угла, а (x2, y2) — координата его правого верхнего угла. Его верхняя и нижняя стороны параллельны оси X, а левая и правая стороны параллельны оси Y.
    Два прямоугольника пересекаются, если площадь их пересечения положительна. Для ясности: два прямоугольника, которые соприкасаются только в углах или по краям, не пересекаются.
    Учитывая два прямоугольника rec1 и rec2, выровненных по осям, верните trueе сли они пересекаются, в противном случае верните false.
    https://leetcode.com/problems/rectangle-overlap/description/
     */
    public class Task836 : InfoBasicTask
    {
        public Task836(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] rect1 = new int[] { -193634870, -175701756, 958697367, 607619635 };
            Console.WriteLine($"Первый прямоугольник\nКоординаты левого нижнего угла = ({rect1[0]},{rect1[1]})\nКоординаты правого верхнего угла = ({rect1[2]},{rect1[3]})");
            int[] rect2 = new int[] { 91619846, 10349052, 822028072, 696611776 };
            Console.WriteLine($"Второй прямоугольник\nКоординаты левого нижнего угла = ({rect2[0]},{rect2[1]})\nКоординаты правого верхнего угла = ({rect2[2]},{rect2[3]})");
            Console.WriteLine(isRectangleOverlap(rect1, rect2) ? "Прямоугольники имеют перекрытие" : "Прямоугольники не имеют перекрытия");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isRectangleOverlap(int[] rec1, int[] rec2)
        {
            int left = Math.Max(rec1[0], rec2[0]);
            int bottom = Math.Max(rec1[1], rec2[1]);
            int right = Math.Min(rec1[2], rec2[2]);
            int top = Math.Min(rec1[3], rec2[3]);
            int width = right - left;
            int height = top - bottom;
            if (width <= 0 || height <=0)
            {
                return false;
            }
            return true;
        }
    }
}
