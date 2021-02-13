using RegApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
        }
        string email = "[@][.]"; // Для проверки на наличие этих символов
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxbLogin.Text)
                &&
                !string.IsNullOrEmpty(TxbLogin.Text))
            {
                if (!string.IsNullOrWhiteSpace(TxbPass.Password)
                    &&
                    !string.IsNullOrEmpty(TxbPass.Password))
                {
                    if (TxbPass.Password == TxbPassRepeat.Password)
                    {
                        if (Regex.IsMatch(TxbEmail.Text, email))
                        {
                            MessageBox.Show("Регистрация успешна!");
                            Frames.frmNav.Navigate(new PageLogin());
                        }
                        else
                            MessageBox.Show("Проверьте правильность почты");
                    }
                    else
                        MessageBox.Show("Неправильный ввод пароля");
                }
                else
                    MessageBox.Show("Проверьте пароль");
            }
            else
                MessageBox.Show("Проверьте логин");
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frames.frmNav.GoBack();
        }
    }
}
