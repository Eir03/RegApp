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
            TbAnswer.IsEnabled = false;
            Answer();
        }
        string email = "[@]"; // Для проверки на наличие этих символов
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            int id = cbQeustion.SelectedIndex + 1;
            if (!string.IsNullOrEmpty(TxbLogin.Text) &&
                !string.IsNullOrWhiteSpace(TxbLogin.Text))
            {
                Add(TxbLogin.Text, PsbPass.Password, TxbEmail.Text, id, TbAnswer.Text);
            }
            else
                TbLog.Text = "ИШЬ ТЫ";
            
              
        }

        private void Answer()
        {
            foreach(string question in DataBase.oladik.Question.Select(sobaka => sobaka.Name))
            {
                cbQeustion.Items.Add(question);
            }
            
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frames.frmNav.GoBack();
        }

        private void Add(string login, string password, string email, int idQuestion, string answer)
        {
            try
            {
            User add = new User()
            {
                Login = login,
                Password = password,
                Email = email,
                IdRole = 2,
                IdQuestion = idQuestion,
                Answer = answer

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
                    MessageBox.Show("Такой логин уже существует или вы сделали что-то запретное", "Увы");

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
                    
                }

            }
            else
            {
                
                PsbPass.Background = Brushes.White;
                TbPass.Text = "Введите пароль:";
            }
            Knopka(TxbLogin.Text, PsbPass.Password, PsbPassRepeat.Password, TbAnswer.Text);
        }

        private void PsbPassRepeat_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PsbPass.Password == PsbPassRepeat.Password &&
                !string.IsNullOrEmpty(PsbPass.Password) &&
                !string.IsNullOrWhiteSpace(PsbPass.Password))
            {
                PsbPassRepeat.Background = Brushes.Green;
                
            }
            else
            {
                PsbPassRepeat.Background = Brushes.White;
                
            }
            Knopka(TxbLogin.Text, PsbPass.Password, PsbPassRepeat.Password, TbAnswer.Text);
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
        private void cbQeustion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TbAnswer.IsEnabled = true;
            
        }

        private void TbAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TbAnswer.Text) &&
                !string.IsNullOrWhiteSpace(TbAnswer.Text))
            {
                TbAnswer.Background = Brushes.Green;
            }
            else
            {
                TbAnswer.Background = Brushes.White;
            }
            Knopka(TxbLogin.Text, PsbPass.Password, PsbPassRepeat.Password, TbAnswer.Text);
        }

        private void Knopka(string login, string password, string password1, string answer)
        {
            if (login == "" || password == "" || answer == "" || password != password1)
                BtnCreate.IsEnabled = false;
            else
                BtnCreate.IsEnabled = true;
        }
    }
}
