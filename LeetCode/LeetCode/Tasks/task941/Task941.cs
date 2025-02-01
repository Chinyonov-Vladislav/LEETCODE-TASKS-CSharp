using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task941
{
    /*
    941. Валидный массив гор
     Учитывая массив целых чисел arr, верните trueесли и только если он является допустимым массивом гор.
    Напомним, что arr является горным массивом тогда и только тогда, когда:
    arr.length >= 3
    Существует некоторое i с 0 < i < arr.length - 1 таким , что:
        arr[0] < arr[1] < ... < arr[i - 1] < arr[i] 
        arr[i] > arr[i + 1] > ... > arr[arr.length - 1]
     */
    public class Task941 : InfoBasicTask
    {
        public Task941(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 3, 5, 5 };
            printArray(arr, "Массив гор: ");
            Console.WriteLine(validMountainArray(arr) ? "Массив гор валиден" : "Массив гор не валиден");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool validMountainArray(int[] arr)
        {
            if (arr.Length < 3)
            {
                return false;
            }
            bool directionIncrease = arr[0] < arr[1];
            if (!directionIncrease)
            {
                return false;
            }
            int countChangeDirection = 0;
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    return false;
                }
                if (directionIncrease)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        continue;
                    }
                    else if (countChangeDirection == 0)
                    {
                        countChangeDirection++;
                        directionIncrease = !directionIncrease;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (arr[i] > arr[i + 1])
                    {
                        continue;
                    }
                    else if (countChangeDirection == 0)
                    {
                        countChangeDirection++;
                        directionIncrease = !directionIncrease;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return countChangeDirection == 1;
        }
    }
}
