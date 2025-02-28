using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2570
{
    /*
     2570. Объедините два двумерных массива, суммируя значения
    Вам даны два 2D целочисленных массива nums1 и nums2.
        nums1[i] = [idi, vali] укажите, что номер с идентификатором idi имеет значение, равное vali.
        nums2[i] = [idi, vali] укажите, что номер с идентификатором idi имеет значение, равное vali.
    Каждый массив содержит уникальные идентификаторы и отсортирован по возрастанию идентификаторов.
    Объедините два массива в один, отсортированный по возрастанию идентификаторов, соблюдая следующие условия:
        В результирующий массив следует включать только идентификаторы, которые встречаются хотя бы в одном из двух массивов.
    Каждый идентификатор должен быть включён только один раз, а его значение должно быть суммой значений этого идентификатора в двух массивах. Если идентификатор отсутствует в одном из двух массивов, то его значение в этом массиве принимается равным 0.
    Верните полученный массив. Возвращаемый массив должен быть отсортирован по идентификатору в порядке возрастания.
    Ограничения:
        1 <= nums1.length, nums2.length <= 200
        nums1[i].length == nums2[j].length == 2
        1 <= idi, vali <= 1000
        Оба массива содержат уникальные идентификаторы.
        Оба массива расположены в строго возрастающем порядке по идентификатору.
    https://leetcode.com/problems/merge-two-2d-arrays-by-summing-values/description/
     */
    public class Task2570 : InfoBasicTask
    {
        public Task2570(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] nums1 = new int[][] {
                new int[] { 1,2 },
                new int[] { 2,3 },
                new int[] { 4, 5 }
            };
            int[][] nums2 = new int[][] {
                new int[] { 1,4 },
                new int[] { 3,2 },
                new int[] { 4, 1 }
            };
            printTwoDimensionalArray(nums1, "Двумерный массив №1");
            printTwoDimensionalArray(nums2, "Двумерный массив №2");
            if (isValid(nums1, nums2))
            {
                int[][] result = mergeArrays(nums1, nums2);
                printTwoDimensionalArray(result,"Результирующий двумерный массив");
            }
            else
            {
                Console.WriteLine($"Исходные данные неверны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[][] nums1, int[][] nums2)
        {
            if (nums1.Length < 1 || nums1.Length > 200 || nums2.Length < 1 || nums2.Length > 200)
            {
                return false;
            }
            List<int[][]> arrays = new List<int[][]>() { nums1, nums2 };
            foreach (var currentArray in arrays)
            {
                foreach (var arr in currentArray)
                {
                    if (arr.Length != 2)
                    {
                        return false;
                    }
                }
                foreach (var arr in currentArray)
                {
                    if (arr[0] < 1 || arr[0] > 1000)
                    {
                        return false;
                    }
                    if (arr[1] < 1 || arr[1] > 1000)
                    {
                        return false;
                    }
                }
                HashSet<int> setIdFromArray = new HashSet<int>();
                foreach (var arr in currentArray)
                {
                    setIdFromArray.Add(arr[0]);
                }
                if (setIdFromArray.Count != currentArray.Length)
                {
                    return false;
                }
                if (currentArray.Length >= 2)
                {
                    for (int i = 1; i < currentArray.Length; i++)
                    {
                        if (currentArray[i-1][0] >= currentArray[i][0])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private int[][] mergeArrays(int[][] nums1, int[][] nums2)
        {
            Dictionary<int,int> result = new Dictionary<int,int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (result.ContainsKey(nums1[i][0]))
                {
                    result[nums1[i][0]]+=nums1[i][1];
                }
                else
                {
                    result.Add(nums1[i][0], nums1[i][1]);
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (result.ContainsKey(nums2[i][0]))
                {
                    result[nums2[i][0]] += nums2[i][1];
                }
                else
                {
                    result.Add(nums2[i][0], nums2[i][1]);
                }
            }
            var items = result.OrderBy(x => x.Key);
            int[][] returnedResult = new int[items.Count()][];
            int index = 0;
            foreach (var item in items)
            {
                returnedResult[index] = new int[] { item.Key, item.Value };
                index++;
            }
            return returnedResult;
        }
        // скопировано с leetcode
        private int[][] bestSoltuion(int[][] nums1, int[][] nums2)
        {
            var n = nums1.Length;
            var m = nums2.Length;

            var res = new List<int[]>();
            var nums1Index = 0;
            var nums2Index = 0;
            while (nums1Index < n && nums2Index < m)
            {
                if (nums1[nums1Index][0] < nums2[nums2Index][0])
                {
                    res.Add(nums1[nums1Index]);
                    nums1Index++;
                }
                else if (nums1[nums1Index][0] > nums2[nums2Index][0])
                {
                    res.Add(nums2[nums2Index]);
                    nums2Index++;
                }
                else
                {
                    res.Add(new int[] { nums1[nums1Index][0], nums1[nums1Index][1] + nums2[nums2Index][1] });
                    nums1Index++;
                    nums2Index++;
                }
            }

            while (nums1Index < n)
            {
                res.Add(nums1[nums1Index]);
                nums1Index++;
            }
            while (nums2Index < m)
            {
                res.Add(nums2[nums2Index]);
                nums2Index++;
            }
            return res.ToArray();
        }
    }
}
