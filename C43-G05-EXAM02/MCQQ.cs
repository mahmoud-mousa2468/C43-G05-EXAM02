namespace C43_G05_EXAM02
{
    internal class MCQQ : Question
    {
        public MCQQ(string BOfQ, int Mark, Answers[] AnswerList, int RightAnswer) : base(BOfQ, Mark, AnswerList, RightAnswer)
        {
        }

        public override void ShowQ()
        {
            Console.WriteLine($"MCQ Question Mark {Mark}");
            Console.WriteLine($"{BOfQ}");
            foreach (var Answer in AnswerList)
            {
                Console.WriteLine(Answer);
            }

        }
    }
}
