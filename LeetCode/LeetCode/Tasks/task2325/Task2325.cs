using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2325
{
    /*
     2325. Расшифруйте сообщение
    Вам даны строки key и message, которые представляют собой ключ шифрования и секретное сообщение соответственно. Шаги по расшифровке message следующие:
        Используйте первое появление всех 26 строчных букв английского алфавита в key в качестве порядка в таблице замен.
        Приведите таблицу подстановок в соответствие с обычным английским алфавитом.
        Каждая буква в message затем заменяется с помощью таблицы.
        Пространства ' ' преобразуются сами в себя.
    Например, учитывая, что key = "happy boy" (фактический ключ будет содержать по крайней мере один экземпляр каждой буквы алфавита), у нас есть таблица частичной замены ('h' -> 'a', 'a' -> 'b', 'p' -> 'c', 'y' -> 'd', 'b' -> 'e', 'o' -> 'f').
    Верните расшифрованное сообщение.

    Ограничения:
        26 <= key.length <= 2000
        key состоит из строчных английских букв и ' '.
        key содержит все буквы английского алфавита (от 'a' до 'z') хотя бы по одному разу.
        1 <= message.length <= 2000
        message состоит из строчных английских букв и ' '.
    https://leetcode.com/problems/decode-the-message/description/
     */
    public class Task2325 : InfoBasicTask
    {
        public Task2325(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string key = "the quick brown fox jumps over the lazy dog";
            string message = "vkbs bs t suepuv";
            Console.WriteLine($"Ключ: \"{key}\"");
            Console.WriteLine($"Закодированное сообщение: \"{message}\"");
            string result = decodeMessage(key, message);
            Console.WriteLine($"Декодированное сообщение: \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string decodeMessage(string key, string message)
        {
            Dictionary<char, char> alphabet = new Dictionary<char, char>();
            char startChar = 'a';
            for (int i = 0; i < key.Length; i++)
            {
                if (!alphabet.ContainsKey(key[i]) && !char.IsWhiteSpace(key[i]))
                {
                    alphabet.Add(key[i], startChar);
                    startChar++;
                    
                    if (startChar > 'z')
                    {
                        break;
                    }
                }
            }
            StringBuilder resultMessage = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsWhiteSpace(message[i]))
                {
                    resultMessage.Append(message[i]);
                }
                else
                {
                    resultMessage.Append(alphabet[message[i]]);
                }
                
            }
            return resultMessage.ToString();
        }
    }
}
