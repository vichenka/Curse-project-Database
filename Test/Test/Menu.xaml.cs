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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Label l1,l2,l3,l4,l5,l6,l7,l8,l9;
        TextBox txt;
        SolidColorBrush Mcolor = new SolidColorBrush();
        SolidColorBrush Mcolor1 = new SolidColorBrush();
        SolidColorBrush Mcolor2 = new SolidColorBrush();
      
       
        public Menu()
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
            l9 = (Label)FindName("label9");
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
        private void label9_MouseMove(object sender, MouseEventArgs e)
        {
            l9.Foreground = Mcolor;
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
        private void label9_MouseLeave(object sender, MouseEventArgs e)
        {
            l9.Foreground = Mcolor2;
        }
        #endregion MouseLeave

        #region MouseLeftButtonDown

        private void Label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                 }

        private void label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
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

        private void label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void label6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            About a = new About();
            a.Show();
            this.Close();
        }

        private void label7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }
        
        private void label8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Search s = new Search();
            s.Show();
            this.Close();

            }
            private void label9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            History a = new History();
            a.Show();//имя теста и результат
            this.Close();

        }
        #endregion MouseLeftButtonDown


        #region Navig

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown_one(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

       
    }
}
