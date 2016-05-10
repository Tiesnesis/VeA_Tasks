using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace QuizDown
{


    public class Round
    {
        public string answer = "";
        public Question currentQuestion;

        public Round(Question question)
        {
            currentQuestion = question;
        }

        public void startRound()
        {

        }

    }
}
