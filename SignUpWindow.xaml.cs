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
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }


        private void textBoxLoginTextChanged(object sender, TextChangedEventArgs e)
        {
            using (UserDataContext context = new UserDataContext())

            {
                string login = textBoxLogin.Text;
                bool userfound = context.Users.Any(user => user.login == login);

                if (userfound)
                {
                    textBoxLogin.ToolTip = "Логин уже занят";
                    textBoxLogin.Background = Brushes.LightPink;

                }
                else if (!userfound)
                {
                    textBoxLogin.ToolTip = null;
                    textBoxLogin.Background = Brushes.Transparent;
                }

                else if (textBoxLogin.Text.Length < 4)
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

        }



        private void textBoxPasswordChanged(object sender, RoutedEventArgs e)
        {


            if (textBoxPassword.Password.Length < 4)
            {
                textBoxPassword.ToolTip = "Пароль не может быть менее 4 символов";
                textBoxPasswordRepeat.ToolTip = "Пароль не может быть менее 4 символов";

                textBoxPassword.Background = Brushes.LightPink;
                textBoxPasswordRepeat.Background = Brushes.LightPink;
            }
            else if (textBoxPasswordRepeat.Password!=textBoxPassword.Password && textBoxPasswordRepeat.Password.Length>=2)
            {
                textBoxPassword.ToolTip = "Пароли не совпадают";
                textBoxPasswordRepeat.ToolTip = "Пароли не совпадают";

                textBoxPassword.Background = Brushes.LightPink;
                textBoxPasswordRepeat.Background = Brushes.LightPink;
            }
            else
            {
                textBoxPassword.ToolTip = null;
                textBoxPasswordRepeat.ToolTip = null;

                textBoxPassword.Background = Brushes.Transparent;
                textBoxPasswordRepeat.Background = Brushes.Transparent;
            }
        }
    


        private void buttonСlickLogInUser(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();

        }

        private void buttonClickSignUpUser(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Password;
            string passwordRepeat = textBoxPasswordRepeat.Password;

            using (UserDataContext context = new UserDataContext())

            {
                bool userfound = context.Users.Any(user => user.login == login);

                if (userfound)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");

                }
                else if (String.IsNullOrWhiteSpace(login))
                {
                    textBoxLogin.ToolTip = "Логин не может быть пустым";
                    textBoxLogin.Background = Brushes.LightPink;
                    MessageBox.Show("Логин не может быть пустым");
                }
                else if (!String.IsNullOrWhiteSpace(login) && !String.IsNullOrWhiteSpace(password) && !String.IsNullOrWhiteSpace(passwordRepeat) && login.Length>=4 && password.Length>=4)

                {
                    User user = new User(login, password);
                    context.Add(user);
                    context.SaveChanges();
                    MessageBox.Show("Аккаунт успешно создан, Вы можете перейти на страницу авторизации, чтобы войти в свой аккаунт");

                    AuthWindow authWindow = new AuthWindow();
                    authWindow.Show();
                    Hide();


                }
                else
                {
                    MessageBox.Show("Что то введено неверно");
                }

            }
        }
    }
}
