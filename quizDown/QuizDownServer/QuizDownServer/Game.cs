using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace QuizDownServer
{
    class Game
    {
        NetworkTcpServer tcpServer;

        private List<Question> selectQuestions()
        {
            List<Question> questions = new List<Question>();
            Random rnd = new Random();
            Database temp_connection = new Database();
            List<Question> temp_list = temp_connection.Select();
            while( questions.Count <= 7)
            {
                int index =  rnd.Next(0, temp_list.Count);
                questions.Add(temp_list.ElementAt(index));
                temp_list.RemoveAt(index);
            }
            return questions;
        }

        public void startServerConenction()
        {
            tcpServer = new NetworkTcpServer("localhost", 4567);
        }

        private void doGame()
        {
            List<Question> questions = selectQuestions();
            Player player_1 = new Player(tcpServer.waitForNewConnection(), questions);
            Player player_2 = new Player(tcpServer.waitForNewConnection(), questions);

            player_1.status = "sendQuestions";
            player_2.status = "sendQuestions";
            while(player_1.status != "wait" && player_2.status != "wait")
            {

            }
            int i = 0;
            do
            {

                i++;
                player_1.status = i.ToString();
                player_2.status = i.ToString();
                while (player_1.status != "wait" && player_2.status != "wait")
                {

                }
                player_1.opScore = player_2.score;
                player_2.opScore = player_1.score;
                player_1.status = "sendScore";
                player_2.status = "sendScore";
                while (player_1.status != "wait" && player_2.status != "wait")
                {

                }
            } while (i < 7);
            player_1.status = "end";
            player_2.status = "end";
        }

        public void playGame()
        {
            while (true)
            {
                ThreadStart game_ref = new ThreadStart(doGame);
                Thread game_thread = new Thread(game_ref);
                game_thread.Start();
            }
            
        }

        public void launchGamingThread()
        {
            ThreadStart launch_ref = new ThreadStart(playGame);
            Thread launch_thread = new Thread(launch_ref);
            launch_thread.Start();
        }


    }
}
