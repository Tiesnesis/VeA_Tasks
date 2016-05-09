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

        public void sendQuestions(List<Question> question_list)
        {
            connection.send(question_list);
        }

        public int receiveScore()
        {
            return int.Parse(connection.receive().ToString());
        }

        public void sendOponentScore(int op_score)
        {
            connection.send(op_score);
        }

        public void sendCurrentQuestion(int active_question)
        {
            connection.send(active_question);

        }

        public void close()
        {
            connection.closeConnection();
        }
    }
}
