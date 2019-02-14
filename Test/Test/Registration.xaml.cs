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
using System.Data;
using System.Data.SqlClient;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void ButtomReg_Click(object sender, RoutedEventArgs e)
        {
            if ((textBox.Text).Length > 2 && (textBox.Text).Length < 20 && login.Text != "")
            {
                SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.Constr);
                try
                {
                    string sqlExpression = @"exec KP.dbo.InsertUser
                @login='" + login.Text + "',@password ='" + passwordBox.Password + "',@access='2';";
                    string isEmpty = "select KP.dbo.IfEmpty('" + login.Text + "');";
                    using (SqlConnection connection = new SqlConnection(SqlConn.CurrentConnectionString))
                    {
                        connection.Open();
                        SqlCommand command_is_empty = new SqlCommand(isEmpty, connection);
                        int is_empty = Convert.ToInt32(command_is_empty.ExecuteScalar());
                        if (is_empty == 0)
                        {

                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            int number = command.ExecuteNonQuery();
                            MessageBox.Show("Complete");
                            Login Menu = new Login();
                            Menu.Show();
                            this.Close();

                        }
                        else if (is_empty == 1)
                        {
                            MessageBox.Show("This name is used by onather user");
                            login.Clear();
                        }

                    }
 
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }
            }
            else {
                try
                {
                    MessageBox.Show("Password langht should be < 20 and > 2 and login can not be empty");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //sqlCon.Close();
                }
            }

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

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion
    }
}
