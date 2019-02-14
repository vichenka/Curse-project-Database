using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public static class MT
    {
        public static int idTest;
        public static int type;
    }
    public class TestModel
    {
       public int id { get; set; }
        public string nameTest { get; set; }
        public string author { get; set; }
        public int idType { get; set; }


        public TestModel() { }
        public TestModel(string nameTest) {
            this.nameTest = nameTest;
        }
        public TestModel(int id)
        {
            this.id = id;
        }
        public TestModel(int id, string nameTest, string author, int idType)
        {
            this.id = id;
            this.nameTest = nameTest;
            this.author = author;
            this.idType = idType;
            MT.idTest = id;
            MT.type = idType;
        }

        public override string ToString()
        {
            return nameTest;
        }

        public string ToString2()
        {
            return nameTest;
        }
    }
}
