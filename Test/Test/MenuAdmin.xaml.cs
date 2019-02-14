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

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        Label l1;
        Label l2;
        Label l3;
        Label l4;
        Label l5;
        Label l6;
        Label l7;
        Label l8;
        TextBox txt;
        SolidColorBrush Mcolor = new SolidColorBrush();
        SolidColorBrush Mcolor1 = new SolidColorBrush();
        SolidColorBrush Mcolor2 = new SolidColorBrush();


        public MenuAdmin()
        {
            InitializeComponent();
            #region FindNme
            l1 = (Label)FindName("label1");
            l2 = (Label)FindName("label2");
            l3 = (Label)FindName("label3");
            l4 = (Label)FindName("label4");
            l5 = (Label)FindName("label5");
            l6 = (Label)FindName("label6");
            l7 = (Label)FindName("label7");
            l8 = (Label)FindName("label8");
            txt = (TextBox)FindName("text");
            #endregion
            Mcolor = (SolidColorBrush)(new BrushConverter().ConvertFrom("Black"));
            Mcolor1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#951ba3"));
            Mcolor2 = (SolidColorBrush)(new BrushConverter().ConvertFrom("White"));
        }

        #region methods_MouseMove
        private void text_MouseMove(object sender, MouseEventArgs e)
        {
            txt.Foreground = Mcolor1;
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            l1.Foreground = Mcolor;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            l2.Foreground = Mcolor;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            l3.Foreground = Mcolor;
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            l4.Foreground = Mcolor;
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            l5.Foreground = Mcolor;
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            l6.Foreground = Mcolor;
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            l7.Foreground = Mcolor;
        }

        private void label8_MouseMove(object sender, MouseEventArgs e)
        {
            l8.Foreground = Mcolor;
        }
        #endregion methods_MouseMove

        #region MouseLeave

        private void text_MouseLeave(object sender, MouseEventArgs e)
        {
            txt.Foreground = Mcolor2;
        }
        private void label1_MouseLeave(object sender, MouseEventArgs e)
        {
            l1.Foreground = Mcolor2;
        }

        private void label2_MouseLeave(object sender, MouseEventArgs e)
        {
            l2.Foreground = Mcolor2;
        }

        private void label3_MouseLeave(object sender, MouseEventArgs e)
        {
            l3.Foreground = Mcolor2;
        }

        private void label4_MouseLeave(object sender, MouseEventArgs e)
        {
            l4.Foreground = Mcolor2;
        }
        private void label5_MouseLeave(object sender, MouseEventArgs e)
        {
            l5.Foreground = Mcolor2;
        }
        private void label6_MouseLeave(object sender, MouseEventArgs e)
        {
            l6.Foreground = Mcolor2;
        }
        private void label7_MouseLeave(object sender, MouseEventArgs e)
        {
            l7.Foreground = Mcolor2;
        }

        private void label8_MouseLeave(object sender, MouseEventArgs e)
        {
            l8.Foreground = Mcolor2;
        }
        #endregion MouseLeave

        #region MouseLeftButtonDown

        private void Label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MainWindow Menu = new MainWindow();
            //Menu.Show();
            //this.Close();
        }

        private void label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //пройти готовый тест
            Tests t = new Tests();
            t.Show();
            this.Close();
        }

        private void label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CreateTest c = new CreateTest();
            c.Show();
            this.Close();
        }

       
        private void label5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //удалить юзера
            DeleteUser d = new DeleteUser();
            d.Show();
            this.Close();
        }

      
        private void label7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(" Test\n© Savenko Anna POIT 6, 2018. \n Have a nice day.\n", "About ");
            About a = new About();
            a.Show();
            this.Close();

        }
        #endregion MouseLeftButtonDown




        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown_one(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void label8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }
    }
}
