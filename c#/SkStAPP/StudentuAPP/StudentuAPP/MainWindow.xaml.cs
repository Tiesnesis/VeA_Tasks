using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace StudentuAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<questionsObject> questionList;
        public List<studentTest> testList;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void addElemensAllQuestionListBox()
        {
            listBox.Items.Clear();
            listBox.Items.Clear();
            foreach (studentTest value in testList)
            {
                listBox.Items.Add(value.ToString());
            }
            listBox.SelectionMode = new SelectionMode();
        }

        public List<T> DeSerializeObject<T>(string fileName)
        {
            List<T> readList;
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    readList = (List<T>)bin.Deserialize(stream);
                    foreach (T question in readList)
                    {
                        MessageBox.Show(
                        question.ToString());
                    }
                }
                MessageBox.Show("Size:" + readList.Count());
                MessageBox.Show("Size:" + readList.ElementAt(0).ToString());
                return readList;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                 "Important Note");
                return new List<T>();
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog dlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            dlg.Description = "Select test and question storage folder";
            dlg.UseDescriptionForTitle = true;
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                textBox.Text = dlg.SelectedPath;
                testList = DeSerializeObject<studentTest>(textBox.Text + "\\tests.quest");
                addElemensAllQuestionListBox();
            }
        }
    }
}
