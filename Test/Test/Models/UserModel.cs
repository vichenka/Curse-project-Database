using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public static class MY
    {
        public static string login;
    }

    public class UserModel
    {
        public int access { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UserModel() { }
        public  UserModel(int access, string Login, string Password)
        {
            this.access = access;
            this.Login = Login;
            MY.login = Login;
            this.Password = Password;
        }
        public UserModel(string Login)
        {
            this.Login = Login; 
        }
        public override string ToString()
        {          
            return Login;
        }
    }
   
}
