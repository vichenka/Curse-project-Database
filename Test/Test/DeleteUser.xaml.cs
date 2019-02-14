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
    public partial class DeleteUser : Window
    {
        List<Models.QuestionModel> listIdQ = new List<Models.QuestionModel>();
        List<Models.ResultModel> listIdR = new List<Models.ResultModel>();
        public int IDTEST;
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        public string access = Models.MY.login;
        public List<Models.TestModel> ListTest2 = new List<Models.TestModel>();

        public DeleteUser()
        {
            try
            {
                InitializeComponent();
                showUser();
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }

        }

        private void showUser()
        {
            SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
            SqlCommand command = new SqlCommand("ListTestsSelect", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader result = command.ExecuteReader();
            List<Models.TestModel> Test = new List<Models.TestModel>();
            while (result.Read())
            {
                Models.TestModel ListTest = new Models.TestModel(
                    result["NAME_TEST"].ToString()
                    );
                Test.Add(ListTest);
            }
            list.ItemsSource = Test;
            ListTest2 = Test;
            conn.Close();
        }

        public void deleteTestByName(string name)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteTest", conn))
                {
                    conn.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }
        }

        public void DeleteQuestionByTest(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteQuestionByTest", conn))
                {
                    conn.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTest", id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }
        }

        public void DeletePointByIdQuest(List<Models.QuestionModel> list)
        {
            try
            {
                foreach (var a in list)
                {
                    using (SqlCommand cmd = new SqlCommand("DeletePointByIdQuest", conn))
                    {
                        conn.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idQ", a.idQuestion);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                }
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }
        }

        public void DeleteResultByIdTest(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DeleteResultBiIdTest", conn))
                {
                    conn.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idT", id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }
        }

        public void DeleteHistoryByIdResult(List<Models.ResultModel> list)
        {
            try
            {
                foreach (var a in list)
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteHistoryByIdResult", conn))
                    {
                        conn.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idR", a.idResult);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
               
            }
            catch (SqlException q)
            {
                MessageBox.Show(q.Message);
            }
        }

        public int getIdTestByName(string nametest)
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
     
        public void IdQuestionByIdTest(int id)
        {           
            try
            {
                SqlCommand command = new SqlCommand("IdQuestionByIdTest", conn);
                command.Parameters.AddWithValue("@idTest", IDTEST);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    Models.QuestionModel idres = new Models.QuestionModel(
                        (int)result["ID_QUESTION"]
                        );

                    listIdQ.Add(idres);

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }

        }
        
        public void IdQResultIdTest(int id)//получаем список ид результатов по ИД теста
        {
            try
            {
                SqlCommand command = new SqlCommand("IdQResultIdTest", conn);
                command.Parameters.AddWithValue("@idTest", id);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader result = command.ExecuteReader();
                while (result.Read())
                {
                    Models.ResultModel idres = new Models.ResultModel(
                        (int)result["ID_Result"]
                        );

                    listIdR.Add(idres);

                }
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
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                if (list.SelectedItems.ToString() == "") { }
                else
                {
                    string name = ListTest2[list.SelectedIndex].ToString();
                    conn.Open();
                    IDTEST = getIdTestByName(name);
                    IdQResultIdTest(IDTEST);
                    DeleteHistoryByIdResult(listIdR);//удаляем историю по ид резульата         
                    DeleteResultByIdTest(IDTEST);//удаляем список результатов
                    IdQuestionByIdTest(IDTEST);//должен быть лист!!!!! 
                    DeletePointByIdQuest(listIdQ);//удаляем список ответов по СПИСКУ ИД ВОПРОСОВ
                    DeleteQuestionByTest(IDTEST);//удаляем список вопросов
                       
                    deleteTestByName(name);                  
                   
                    Fill();
                    conn.Close();
                   // MessageBox.Show("Выполнено !!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Fill()
        {
            ListTest2.Clear();
            showUser();
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