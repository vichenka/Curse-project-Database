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
    /// Логика взаимодействия для DeleteUser.xaml
    /// </summary>
    public partial class Search : Window
    { 
        public List<Models.TestModel> Tests = new List<Models.TestModel>();
        public List<Models.TestModel> Tests2 = new List<Models.TestModel>();
        public string access = Models.MY.login;
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
       
        public Search()
        {
            try
            {
                InitializeComponent();               
            } 
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }

        }         

    public void SearchTest() /////////////////////////////////////////////////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        { 
                try
                {
               
                SqlCommand command = new SqlCommand("SearchTestByName", conn);
                //WHERE CONTAINS (Comments, 'FORMSOF(INFLECTIONAL, "foot")'  )   "\""
                //string s = "'FORMSOF(INFLECTIONAL," + name.Text+ ")'";
                command.Parameters.AddWithValue("@name",name.Text);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader result = command.ExecuteReader();               
                while (result.Read())
                {
                    Models.TestModel test = new Models.TestModel(
                        result["NAME_TEST"].ToString()
                        );                          
                    Tests.Add(test);
                  
                }
                
                if (Tests.Count > 0) {
                    list.ItemsSource = Tests;

                   // Tests2 = Tests;
                }
                else { MessageBox.Show("Совпадений не найдено"); }
                conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);               
                }
        }

        private void ButtomLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text == "") { MessageBox.Show("Введите название теста"); }
                else
                {
                   
                    SearchTest();
                    name.Clear();       
                } 
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
                if (list.SelectedItems.ToString() == "")
                {
                    MessageBox.Show("Выберите тест");
                    name.Clear();
                }
                else
                {
                    conn.Open();                    
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

    private void Image_MouseLeftButtonDown_one(object sender, MouseButtonEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        this.Close();
    }

        #endregion
    }

}