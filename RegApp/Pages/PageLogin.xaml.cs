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
            try
            {
                var userTable = DataBase.oladik.User.FirstOrDefault(
                    petya => petya.Login == TxbLogin.Text &&
                    petya.Password == PsbPassword.Password);
                if (userTable == null)
                {
                    MessageBox.Show("Одно из трех либо вы меня проверяете, либо вы забывчивый, либо вы промазали. Увы данные некорректны", "Предупреждение", MessageBoxButton.OK);
                }
                else
                {
                   
                    switch (userTable.IdRole)
                    {
                        case 1: MessageBox.Show("Добро пожаловать о великое божество", "Приветсвие", MessageBoxButton.OK);
                            Frames.frmNav.Navigate(new PageAdmin());
                            break;
                        case 2:
                            MessageBox.Show("Добро пожаловать простой смертный", "Приветсвие", MessageBoxButton.OK);
                            Frames.frmNav.Navigate(new PageMenu());
                            break;
                        default: MessageBox.Show("Жулик не ломай", "Это аморально", MessageBoxButton.OK);
                            TxbLogin.Text = null;
                            PsbPassword.Password = null;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);

                
            }
        }

        private void BtnQuest_Click(object sender, RoutedEventArgs e)
        {
            Frames.frmNav.Navigate(new PageQuestion());
        }
    }
}
