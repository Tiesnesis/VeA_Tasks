using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDown
{
    public class Question
    {
        //TODO update this class to match server side question attributes
        public String question;
        public List<String> answers;
        public String correctAnswer;
        public double score;

        public Question(String question, List<String> answers, String correctAnswer)
        {
            this.question = question;
            this.answers = answers;
            this.correctAnswer = correctAnswer;
        }

        public bool checkAnswer(String answer, int score)
        {
            if (answer.Equals(correctAnswer))
            {
                this.score += score;
                return true;
            }
            else
                return false;
        }

        public List<String> getAnswers()
        {
            return answers;
        }
    }
}
