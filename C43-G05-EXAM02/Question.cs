using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G05_EXAM02
{
    internal abstract class Question
    {
        public string BOfQ { get; set; }
        public int Mark { get; set; }
        public Answers[] AnswerList { get; set; }
        public int RightAnswer { get; set; }
        public Question(string BOfQ,int Mark, Answers[] AnswerList,int RightAnswer)
        {
            this.BOfQ = BOfQ;
            this.Mark = Mark;
            this.AnswerList = AnswerList;
            this.RightAnswer = RightAnswer;
        }
        public abstract void ShowQ();
    }
}
