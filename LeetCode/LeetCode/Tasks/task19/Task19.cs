using System;
using LeetCode.Basic;

namespace LeetCode.Tasks.task19
{
    public class Task19 : InfoBasicTask
    {
        private ListNode root;
        public Task19(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
            root = new ListNode(1, new ListNode(2,new ListNode(3, new ListNode(4, new ListNode(5)))));
            root = new ListNode(1);
            root = new ListNode(1, new ListNode(2));
            root = new ListNode(1, new ListNode(2, new ListNode(3)));
            //root = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7, new ListNode(8, new ListNode(9, new ListNode(10))))))))));
        }

        public override void execute()
        {
            //printValuesFromListNode(root, 0);
            ListNode resultNode = removeNthFromEnd(root, 2);
            printValuesFromListNode(resultNode, 0);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private ListNode removeNthFromEnd(ListNode head, int n)
        {

            int totalCountNodes = getCountNodes(head);
            int indexNodeForDelete = totalCountNodes - n;
            Console.WriteLine($"Общее количество узлов = {totalCountNodes}");
            Console.WriteLine($"Индекс узла для удаления = {indexNodeForDelete}");
            if (indexNodeForDelete < 0)
            {
                return head;
            }
            if (indexNodeForDelete == 0 && totalCountNodes <= 1)
            {
                return null;
            }
            ListNode resultNode = new ListNode();
            deleteNode(head, resultNode, indexNodeForDelete, totalCountNodes);
            return resultNode;
        }
        private void deleteNode(ListNode head,ListNode resultNode, int indexNodeForDelete, int totalCountNodes, int currentNodeNumber = 0)
        {
            if (indexNodeForDelete == 0 && currentNodeNumber == 0)
            {
                currentNodeNumber++;
                deleteNode(head.next, resultNode, indexNodeForDelete, totalCountNodes, currentNodeNumber);
            }
            else if (currentNodeNumber == indexNodeForDelete - 1)
            {
                resultNode.val = head.val;
                if (indexNodeForDelete == totalCountNodes - 1)
                {
                    resultNode.next = null;
                }
                else
                {
                    resultNode.next = head.next;
                    currentNodeNumber +=2;
                    deleteNode(head.next.next, resultNode.next, indexNodeForDelete, totalCountNodes, currentNodeNumber);
                }
            }
            else
            {
                if (head != null)
                {
                    resultNode.val = head.val;
                    resultNode.next = head.next;
                    currentNodeNumber++;
                    deleteNode(head.next, resultNode.next, indexNodeForDelete, totalCountNodes, currentNodeNumber);
                }
            }
        }
        private int getCountNodes(ListNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return travelByNodes(root);
        }
        private int travelByNodes(ListNode node, int countNodes = 0)
        {
            countNodes += 1;
            if (node.next != null)
            {
                countNodes = travelByNodes(node.next, countNodes);
            }
            return countNodes;
        }
        
    }
}
