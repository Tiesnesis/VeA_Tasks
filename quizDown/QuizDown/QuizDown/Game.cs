using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace QuizDown
{
    public class Game
    {
        List<Question> questions;
        public List<Round> rounds;
        System.Timers.Timer timer;
        double questionTime = 5;
        public double timeElapsed = 0;

        public Game(List<Question> questions)
        {
            rounds = new List<Round>();
            this.questions = questions;
        }

        public void play()
        {
            runTimer();
            foreach (Question question in questions)
            {
                Round round = new Round(question);
                rounds.Add(round);
            }
            rounds.First().startRound();
        }
        public void runTimer()
        {
            timer = new System.Timers.Timer();
            timer.Start();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        public void resetTimer()
        {
            timeElapsed = 0;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            double percent = (questionTime - timeElapsed) / questionTime * 100.0;
            MainWindow.updateTimeBar(percent);
            timeElapsed++;
            Console.WriteLine("" + timeElapsed);
            if (timeElapsed > questionTime)
            {
                timeElapsed = 0;
            }
        }


    }
}
