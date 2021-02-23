using RegApp.Classes;
using RegApp.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace RegApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageQuestion.xaml
    /// </summary>
    public partial class PageQuestion : Page
    {
        public PageQuestion()
        {
            InitializeComponent();
        }

        
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var LogAns = DataBase.oladik.User.FirstOrDefault(
                    x => x.Login == TxbLogin.Text);

                var Id = LogAns.IdQuestion;

                var Questions = DataBase.oladik.Question.FirstOrDefault(
                        x => x.Id == Id);
                if (TxbLogin.IsEnabled == true)
                {

                    if (LogAns == null)
                    {
                        MessageBox.Show("Ничего не понимаю");
                    }
                    else
                    {
                        if (Questions == null)
                        {
                            MessageBox.Show("У матросов нет вопросов");
                        }
                        else
                        {
                            TbQuestion.Text = Questions.Name;
                            TxbQuestion.Background = Brushes.White;
                            TxbQuestion.IsEnabled = true;
                            TxbLogin.IsEnabled = false;

                        }
                    }
                }
                else
                {
                    if (TxbQuestion.Text == LogAns.Answer)
                    {
                        MessageBox.Show("Ваш пароль " + LogAns.Password);
                    }
                    else
                    {
                        MessageBox.Show("Осуждаю","Фу таким быть");
                    }
                        Frames.frmNav.Navigate(new PageLogin());
                }
            }
            catch
            {
                MessageBox.Show("Упс", "Что-то пошло не так");
            }
             
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frames.frmNav.Navigate(new PageLogin());
            
        }

        
        
    }
}
