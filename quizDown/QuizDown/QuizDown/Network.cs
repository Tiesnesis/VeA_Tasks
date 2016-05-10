using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizDown
{
    static class Network
    {
        static int myScore = 0;
        static int oponentScore = 0;
        public static void init(String server, String name)
        {
            //Connect to server
            //Send my name
        }
        public static List<Question> getQuestions()
        {
            //Get questions from server
            List<Question> questions = new List<Question>();
            questions.Add(getDummyQuestion());
            questions.Add(getDummyQuestion2());
            questions.Add(getDummyQuestion2());
            questions.Add(getDummyQuestion2());
            questions.Add(getDummyQuestion2());
            questions.Add(getDummyQuestion2());
            return questions;
        }

        public static void sendResult(int result)
        {
            myScore += result;
            oponentScore += 3;
        }

        public static int getOponentScore()
        {
            return oponentScore;
        }

        public static int getMyScore()
        {
            return myScore;
        }

        public static Question getDummyQuestion()
        {
            List<string> answers = new List<string>(4);
            answers.Add("Answer1");
            answers.Add("Answer2");
            answers.Add("Answer3");
            answers.Add("Answer4");
            return new Question("This is a question no. 1 with the correct answer: Answer1", "Answer1", "Answer2", "Answer3", "Answer4");
        }

        public static Question getDummyQuestion2()
        {
            List<string> answers = new List<string>(4);
            answers.Add("Answer1");
            answers.Add("Answer2");
            answers.Add("Answer3");
            answers.Add("Answer4");
            return new Question("This is a question no. 2 with the correct answer: Answer1", "Answer1", "Answer2", "Answer3", "Answer4");
        }

        public static void sendQuestion(Question question)
        {
            //Send question with answer and score to server
            Console.WriteLine("Answer sent to server");
        }
    }
}
