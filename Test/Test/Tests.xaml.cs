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

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для Tests.xaml
    /// </summary>
    public partial class Tests : Window
    {
        public string access = Models.MY.login;
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        public List<Models.UserModel> Users2 = new List<Models.UserModel>();
       
        public Tests() {
            try
            {
                InitializeComponent();
                showTests();
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }
        }

        private void showTests()
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                SqlCommand command = new SqlCommand("ListTestsSelect", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader result = command.ExecuteReader();
                List<Models.UserModel> Tests = new List<Models.UserModel>();
                while (result.Read())
                {
                    Models.UserModel test = new Models.UserModel(
                        result["NAME_TEST"].ToString()
                        );
                    Tests.Add(test);
                }
                list.ItemsSource = Tests;
                Users2 = Tests;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int GetIdT(string nametest)
        {
            try
            {
                string stringid = "select KP.dbo.IdTest('" + nametest + "');";
                conn.Open();
                SqlCommand command_id = new SqlCommand(stringid, conn);
                int id = Convert.ToInt32(command_id.ExecuteScalar());
                conn.Close();
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                if (list.SelectedItems.ToString() == "") { }
                else
                { 
                    conn.Open();
                   // int i = GetIdT(list.SelectedItem.ToString());                   
                    int ind = GetIdT(list.SelectedItem.ToString());
                    UserTest t = new UserTest(ind);
                    t.Show();
                    conn.Close();
                    this.Close();
                  //  showTests();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        #region Navig
             
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown_one(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Image_MouseLeftButtonDown_two(object sender, MouseButtonEventArgs e)
        {
            if (access == "admin")
            {
                MenuAdmin a = new MenuAdmin();
                a.Show();
                this.Close();
            }
            else
            {
                Menu m = new Menu();
                m.Show();
                this.Close();
            }
        }
    }
    #endregion
}
