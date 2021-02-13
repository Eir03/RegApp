using RegApp.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Btn_reg_Click(object sender, RoutedEventArgs e)
        {
            Frames.frmNav.Navigate(new PageReg());
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            Frames.frmNav.Navigate(new PageMenu());
        }
    }
}
