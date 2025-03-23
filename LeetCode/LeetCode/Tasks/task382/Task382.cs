using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task382
{
    /*
     382. Случайный узел связанного списка
    Учитывая односвязный список, верните значение случайного узла из связанного списка. Каждый узел должен иметь одинаковую вероятность быть выбранным.
    Реализовать класс Solution:
        Solution(ListNode head) Инициализирует объект с помощью заголовка односвязного списка head.
        int getRandom() Выбирает узел случайным образом из списка и возвращает его значение. Все узлы списка должны быть выбраны с равной вероятностью.
    Ограничения:
        Количество узлов в связанном списке будет находиться в диапазоне [1, 10^4].
        -10^4 <= Node.val <= 10^4
    https://leetcode.com/problems/linked-list-random-node/description/
     */
    public class Task382 : InfoBasicTask
    {
        public Task382(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3)));
            printValuesFromListNode(head);
            if (isValid(head))
            {
                Solution s = new Solution(head);
                int count = 5;
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"Случайное число №{i+1} из связанного списка = {s.GetRandom()}");
                }
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
        private bool isValid(ListNode head)
        {
            int countNodes = 0;
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = (int)Math.Pow(10, 4);
            int lowLimitValueNode = -1 * (int)Math.Pow(10, 4);
            int highLimitValueNode = (int)Math.Pow(10, 4);
            while (head != null)
            {
                countNodes++;
                if (head.val < lowLimitValueNode || head.val > highLimitValueNode)
                {
                    return false;
                }
                head = head.next;
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
    }
}
