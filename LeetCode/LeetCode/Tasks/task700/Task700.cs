using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.Task700
{
    /*
     700. Поиск в двоичном дереве поиска
    Вам дано root двоичного дерева поиска (BST) и целое число val.
    Найдите в двоичном дереве поиска узел, значение которого равно val, и верните поддерево с этим узлом в качестве корня. Если такого узла нет, верните null.
    https://leetcode.com/problems/search-in-a-binary-search-tree/description/
     */
    public class Task700: InfoBasicTask
    {
        public Task700(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode treeNode = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7));
            int searchedValue = 2;
            TreeNode resultedTreeNode = searchBST(treeNode, searchedValue);
            printTreeNode(resultedTreeNode);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private TreeNode searchBST(TreeNode root, int val)
        {
            return recursiveTravel(root, val);
        }
        private TreeNode recursiveTravel(TreeNode root, int val)
        {
            if (root == null)
            {
                return null;
            }
            if (root.val == val)
            {
                return root;
            }
            TreeNode left = recursiveTravel(root.left, val);
            TreeNode right = recursiveTravel(root.right, val);
            if (left == null && right == null)
            {
                return null;
            }
            else if (left != null)
            {
                return left;
            }
            else
            {
                return right;
            }

        }
    }
}
