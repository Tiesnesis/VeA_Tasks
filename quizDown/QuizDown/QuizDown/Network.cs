using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizDown
{
    static class Network
    {
        static int myScore = 0;
        static int oponentScore = 0;
        static TcpClient client;
        static Stream stream;


        public static void init(String server, String name)
        {
            //Connect to server
            Console.WriteLine("Will create object");
                client = new TcpClient();
            Console.WriteLine("Will connect");

            client.Connect(server, 8001);
            Console.WriteLine("Will get stream");

            stream = client.GetStream();

            //Send my name
        }
        public static List<Question> getQuestions()
        {
            //Get questions from server
            Console.WriteLine("Will read stream");
            byte[] bb = new byte[100]; // Increas buffer size
            Console.WriteLine("Created byte buffer"); 

            int k = stream.Read(bb, 0, 100);
            Console.WriteLine("Got something from stream that is : ");

            for (int i = 0; i < k; i++)
            {
                Console.WriteLine(""+Convert.ToChar(bb[i])); //Decode questions and add to list
            }

            return null; //Return list
        }

        public static void sendResult(int result)
        {
            myScore += result;
            oponentScore += 3;
        }

        public static int getOponentScore()
        {
            return oponentScore;
        }

        public static int getMyScore()
        {
            return myScore;
        }

        public static Question getDummyQuestion()
        {
            List<string> answers = new List<string>(4);
            answers.Add("Answer1");
            answers.Add("Answer2");
            answers.Add("Answer3");
            answers.Add("Answer4");
            return new Question("This is a question no. 1 with the correct answer: Answer1", "Answer1", "Answer2", "Answer3", "Answer4");
        }

        public static Question getDummyQuestion2()
        {
            List<string> answers = new List<string>(4);
            answers.Add("Answer1");
            answers.Add("Answer2");
            answers.Add("Answer3");
            answers.Add("Answer4");
            return new Question("This is a question no. 2 with the correct answer: Answer1", "Answer1", "Answer2", "Answer3", "Answer4");
        }

        public static void sendQuestion(Question question)
        {
            //Send question with answer and score to server
            Console.WriteLine("Answer sent to server");
        }
    }
}
