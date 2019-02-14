using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace Test
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
      
        public Login()
        {
            InitializeComponent();           
        }

        #region navig
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown_one(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        private void ButtomReg_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtomLog_Click(object sender, RoutedEventArgs e)
        {
            string sqlExpression = "select dbo.AutoValid('" + login.Text + "', '" + passwordBox.Password + "');";
            string take_access = " select dbo.Take_Access('" + login.Text + "');";
            using (SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString))
            {
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                conn.Open();
                Int32 number = Convert.ToInt32(command.ExecuteScalar());
                if (number == 0)
                {
                    MessageBox.Show("invalid Data");
                    login.Clear();
                    passwordBox.Clear();
                }
                else if (number == 1)
                {
                    SqlCommand take_id_ = new SqlCommand(take_access, conn);
                    Int32 id = Convert.ToInt32(take_id_.ExecuteScalar());
                    SqlConnection conn1 = new SqlConnection(SqlConn.CurrentConnectionString);
                   // SqlConnection conn2 = new SqlConnection(SqlConn.CurrentConnectionString);
                     SqlConnection conn2 = new SqlConnection(SqlConn.UserConnectionString);
                    if (id == 1)
                    {
                        SqlCommand comm = new SqlCommand(sqlExpression, conn1);
                        int number1 = command.ExecuteNonQuery();
                       // MessageBox.Show("Complete");
                        Models.MY.login = login.Text;
                        MenuAdmin MenuAdmin = new MenuAdmin();
                        MenuAdmin.Show();
                        this.Close();
                    }
                    else
                    {
                        SqlCommand comm = new SqlCommand(sqlExpression, conn2);
                        int number2 = command.ExecuteNonQuery();
                       // MessageBox.Show("Complete");
                        Models.MY.login = login.Text;
                        Menu Menu = new Menu();
                        Menu.Show();
                        this.Close();
                    }
                }
            }

        }
    }
}
    

