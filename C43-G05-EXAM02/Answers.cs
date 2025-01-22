using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G05_EXAM02
{
    internal class Answers
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Answers(int AnswerId,string AnswerText)
        {
            this.AnswerId = AnswerId;
            this.AnswerText = AnswerText;
        }
        public override string ToString()
        {
            return $"{AnswerId}- {AnswerText}";
        }
    }
}
