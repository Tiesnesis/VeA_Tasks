using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuAPP
{
    [Serializable]
    class questionObject3answ : questionsObject
    {
        string answerA;
        string answerB;
        string answerC;
        int correctIndex;
        public int acccorrectIndex
        {
            get { return correctIndex; }
            set { correctIndex = value; }
        }
        public string accanswerC
        {
            get { return answerC; }
            set { answerC = value; }
        }

        public string accanswerB
        {
            get { return answerB; }
            set { answerB = value; }
        }

        public string accanswerA
        {
            get { return answerA; }
            set { answerA = value; }
        }
        string questionName;

        public string accName
        {
            get { return questionName; }
            set { questionName = value; }
        }
        public questionObject3answ(string qName, string aA, string aB, string aC, int cA)
        {
            questionName = qName;
            answerA = aA;
            answerB = aB;
            answerC = aC;
            correctIndex = cA;
        }
        public override string ToString()
        {
            return accName;
        }
    }
}
