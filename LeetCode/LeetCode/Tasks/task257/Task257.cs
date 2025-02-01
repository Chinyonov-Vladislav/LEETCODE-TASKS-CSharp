using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task257
{
    /*
     257. Пути к бинарному дереву
    Учитывая root двоичного дерева, верните все пути от корня до листьев в любом порядке.
    Лист - это узел, не имеющий дочерних элементов.
    https://leetcode.com/problems/binary-tree-paths
     */
    public class Task257 : InfoBasicTask
    {
        public Task257(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, null, new TreeNode(5)), new TreeNode(3));
            IList<string> result = binaryTreePaths(root);
            foreach (string path in result)
            {
                Console.WriteLine(path);
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<string> binaryTreePaths(TreeNode root)
        {
            IList<string> paths = new List<string>();
            travel(root, paths, new List<int>());
            return paths;
        }
        private void travel(TreeNode treeNode, IList<string> listPath, List<int> result)
        {
            Console.WriteLine($"Текущее значение в узле = {treeNode.val}");
            result.Add(treeNode.val);
            if (treeNode.left == null && treeNode.right == null)
            {
                string addedString = string.Join("->", Array.ConvertAll(result.ToArray(), i => i.ToString()));
                listPath.Add(addedString);
            }
            if (treeNode.left != null)
            {
                travel(treeNode.left, listPath, result);
                
            }
            if (treeNode.right != null)
            {
                travel(treeNode.right, listPath, result);
            }
            if (result.Count > 1)
            {
                result.RemoveAt(result.Count - 1);
            }
        }
    }
}
