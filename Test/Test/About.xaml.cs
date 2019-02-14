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
    /// Логика взаимодействия для About.xaml
    /// </summary>
    public partial class About : Window
    {
        public string access = Models.MY.login;
        TextBox txt;
        SolidColorBrush Mcolor1 = new SolidColorBrush();

        public About()
        {
            InitializeComponent();
            txt = (TextBox)FindName("text");
            Mcolor1 = (SolidColorBrush)(new BrushConverter().ConvertFrom("#841591"));
        }

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

        private void text_MouseMove(object sender, MouseEventArgs e)
        {
            txt.Foreground = Mcolor1;
        }

        private void text_MouseLeave(object sender, MouseEventArgs e)
        {
            txt.Foreground = Mcolor1;
        }

      


    }
}
