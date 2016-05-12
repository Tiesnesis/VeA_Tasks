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
        public static int oponentScore = 0;
        static TcpClient client;
        static Stream stream;


        public static void init(String server, String name)
        {
            Console.WriteLine("Will create object");
                client = new TcpClient();
            Console.WriteLine("Will connect");

            client.Connect(server, 8001);
            Console.WriteLine("Will get stream");

            stream = client.GetStream();
        }
        public static List<Question> getQuestions()
        {
            //Get questions from server
            Console.WriteLine("Will read stream");
            int bufferSize = 16 * 1024;
            byte[] byteBuffer = new byte[bufferSize];
            Console.WriteLine("Created byte buffer"); 

            int k = stream.Read(byteBuffer, 0, bufferSize);
            Console.WriteLine("Got something from stream that is : ");
            string questions = "";
            for (int i = 0; i < k; i++)
            {
                questions += Convert.ToChar(byteBuffer[i]);
            }
            List<string> result = questions.Split(',').ToList();
            List<Question> questionList = new List<Question>();
            foreach(string question in result)
            {
                List<string> qlist = question.Split('_').ToList();
                questionList.Add(new Question(qlist[0], qlist[1], qlist[2], qlist[3], qlist[4]));
            }
            return questionList;
        }

        public static void sendResult(int result)
        {
            myScore += result;
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] byteBuffer = asen.GetBytes(result.ToString());
            stream.Write(byteBuffer,0,byteBuffer.Length);
        }

        public static void getOponentScore()
        {
            int bufferSize = 16;
            byte[] byteBuffer = new byte[bufferSize];
            int k = stream.Read(byteBuffer, 0, bufferSize);
            string opScore = "";
            for (int i = 0; i < k; i++)
            {
                opScore += Convert.ToChar(byteBuffer[i]);
            }
            oponentScore += int.Parse(opScore);
        }

        public static int startNextQuestion()
        {
            int bufferSize = 16;
            byte[] byteBuffer = new byte[bufferSize];
            int k = stream.Read(byteBuffer, 0, bufferSize);
            string questionId = "";
            for (int i = 0; i < k; i++)
            {
                questionId += Convert.ToChar(byteBuffer[i]);
            }
            return int.Parse(questionId);
        }

        public static int getMyScore()
        {
            return myScore;
        }
    }
}
