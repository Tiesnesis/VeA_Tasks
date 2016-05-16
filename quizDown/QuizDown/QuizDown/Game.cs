using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace QuizDown
{
    public class Game
    {
        List<Question> questions;
        public bool gameOn = false;
        public List<Round> rounds;
        public System.Timers.Timer timer;
        public double questionTime = 20;
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
            gameOn = true;
            Thread thread = new Thread(new ThreadStart(game));
            thread.Start();

        }
        public void runTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 1000;
            timer.Enabled = false;
        }

        public void resetTimer()
        {
            timeElapsed = 0;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            double percent = (questionTime - timeElapsed) / questionTime * 100.0;
            MainWindow.updateTimeBar(percent);
            MainWindow.updateTimeLabel((int)questionTime - (int)timeElapsed);
            timeElapsed++;
            Console.WriteLine("" + timeElapsed);
            if (timeElapsed > questionTime)
            {
                timeElapsed = 0;
                timer.Stop();
                
                    System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        ((MainWindow)System.Windows.Application.Current.MainWindow).checkAnswer("");
                        ((MainWindow)System.Windows.Application.Current.MainWindow).showCorrectAnswer(false);
                        if (rounds.Count() > 0)
                        {
                            ((MainWindow)System.Windows.Application.Current.MainWindow).nextRound();
                        }
                    }));
                
            }
        }

        public void game()
        {
            while (gameOn)
            {
                switch (Player.status)
                {
                    case "waitForNextRound":
                        Network.startNextQuestion();
                        if( Network.currentQuestion != 1)
                        {
                            Thread.Sleep(5000);
                        }

                        System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            ((MainWindow)System.Windows.Application.Current.MainWindow).updateQuestion(rounds.First().currentQuestion);
                        }));
                        timer.Start();
                        resetTimer();
                        Player.status = "wait";
                        break;
                    case "sendMyScore":
                        Network.sendResult(Player.score);
                        Player.status = "receiveOponentScore";
                        break;
                    case "receiveOponentScore":
                        Network.getOponentScore();
                        Player.status = "waitForNextRound";
                        break;
                    default:
                        break;

                }
            }
        }

    }
}
