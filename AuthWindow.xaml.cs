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

namespace Practice
{
   
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

       

        private void textBoxLoginTextChanged(object sender, TextChangedEventArgs e)
        {


            if (textBoxLogin.Text.Length < 4)
            {
                textBoxLogin.ToolTip = "Логин не может быть менее 4 символов";
                textBoxLogin.Background = Brushes.LightPink;
            }
            else
            {
                textBoxLogin.ToolTip = null;
                textBoxLogin.Background = Brushes.Transparent;
            }
        }



        private void textBoxPasswordTextChanged(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Password.Length < 4)
            {
                textBoxPassword.ToolTip = "Пароль не может быть менее 4 символов";
                textBoxPassword.Background = Brushes.LightPink;
            }
            else
            {
                textBoxPassword.ToolTip = null;
                textBoxPassword.Background = Brushes.Transparent;
            }

        }
    
        

        private void buttonClickSignUpUser(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            Hide();
        }
        private void buttonClickLogInUser(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Password.Trim();
            using (UserDataContext context = new UserDataContext())

            {

                bool userfound = context.Users.Any(user => user.login == login && user.password == password);
                if (userfound)
                {
                    StudentWindow studentWindow = new StudentWindow();
                    studentWindow.Show();
                    Hide();

                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }
    }
}
