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
    /// Логика взаимодействия для CreateTest.xaml
    /// </summary>
    public partial class CreateTest : Window
    {
        public int idt;
        public string access = Models.MY.login;
        int e1 = -100;
        int e2 = -10;
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
     //ВАЛИДАЦИЯ НА РЕЗУЛЬТАТ
        public CreateTest()
        {
            InitializeComponent();
        }      
      
        private void Button2_Click(object sender, RoutedEventArgs e)//Создать тест
        {
            try
            {                
                string author = Models.MY.login;
                if (name.Text.Length == 0 || comboBox.Text.CompareTo("") == 0)
                {
                    MessageBox.Show("Введите название и тип теста");
                }
                else
                {
                    string isEmpty = "select KP.dbo.IfEmptyNameTest('" + name.Text + "');";
                    conn.Open();
                    SqlCommand command_is_empty = new SqlCommand(isEmpty, conn);
                    int is_empty = Convert.ToInt32(command_is_empty.ExecuteScalar());
                    if (is_empty == 0)
                    {
                        switch (comboBox.SelectedIndex)
                        {
                            case 0:
                                CreateT(name.Text, author, 1);                               
                                Models.MT.type = 1;
                                break;
                            case 1:
                                CreateT(name.Text, author, 2);                               
                                Models.MT.type = 2;
                                break;
                        }
                       

                        MessageBox.Show("Выполнено !!!");
                    }
                    else if (is_empty == 1)
                    {
                        MessageBox.Show("This name is used by onather test");
                        conn.Close();
                        name.Clear();
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button1_Click(object sender, RoutedEventArgs e)//Добавить вопрос
        {
            try
            {
              
                GetIdT(name.Text);
                int idt = Models.MQ.idT;
                CreateQ(idt, q1.Text);
                GetIdQ(Models.MQ.idT);                
                int idq = Models.MP.idQ;
                if (q1.Text.Length == 0 || t1.Text.Length == 0 || t2.Text.Length == 0|| t3.Text.Length == 0 || a1.Text.Length == 0 || a2.Text.Length == 0 || a3.Text.Length == 0 )
                {
                    MessageBox.Show("Заполните все поля вопроса");
                }
                else
                {  
                        for (int j = 1; j <= 3; j++)
                        {
                            TextBox p = (TextBox)FindName("t" + j);
                            TextBox b = (TextBox)FindName("a" + j);
                            CreateA(idq, p.Text, Convert.ToInt32(b.Text));//создание вариантов ответов и баллов за них  
                        }
                    
                   // MessageBox.Show("Выполнено !!!");
                    #region clear
                    q1.Clear();
                    t1.Clear();
                    t2.Clear();
                    t3.Clear();
                    a1.Clear();
                    a2.Clear();
                    a3.Clear();
                    #endregion
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)//Добавить результат
        {

            try
            {
                if (txtresult.Text == "" || i1.Text == "" || i2.Text == "")
                {
                    MessageBox.Show("Not all fields are filled!");
                }
                else
                {
                    e1 = Convert.ToInt32(i1.Text);
                    if (e2 == -10)
                    {
                        GetIdT(name.Text);
                        idt = Models.MQ.idT;
                        CreateR(idt, Convert.ToInt32(i1.Text), Convert.ToInt32(i2.Text), txtresult.Text);
                        e2 = Convert.ToInt32(i2.Text);
                      //  MessageBox.Show("Выполнено !!!");
                        #region clear
                        txtresult.Clear();
                        i1.Clear();
                        i2.Clear();
                        #endregion
                    }
                    else
                    {
                        if (e1 != e2 + 1)
                        {
                            MessageBox.Show("input correct result's point");
                            #region clear
                            txtresult.Clear();
                            i1.Clear();
                            i2.Clear();
                            #endregion
                        }
                        else
                        {
                            GetIdT(name.Text);
                            int idt = Models.MQ.idT;
                            CreateR(idt, Convert.ToInt32(i1.Text), Convert.ToInt32(i2.Text), txtresult.Text);
                           // MessageBox.Show("Выполнено !!!");
                            #region clear
                            txtresult.Clear();
                            i1.Clear();
                            i2.Clear();
                            #endregion
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        public void CreateA(int questid, string answ, int point)
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("AddNewPoint", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idQuestion", questid);
                cmd.Parameters.AddWithValue("@answer", answ);
                cmd.Parameters.AddWithValue("@point", point);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CreateR(int testid,int r1, int r2, string text)
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("AddNewResult", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@testid", testid);
                cmd.Parameters.AddWithValue("@result1", r1);
                cmd.Parameters.AddWithValue("@result2", r2);
                cmd.Parameters.AddWithValue("@textResult", text);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CreateQ (int testid,string q)
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("AddNewQuestion", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@testid", testid);
                cmd.Parameters.AddWithValue("@question", q);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void CreateT(string nametest, string authr, int idtype)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("TestCreate", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nameTest", name.Text);
                    cmd.Parameters.AddWithValue("@author", authr);
                    cmd.Parameters.AddWithValue("@idType", idtype);
                    cmd.ExecuteNonQuery(); 
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetIdT(string nametest)
        {           
            try
            {               
                string stringid = "select KP.dbo.IdTest('" + nametest + "');";                
                conn.Open();
                SqlCommand command_id = new SqlCommand(stringid, conn);
                int id = Convert.ToInt32(command_id.ExecuteScalar());
                Models.MQ.idT= id;               
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void GetIdQ(int idTest) //по IDTest надо получить IdQuestion
        {
            try
            {
                string stringid = "select KP.dbo.IdQuestion('" + idTest + "');";
                conn.Open();
                SqlCommand command_id = new SqlCommand(stringid, conn);
                int id = Convert.ToInt32(command_id.ExecuteScalar());
                Models.MP.idQ = id;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button3_Click(object sender, RoutedEventArgs e)//Finish
        {
            try
            {
                string isEmpty = "select KP.dbo.QuestionByTestEmpty('" + idt+ "');";
                conn.Open();
                SqlCommand command_is_empty = new SqlCommand(isEmpty, conn);
                int is_empty = Convert.ToInt32(command_is_empty.ExecuteScalar());
                if (is_empty == 0)
                { MessageBox.Show("Добавьте вопрос или результат");
                   conn.Close();
                }
                else if (is_empty ==1)
                { 
                    MessageBox.Show("Test created!!!");
                    Menu a = new Menu();
                    a.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #region valid
        private void a11_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }
        #endregion

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
        #endregion        
    }
}
