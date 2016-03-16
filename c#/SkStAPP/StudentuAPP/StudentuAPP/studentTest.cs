using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuAPP
{
    [Serializable]
    public class studentTest
    {
        List<questionsObject> questionsList;
        bool randomize;
        int number;
        DateTime testDate;
        string category;

        public List<questionsObject> accQuestionsList
        {
            get { return questionsList; }
            set { questionsList = value; }
        }

        public bool accRandomize
        {
            get { return randomize; }
            set { randomize = value; }
        }


        public int accNumber
        {
            get { return number; }
            set { number = value; }
        }

        public DateTime accTestDate
        {
            get { return testDate; }
            set { testDate = value; }
        }

        public string accCategory
        {
            get { return category; }
            set { category = value; }
        }

        public studentTest(List<questionsObject> qList, bool random, int num, DateTime tDate, string cat)
        {
            accQuestionsList = qList;
            accRandomize = random;
            accNumber = num;
            accTestDate = tDate;
            accCategory = cat;
        }
    }
}
