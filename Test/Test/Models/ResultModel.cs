using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public static class MR
    {
        public static int idT;
    }
    public class ResultModel
    {
        public int idResult { get; set; }
        public int idTest { get; set; }
        public string textResult { get; set; }
        public int result1 { get; set; }
        public int result2 { get; set; }

        public ResultModel() { }

        public ResultModel(int idResult) {
            this.idResult = idResult;
        }

        public ResultModel(int idResult, int idTest,string textResult, int result1, int result2 )
        {
            this.idResult = idResult;
            this.idTest = idTest;
            this.textResult = textResult;
            MR.idT = idTest;
            this.result1 = result1;
            this.result2 = result2;
        }
        
        public override string ToString()
        {
            return textResult;
        }

      

    }
}
