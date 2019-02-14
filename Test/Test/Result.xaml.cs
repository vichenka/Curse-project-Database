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
    public partial class Result : Window
    {
        SqlConnection conn = new SqlConnection(SqlConn.ConnectionString.defaultString);
        TextBox txt;
        SolidColorBrush Mcolor = new SolidColorBrush();
        SolidColorBrush Mcolor1 = new SolidColorBrush();
        SolidColorBrush Mcolor2 = new SolidColorBrush();
        public int idT = Models.MT.idTest;       
        string user = Models.MY.login;
        public Result()
        {
            InitializeComponent();
        }
        public Result(string restext)
        {
            InitializeComponent();
            txt = (TextBox)FindName("text");
            Mcolor = (SolidColorBrush)(new BrushConverter().ConvertFrom("Black"));
            Mcolor1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#951ba3"));
            Mcolor2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("White"));
            Fill(restext);
            addHistory();
        }
        public void Fill (string s)
        {
            txt.Text = s;
        }
         
        public int GetTypeT() //получить ид результата по идтеста и тексту
        {
            try
            {
                string stringid = "select KP.dbo.GetIdTypeByIdTest('" + idT + "');";
                conn.Open();
                SqlCommand command = new SqlCommand(stringid, conn);
                int t = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                return t;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public int ResultId() //получить ид результата по идтеста и тексту
        {
            try
            {
                string stringid = "select KP.dbo.ResultidByText('" + text.Text + "', '" + idT + "');";
                conn.Open();
                SqlCommand command = new SqlCommand(stringid, conn);
                int idR = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                return idR;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        

        private void addHistory()
        {
            try
            {
                int idR = ResultId();
                int idType = GetTypeT();
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("AddNewHistory", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@resultId", idR);
                    cmd.Parameters.AddWithValue("@typeId", idType);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
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
                Tests a = new Tests();
                a.Show(); 
                this.Close(); 
        }
        #endregion

        #region methods_Mouse
        private void text_MouseMove(object sender, MouseEventArgs e)
        {
            txt.Foreground = Mcolor1;
        }
        private void text_MouseLeave(object sender, MouseEventArgs e)
        {
            txt.Foreground = Mcolor2;
        }
        #endregion
    }
}
