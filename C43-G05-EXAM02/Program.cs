using System.Diagnostics;

namespace C43_G05_EXAM02
{
    public static class Globals  //Global Class To Declare Global Variables
    {


        public static int[] HisAnswers { get; set; }    //HisAnswers Property To hold Users Answers
        public static int[] QMarks { get; set; }        //Questions Marks Property To hold Question mark For All Qusetions 
        public static Stopwatch stopwatch;              //stopwatch Property To use it Count Exam Time
        public static string SE { get; set; }           //Start Exam  Property To hold Users Answers about starting Exam
        public static string QB { get; set; }           //Question Body Property To hold Body Of The Question
        public static int Grade { get; set; }           //Grade Property To User Final Grade
        public static int Total { get; set; }           //Total Property To hold Total Marks Of Questions
        public static bool Flag { get; set; }           //Flag Property To use it int TryParse
        static Globals()
        {
            stopwatch = new Stopwatch();
            HisAnswers = new int[1];
            QMarks = new int[1];
            SE = "";
            QB = "";
        }
    }
    internal class Program
    {

        static void Practical(int ExamTime, int NumOfQ) // Practical Fun
        {
            int QM = 0; //Question Mark Variable
            int RA = 0; //Right Answer Variable
            Globals.HisAnswers = new int[NumOfQ]; //HisAnswers Array To hold Users Answers
            Globals.QMarks = new int[NumOfQ];     //Questions Marks Array To hold Question mark For All Qusetions 
            Question[] Questions = new Question[NumOfQ]; //Questions Array Of Objects To hold Questions 
            Answers[] AnswersList = new Answers[2]       //AnswersList  Array Of Objects To hold Answers 
            {
                new Answers(1,"True"),
                new Answers(2,"False"),
            };
            for (int i = 0; i < NumOfQ; i++)  // For Loop To Take T/F Questions 
            {
                Console.WriteLine("Please Enter Question Body");
                Globals.QB = Console.ReadLine();
                do //Check Condition To Be Sure User Will Enter Int For Question Mark
                {
                    Console.WriteLine("Please Enter Question Mark");
                    Globals.Flag = int.TryParse(Console.ReadLine(), out QM);
                } while (!Globals.Flag);
                Globals.QMarks[i] = QM; //Store Qestion Mark In The Qestion Mark Array
                Globals.Total += QM;    // Count Total Marks Of All Questions
                do //Check Condition To Be Sure User Will Enter Int and must be (1,2) For Right AnswerId 
                {
                    Console.WriteLine("Please Enter The Right Answer Id (1 For True | 2 For False");
                    Globals.Flag = int.TryParse(Console.ReadLine(), out RA);
                } while ((RA != 1 && RA != 2) || !Globals.Flag);

                //Send All necessary Parmeters To Create Question
                Questions[i] = new TFQ(Globals.QB, QM, AnswersList, RA);

            }
            //create instanse from Class Subject and send all Parmeters
            Subject Mathmatics = new Subject(1, "Practical");
            //create instanse from Class PracticalExam and send all Parmeters
            PracticalExam Practical = new PracticalExam(ExamTime, NumOfQ, Questions);
            //Call CreateExam Fun
            Mathmatics.CreateExam(Practical);
            // start the exam
            do //To BeSure User Will Enter (Y,N)
            {
                Console.WriteLine("Do You Want To Start Exam (Y/N)");
                Globals.SE = Console.ReadLine();
                if (Globals.SE.ToLower() == "y")
                {
                    // start to count time
                    Globals.stopwatch.Start();
                    for (int i = 0; i < NumOfQ; i++)
                    {
                        // Call Show Exam Fun To Show Questions
                        Mathmatics.SubjectOfExam.ShowExam(i);
                        do //Check Condition To Be Sure User Will Enter Int and must be (1,2) For His AnswerId 
                        {
                            Globals.Flag = false;
                            Console.WriteLine("Please Enter AnswerId (1 For True | 2 For False)");
                            Globals.Flag = int.TryParse(Console.ReadLine(), out Globals.HisAnswers[i]);

                        } while ((Globals.HisAnswers[i] != 1 && Globals.HisAnswers[i] != 2) || !Globals.Flag);
                        // Count User Grade
                        if (Globals.HisAnswers[i] == Questions[i].RightAnswer)
                        {
                            Globals.Grade += Globals.QMarks[i];
                        }
                    }
                    // Finish Exam
                    Globals.stopwatch.Stop();
                    // Show The Final Report With Grade
                    for (int i = 0; i < NumOfQ; i++)
                    {
                        Console.WriteLine($"Q{i + 1}: {Questions[i].BOfQ}");
                        Console.WriteLine($"Your Answer Is ==> {AnswersList[Globals.HisAnswers[i] - 1].AnswerText}");
                        Console.WriteLine($"Right Answer Is ==> {AnswersList[(Questions[i].RightAnswer) - 1].AnswerText}");
                    }
                    Console.WriteLine($"Your Grade Is {Globals.Grade} From {Globals.Total}");
                    Console.WriteLine($"Time Is = {Globals.stopwatch.Elapsed.Duration()}");
                    Console.WriteLine("Thank You");
                }
                else if (Globals.SE.ToLower() == "n")
                {
                    Console.WriteLine("Sorry For Seeing You Leaving");
                }
            } while (Globals.SE.ToLower() != "y" && Globals.SE.ToLower() != "n");

        }

