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
//ДОБВИТЬ РЕЗУЛЬТАТ,ИСТОРИЮ,УДАЛЕНИЕ ЮЗЕРА ВМЕСТЕ С ТЕСТОМ
namespace Test
{
    /// <summary>
    /// Логика взаимодействия для UserTest.xaml
    /// </summary>
    public partial class UserTest : Window
    {
        public string access = Models.MY.login;
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        static public int index;       
        public int resultAll = 0;
        public int count;//кол-во вопросов
        public int idT,idQ;//IdTesta
        public int rall;
        public int idTQ;
        public UserTest(int i)
        {
            InitializeComponent();
            idT = i;
            count = NumberQuest();
            GetIdQ();
            Models.MT.idTest = i;
            FillAll();          
        } 

        public void GetIdQ() //по IDTest надо получить IdQuestion
        {
            try
            {
                string stringid = "select KP.dbo.IdQuestionforCreateTest('" + idT + "');";
                conn.Open();
                SqlCommand command_id = new SqlCommand(stringid, conn);
                idQ = Convert.ToInt32(command_id.ExecuteScalar()); 
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void QuestionFill(int tt) //по IDQuest надо получить Quest 
        {
            try
            {
                string stringid = "select KP.dbo.GetQuestionById('" + (idQ+tt) + "');";
                conn.Open();
                SqlCommand command = new SqlCommand(stringid, conn);
                string quest = Convert.ToString(command.ExecuteScalar());
               // Models.MQ.q = quest;
                q.Content = quest;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int NumberQuest() //по IdT получить кол-во вопросов
        {
            try
            {
                string stringid = "select KP.dbo.NumberQuest('" + idT + "');";//передача ид из другого xaml
                conn.Open();
                SqlCommand command = new SqlCommand(stringid, conn);
               int col = Convert.ToInt32(command.ExecuteScalar());
                // Models.MQ.q = quest;
                 conn.Close();
                return col;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int Ball() //получить балл за ответ
        {
            idTQ = QuestionId();
            int b = 0;
            bool flag = false;
            try
            {
                for (int y = 1; y <= 3; y++)
                {
                    RadioButton rb = (RadioButton)FindName("rb" + y);
                    if ((bool)rb.IsChecked && flag == false)
                    {                       
                        string stringid = "select KP.dbo.Ball('" + rb.Content + "', '" + idTQ + "');";             
                        conn.Open();
                        SqlCommand command = new SqlCommand(stringid, conn);
                        int ball = Convert.ToInt32(command.ExecuteScalar());
                        b = ball;
                        conn.Close();
                        flag = true;
                        return b; 
                    }                 
                }
               
                return b;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int QuestionId() //получить ид вопроса по идтеста и тексту
        {           
            try
            {
                string stringid = "select KP.dbo.QuestionidByText('" + q.Content + "', '" + idT + "');";
                conn.Open();
                SqlCommand command = new SqlCommand(stringid, conn);
                int idTQ = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                return idTQ;
            }
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public string GetResult () //получить результат по idTest и баллу
        {
            try
            {
                string stringid = "select KP.dbo.ShowResult('" + rall + "', '" + idT + "');";
                conn.Open();
                SqlCommand command = new SqlCommand(stringid, conn);
                string result = Convert.ToString(command.ExecuteScalar());
                conn.Close();
                return result;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public void AnsverSelectListByIdQuest(int tt) //по IDQuest надо получить все ответы 
        {
            List<Models.PointModel> list = new List<Models.PointModel>();

            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
                conn.Open();
                SqlCommand command = new SqlCommand("AnsverSelectListByIdQuest", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@QuestId", (idQ+tt));
                command.ExecuteNonQuery();
                SqlDataReader result = command.ExecuteReader();
                while (result.Read())
                {
                    Models.PointModel answ = new Models.PointModel(
                     result["ANSWER"].ToString()
                     );
                    list.Add(answ);

                }

                int i = 1;               
                    foreach (Models.PointModel aa in list)
                    {
                        RadioButton p = (RadioButton)FindName("rb" + i);
                        p.Content = aa.answer;
                        i++;                    
                    }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FillAll()
        {                                          
           
            try
            {
                if (t < count)
                {
                    AnsverSelectListByIdQuest(t);
                    QuestionFill(t);
                    t++;
                }
                else
                {
                   string textresult= GetResult();
                    Result r = new Result(textresult);
                    r.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }
                 
        public int t = 0;//индекс вопроса
        private void ButtomLog_Click(object sender, RoutedEventArgs e)
        { 
                    int res = Ball(); 
                    rall =rall +res;
                    FillAll(); 
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
        #endregion
 
    }
}
