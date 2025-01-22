using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G05_EXAM02
{
    internal class FinalExam : Exam
    {
        public FinalExam(int TimeOfEx, int NumOfQ, Question[] Questions):base(TimeOfEx,NumOfQ,Questions)
        {
            
        }
        public override void ShowExam(int QId)
        {
            Questions[QId].ShowQ();
        }
    }
}
