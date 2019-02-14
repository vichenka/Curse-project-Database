using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public static class MP
    {
        public static int idQ;
    }
    public class PointModel
    {
        public int idAnswer { get; set; }
        public int idQuest { get; set; }
        public string answer { get; set; }
        public int point { get; set; }

        public PointModel() { }
        public PointModel(int idAnswer, int idQuest, string answer, int point)
        {
            this.idAnswer = idAnswer;
            this.idQuest = idQuest;
            this.answer = answer;
            this.point = point;
        }
        public PointModel(string answer)
        {
            this.answer= answer;
        }
        public override string ToString()
        {
            return this.answer;
        }

    }
}
