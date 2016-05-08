using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace QuizDownServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db_connection;
        List<Question> question_list;
        public MainWindow()
        {
            InitializeComponent();
            db_connection = new  Database();
            question_list = db_connection.Select();
            foreach (Question i in question_list)
            { listBox.Items.Add(i); }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Question temqQuestion = new Question(textBox.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            db_connection.Insert(temqQuestion);
            question_list = db_connection.Select();
            listBox.Items.Clear();
            foreach (Question i in question_list)
            { listBox.Items.Add(i); }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
