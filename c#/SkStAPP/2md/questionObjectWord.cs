using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2md
{
    [Serializable]
    class questionObjectWord : questionsObject
    {
        string answerString;

        public string accanswerString
        {
            get { return answerString; }
            set { answerString = value; }
        }
        string questionName;

        public string accName
        {
            get { return questionName; }
            set { questionName = value; }
        }
        public questionObjectWord(string qName, string aString)
        {
            questionName = qName;
            answerString = aString;
        }
        public override string ToString()
        {
            return accName;
        }
    }
}
