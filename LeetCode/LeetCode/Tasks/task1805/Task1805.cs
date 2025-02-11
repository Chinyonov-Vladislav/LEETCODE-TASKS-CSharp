using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1805
{
    /*
     1805. Количество различных целых чисел в строке
    Вам будет предоставлена строка word, состоящая из цифр и строчных английских букв.
    Вы замените все нецифровые символы пробелами. Например, "a123bc34d8ef34" станет " 123  34 8  34". Обратите внимание, что у вас останутся некоторые целые числа, разделённые хотя бы одним пробелом: "123", "34", "8" и "34".
    Верните количество различных целых чисел после выполнения операций замены в word.
    Два целых числа считаются разными, если их десятичные представления без ведущих нулей отличаются.
    https://leetcode.com/problems/number-of-different-integers-in-a-string/description/
     */
    public class Task1805 : InfoBasicTask
    {
        public Task1805(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "3lnhx1n3h5vcb6l7mj3541oimktoxoqk4k8fl5bsur6duunwwsxfv5lmh9nikrihrvrupz846p32wk1hg0haqhubmux8z2ypas3r4c5qz3z78m1bvddlprgobs0i40t8rzoqznydwiz77brqs9ebt7og5db8gqzyctwcfopoho2g3xy575aex6l0mq9j2wekz17hz7bhip95evvt8egpd06c31g6oboi7swik9y50rsl7656ek0kutxr72qgw6xz0eukl63ktp7i0txrj7helqydgh2bo84e8adv9p5jlhep0ma1ff0a85pejprrdhme3260y2jk6ikw6z230rdql58bywjmjxfkx51x7hx7ecivu77m05hph942c7fe9ixd1q6er9p6pcozkdfd417mcklxakfvdv66cogmo6buqfwff2741u0sw8lo7t1rmp4gzbst2ag5k7alkaajyw5ilyzae866zj875p2to4a0ezu2l4ev8gm8zifgkamitw4jlij61vjmzbvmpz6shz87itepu611h4bulsc7w5avqd176n70eyovulnqtu2exsea7mu11gejustlqxo5rpsmbd0gy0ux8eul526tkxpudp73luzcxzfen2tmmvlb6ycod7zbjwy36gk7bftai2j4bdwo598pdmqaiucz5ht1eofv3uftfd26o76qs7dpcl5nxs98sv2z7frubxf36y8ctkyt6grrz19a3w7g81suggnfdy3vne3urcehxnt57q0zpwhcv37pmjt9p3syeuj5g8bjq4jeptzu1p1yd1gqgijer92xsbn1mb7f8a07eaehlr0gxfs7dfyntjm07qd1p2m3x834c9ik0ra4oauwhjl7q6kzy2uawx7drdvdj4q5n047k1r4h3edql4iakqcvpk3rnw6rxfy0tsxt3m0xjtl9wt066x4cnnbl718f850ghy5vgspllnetwqdh0b3c1uw6o8p4zl1kbhopa99";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            int count = numDifferentIntegers(str);
            Console.WriteLine($"Количество различных целых чисел в строке = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int numDifferentIntegers(string word)
        {
            StringBuilder sb = new StringBuilder();
            HashSet<int> numbers = new HashSet<int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsDigit(word[i]))
                {
                    sb.Append(word[i]);
                }
                if (!char.IsDigit(word[i]) && sb.Length > 0)
                {
                    numbers.Add(getNumberFromStringBuilder(sb));
                    sb.Clear();
                }
            }
            if (sb.Length > 0)
            {
                numbers.Add(getNumberFromStringBuilder(sb));
            }
            return numbers.Count;
        }
        private int getNumberFromStringBuilder(StringBuilder sb)
        {
            int currentNumber = 0;
            for (int j = 0; j < sb.Length; j++)
            {
                int currentDigit = sb[j] - '0';
                if (j != sb.Length - 1)
                {
                    currentNumber += currentDigit * (int)Math.Pow(10, sb.Length - j - 1) ;
                }
                else
                {
                    currentNumber += currentDigit;
                }
            }
            return currentNumber;
        }
    }
}
