using RegApp.Classes;
using RegApp.DataBases;
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
            BtnCreate.IsEnabled = false;
        }
        string email = "[@]"; // Для проверки на наличие этих символов
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxbLogin.Text) &&
                !string.IsNullOrWhiteSpace(TxbLogin.Text))
            {
                Add(TxbLogin.Text, PsbPass.Password, TxbEmail.Text);
            }
            else
                TbLog.Text = "ИШЬ ТЫ";
              
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frames.frmNav.GoBack();
        }

        private void Add(string login, string password, string email)
        {
            try
            {
            User add = new User()
            {
                Login = login,
                Password = password,
                Email = email,
                IdRole = 2
                
            };
                var check = DataBase.oladik.User.FirstOrDefault(valya => valya.Login == login);
                if (check == null)
                    
                {
                    DataBase.oladik.User.Add(add);
                    DataBase.oladik.SaveChanges();
                    MessageBox.Show("Регистрация успешна!");
                    Frames.frmNav.Navigate(new PageLogin());
                }
                else
                {
                    MessageBox.Show("Такой логин уже существует или вы ввели что-то запретное", "Увы");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ОШИБКА");
            }
        }

        private void PsbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PsbPass.Password) &&
               !string.IsNullOrWhiteSpace(PsbPass.Password))
            {
                PsbPass.Background = Brushes.LightGreen;
                if (PsbPass.Password == PsbPassRepeat.Password)
                BtnCreate.IsEnabled = true;
                else
                    BtnCreate.IsEnabled = false;
                if (PsbPass.Password.Length > 4)
                {
                    TbPass.Text = "Неплохо, но есть куда стремиться";
                    PsbPass.Background = Brushes.Green;
                    
                }
                if (PsbPass.Password.Length > 7)
                {
                    TbPass.Text = "Нам нужно больше СИМВОЛОВ";

                }
                if (PsbPass.Password.Length > 10)
                {
                    TbPass.Text = "ИДЕАЛЬНО";
                    PsbPass.Background = Brushes.DarkGreen;
                }
                if (PsbPass.Password.Length > 50)
                {
                    TbPass.Text = "Не твой уровень дорогой";
                    PsbPass.Background = Brushes.Red;
                    BtnCreate.IsEnabled = false;
                }

            }
            else
            {
                BtnCreate.IsEnabled = false;
                PsbPass.Background = Brushes.White;
                TbPass.Text = "Введите пароль:";
            }
        }

        private void PsbPassRepeat_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PsbPass.Password == PsbPassRepeat.Password &&
                !string.IsNullOrEmpty(PsbPass.Password) &&
                !string.IsNullOrWhiteSpace(PsbPass.Password))
            {
                PsbPassRepeat.Background = Brushes.Green;
                BtnCreate.IsEnabled = true;
            }
            else
            {
                PsbPassRepeat.Background = Brushes.White;
                BtnCreate.IsEnabled = false;
            }
            
        }

        private void TxbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(TxbEmail.Text, email))
            {
                TxbEmail.Background = Brushes.Green;
                TbEmail.Text = "Вы нашли собаке домик :3";
            }
            else
            {
                TbEmail.Text = "В мире плачет одна собака";
                TxbEmail.Background = Brushes.White;
            }
            if (string.IsNullOrEmpty(TxbEmail.Text))
            {
                TbEmail.Text = "Введите email:";
            }
        }

       
    }
}
