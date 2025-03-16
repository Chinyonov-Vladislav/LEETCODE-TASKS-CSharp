using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task24
{
    /*
     24. Меняйте местами узлы попарно
    Дан связный список. Поменяйте местами каждые два соседних узла и верните его начало. 
    Вы должны решить задачу, не изменяя значения узлов списка (то есть можно изменять только сами узлы).
    Ограничения:
        Количество узлов в списке находится в диапазоне [0, 100].
        0 <= Node.val <= 100
    https://leetcode.com/problems/swap-nodes-in-pairs/description/
     */
    public class Task24 : InfoBasicTask
    {
        public Task24(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode listNode = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            Console.WriteLine("Исходный связанный список");
            printValuesFromListNode(listNode);
            if (isValid(listNode))
            {
                ListNode head = swapPairs(listNode);
                Console.WriteLine("Конечный связанный список");
                printValuesFromListNode(head);
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
            int lowLimit = 0;
            int highLimit = 100;
            int countNodes = 0;
            while (head != null)
            {
                if (head.val < lowLimit || head.val > highLimit)
                {
                    return false;
                }
                countNodes++;
                head = head.next;
            }
            if (countNodes < lowLimit || countNodes > highLimit)
            {
                return false;
            }
            return true;
        }
        private ListNode swapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode newHeadDummy = head.next;
            ListNode firstPointer = head;
            ListNode secondPointer = head.next;
            ListNode previousPointerNode = null;
            bool isFirstIteration = true;
            while (firstPointer != null || secondPointer != null)
            {
                ListNode nextFirstPointer = firstPointer == null ? null : firstPointer.next == null ? null : firstPointer.next.next;
                ListNode nextSecondPointer = secondPointer == null ? null : secondPointer.next == null ? null : secondPointer.next.next;
                if (secondPointer != null)
                {
                    secondPointer.next = firstPointer;
                }
                if (!isFirstIteration)
                {
                    if (firstPointer != null && secondPointer != null)
                    {
                        previousPointerNode.next = secondPointer;
                    }
                    else
                    {
                        previousPointerNode.next = firstPointer;
                    }
                }
                previousPointerNode = firstPointer;
                firstPointer = nextFirstPointer;
                secondPointer = nextSecondPointer;
                if (firstPointer == null && secondPointer == null)
                {
                    previousPointerNode.next = null;
                }
                isFirstIteration = false;
            }
            return newHeadDummy;
        }
    }
}
