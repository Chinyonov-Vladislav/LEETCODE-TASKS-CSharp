using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task654
{
    /*
     654. Максимальное двоичное дерево
    Вам дан целочисленный массив nums без дубликатов.Максимальное двоичное дерево можно построить рекурсивно из nums с помощью следующего алгоритма:
        Создайте корневой узел, значение которого является максимальным значением в nums.
        Рекурсивно постройте левое поддерево на префиксе подмассива слева от максимального значения.
        Рекурсивно постройте правое поддерево на суффиксе подмассива справа от максимального значения.
    Возвращает бинарное дерево, построенное на основании массива nums.
    Ограничения:
        1 <= nums.length <= 1000
        0 <= nums[i] <= 1000
        Все целые числа в nums являются уникальными.
    https://leetcode.com/problems/maximum-binary-tree/description/
     */
    public class Task654 : InfoBasicTask
    {
        private enum TypeSolution
        {
            None = 0,
            Queue = 1,
            Recursive = 2,
            Both = 3
        }
        public Task654(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 2, 1, 6, 0, 5 };
            printArray(nums, "Исходный массив для значений бинарного дерева: ");
            if (isValid(nums))
            {
                TypeSolution typeSolution = askUserTypeSolution();
                switch (typeSolution)
                {
                    case TypeSolution.Recursive:
                        applyRecursiveMethod(nums);
                        break;
                    case TypeSolution.Queue:
                        applySecondMethod(nums);
                        break;
                    case TypeSolution.Both:
                        applyRecursiveMethod(nums);
                        applySecondMethod(nums);
                        break;
                }
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
        private void applyRecursiveMethod(int[] nums)
        {
            TreeNode res = new TreeNode();
            recursive(res, nums, 0, nums.Length - 1);
            printBinaryTreeUsingList(res, "Результирующее бинарное дерево на основании рекурсивного метода");
        }
        private void applySecondMethod(int[] nums)
        {
            TreeNode res = constructMaximumBinaryTree(nums);
            printBinaryTreeUsingList(res, "Результирующее бинарное дерево на основании применения очереди и выделении памяти под каждый подмассив");
        }
        private bool isValid(int[] nums)
        {
            int lowLimitLengthNums = 1;
            int highLimitLengthNums = 1000;
            int lowLimitValueInNums = 0;
            int highLimitValueInNums = 1000;
            if (nums.Length < lowLimitLengthNums || nums.Length > highLimitLengthNums)
            {
                return false;
            }
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                if (num < lowLimitValueInNums || num > highLimitValueInNums)
                {
                    return false;
                }
                set.Add(num);
            }
            if (set.Count != nums.Length)
            {
                return false;
            }
            return true;
        }

        private void recursive(TreeNode treeNode, int[] nums, int left, int right)
        {
            int max = nums[left];
            int indexMax = left;
            for (int i = left + 1; i <= right; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    indexMax = i;
                }
            }
            treeNode.val = max;
            int firstNewLeft = left;
            int firstNewRight = indexMax - 1;
            int secondNewLeft = indexMax + 1;
            int secondNewRight = right;
            if (firstNewRight >= firstNewLeft)
            {
                TreeNode leftNode = new TreeNode();
                treeNode.left = leftNode;
                recursive(leftNode, nums, firstNewLeft, firstNewRight);
            }
            if (secondNewRight >= secondNewLeft)
            {
                TreeNode rightNode = new TreeNode();
                treeNode.right = rightNode;
                recursive(rightNode, nums, secondNewLeft, secondNewRight);
            }
        }

        private TreeNode constructMaximumBinaryTree(int[] nums)
        {
            Stack<Tuple<TreeNode, List<int>>> stack = new Stack<Tuple<TreeNode, List<int>>>();
            TreeNode treeNode = new TreeNode();
            stack.Push(new Tuple<TreeNode, List<int>>(treeNode, nums.ToList()));
            while (stack.Count > 0)
            {
                Tuple<TreeNode, List<int>> currentItemFromStack = stack.Pop();
                TreeNode currentNode = currentItemFromStack.Item1;
                List<int> currentValues = currentItemFromStack.Item2;
                int max = currentValues[0];
                int indexMax = 0;
                for (int i = 1; i < currentValues.Count; i++)
                {
                    if (currentValues[i] > max)
                    {
                        max = currentValues[i];
                        indexMax = i;
                    }
                }
                currentNode.val = max;
                List<int> valuesForLeft = new List<int>();
                List<int> valuesForRight = new List<int>();
                for (int index = 0; index < currentValues.Count; index++)
                {
                    if (index < indexMax)
                    {
                        valuesForLeft.Add(currentValues[index]);
                    }
                    else if (index > indexMax)
                    {
                        valuesForRight.Add(currentValues[index]);
                    }
                }
                if (valuesForLeft.Count > 0)
                {
                    TreeNode nodeLeft = new TreeNode();
                    currentNode.left = nodeLeft;
                    stack.Push(new Tuple<TreeNode, List<int>>(nodeLeft, valuesForLeft));
                }
                if (valuesForRight.Count > 0)
                {
                    TreeNode nodeRight = new TreeNode();
                    currentNode.right = nodeRight;
                    stack.Push(new Tuple<TreeNode, List<int>>(nodeRight, valuesForRight));
                }
            }
            return treeNode;
        }
        private TypeSolution askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Рекурсивный\n" +
                    "2 - На основании очереди и выделении памяти под каждый подмассив\n" +
                    "3 - Протестировать оба варианта\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 3)
                    {
                        throw new FormatException();
                    }
                    switch (choiceUser)
                    {
                        case 0:
                            return TypeSolution.None;
                        case 1:
                            return TypeSolution.Recursive;
                        case 2:
                            return TypeSolution.Queue;
                        case 3:
                            return TypeSolution.Both;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }
    }
}
