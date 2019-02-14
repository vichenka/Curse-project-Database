using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public static class MQ
    {
        public static int idT;
        public static string q;
    }

    public class QuestionModel
    {
        public int idQuestion { get; set; }
        public int idTest { get; set; }
        public string question { get; set; }

        public QuestionModel() { }
        public QuestionModel(int idQuestion, int idTest, string question)
        {
            this.idQuestion = idQuestion;
            this.idTest = idTest;
            MQ.idT = idTest;
            MQ.q = question;
            this.question = question;
        }

        public QuestionModel(int idQuestion)
        {           
            this.idQuestion = idQuestion;           
        }
        //public QuestionModel(int idTest)
        //{
        //    this.idTest = idTest;
        //}

        public override string ToString()
        { 
            return this.question;
        }

    }
}
