using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task199
{
    /*
     199. Вид двоичного дерева справа
    Учитывая root двоичного дерева, представьте, что вы стоите справа от него, и верните значения узлов, которые вы видите, в порядке сверху вниз.
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 100].
        -100 <= Node.val <= 100
    https://leetcode.com/problems/binary-tree-right-side-view/description/
     */
    public class Task199 : InfoBasicTask
    {
        public Task199(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(1, new TreeNode(2, new TreeNode(4, new TreeNode(5))), new TreeNode(3));
            printBinaryTreeUsingList(treeNode);
            if (isValid(treeNode))
            {
                IList<int> res = rightSideView(treeNode);
                printIListInt(res, "Значение в узлах, которые видно, находясь справа от бинарного дерева: ");
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
        private bool isValid(TreeNode root)
        {
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = 100;
            int lowLimitValueNode = -100;
            int highLimitValueNode = 100;
            int countNodes = 0;
            if (root != null)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                List<TreeNode> nodesOfCurrentLevel = new List<TreeNode>();
                while (queue.Count > 0)
                {
                    TreeNode currentNode = queue.Dequeue();
                    nodesOfCurrentLevel.Add(currentNode);
                    if (queue.Count == 0)
                    {
                        for (int i = 0; i < nodesOfCurrentLevel.Count; i++)
                        {
                            countNodes++;
                            if (nodesOfCurrentLevel[i].val < lowLimitValueNode || nodesOfCurrentLevel[i].val > highLimitValueNode)
                            {
                                return false;
                            }
                            if (nodesOfCurrentLevel[i].left != null)
                            {
                                queue.Enqueue(nodesOfCurrentLevel[i].left);
                            }
                            if (nodesOfCurrentLevel[i].right != null)
                            {
                                queue.Enqueue(nodesOfCurrentLevel[i].right);
                            }
                        }
                        nodesOfCurrentLevel.Clear();
                    }
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private IList<int> rightSideView(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            List<TreeNode> nodesOfCurrentLevel = new List<TreeNode>();
            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();
                nodesOfCurrentLevel.Add(currentNode);
                if (queue.Count == 0)
                {
                    result.Add(nodesOfCurrentLevel[nodesOfCurrentLevel.Count - 1].val);
                    for (int i = 0; i < nodesOfCurrentLevel.Count; i++)
                    {
                        if (nodesOfCurrentLevel[i].left != null)
                        {
                            queue.Enqueue(nodesOfCurrentLevel[i].left);
                        }
                        if (nodesOfCurrentLevel[i].right != null)
                        {
                            queue.Enqueue(nodesOfCurrentLevel[i].right);
                        }
                    }
                    nodesOfCurrentLevel.Clear();
                }
            }
            return result;
        }
    }
}
