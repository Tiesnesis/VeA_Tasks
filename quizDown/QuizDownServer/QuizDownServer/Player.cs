using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace QuizDownServer
{
    class Player
    {
        Socket connection;
        public int score, opScore;
        public string status;
        public List<Question> question_list;

        public Player(Socket getConnection, List<Question> q_list)
        {
            connection = getConnection;
            score = 0;
            opScore = 0;
            question_list = q_list;

        }
        public void sendQuestions(List<Question> question_list)
        {
            var combined = string.Join(", ", question_list);
            ASCIIEncoding asen = new ASCIIEncoding();
            connection.Send(asen.GetBytes(combined));
        }

        public void receiveScore()
        {
            byte[] b = new byte[100];
            int k = connection.Receive(b);
            string receive_score = "";
            for (int i = 0; i < k; i++)
                receive_score = receive_score + Convert.ToChar(b[i]);
            score = int.Parse(receive_score.ToString());
            
        }

        public void sendOponentScore(int op_score)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            connection.Send(asen.GetBytes(op_score.ToString()));
            Thread.Sleep(1000);
        }

        public void sendCurrentQuestion(int active_question)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            connection.Send(asen.GetBytes(active_question.ToString()));

        }

        private void do_game()
        {
            Console.WriteLine(status);
            while (status != "end")
            {
                switch (status)
                {
                    case "sendQuestions":
                        Console.WriteLine("Will send questions");
                        sendQuestions(question_list);
                        Console.WriteLine("Questions sent");
                        status = "wait";
                        break;
                    case "1":
                        sendCurrentQuestion(1);
                        status = "getScore";
                        break;
                    case "2":
                        sendCurrentQuestion(2);
                        status = "getScore";
                        break;
                    case "3":
                        sendCurrentQuestion(3);
                        status = "getScore";
                        break;
                    case "4":
                        sendCurrentQuestion(4);
                        status = "getScore";
                        break;
                    case "5":
                        sendCurrentQuestion(5);
                        status = "getScore";
                        break;
                    case "6":
                        sendCurrentQuestion(6);
                        status = "getScore";
                        break;
                    case "7":
                        sendCurrentQuestion(7);
                        status = "getScore";
                        break;
                    case "getScore":
                        receiveScore();
                        status = "wait";
                        break;
                    case "sendScore":
                        sendOponentScore(opScore);
                        status = "wait";
                        break;
                    case "wait":
                        break;
                }
            }
            close();
        }

        public void playGame()
        {
            ThreadStart player_ref = new ThreadStart(do_game);
            Thread player_thread = new Thread(player_ref);
            player_thread.Start();
        }
        public void close()
        {
            connection.Close();
        }
    }
}
