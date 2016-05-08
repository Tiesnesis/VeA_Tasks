using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDownServer
{
    class Game
    {
        Player player_1;
        Player player_2;
        List<Question> questions;
        int currentQuestion;

        public void selectQuestions()
        {
            Random rnd = new Random();
            Database temp_connection = new Database();
            List<Question> temp_list = temp_connection.Select();
            while( questions.Count <= 7)
            {
                int index =  rnd.Next(0, temp_list.Count);
                questions.Add(temp_list.ElementAt(index));
                temp_list.RemoveAt(index);
            }

        }
    }
}
