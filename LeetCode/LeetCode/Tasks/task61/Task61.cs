using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task61
{
    /*
     61. Поворот списка
    Учитывая, что head элементов связанного списка расположены в определённом порядке, поверните список вправо на k позиций.
    Ограничения:
        Количество узлов в списке находится в диапазоне [0, 500].
        -100 <= Node.val <= 100
        0 <= k <= 2 * 10^9
    https://leetcode.com/problems/rotate-list/description/
     */
    public class Task61 : InfoBasicTask
    {
        public Task61(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode list = new ListNode(1,new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            Console.WriteLine("Исходный связанный список");
            printValuesFromListNode(list);
            int countRotate = 2;
            Console.WriteLine($"Количество поворотов списка вправо = {countRotate}");
            if (isValid(list, countRotate))
            {
                ListNode headRotated = rotateRight(list, countRotate);
                Console.WriteLine($"Повернутый связанный список на {countRotate} позиций вправо");
                printValuesFromListNode(headRotated);
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
        private bool isValid(ListNode head, int k)
        {
            int countNodes = 0;
            int lowLimit = -100;
            int highLimit = 100;
            while (head != null)
            {
                countNodes++;
                if (head.val < lowLimit || highLimit > head.val)
                {
                    return false;
                }
            }
            lowLimit = 0;
            highLimit = 500;
            if (countNodes < lowLimit || countNodes > highLimit)
            {
                return false;
            }
            highLimit = 2* (int)Math.Pow(10,9);
            if (k < lowLimit || k > highLimit)
            {
                return false;
            }
            return true;
        }
        private ListNode rotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            int countNodes = 0;
            ListNode dummyHead = head;            
            while (dummyHead != null)
            {
                countNodes++;
                dummyHead = dummyHead.next;
            }
            k = k % countNodes;
            int countRotate = 0;
            while (countRotate < k)
            {
                ListNode startNode = head;
                ListNode currentNode = head;
                ListNode nextNode = head.next;
                while (nextNode.next != null)
                {
                    currentNode = currentNode.next;
                    nextNode = nextNode.next;
                }
                nextNode.next = head;
                currentNode.next = null;
                head = nextNode;
                countRotate++;
            }
            return head;
        }
    }
}