        static void Final(int ExamTime, int NumOfQ) // Final Fun
        {
            int[] TOfQ = new int[NumOfQ]; // Type Of Questions Array To Hold All Question Type
            int QM = 0; //Question Mark Variable
            int RA = 0; //Right Answer Variable
            Globals.HisAnswers = new int[NumOfQ]; //HisAnswers Array To hold Users Answers
            Globals.QMarks = new int[NumOfQ];     //Questions Marks Array To hold Question mark For All Qusetions 
            Question[] Questions = new Question[NumOfQ]; //Questions Array Of Objects To hold Questions 
            int QType = 0; // Question Type Variable To 
            Answers[] AnswersList;      //AnswersList  Array Of Objects To hold Answers
            // For Loop To Take Questions From User
            for (int i = 0; i < NumOfQ; i++)
            {
                // If Condition To handel If The Exam Type Is Final must has At least T/FQ Or MCQQ
                if (i < (NumOfQ - 1))
                {
                    do //Check Condition To Be Sure User Will Enter Int and must be (1,2) For Question Type 
                    {
                        Console.WriteLine("Please Enter Type Of Question (1 For MCQ | 2 For T/F ");
                        Globals.Flag = int.TryParse(Console.ReadLine(), out QType);
                        // If MCQQ Do This Code
                        if (QType == 1)
                        {
                            TOfQ[i] = QType;
                            AnswersList = new Answers[3];
                            Console.WriteLine("MCQ Question");
                            Console.WriteLine("Please Enter Question Body");
                            Globals.QB = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Please Enter Question Mark");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out QM);
                            } while (!Globals.Flag);
                            Globals.QMarks[i] = QM;
                            Globals.Total += QM;
                            Console.WriteLine("Choices Of Question");
                            for (int j = 0; j < 3; j++)
                            {
                                AnswersList[j] = new Answers(0, "");
                                Console.WriteLine($"Please Enter Choice Num{j + 1}");
                                AnswersList[j].AnswerId = (j + 1);
                                AnswersList[j].AnswerText = Console.ReadLine();
                            }
                            do
                            {
                                Console.WriteLine("Please Enter The Right Answer Id");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out RA);
                            } while ((RA != 1 && RA != 2 && RA != 3) || !Globals.Flag);
                            Questions[i] = new MCQQ(Globals.QB, QM, AnswersList, RA);
                        }
                        else if (QType == 2)
                        {
                            TOfQ[i] = QType;
                            AnswersList = new Answers[2]
                            {
                            new Answers(1,"True"),
                            new Answers(2,"False"),
                            };
                            Console.WriteLine("True/False Question");
                            Console.WriteLine("Please Enter Question Body");
                            Globals.QB = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Please Enter Question Mark");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out QM);
                            } while (!Globals.Flag);
                            Globals.QMarks[i] = QM;
                            Globals.Total += QM;
                            do
                            {
                                Console.WriteLine("Please Enter The Right Answer Id (1 For True | 2 For False)");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out RA);
                            } while ((RA != 1 && RA != 2) || !Globals.Flag);

                            Questions[i] = new TFQ(Globals.QB, QM, AnswersList, RA);
                        }
                    } while ((QType != 1 && QType != 2) || !Globals.Flag);
                }
                else if (i == (NumOfQ - 1))
                {
                    int ones = 0;
                    int twos = 0;
                    Globals.Flag = false;
                    do
                    {
                        for (int j = 0; j < TOfQ.Length; j++)
                        {
                            if (TOfQ[j] == 1)
                                ones++;
                            else if (TOfQ[j] == 2)
                                twos++;
                        }
                        if (ones != 0 && twos != 0)
                        {
                            Console.WriteLine("Please Enter Type Of Question (1 For MCQ | 2 For T/F ");
                            Globals.Flag = int.TryParse(Console.ReadLine(), out QType);
                            if (QType == 1)
                            {
                                TOfQ[i] = QType;
                                AnswersList = new Answers[3];
                                Console.WriteLine("MCQ Question");
                                Console.WriteLine("Please Enter Question Body");
                                Globals.QB = Console.ReadLine();
                                do
                                {
                                    Console.WriteLine("Please Enter Question Mark");
                                    Globals.Flag = int.TryParse(Console.ReadLine(), out QM);
                                } while (!Globals.Flag);
                                Globals.QMarks[i] = QM;
                                Globals.Total += QM;
                                Console.WriteLine("Choices Of Question");
                                for (int j = 0; j < 3; j++)
                                {
                                    AnswersList[j] = new Answers(0, "");
                                    Console.WriteLine($"Please Enter Choice Num{j + 1}");
                                    AnswersList[j].AnswerId = (j + 1);
                                    AnswersList[j].AnswerText = Console.ReadLine();
                                }
                                do
                                {
                                    Console.WriteLine("Please Enter The Right Answer Id");
                                    Globals.Flag = int.TryParse(Console.ReadLine(), out RA);
                                } while ((RA != 1 && RA != 2 && RA != 3) || !Globals.Flag);
                                Questions[i] = new MCQQ(Globals.QB, QM, AnswersList, RA);
                            }
                            else if (QType == 2)
                            {
                                TOfQ[i] = QType;
                                AnswersList = new Answers[2]
                                {
                            new Answers(1,"True"),
                            new Answers(2,"False"),
                                };
                                Console.WriteLine("True/False Question");
                                Console.WriteLine("Please Enter Question Body");
                                Globals.QB = Console.ReadLine();
                                do
                                {
                                    Console.WriteLine("Please Enter Question Mark");
                                    Globals.Flag = int.TryParse(Console.ReadLine(), out QM);
                                } while (!Globals.Flag);
                                Globals.QMarks[i] = QM;
                                Globals.Total += QM;
                                do
                                {
                                    Console.WriteLine("Please Enter The Right Answer Id (1 For True | 2 For False)");
                                    Globals.Flag = int.TryParse(Console.ReadLine(), out RA);
                                } while ((RA != 1 && RA != 2) || !Globals.Flag);

                                Questions[i] = new TFQ(Globals.QB, QM, AnswersList, RA);
                            }
                        }
                        else if (ones == 0)
                        {
                            AnswersList = new Answers[3];
                            Console.WriteLine("MCQ Question");
                            Console.WriteLine("Please Enter Question Body");
                            Globals.QB = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Please Enter Question Mark");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out QM);
                            } while (!Globals.Flag);
                            Globals.QMarks[i] = QM;
                            Globals.Total += QM;
                            Console.WriteLine("Choices Of Question");
                            for (int j = 0; j < 3; j++)
                            {
                                AnswersList[j] = new Answers(0, "");
                                Console.WriteLine($"Please Enter Choice Num{j + 1}");
                                AnswersList[j].AnswerId = (j + 1);
                                AnswersList[j].AnswerText = Console.ReadLine();
                            }
                            do
                            {
                                Console.WriteLine("Please Enter The Right Answer Id");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out RA);
                            } while ((RA != 1 && RA != 2 && RA != 3) || !Globals.Flag);
                            Questions[i] = new MCQQ(Globals.QB, QM, AnswersList, RA);
                        }
                        else if (twos == 0)
                        {
                            TOfQ[i] = QType;
                            AnswersList = new Answers[2]
                            {
                            new Answers(1,"True"),
                            new Answers(2,"False"),
                            };
                            Console.WriteLine("True/False Question");
                            Console.WriteLine("Please Enter Question Body");
                            Globals.QB = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Please Enter Question Mark");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out QM);
                            } while (!Globals.Flag);
                            Globals.QMarks[i] = QM;
                            Globals.Total += QM;
                            do
                            {
                                Console.WriteLine("Please Enter The Right Answer Id (1 For True | 2 For False)");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out RA);
                            } while ((RA != 1 && RA != 2) || !Globals.Flag);

                            Questions[i] = new TFQ(Globals.QB, QM, AnswersList, RA);
                        }

                    } while ((QType != 1 && QType != 2) || !Globals.Flag);
                }

            }
            Subject Mathmatics = new Subject(1, "Math");
            FinalExam finalExam = new FinalExam(ExamTime, NumOfQ, Questions);
            Mathmatics.CreateExam(finalExam);

            do
            {
                Console.WriteLine("Do You Want To Start Exam (Y/N)");
                Globals.SE = Console.ReadLine();
                if (Globals.SE.ToLower() == "y")
                {
                    Globals.stopwatch.Start();
                    for (int i = 0; i < NumOfQ; i++)
                    {
                        Mathmatics.SubjectOfExam.ShowExam(i);
                        do
                        {
                            Globals.Flag = false;
                            if (Questions[i].AnswerList.Length == 2)
                            {
                                Console.WriteLine("Please Enter AnswerId (1 For True | 2 For False)");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out Globals.HisAnswers[i]);
                            }
                            else if (Questions[i].AnswerList.Length == 3)
                            {
                                Console.WriteLine("Please Enter AnswerId");
                                Globals.Flag = int.TryParse(Console.ReadLine(), out Globals.HisAnswers[i]);
                            }
                        } while ((Globals.HisAnswers[i] != 1 && Globals.HisAnswers[i] != 2 && Globals.HisAnswers[i] != 3) || !Globals.Flag);
                        if (Globals.HisAnswers[i] == Questions[i].RightAnswer)
                        {
                            Globals.Grade += Globals.QMarks[i];
                        }
                    }
                    Globals.stopwatch.Stop();
                    for (int i = 0; i < NumOfQ; i++)
                    {
                        Answers[] QAL = Questions[i].AnswerList;
                        Console.WriteLine($"Q{i + 1}: {Questions[i].BOfQ}");
                        Console.WriteLine($"Your Answer Is ==> {QAL[Globals.HisAnswers[i] - 1].AnswerText}");
                        Console.WriteLine($"Right Answer Is ==> {QAL[(Questions[i].RightAnswer) - 1].AnswerText}");
                    }
                    Console.WriteLine($"Your Grade Is {Globals.Grade} From {Globals.Total}");
                    Console.WriteLine($"Time Is = {Globals.stopwatch.Elapsed.Duration()}");
                    Console.WriteLine("Thank You");
                }
                else if (Globals.SE.ToLower() == "n")
                {
                    Console.WriteLine("Sorry For Seeing You Leaving");
                }
            } while (Globals.SE.ToLower() != "y" && Globals.SE.ToLower() != "n");
        }
        static void Main(string[] args)
        {
            int ExamType = 0; // Exam Type Variable
            int ExamTime = 0; // Exam Time Variable
            int NumOfQ = 0;   // Number Of Questions Variable        
            do //condition to besure Exam Type Is Int Value and (1,2)
            {
                Console.WriteLine("Please Enter The Type Of Exam (1 For Practical | 2 For Final)");
                Globals.Flag = int.TryParse(Console.ReadLine(), out ExamType);
                if (ExamType == 1)
                {
                    do //condition to besure 180> ExamTime >30 and Int Value
                    {
                        Console.WriteLine("Please Enter The Time Of The Exam From (30 Min To 180 Min)");
                        Globals.Flag = int.TryParse(Console.ReadLine(), out ExamTime);
                    } while ((ExamTime < 30 || ExamTime > 180) || !Globals.Flag);
                    do //condition to besure Number Of Question Is Int Value
                    {
                        Console.WriteLine("Please Enter The Number Of Questions");
                        Globals.Flag = int.TryParse(Console.ReadLine(), out NumOfQ);
                    } while (!Globals.Flag);
                    Practical(ExamTime, NumOfQ);
                }

                else if (ExamType == 2)
                {
                    do //condition to besure 180> ExamTime >30 and Int Value
                    {
                        Console.WriteLine("Please Enter The Time Of The Exam From (30 Min To 180 Min)");
                        Globals.Flag = int.TryParse(Console.ReadLine(), out ExamTime);
                    } while ((ExamTime < 30 || ExamTime > 180) || !Globals.Flag);
                    do //condition to besure Number Of Question Is Int Value
                    {
                        Console.WriteLine("Please Enter The Number Of Questions");
                        Globals.Flag = int.TryParse(Console.ReadLine(), out NumOfQ);
                    } while (!Globals.Flag);
                    Final(ExamTime, NumOfQ);
                }
            } while ((ExamType != 1 && ExamType != 2) || !Globals.Flag);
        }
    }
}
