using QuizDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public Game game = new Game(Network.getQuestions());
        public MainWindow()
        {
            InitializeComponent();
            questionCountBar.Maximum = game.rounds.Count();
            game.play();
        }

        public static void updateQuestion(Question question)
        {
            ((MainWindow)Application.Current.MainWindow).questionBox.Text = question.QuestionContent;
            ((MainWindow)Application.Current.MainWindow).questionCountBar.Value =   ((MainWindow)Application.Current.MainWindow).game.rounds.Count();

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

        public void checkAnswer(string answer) //Also call this when time ends
        {
            if (game.rounds.First().currentQuestion.CorrectAnsw.Equals(answer))
            {
                Network.sendResult((int)game.timeElapsed);
            }
            else
            {
                Network.sendResult(0);
            }

            if (game.rounds.Count > 1)
            {
                game.rounds.RemoveAt(0);
            } else
            {
                endGame();
            }
            updateUi();
        }

        private void endGame()
        {
            MessageBox.Show("Game ended");
        }

        private void updateUi()
        {
            //Wait from server to start next round
            //Update both player scores
            game.timeElapsed = 0;
            updateQuestion(game.rounds.First().currentQuestion);
        }
        private void AnswerQuestion(object sender, RoutedEventArgs e)
        {
            Button source = (Button)sender;
            checkAnswer(source.Content.ToString());
        }
    }


}
