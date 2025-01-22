using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G05_EXAM02
{
    internal abstract class Exam
    {
        public int TimeOfEx { get; set; }
        public int NumOfQ { get; set; }
        public Question[] Questions { get; set; }
        public Subject ExamSubject { get; set; }
        protected Exam(int TimeOfEx, int NumOfQ, Question[] Questions)
        {
            this.TimeOfEx = TimeOfEx;
            this.NumOfQ = NumOfQ;
            this.Questions = Questions;
        }
        public abstract void ShowExam(int QId);
    }
}
