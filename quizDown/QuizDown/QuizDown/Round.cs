using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace QuizDown
{
    class Round
    {
        static double questionTime = 5;
        static double timeElapsed = 0;
        static Question currentQuestion;

        static Timer timer;
        public Round(Question question)
        {
            currentQuestion = question;
        }
        
        public void round()
        {
                MainWindow.updateQuestion(currentQuestion);
                timer = new Timer();
                timer.Start();
                timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                timer.Interval = 1000;
                timer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            
            double percent = (questionTime - timeElapsed) / questionTime * 100.0;
            MainWindow.updateTimeBar(percent);
            timeElapsed++;
            if (timeElapsed > questionTime)
            {
                currentQuestion.score = 0;
                Network.sendQuestion(currentQuestion);
                timer.Stop();
            }

        }

        public void updateAnswer(String answer)
        {
            if (!answer.Equals(currentQuestion.correctAnswer))
            {
                currentQuestion.score = 0;
            } else
            {
                currentQuestion.score = timeElapsed;
            }
            Network.sendQuestion(currentQuestion);
            timer.Stop();
        }

    }
}
