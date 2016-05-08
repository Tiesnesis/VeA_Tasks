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
        public MainWindow()
        {
            InitializeComponent();
            updateQuestion(Network.getDummyQuestion());
            Round round = new Round(Network.getDummyQuestion()); // Move to Game
            round.round(); // Move to game

        }

        public static void updateQuestion(Question question)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).questionBox.Text = question.question;
           int idx = 0;
           foreach(Button button in ((MainWindow)System.Windows.Application.Current.MainWindow).answerButtons.Children)
            {
                button.Content = question.answers[idx]; 
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

        private void AnswerQuestion(object sender, RoutedEventArgs e)
        {
           //Call answer method from current round object
        }
    }

}
