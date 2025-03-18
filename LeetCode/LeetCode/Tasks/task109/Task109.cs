using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task109
{
    /*
     109. Преобразуйте отсортированный список в двоичное дерево поиска
    Учитывая head односвязный список, в котором элементы отсортированы в порядке возрастания, преобразуйте его всбалансированное по высоте двоичное дерево поиска.
    Ограничения:
        Количество узлов в head находится в диапазоне [0, 2 * 10^4].
        -10^5 <= Node.val <= 10^5
    https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/description/
     */
    public class Task109 : InfoBasicTask
    {
        public Task109(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode list = new ListNode(-10, new ListNode(-3, new ListNode(0, new ListNode(5, new ListNode(9)))));
            Console.WriteLine("Исходный связанный список");
            printValuesFromListNode(list);
            if (isValid(list))
            {
                TreeNode tree = sortedListToBST(list);
                Console.WriteLine("Результирующее дерево поиска");
                printTreeNode(tree);
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
            int lowLimitValueNode = -1*(int)Math.Pow(10,5);
            int highLimitValueNode = (int)Math.Pow(10, 5);
            List<int> values = new List<int>();
            while (head != null)
            {
                countNodes++;
                if (head.val < lowLimitValueNode || head.val > highLimitValueNode)
                {
                    return false;
                }
                values.Add(head.val);
                head = head.next;
            }
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = 2* (int)Math.Pow(10, 4);
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            if (values.Count > 1)
            {
                for (int i = 1; i < values.Count; i++)
                {
                    if (values[i] < values[i - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        private TreeNode sortedListToBST(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            List<int> values = new List<int>();
            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }
            return recursive(values);
        }

        private TreeNode recursive(List<int> values)
        {
            int left = 0;
            int right = values.Count - 1;
            int mid = (left + right) / 2;
            TreeNode treeNode = new TreeNode(values[mid]);
            List<int> newValuesLeft = new List<int>();
            List<int> newValuesRight = new List<int>();
            for (int i = 0; i < mid;i++)
            {
                newValuesLeft.Add(values[i]);
            }
            for (int i = mid+1; i < values.Count; i++)
            {
                newValuesRight.Add(values[i]);
            }
            if (newValuesLeft.Count != 0)
            {
                treeNode.left = recursive(newValuesLeft);
            }
            if (newValuesRight.Count != 0)
            {
                treeNode.right = recursive(newValuesRight);
            }
            return treeNode;
        }
    }
}
