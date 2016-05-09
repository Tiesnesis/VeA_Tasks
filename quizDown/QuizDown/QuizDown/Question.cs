using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDown
{
    public class Question
    {
        string questionContent, correctAnsw, wrongAnsw1, wrongAnsw2, wrongAnsw3;
        public Question(string name, string correct, string wrong1, string wrong2, string wrong3)
        {
            questionContent = name;
            correctAnsw = correct;
            wrongAnsw1 = wrong1;
            wrongAnsw2 = wrong2;
            wrongAnsw3 = wrong3;
        }

        public string CorrectAnsw
        {
            get
            {
                return correctAnsw;
            }

            set
            {
                correctAnsw = value;
            }
        }

        public string QuestionContent
        {
            get
            {
                return questionContent;
            }

            set
            {
                questionContent = value;
            }
        }

        public string WrongAnsw1
        {
            get
            {
                return wrongAnsw1;
            }

            set
            {
                wrongAnsw1 = value;
            }
        }

        public string WrongAnsw2
        {
            get
            {
                return wrongAnsw2;
            }

            set
            {
                wrongAnsw2 = value;
            }
        }

        public string WrongAnsw3
        {
            get
            {
                return wrongAnsw3;
            }

            set
            {
                wrongAnsw3 = value;
            }
        }

        override
        public string ToString()
        {
            return QuestionContent;
        }
    }

}
