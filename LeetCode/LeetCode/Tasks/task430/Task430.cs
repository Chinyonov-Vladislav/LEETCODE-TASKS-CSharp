using LeetCode.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task430
{
    /*
     430. Сгладьте многоуровневый двусвязный список
    Вам дан двусвязный список, содержащий узлы с указателем на следующий элемент, указателем на предыдущий элемент и дополнительным указателем на дочерний элемент. Этот указатель на дочерний элемент может указывать или не указывать на отдельный двусвязный список, также содержащий эти специальные узлы. Эти дочерние списки могут иметь один или несколько собственных дочерних элементов и так далее, образуя многоуровневую структуру данных, как показано в примере ниже.
    Учитывая head первого уровня списка, сгладьте список так, чтобы все узлы оказались в одноуровневом двусвязном списке. Пусть curr будет узлом с дочерним списком. Узлы в дочернем списке должны оказаться после curr и до curr.next в сглаженном списке.
    Верните значение head из сглаженного списка. Узлы в списке должны иметь все указатели на дочерние элементы, равные null.
     Ограничения:
        Количество узлов не будет превышать 1000.
        1 <= Node.val <= 10^5
    https://leetcode.com/problems/flatten-a-multilevel-doubly-linked-list/description/
     */
    public class Task430 : InfoBasicTask
    {
        public Task430(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TwoDirectionalNodeWithChildrens node1 = new TwoDirectionalNodeWithChildrens(1);
            TwoDirectionalNodeWithChildrens node2 = new TwoDirectionalNodeWithChildrens(2);
            TwoDirectionalNodeWithChildrens node3 = new TwoDirectionalNodeWithChildrens(3);
            node1.child = node2;
            node2.child = node3;
            printTreeNodeWithTwoDirectionalConnection(node1);
            if (isValid(node1))
            {
                TwoDirectionalNodeWithChildrens res = flatten(node1);
                printTreeNodeWithTwoDirectionalConnection(res, "Результирующий сглаженный двусвязанный список");
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
        private bool isValid(TwoDirectionalNodeWithChildrens node)
        {
            int lowLimitCountNode = 0;
            int highLimitCountNode = 1000;
            int lowLimitValueNode = 1;
            int highLimitValueNode = (int)Math.Pow(10,5);
            Queue<TwoDirectionalNodeWithChildrens> queue = new Queue<TwoDirectionalNodeWithChildrens>();
            if (node != null)
            {
                Stack<TwoDirectionalNodeWithChildrens> stack = new Stack<TwoDirectionalNodeWithChildrens>();
                stack.Push(node);
                while (stack.Count > 0)
                {
                    TwoDirectionalNodeWithChildrens current = stack.Pop();
                    queue.Enqueue(current);
                    if (current.next != null)
                    {
                        stack.Push(current.next);
                    }
                    if (current.child != null)
                    {
                        stack.Push(current.child);
                    }
                }
            }
            if (queue.Count < lowLimitCountNode || queue.Count > highLimitCountNode)
            {
                return false;
            }
            while (queue.Count > 0)
            {
                TwoDirectionalNodeWithChildrens currentNode = queue.Dequeue();
                if (currentNode.val < lowLimitValueNode || currentNode.val > highLimitValueNode)
                {
                    return false;
                }
            }
            return true;
        }
        private TwoDirectionalNodeWithChildrens flatten(TwoDirectionalNodeWithChildrens head)
        {
            if (head == null)
            {
                return null;
            }
            TwoDirectionalNodeWithChildrens dummyHead = head;
            recursive(head);
            return dummyHead;
        }
        private TwoDirectionalNodeWithChildrens recursive(TwoDirectionalNodeWithChildrens head)
        {
            TwoDirectionalNodeWithChildrens returnedNode = null;
            while (true)
            {
                if (head.child != null)
                {
                    TwoDirectionalNodeWithChildrens nextNode = head.next;
                    head.next = head.child;
                    head.child.prev = head;
                    TwoDirectionalNodeWithChildrens lastNodeFromChild = recursive(head.child);
                    lastNodeFromChild.next = nextNode;
                    if (nextNode != null)
                    {
                        nextNode.prev = lastNodeFromChild;
                    }
                    head.child = null;
                    if (nextNode != null)
                    {
                        head = nextNode;
                    }
                }
                if (head.next != null)
                {
                    head = head.next;
                }
                else
                {
                    returnedNode = head;
                    break;
                }
            }
            return returnedNode;
        }
    }
}
