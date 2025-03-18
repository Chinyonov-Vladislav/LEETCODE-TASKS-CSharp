using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.Tasks.task142
{
    /*
     142. Цикл в связанном списке II
    Учитывая head связанного списка, верните узел, с которого начинается цикл. 
    Если цикла нет, верните null.
    В связанном списке возникает цикл, если в списке есть какой-то узел, до которого можно снова добраться, постоянно следуя за next указателем. Внутренне, pos используется для обозначения индекса узла, к которому подключен next указатель tail (с индексом 0). Это -1 если нет цикла. Обратите внимание, что pos не передается в качестве параметра.
    Не изменяйте связанный список.
    Ограничения:
        Количество узлов в списке находится в диапазоне [0, 10^4].
        -10^5 <= Node.val <= 10^5
        pos является -1 или допустимым индексом в связанном списке.
    https://leetcode.com/problems/linked-list-cycle-ii/description/
     */
    public class Task142 : InfoBasicTask
    {
        public Task142(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            List<ListNode> listNodes = new List<ListNode>()
            {
                new ListNode(3),
                new ListNode(2),
                new ListNode(0),
                new ListNode(4),
            };
            for (int i = 0; i < listNodes.Count - 1; i++)
            {
                listNodes[i].next = listNodes[i+1];
            }
            listNodes[listNodes.Count - 1].next = listNodes[1];
            Console.WriteLine("Исходный связанный список");
            printValuesFromListNode(listNodes[0]);
            if (isValid(listNodes[0]))
            {
                ListNode listNode = detectCycle(listNodes[0]);
                if (listNode == null)
                {
                    Console.WriteLine("Исходный связанный список не имеет цикличности");
                    
                }
                else
                {
                    Console.WriteLine($"Исходный связанный список имеет цикличность в узле со значением = {listNode.val}");
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
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = (int)Math.Pow(10,4);
            int countNodes = 0;
            int lowLimitValueNode = -1*(int)Math.Pow(10,5);
            int highLimitValueNode = (int)Math.Pow(10, 5);
            HashSet<ListNode> listNodeSet = new HashSet<ListNode>();
            while (head != null)
            {
                if (listNodeSet.Contains(head))
                {
                    break;
                }
                listNodeSet.Add(head);
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
        private ListNode detectCycle(ListNode head)
        {
            HashSet<ListNode> cycle = new HashSet<ListNode>();
            while (head != null)
            {
                if (cycle.Contains(head))
                {
                    return head;
                }
                cycle.Add(head);
                head = head.next;
            }
            return null;
        }
    }
}
