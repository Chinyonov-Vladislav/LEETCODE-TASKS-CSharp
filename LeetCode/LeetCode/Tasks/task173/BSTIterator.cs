using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task173
{
    public class BSTIterator
    {
        List<int> values;
        int index = -1;
        public BSTIterator(TreeNode root)
        {
            values = new List<int>();
            if (root != null)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    TreeNode treeNode = queue.Dequeue();
                    values.Add(treeNode.val);
                    if (treeNode.left != null)
                    {
                        queue.Enqueue(treeNode.left);
                    }
                    if (treeNode.right != null)
                    {
                        queue.Enqueue(treeNode.right);
                    }
                }
                values.Sort();
            }
        }

        public int Next()
        {
            index++;
            return values[index];
        }

        public bool HasNext()
        {
            int nextIndex = index + 1;
            if (nextIndex < values.Count)
            {
                return true;
            }
            return false;
        }
    }
}
