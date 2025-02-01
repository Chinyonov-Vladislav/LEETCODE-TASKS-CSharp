using System;
using Xunit.Sdk;
using Xunit;
using LeetCode.Basic;
namespace LeetCode.Tasks.Task7
{
    public class Task7 : InfoBasicTask
    {

        public Task7(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int numberToReverse = 0;
            while (true)
            {
                Console.Write("Введите целое число для инверсии: ");
                try
                {
                    numberToReverse = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
            int result = reverseFirstMethod(numberToReverse);
            Console.WriteLine($"Original Number = {numberToReverse}");
            Console.WriteLine($"Reserved Number = {result}" + (result == 0 && numberToReverse != 0 ? ". The reserved number goes beyond int" : ""));
        }

        public override void testing()
        {
            int numberToReverse = 256;
            int expected = 652;
            int actual = reverseFirstMethod(numberToReverse);
            try
            {
                Assert.Equal(expected, actual);
                Console.WriteLine("Тест пройден");
            }
            catch (EqualException ex)
            {
                Console.WriteLine("Тест не пройден");
                Console.WriteLine(ex.Message);
            }
        }
        private int reverseFirstMethod(int x)
        {
            int answer = 0;
            while (x != 0)
            {
                int popedNumber = x % 10;
                if (answer > int.MaxValue / 10 || (answer == int.MaxValue / 10 && popedNumber > 7 ) 
                    || answer < int.MinValue / 10 || (answer == int.MinValue / 10 && popedNumber < -8))
                {
                    return 0;
                }
                answer = answer * 10 + popedNumber;
                x /= 10;
            }
            return answer;
        }
    }
}
