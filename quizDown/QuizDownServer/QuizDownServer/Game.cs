using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Network;
using System.Net.Sockets;
using System.Net;

namespace QuizDownServer
{
    class Game
    {

        TcpListener myList;


        private List<Question> selectQuestions()
        {
            //List<Question> questions = new List<Question>();
            //Random rnd = new Random();
            //Database temp_connection = new Database();
            //List<Question> temp_list = temp_connection.Select();
            //while( questions.Count <= 7)
            //{
            //    int index =  rnd.Next(0, temp_list.Count - 1 );
            //    questions.Add(temp_list.ElementAt(index));
            //    temp_list.RemoveAt(index);
            //}
            List<Question> sample = new List<Question>();
            sample.Add(new Question("Question1", "Correct", "Wrong1", "Wrong2", "Wrong3"));
            sample.Add(new Question("Question2", "Correct", "Wrong1", "Wrong2", "Wrong3"));
            sample.Add(new Question("Question3", "Correct", "Wrong1", "Wrong2", "Wrong3"));
            sample.Add(new Question("Question3", "Correct", "Wrong1", "Wrong2", "Wrong3"));
            sample.Add(new Question("Question3", "Correct", "Wrong1", "Wrong2", "Wrong3"));
            sample.Add(new Question("Question3", "Correct", "Wrong1", "Wrong2", "Wrong3"));


            return sample;
        }

        public void startServerConenction()
        {
            IPAddress ipAd = IPAddress.Parse("127.0.0.1");
            // use local m/c IP address, and 
            // use the same in the client

            /* Initializes the Listener */
            myList = new TcpListener(ipAd, 8001);
            myList.Start();
            Console.WriteLine("Listener started");
        }

        private void doGame()
        {
            List<Question> questions = selectQuestions();

            Player player_1 = new Player(myList.AcceptSocket(), questions);
            Player player_2 = new Player(myList.AcceptSocket(), questions);
            player_1.status = "sendQuestions";
            player_2.status = "sendQuestions";
            player_1.playGame();
            player_2.playGame();
            while (player_1.status != "wait" || player_2.status != "wait")
            {

            }
            int i = 0;
            do
            {

                Console.WriteLine("Player 1 score" + player_1.score);
                Console.WriteLine("Player 2 score" + player_2.score);
                Console.WriteLine("Player 1 score" + player_1.opScore);
                Console.WriteLine("Player 2 score" + player_2.opScore);

                i++;
                player_1.status = i.ToString();
                player_2.status = i.ToString();
                while (player_1.status != "wait" || player_2.status != "wait")
                {

                }
                player_1.opScore = player_2.score;
                player_2.opScore = player_1.score;
                player_1.status = "sendScore";
                player_2.status = "sendScore";
                while (player_1.status != "wait" || player_2.status != "wait")
                {

                }
            } while (i < 7);
            player_1.status = "end";
            player_2.status = "end";
        }

        public void playGame()
        {
            // while (true)
            //{
                ThreadStart game_ref = new ThreadStart(doGame);
                Thread game_thread = new Thread(game_ref);
                game_thread.Start();
            //}
            
        }

        public void launchGamingThread()
        {
            ThreadStart launch_ref = new ThreadStart(playGame);
            Thread launch_thread = new Thread(launch_ref);
            launch_thread.Start();
        }


    }
}
