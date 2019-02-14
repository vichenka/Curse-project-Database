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
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class History : Window
    {
        List<Models.ResultModel> Id = new List<Models.ResultModel>();
        List<Models.ResultModel> listIdRes = new List<Models.ResultModel>();
        List<Models.TestModel> NameT = new List<Models.TestModel>();
        string user = Models.MY.login;
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);

        public History()
        {
            InitializeComponent();            
            FillList(user);
        }
        public void FillList (string user)
        {
            SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
            SqlCommand command = new SqlCommand("GetIdResultByLogin", conn);
            command.Parameters.AddWithValue("@login", user);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader result = command.ExecuteReader();
            
            while (result.Read())
            {
                Models.ResultModel idres = new Models.ResultModel(
                    (int)result["ID_RESULTH"]
                    );              

                Id.Add(idres);

            }
        //    list.ItemsSource = Id;           
            conn.Close();
            GetTestId();
            GetNameTest();
        }

        public void GetTestId() //получить ид тетса по ид резульатта
        {
            try
            {
               
                foreach (var a in Id)
                {
                    SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                    SqlCommand command = new SqlCommand("IdTestByIdRes", conn);
                    command.Parameters.AddWithValue("@idR", a.idResult);
                    command.CommandType = System.Data.CommandType.StoredProcedure; 
                    conn.Open();
                    SqlDataReader result = command.ExecuteReader();

                    while (result.Read())
                    {
                        a.idTest = (int)result["ID_Test"];                        
                         
                    }
                    conn.Close();
                }              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        public void GetNameTest() //получить имя по ид теста
        {
            try
            {
               
                foreach (var a in Id)
                {
                    SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                    SqlCommand command = new SqlCommand("GetNameTestByIdTest", conn);
                    command.Parameters.AddWithValue("@idT", a.idTest);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader result = command.ExecuteReader();

                    while (result.Read())
                    {
                        Models.TestModel name = new Models.TestModel(
                            result["NAME_TEST"].ToString()
                            );

                        NameT.Add(name);

                    }
                    conn.Close();
                }
                list.ItemsSource = NameT;
                
            }
            

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        //ПО ИДРЕЗУЛЬТАТА ПОЛУЧИТЬ РЕЗУЛЬТАТ
        public string GetTextRes(int idR)
        {
            try
            {
                string stringid = "select KP.dbo.GetTextRes('" + idR + "');";
                conn.Open();
                SqlCommand command_id = new SqlCommand(stringid, conn);
                string text = Convert.ToString(command_id.ExecuteScalar());
                conn.Close();
                return text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
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

        public void IdResbyTdTest(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                SqlCommand command = new SqlCommand("IdResbyTdTest", conn);
                command.Parameters.AddWithValue("@idT",id);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    Models.ResultModel idres = new Models.ResultModel(
                        (int)result["ID_Result"]
                        );

                    listIdRes.Add(idres);

                }                   
                conn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }

        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string r = NameT[list.SelectedIndex].nameTest;
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
              //  string r = (list.SelectedItems).ToString2();
                if (r == "") { }
                else
                {
                    conn.Open();
                    //получитидтеста по названию теста+
                    //нацти все ид результута этого теста+
                    //найти ид рез  в хистори табл и если да то вывести его
                    int IdTest = GetIdT(r);
                    IdResbyTdTest(IdTest);
                    int flag = 0;//нашли или нет нужный ид
                    foreach (var a in listIdRes)
                    {
                        foreach(var b in Id)
                        {
                            if (b.idResult==(a.idResult))
                            {
                                flag = a.idResult;
                                break;
                            }
                        }
                        
                    }
                    if (flag!=0)
                    {
                    string txt = GetTextRes(flag);
                    HistoryText t = new HistoryText(txt,IdTest);
                    t.Show();
                    conn.Close();
                    this.Close();
                    }
                    
                    //  showTests();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void Image_MouseLeftButtonDown_two(object sender, MouseButtonEventArgs e)
        { 
                Menu a = new Menu();
                a.Show(); 
                this.Close(); 
        }

        #endregion

       
    }
}
