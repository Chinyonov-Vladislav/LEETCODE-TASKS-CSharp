using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task107
{
    /*
     107. Обход порядка на уровне бинарного дерева II
    Учитывая root двоичного дерева, верните последовательность обхода его узлов в порядке возрастания. (т. е. слева направо, уровень за уровнем, от листа к корню).
    Ограничения:
        Количество узлов в дереве находится в диапазоне [0, 2000].
        -1000 <= Node.val <= 1000
    https://leetcode.com/problems/binary-tree-level-order-traversal-ii/description/
     */
    public class Task107 : InfoBasicTask
    {
        public Task107(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            printTreeNode(root);
            if (isValid(root))
            {
                IList<IList<int>> res = levelOrderBottom(root);
                printIListIListInt(res, "Результирующий список списоков целых чисел по уровня от нижнего к верхнему: ");
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
            int highLimitCountNodes = 2000;
            int lowLimitValueNode = -1000;
            int highLimitValueNode = 1000;
            int countNodes = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();
                countNodes++;
                if (currentNode.val < lowLimitValueNode || currentNode.val > highLimitValueNode)
                {
                    return false;
                }
                if (currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private IList<IList<int>> levelOrderBottom(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            List<TreeNode> nodesOfNextLevel = new List<TreeNode>() {  };
            result.Add(new List<int>() { root.val });
            while (queue.Count>0)
            {
                TreeNode currentTreeNode = queue.Dequeue();
                if (currentTreeNode.left != null)
                {
                    nodesOfNextLevel.Add(currentTreeNode.left);
                }
                if (currentTreeNode.right != null)
                {
                    nodesOfNextLevel.Add(currentTreeNode.right);
                }
                if (queue.Count == 0)
                {
                    List<int> valuesOfNextLevel = new List<int>();
                    for (int i = 0; i < nodesOfNextLevel.Count; i++)
                    {
                        valuesOfNextLevel.Add(nodesOfNextLevel[i].val);
                        queue.Enqueue(nodesOfNextLevel[i]);
                    }
                    if (valuesOfNextLevel.Count > 0)
                    {
                        result.Add(valuesOfNextLevel);
                    }
                    nodesOfNextLevel.Clear();
                }
            }
            int left = 0;
            int right = result.Count-1;
            while (left < right)
            {
                (result[left], result[right]) = (result[right], result[left]);
                left++;
                right--;
            }
            return result;
        }
    }
}
