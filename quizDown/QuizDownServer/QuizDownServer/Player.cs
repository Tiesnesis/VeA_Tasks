using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Network;


namespace QuizDownServer
{
    class Player
    {
        NetworkTcpServer.Connection connection;
        public int score, opScore;
        public string status;
        public List<Question> question_list;

        public Player(NetworkTcpServer.Connection getConnection, List<Question> q_list)
        {
            connection = getConnection;
            score = 0;
            opScore = 0;
            question_list = q_list;


        }
        public void sendQuestions(List<Question> question_list)
        {
            connection.send(question_list);
        }

        public void receiveScore()
        {
            score = int.Parse(connection.receive().ToString());
        }

        public void sendOponentScore(int op_score)
        {
            connection.send(op_score);
        }

        public void sendCurrentQuestion(int active_question)
        {
            connection.send(active_question);

        }

        private void do_game()
        {
            while (status != "end")
            {
                switch (status)
                {
                    case "sendQuestions":
                        sendQuestions(question_list);
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
            connection.closeConnection();
        }
    }
}
