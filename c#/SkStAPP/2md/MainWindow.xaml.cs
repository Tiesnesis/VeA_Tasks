using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace _2md
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<questionsObject> questionList;
        public List<studentTest> testList;
        Label questionLabel;
        TextBox questionText;

        RadioButton corectRadio;
        RadioButton wrongRadio;
        RadioButton aRadio;
        TextBox answerAText;
        RadioButton bRadio;
        TextBox answerBText;
        RadioButton cRadio;
        TextBox answerCText;
        TextBox answerText;


        public MainWindow()
        {
            InitializeComponent();
            
            questionList = new List<questionsObject>();
            testList = new List<studentTest>();

        }

        private void choseFile_Click(object sender, RoutedEventArgs e)
        {


            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog dlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            dlg.Description = "Select test and question storage folder";
            dlg.UseDescriptionForTitle = true;
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                fileLocation.Text = dlg.SelectedPath;
            }
        }

        private void questionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (questionType.SelectedIndex == 0)
            {
                createGroup.Content = new Grid();
                Grid groupCreateGrid = new Grid();
                groupCreateGrid.HorizontalAlignment = HorizontalAlignment.Left;
                groupCreateGrid.VerticalAlignment = VerticalAlignment.Top;
                ColumnDefinition colDef1 = new ColumnDefinition();
                RowDefinition rowDef1 = new RowDefinition();
                RowDefinition rowDef2 = new RowDefinition();
                RowDefinition rowDef3 = new RowDefinition();
                RowDefinition rowDef4 = new RowDefinition();
                RowDefinition rowDef5 = new RowDefinition();
                RowDefinition rowDef6 = new RowDefinition();
                RowDefinition rowDef7 = new RowDefinition();
                RowDefinition rowDef8 = new RowDefinition();
                groupCreateGrid.ColumnDefinitions.Add(colDef1);
                groupCreateGrid.RowDefinitions.Add(rowDef1);
                groupCreateGrid.RowDefinitions.Add(rowDef2);
                groupCreateGrid.RowDefinitions.Add(rowDef3);
                groupCreateGrid.RowDefinitions.Add(rowDef4);
                groupCreateGrid.RowDefinitions.Add(rowDef5);
                groupCreateGrid.RowDefinitions.Add(rowDef6);
                groupCreateGrid.RowDefinitions.Add(rowDef7);
                groupCreateGrid.RowDefinitions.Add(rowDef8);

                questionLabel = new Label();
                questionLabel.Content = "Ievadiet jautajumu:";
                Grid.SetColumnSpan(questionLabel,1);
                Grid.SetRow(questionLabel, 1);
                groupCreateGrid.Children.Add(questionLabel);

                questionText = new TextBox();
                Grid.SetColumnSpan(questionText, 1);
                Grid.SetRow(questionText, 2);
                questionText.Width = 800;
                groupCreateGrid.Children.Add(questionText);

                Label answerLabel = new Label();
                answerLabel.Content = "Izvelieties atbildi:";
                Grid.SetColumnSpan(answerLabel, 1);
                Grid.SetRow(answerLabel, 3);
                groupCreateGrid.Children.Add(answerLabel);

                corectRadio = new RadioButton();
                corectRadio.Content = "Pareizi";
                Grid.SetColumnSpan(corectRadio,1);
                Grid.SetRow(corectRadio, 4);
                groupCreateGrid.Children.Add(corectRadio);

                wrongRadio = new RadioButton();
                wrongRadio.Content = "Neparezi";
                Grid.SetColumnSpan(wrongRadio, 1);
                Grid.SetRow(wrongRadio, 6);
                groupCreateGrid.Children.Add(wrongRadio);

                createGroup.Content = groupCreateGrid;
                createGroup.UpdateLayout();

            }
            else if (questionType.SelectedIndex == 1)
            {
                createGroup.Content = new Grid();
                Grid groupCreateGrid = new Grid();
                groupCreateGrid.HorizontalAlignment = HorizontalAlignment.Left;
                groupCreateGrid.VerticalAlignment = VerticalAlignment.Top;
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                RowDefinition rowDef1 = new RowDefinition();
                RowDefinition rowDef2 = new RowDefinition();
                RowDefinition rowDef3 = new RowDefinition();
                RowDefinition rowDef4 = new RowDefinition();
                RowDefinition rowDef5 = new RowDefinition();
                RowDefinition rowDef6 = new RowDefinition();
                RowDefinition rowDef7 = new RowDefinition();
                RowDefinition rowDef8 = new RowDefinition();
                groupCreateGrid.ColumnDefinitions.Add(colDef1);
                groupCreateGrid.ColumnDefinitions.Add(colDef2);
                groupCreateGrid.RowDefinitions.Add(rowDef1);
                groupCreateGrid.RowDefinitions.Add(rowDef2);
                groupCreateGrid.RowDefinitions.Add(rowDef3);
                groupCreateGrid.RowDefinitions.Add(rowDef4);
                groupCreateGrid.RowDefinitions.Add(rowDef5);
                groupCreateGrid.RowDefinitions.Add(rowDef6);
                groupCreateGrid.RowDefinitions.Add(rowDef7);
                groupCreateGrid.RowDefinitions.Add(rowDef8);

                questionLabel = new Label();
                questionLabel.Content = "Ievadiet jautajumu:";
                Grid.SetColumnSpan(questionLabel, 1);
                Grid.SetRow(questionLabel, 1);
                groupCreateGrid.Children.Add(questionLabel);

                questionText = new TextBox();
                Grid.SetColumnSpan(questionText, 1);
                Grid.SetRow(questionText, 2);
                questionText.Width = 800;
                groupCreateGrid.Children.Add(questionText);

                Label answerLabel = new Label();
                answerLabel.Content = "Izvelieties atbildi:";
                Grid.SetColumnSpan(answerLabel, 1);
                Grid.SetRow(answerLabel, 3);
                groupCreateGrid.Children.Add(answerLabel);

                aRadio = new RadioButton();
                aRadio.Content = "a)";
                Grid.SetColumnSpan(aRadio, 1);
                Grid.SetRow(aRadio, 4);
                groupCreateGrid.Children.Add(aRadio);

                answerAText = new TextBox();
                Grid.SetColumnSpan(answerAText, 2);
                Grid.SetRow(answerAText, 4);
                answerAText.Width = 700;
                groupCreateGrid.Children.Add(answerAText);

                bRadio = new RadioButton();
                bRadio.Content = "b)";
                Grid.SetColumnSpan(bRadio, 1);
                Grid.SetRow(bRadio, 6);
                groupCreateGrid.Children.Add(bRadio);

                answerBText = new TextBox();
                Grid.SetColumnSpan(answerBText, 2);
                Grid.SetRow(answerBText, 6);
                answerBText.Width =700;
                groupCreateGrid.Children.Add(answerBText);

                cRadio = new RadioButton();
                cRadio.Content = "c)";
                Grid.SetColumnSpan(cRadio, 1);
                Grid.SetRow(cRadio, 8);
                groupCreateGrid.Children.Add(cRadio);

                answerCText = new TextBox();
                Grid.SetColumnSpan(answerCText, 2);
                Grid.SetRow(answerCText, 8);
                answerCText.Width = 700;
                groupCreateGrid.Children.Add(answerCText);

                createGroup.Content = groupCreateGrid;
                createGroup.UpdateLayout();

            }
            else if (questionType.SelectedIndex == 2)
            {
                Grid groupCreateGrid = new Grid();
                groupCreateGrid.HorizontalAlignment = HorizontalAlignment.Left;
                groupCreateGrid.VerticalAlignment = VerticalAlignment.Top;
                ColumnDefinition colDef1 = new ColumnDefinition();
                RowDefinition rowDef1 = new RowDefinition();
                RowDefinition rowDef2 = new RowDefinition();
                RowDefinition rowDef3 = new RowDefinition();
                RowDefinition rowDef4 = new RowDefinition();
                RowDefinition rowDef5 = new RowDefinition();
                RowDefinition rowDef6 = new RowDefinition();
                RowDefinition rowDef7 = new RowDefinition();
                RowDefinition rowDef8 = new RowDefinition();
                groupCreateGrid.ColumnDefinitions.Add(colDef1);
                groupCreateGrid.RowDefinitions.Add(rowDef1);
                groupCreateGrid.RowDefinitions.Add(rowDef2);
                groupCreateGrid.RowDefinitions.Add(rowDef3);
                groupCreateGrid.RowDefinitions.Add(rowDef4);
                groupCreateGrid.RowDefinitions.Add(rowDef5);
                groupCreateGrid.RowDefinitions.Add(rowDef6);
                groupCreateGrid.RowDefinitions.Add(rowDef7);
                groupCreateGrid.RowDefinitions.Add(rowDef8);
                questionLabel = new Label();
                questionLabel.Content = "Ievadiet jautajumu:";
                Grid.SetColumnSpan(questionLabel, 1);
                Grid.SetRow(questionLabel, 1);
                groupCreateGrid.Children.Add(questionLabel);

                questionText = new TextBox();
                Grid.SetColumnSpan(questionText, 1);
                Grid.SetRow(questionText, 2);
                questionText.Width = 800;
                groupCreateGrid.Children.Add(questionText);

                Label answerLabel = new Label();
                answerLabel.Content = "Ievadiet atbildi:";
                Grid.SetColumnSpan(answerLabel, 1);
                Grid.SetRow(answerLabel, 3);
                groupCreateGrid.Children.Add(answerLabel);

                answerText = new TextBox();
                Grid.SetColumnSpan(answerText, 1);
                Grid.SetRow(answerText, 4);
                answerText.Width = 800;
                groupCreateGrid.Children.Add(answerText);

                createGroup.Content = groupCreateGrid;
                createGroup.UpdateLayout();

            }
        }

        private void saveQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (questionType.SelectedIndex == 0)
            {
                questionList.Add(new questionObjectWrongCorect(questionText.Text, (bool)corectRadio.IsChecked));
            }
            else if (questionType.SelectedIndex == 1)
            {
                int tempCorrect = -1;
                if ((bool)aRadio.IsChecked)
                {
                    tempCorrect = 0;
                }
                else if ((bool)bRadio.IsChecked)
                {
                    tempCorrect = 1;
                }
                else if ((bool)cRadio.IsChecked)
                {
                    tempCorrect = 2;
                }
                questionList.Add(new questionObject3answ(questionText.Text, answerAText.Text, answerBText.Text, answerCText.Text, tempCorrect));
            }
            else if (questionType.SelectedIndex == 2)
            {
                questionList.Add(new questionObjectWord(questionText.Text, answerText.Text));
            }
            addElemensAllQuestionListBox();
        }

        private void writeButton_Click(object sender, RoutedEventArgs e)
        {
            
            SerializeObject<List<questionsObject>>(questionList, fileLocation.Text+"\\questions.quest");

         }
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, serializableObject);
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                 "Important Note");
            }
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
                MessageBox.Show("Size:"+readList.Count());
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

        private void readButton_Click(object sender, RoutedEventArgs e)
        {
            questionList = DeSerializeObject<questionsObject>(fileLocation.Text+"\\questions.quest");
            addElemensAllQuestionListBox();
        }
        public void addElemensAllQuestionListBox()
        {
            allQuestions.Items.Clear();
            testQuestions.Items.Clear();
            foreach (questionsObject value in questionList)
            {
                allQuestions.Items.Add(value.ToString());
            }
            allQuestions.SelectionMode = new SelectionMode();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            testQuestions.Items.Add(allQuestions.SelectedItem);
            allQuestions.Items.RemoveAt(allQuestions.SelectedIndex);
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            allQuestions.Items.Add(testQuestions.SelectedItem);
            testQuestions.Items.RemoveAt(testQuestions.SelectedIndex);
        }

        private void saveTest_Click(object sender, RoutedEventArgs e)
        {
            //TODO add exception for non existing file
            try
            {
                testList = DeSerializeObject<studentTest>(fileLocation.Text + "\\tests.quest");
            }
            catch {
                testList = new List<studentTest>();
            }
                testList.Add(new studentTest(questionList,(bool) randomizeCheckBox.IsChecked, Int32.Parse(numberTextBox.Text), (System.DateTime)calendar.SelectedDate, testNameTextBox.Text));
            SerializeObject<List<studentTest>>(testList, fileLocation.Text + "\\tests.quest");
        }
        public void addElemensAllTestsListBox(List<studentTest> testTempList)
        {
            listBox.Items.Clear();
            listBox.Items.Clear();
            foreach (studentTest value in testTempList)
            {
                listBox.Items.Add(value.ToString());
            }
            listBox.SelectionMode = new SelectionMode();
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
                List<studentTest> tempList;
                tempList = DeSerializeObject<studentTest>(textBox.Text + "\\tests.quest");
                addElemensAllTestsListBox(tempList);
            }
        }
    }
}