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
using System.Xml.Schema;

namespace RegApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public PageMenu()
        {
            InitializeComponent();
            
        }

        
        
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Frames.frmNav.Navigate(new PageLogin());
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
