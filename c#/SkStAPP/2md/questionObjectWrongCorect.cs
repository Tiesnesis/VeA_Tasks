using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2md
{
    [Serializable]
    class questionObjectWrongCorect : questionsObject
    {
        string questionName;

        public string accName
        {
            get { return questionName; }
            set { questionName = value; }
        }
        bool correctAnswer;

        public bool acccorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }
        public questionObjectWrongCorect(string qName, bool cAnsw)
        {
            questionName = qName;
            correctAnswer = cAnsw;
        }
        public override string ToString()
        {
            return accName;
        }
    }
}
