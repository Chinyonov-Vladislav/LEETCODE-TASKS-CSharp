using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task617
{
    /*
     617. Объединить два бинарных дерева
    Вам даны два бинарных дерева root1 и root2.
    Представьте, что когда вы накладываете одно из них на другое, некоторые узлы двух деревьев перекрываются, а другие — нет. Вам нужно объединить два дерева в новое двоичное дерево. Правило объединения заключается в том, что если два узла перекрываются, то значения узлов суммируются и становятся новым значением объединённого узла. В противном случае в качестве узла нового дерева будет использоваться ненулевой узел.
    Верните объединенное дерево.
    Примечание: процесс слияния должен начинаться с корневых узлов обоих деревьев.
     */
    public class Task617 : InfoBasicTask
    {
        public Task617(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root1 = new TreeNode(1, new TreeNode(3, new TreeNode(5)), new TreeNode(2));
            TreeNode root2 = new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)));
            TreeNode result = mergeTrees(root1, root2);
            printTreeNode(result);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private TreeNode merge(TreeNode resultNode, TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
            {
                return null;
            }
            int currentValue = 0;
            if (root1 != null)
            {
                currentValue += root1.val;
            }
            if (root2 != null)
            {
                currentValue += root2.val;
            }
            resultNode.val = currentValue;
            resultNode.left = merge(new TreeNode(), root1 == null ? null : root1.left, root2 == null ? null : root2.left);
            resultNode.right = merge(new TreeNode(), root1 == null ? null : root1.right, root2 == null ? null : root2.right);
            return resultNode;
        }
        private TreeNode mergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
            {
                return null;
            }
            if (root1 == null)
            {
                return root2;
            }
            if (root2 == null)
            {
                return root1;
            }
            return merge(new TreeNode(), root1, root2);
        }
    }
}
