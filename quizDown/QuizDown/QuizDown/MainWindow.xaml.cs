using QuizDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game;
        public bool gameOn = false;
        public int questionId = 0;
        public int score;
        public bool correct;
        public MainWindow()
        {
            InitializeComponent();
            Network.init("127.0.0.1", "Name");
            game = new Game(Network.getQuestions());
            game.play();
            questionCountBar.Maximum = game.rounds.Count();
            myScoreBar.Maximum = game.rounds.Count() * game.questionTime;
            oponentScoreBar.Maximum = game.rounds.Count() * game.questionTime;
            nextRound();
            gameOn = true;
        }

        public void updateQuestion(Question question)
        {
            ((MainWindow)Application.Current.MainWindow).questionBox.Text = question.QuestionContent;
            ((MainWindow)Application.Current.MainWindow).questionCountBar.Value = ((MainWindow)Application.Current.MainWindow).game.rounds.Count();
            ((MainWindow)Application.Current.MainWindow).questionLabel.Content = ((MainWindow)Application.Current.MainWindow).game.rounds.Count();
            List<string> answers = new List<string>() { question.CorrectAnsw, question.WrongAnsw1, question.WrongAnsw2, question.WrongAnsw3 };
            Random rand = new Random();
            answers = answers.OrderBy(c => rand.Next()).ToList();
            updateAnswerButtons(answers);
        }
        public static void updateAnswerButtons(List<string> answers)
        {
            int idx = 0;
            foreach (Button button in ((MainWindow)System.Windows.Application.Current.MainWindow).answerButtons.Children)
            {
                button.IsEnabled = true;
                button.Background = Brushes.LightGray;
                button.Content = answers[idx];
                idx++;
            }
        }
        public static void updateTimeBar(double percent)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).questionTimeBar.Value = percent;
            }));
        }

        public static void updateTimeLabel(int seconds)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).timeLabel.Content = seconds.ToString();
            }));
        }

        public void showCorrectAnswer(bool gotAnswer)
        {
            if (game.rounds.Count() > 0) {
                foreach (Button button in ((MainWindow)Application.Current.MainWindow).answerButtons.Children)
                {
                    if (button.Content.ToString() == game.rounds.First().currentQuestion.CorrectAnsw)
                    {
                        button.Background = Brushes.Green;
                    }
                    if (!gotAnswer)
                    {
                        if (button.Content.ToString() != game.rounds.First().currentQuestion.CorrectAnsw)
                        {
                            button.Background = Brushes.Red;
                        }
                    }
                }
            }
        }

        public void checkAnswer(string answer)
        {
            correct = false;
            if (game.rounds.First().currentQuestion.CorrectAnsw == answer)
            {
                Player.status = "sendMyScore";
                Player.score = (int)(game.questionTime - game.timeElapsed);
                correct = true;
            }
            else
            {
                Player.score = 0;
                Player.status = "sendMyScore";
            }


            if (game.rounds.Count > 0)
            {
                game.rounds.RemoveAt(0);
            }

            if (game.rounds.Count == 0)
            {
                endGame();
            }
            disableButtons();

        }

        private void endGame()
        {
            questionCountBar.Value = 0;
            ((MainWindow)Application.Current.MainWindow).questionLabel.Content = 0.ToString();
            game.timer.Stop();
            game.timer.Close();
            game.timer.Dispose();
            gameOn = false;
            MessageBox.Show("Game ended");
        }

        public void nextRound()
        {
            Player.status = "waitForNextRound";
            myScoreBar.Value = Network.getMyScore();
        }
        private void AnswerQuestion(object sender, RoutedEventArgs e)
        {
            game.timer.Stop();
            Button source = (Button)sender;
            disableButtons();
            ((MainWindow)Application.Current.MainWindow).showCorrectAnswer(true);
            Console.WriteLine(source.Content.ToString());
            checkAnswer(source.Content.ToString());
            if (!correct)
            {
                source.Background = Brushes.Red;
            }

            if (gameOn)
            {
                nextRound();
            }

        }

        private void disableButtons()
        {
            foreach (Button button in ((MainWindow)System.Windows.Application.Current.MainWindow).answerButtons.Children)
            {
                //button.IsEnabled = false;
            }
        }

        

        


    }


}
