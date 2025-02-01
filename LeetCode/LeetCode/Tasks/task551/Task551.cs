using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task551
{
    /*
     551. Отчет о посещаемости учащихся I
    Вам дана строка s с записью о посещаемости ученика, где каждый символ обозначает, отсутствовал ли ученик, опоздал или присутствовал на уроке в этот день. Запись содержит только следующие три символа:
        'A': Отсутствует.
        'L': Поздно.
        'P': Настоящее время.
    Учащийся имеет право на поощрение за посещаемость, если он соответствует обоим следующим критериям:
        Ученик отсутствовал ('A') строго менее 2 дней всего.
        Студент никогда не опаздывал ('L') более чем на 3 дня подряд.
    Верните true если учащийся имеет право на поощрение за посещаемость, или false в противном случае.
     */
    public class Task551 : InfoBasicTask
    {
        public Task551(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "PPALLP";
            Console.WriteLine(checkRecord(str) ? "Студент имеет право на поощрение" : "Студент не имеет право на поощрение");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool checkRecord(string s)
        {
            int countAbsenceDays = 0;
            int maxCountLateSuccessively = 0;
            int countLateSuccessively = 0;
            foreach (var symbol in s)
            {
                if (symbol == 'A')
                {
                    countAbsenceDays++;
                }
                if (symbol == 'L')
                {
                    countLateSuccessively++;
                    if (countLateSuccessively > maxCountLateSuccessively)
                    {
                        maxCountLateSuccessively = countLateSuccessively;
                    }
                }
                else
                {
                    countLateSuccessively = 0;
                }
            }
            return countAbsenceDays < 2 && maxCountLateSuccessively < 3;
        }
    }
}
