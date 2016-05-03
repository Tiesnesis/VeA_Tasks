namespace QuizDownServer
{
    internal class Question
    {
        string questionContent, correctAnsw, wrongAnsw1, wrongAnsw2, wrongAnsw3;
        public Question()
        {
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
    }
}