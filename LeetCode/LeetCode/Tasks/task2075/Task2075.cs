using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2075
{
    /*
     2075. Расшифруйте наклонный текст
    Строка originalText кодируется с помощью шифра наклонной перестановки в строку encodedText с помощью матрицы с фиксированным количеством строк rows.
    originalText размещается первым в порядке от верхнего левого до нижнего правого угла.
    Сначала заполняются синие ячейки, затем красные, потом жёлтые и так далее, пока мы не дойдём до конца originalText. Стрелка указывает порядок заполнения ячеек. Все пустые ячейки заполняются ' '. Количество столбцов выбирается таким образом, чтобы крайний правый столбец не был пустым после заполнения originalText.
    encodedText Затем формируется строка, в которую последовательно добавляются все символы матрицы.
    Символы в синих ячейках добавляются сначала в encodedText, затем в красные ячейки и так далее, и, наконец, в жёлтые ячейки. 
    Стрелка указывает порядок обращения к ячейкам.
    Учитывая закодированную строку encodedText и количество строк rows, верните исходную строку originalText.
    Примечание: originalText не содержит пробелов в конце ' '. Тестовые примеры генерируются таким образом, чтобы был только один возможный originalText.
    Ограничения:
        0 <= encodedText.length <= 106
        encodedText состоит только из строчных английских букв и ' '.
        encodedText Это корректная кодировка некоторых originalText символов, не содержащих конечные пробелы.
        1 <= rows <= 1000
        Тестовые сценарии генерируются таким образом, что существует только один возможный originalText.
     */
    public class Task2075 : InfoBasicTask
    {
        public Task2075(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string encodedText = "iveo    eed   l te   olc";
            int countRows = 4;
            Console.WriteLine($"Исходная закодированная строка: \"{encodedText}\"\nКоличество строк в матрице кодирования = {countRows}");
            if (isValid(encodedText, countRows))
            {
                string res = decodeCiphertext(encodedText, countRows);
                Console.WriteLine($"Декодированная строка: \"{res}\"");
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
        private bool isValid(string encodedText, int rows)
        {
            int lowLimitEncodedText = 0;
            int highLimitEncodedText = (int)Math.Pow(10,6);
            if (encodedText.Length < lowLimitEncodedText || encodedText.Length > highLimitEncodedText)
            {
                return false;
            }
            foreach (char c in encodedText)
            {
                if (!((c >= 'a' && c <= 'z') || c == ' '))
                {
                    return false;
                }
            }
            if (encodedText.EndsWith(" "))
            {
                return false;
            }
            if (rows < 1 || rows > 1000)
            {
                return false;
            }
            return true;
        }
        private string decodeCiphertext(string encodedText, int rows)
        {
            if (rows == 1)
            {
                return encodedText;
            }
            int countColumns = encodedText.Length / rows;
            char[][] chars = new char[rows][];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = new char[countColumns];
            }
            int indexInEncodedText = 0;
            for (int indexRow = 0; indexRow < chars.Length; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < chars[indexRow].Length; indexColumn++)
                {
                    chars[indexRow][indexColumn] = encodedText[indexInEncodedText];
                    indexInEncodedText++;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int indexColumn = 0; indexColumn < chars[0].Length; indexColumn++)
            {
                int currentIndexRow = 0;
                int currentIndexColumn = indexColumn;
                while (currentIndexRow >= 0 && currentIndexRow < rows && currentIndexColumn >= 0 && currentIndexColumn < countColumns)
                {
                    sb.Append(chars[currentIndexRow][currentIndexColumn]);
                    currentIndexRow++;
                    currentIndexColumn++;
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
